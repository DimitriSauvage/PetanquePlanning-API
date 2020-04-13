using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abalone.Business.Identity.Application.Abstractions.Abstractions;
using Abalone.Business.Identity.Application.DTO.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using PetanquePlanning.Business.Identity.Application.Abstractionns.Abstractions;
using PetanquePlanning.Business.Identity.Domain.Entities;
using PetanquePlanning.Business.Identity.Infrastructure.Abstractions.Abstractions;
using Tools.Application.Abstractions.Abstractions;
using Tools.Helpers;
using Tools.Infrastructure.Exceptions;

namespace Abalone.Business.Identity.Application.Services
{
    public class ApplicationUserService : Service<ApplicationUser, IApplicationUserRepository>, IApplicationUserService
    {
        #region Properties

        /// <summary>
        /// User manager
        /// </summary>
        private UserManager<ApplicationUser> UserManager { get; }

        /// <summary>
        /// Account manager
        /// </summary>
        private IAccountService AccountService { get; }

        /// <summary>
        /// Role manager
        /// </summary>
        private IApplicationRoleService ApplicationRoleService { get; }

        #endregion

        #region Constantes

        /// <summary>
        /// Password base length
        /// </summary>
        private const int PASSWORD_BASE_LENGTH = 10;

        //TODO : Change values with appsettings conf
        /// <summary>
        /// IMAP server name
        /// </summary>
        private const string IMAP_SERVER_NAME = "imap-mail.outlook.com";

        /// <summary>
        /// IMAP server port
        /// </summary>
        private const int IMAP_SERVER_PORT = 993;

        /// <summary>
        /// SMTP email address
        /// </summary>
        private const string SMTP_USERNAME = "dimitri@outlook.com";

        /// <summary>
        /// SMTP password
        /// </summary>
        private const string SMTP_PASSWORD = "8T4W~rP7]+gm";

        /// <summary>
        /// Temp salt
        /// </summary>
        private const string TEMP_SALT = "_temp";

        #endregion

        #region Constructors

        public ApplicationUserService(UserManager<ApplicationUser> userManager, IAccountService accountService,
            IApplicationRoleService applicationRoleService)
        {
            this.UserManager = userManager;
            this.AccountService = accountService;
            this.ApplicationRoleService = applicationRoleService;
        }

        #endregion


        #region Methods

        /// <inheritdoc />
        public async Task<IEnumerable<ApplicationUserDTO>> GetAllAsync()
        {
            //Get the users
            var users = await this.Repository.ListAsync();
            return users.Select(x => this.Mapper.Map<ApplicationUserDTO>(x)).ToList();
        }

        /// <inheritdoc />
        public async Task<ApplicationUserDTO> GetByIdAsync(long userId)
        {
            var user = await this.Repository.GetByIdAsync(userId);
            return this.Mapper.Map<ApplicationUserDTO>(user);
        }

        /// <inheritdoc />
        public async Task<ApplicationUserDTO> UpdateAsync(ApplicationUserDTO user, string baseStoragePath)
        {
            using (var transaction = this.Repository.BeginTransaction())
            {
                try
                {
                    ApplicationUserDTO applicationUserDTO =
                        await this.UpdateUserAsync(user, baseStoragePath, transaction);

                    //Validation de la transaction
                    transaction.Commit();

                    return user;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }
        }

        /// <inheritdoc />
        public async Task<ApplicationUserDTO> UpdateUserAsync(ApplicationUserDTO user, string baseStoragePath,
            IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));

            //Récupération de l'utilisateur en base de données
            ApplicationUser userDb = await this.UserManager.FindByIdAsync(user.Id.ToString());
            if (userDb == null) throw new EntityNotFoundException<ApplicationUser>(user.Id);

            //Mise à jour de l'image
            if (userDb.Avatar != user.Avatar)
            {
                //Je convertis l'utilisateur en DTO
                ApplicationUserDTO userDbDTO = this.Mapper.Map<ApplicationUserDTO>(userDb);

                //Si l'utilisateur avait un avatar, on doit le supprimer
                if (userDbDTO.Avatar != null)
                {
                    FileInfo oldAvatar = new FileInfo(Path.Combine(baseStoragePath, userDbDTO.AvatarUrl));
                    if (oldAvatar.Exists) oldAvatar.Delete();
                }

                //On déplace la nouvelle image du dossier temp au dossier de l'utilisateur
                FileInfo tempFile =
                    new FileInfo(Path.Combine(this.GetTempImageDirectoryPath(baseStoragePath, userDbDTO).FullName,
                        user.Avatar));

                //Destination
                FileInfo destinationFile = new FileInfo(Path.Combine(
                    this.GetUserImageDirectoryPath(baseStoragePath, userDbDTO).FullName,
                    this.GetImageNameFromTempImageName(tempFile.Name)));

                //On déplace l'image temporaire
                tempFile.MoveTo(destinationFile.FullName);

                //On met le nouvel avatar à l'utilisateur
                user.Avatar = destinationFile.Name;
            }

            //Mise à jour de son contenu
            userDb.CopyFrom(this.Mapper.Map<ApplicationUser>(user));
            await userDb.SetMandatoryValuesAsync(this.UserManager);

            //Mise à jour en base de données
            await this.UserManager.UpdateAsync(userDb);

            return this.Mapper.Map<ApplicationUserDTO>(userDb);
        }

        /// <inheritdoc />
        public async Task<ApplicationUserDTO> CreateAsync(ApplicationUserDTO user, string baseStoragePath)
        {
            using (var transaction = this.Repository.BeginTransaction())
            {
                try
                {
                    //Vérifications de cohérence
                    if (user == null) throw new ArgumentNullException(nameof(user));
                    if (user.Id > 0) throw new EntityAlreadyExistsException<ApplicationUser>();


                    //Création du nouvel utiliasteur
                    var newUser = this.Mapper.Map<ApplicationUser>(user);

                    //On met les valeurs obligatoires
                    await newUser.SetMandatoryValuesAsync(this.UserManager);

                    //Ajout en bdd
                    await this.Repository.AddAsync(newUser);


                    //On déplace l'image du dossier temp au dossier de l'utilisateur
                    if (user.Avatar != null)
                    {
                        FileInfo avatar =
                            new FileInfo(Path.Combine(this.GetTempImageDirectoryPath(baseStoragePath, user).FullName,
                                user.Avatar));
                        if (avatar.Exists)
                        {
                            string avatarName = this.GetImageNameFromTempImageName(newUser.Avatar);
                            FileInfo newFile = new FileInfo(Path.Combine(
                                this.GetUserImageDirectoryPath(baseStoragePath,
                                    this.Mapper.Map<ApplicationUserDTO>(newUser)).FullName, avatarName));
                            if (newFile.Directory != null && !newFile.Directory.Exists) newFile.Directory.Create();
                            avatar.MoveTo(newFile.FullName);

                            //On donne le lien et on sauvegarde l'utilisateur
                            newUser.Avatar = avatarName;
                            await this.Repository.SaveChangesAsync();
                        }
                    }

                    //Tranformation en DTO
                    ApplicationUserDTO applicationUserDto = this.Mapper.Map<ApplicationUserDTO>(newUser);

                    //Ajout en base de données et renvoi
                    transaction.Commit();

                    return applicationUserDto;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        /// <inheritdoc />
        public async Task ReinitializePasswordAsync(long id)
        {
            //Get the user
            var user = await this.UserManager.FindByIdAsync(id.ToString());
            if (user == null) throw new EntityNotFoundException<ApplicationUser>(id);

            //Génération du token
            var token = await this.UserManager.GeneratePasswordResetTokenAsync(user);

            EmailHelper.SendMail(
                IMAP_SERVER_NAME,
                IMAP_SERVER_PORT,
                SMTP_USERNAME,
                SMTP_USERNAME,
                SMTP_USERNAME,
                user.NormalizedEmail,
                "Reset password",
                $"Please click here : ${token}"
            );
        }

        /// <inheritdoc />
        public async Task DeleteAsync(long userId)
        {
            using (var transaction = this.Repository.BeginTransaction())
            {
                try
                {
                    var user = await this.UserManager.FindByIdAsync(userId.ToString());
                    if (user == null) throw new EntityNotFoundException<ApplicationUser>(userId);

                    //Suppression
                    await this.UserManager.DeleteAsync(user);
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ApplicationUserDTO>> GetByRoleAsync(long roleId)
        {
            var users = await this.Repository.GetByRoleAsync(roleId);
            return users.Select(x => this.Mapper.Map<ApplicationUserDTO>(x));
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Récupère le chemin du dossier ou sont stockés les images de l'utilisateur
        /// </summary>
        /// <param name="baseStoragePath">Chemin de base ou sont stockés les fichiers</param>
        /// <param name="applicationUserDTO">Utilisateur concerné</param>
        /// <returns></returns>
        private DirectoryInfo GetUserImageDirectoryPath(string baseStoragePath, ApplicationUserDTO applicationUserDTO)
        {
            if (applicationUserDTO == null) throw new EntityNotFoundException<ApplicationUser>();
            return new DirectoryInfo(Path.Combine(baseStoragePath, "data", "users",
                applicationUserDTO.NormalizedEmail));
        }

        /// <summary>
        /// Récupère le nom de l'image temporaire selon le nom de l'image de base
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string GetTempImageName(string fileName)
        {
            return Path.GetFileNameWithoutExtension(fileName) + TEMP_SALT + Path.GetExtension(fileName);
        }

        /// <summary>
        /// Récupérer le nom de l'image à stocker sans le salt de l'image temporaire
        /// </summary>
        /// <param name="tempImageName">Nom de l'image temporaire actuel</param>
        /// <returns></returns>
        private string GetImageNameFromTempImageName(string tempImageName)
        {
            string currentDateTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            return Path.GetFileNameWithoutExtension(tempImageName).Replace(TEMP_SALT, string.Empty) + currentDateTime +
                   Path.GetExtension(tempImageName);
        }

        /// <summary>
        /// Récupère le chemin du dossier ou sont stockés les images temporaires
        /// </summary>
        /// <remarks>Si l'utilisateur est null, il n'éxiste pas, ou recevra donc le chemin du dossier temporaire commun</remarks>
        /// <param name="baseStoragePath">Chemin de base ou sont stockés les fichiers</param>
        /// <param name="applicationUserDTO">Utilisateur concerné</param>
        /// <returns></returns>
        private DirectoryInfo GetTempImageDirectoryPath(string baseStoragePath, ApplicationUserDTO applicationUserDTO)
        {
            DirectoryInfo directoryInfo = null;

            if (applicationUserDTO != null && applicationUserDTO.Id > 0)
            {
                //On renvoi le lien du dossier de l'utilisateur
                directoryInfo = this.GetUserImageDirectoryPath(baseStoragePath, applicationUserDTO);
            }
            else
            {
                //On renvoi le dossier temporaire commun
                directoryInfo = new DirectoryInfo(Path.Combine(baseStoragePath, "data", "users", "temp"));
            }

            return directoryInfo;
        }

        #endregion
    }
}