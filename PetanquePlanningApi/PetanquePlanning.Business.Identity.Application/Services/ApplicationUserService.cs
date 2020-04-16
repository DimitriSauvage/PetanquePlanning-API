using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using PetanquePlanning.Business.Identity.Application.Abstractions.Abstractions;
using PetanquePlanning.Business.Identity.Application.Abstractions.DTO.Users;
using PetanquePlanning.Business.Identity.Application.Exceptions;
using PetanquePlanning.Business.Identity.Domain.Entities;
using PetanquePlanning.Business.Identity.Infrastructure.Abstractions.Abstractions;
using Tools.Application.Abstractions;
using Tools.Helpers;
using Tools.Infrastructure.Exceptions;

namespace PetanquePlanning.Business.Identity.Application.Services
{
    public class ApplicationUserService : BaseService<ApplicationUser, IApplicationUserRepository>,
        IApplicationUserService
    {
        #region Properties

        /// <summary>
        /// User manager
        /// </summary>
        private UserManager<ApplicationUser> UserManager { get; }

        #endregion

        #region Constantes

        //TODO : Change values with appsettings conf
        /// <summary>
        /// IMAP server name
        /// </summary>
        private const string ImapServerName = "imap-mail.outlook.com";

        /// <summary>
        /// IMAP server port
        /// </summary>
        private const int ImapServerPort = 993;

        /// <summary>
        /// SMTP email address
        /// </summary>
        private const string SmtpUsername = "dimitri@outlook.com";

        /// <summary>
        /// SMTP password
        /// </summary>
        private const string SmtpPassword = "8T4W~rP7]+gm";

        /// <summary>
        /// Temp salt
        /// </summary>
        private const string TempSalt = "_temp";

        #endregion

        #region Constructors

        public ApplicationUserService(UserManager<ApplicationUser> userManager)
        {
            this.UserManager = userManager;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<ApplicationUserDTO> GetByEmailAsync(string email)
        {
            var user = await this.UserManager.FindByEmailAsync(email);
            if (user == null) throw new EntityNotFoundException<ApplicationUser>();

            return this.Mapper.Map<ApplicationUserDTO>(user);
        }

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
            return await this.Repository.TransactionalExecutionAsync(
                action: async (applicationUser, transaction) =>
                {
                    await this.UpdateAsync(user, baseStoragePath, transaction);
                },
                obj: this.Mapper.Map<ApplicationUser>(user),
                onSuccessFunc: updatedUser => this.Mapper.Map<ApplicationUserDTO>(updatedUser));
        }

        /// <inheritdoc />
        public async Task<ApplicationUserDTO> UpdateAsync(ApplicationUserDTO user, string baseStoragePath,
            IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));

            //Récupération de l'utilisateur en base de données
            var userDb = await this.UserManager.FindByIdAsync(user.Id.ToString());
            if (userDb == null) throw new EntityNotFoundException<ApplicationUser>(user.Id);

            //Mise à jour de l'image
            if (userDb.Avatar != user.Avatar)
            {
                //Je convertis l'utilisateur en DTO
                var userDbDto = this.Mapper.Map<ApplicationUserDTO>(userDb);

                //Si l'utilisateur avait un avatar, on doit le supprimer
                if (userDbDto.Avatar != null)
                {
                    var oldAvatar = new FileInfo(Path.Combine(baseStoragePath, userDbDto.AvatarUrl));
                    if (oldAvatar.Exists) oldAvatar.Delete();
                }

                //On déplace la nouvelle image du dossier temp au dossier de l'utilisateur
                var tempFile =
                    new FileInfo(Path.Combine(this.GetTempImageDirectoryPath(baseStoragePath, userDbDto).FullName,
                        user.Avatar));

                //Destination
                var destinationFile = new FileInfo(Path.Combine(
                    this.GetUserImageDirectoryPath(baseStoragePath, userDbDto).FullName,
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
        public async Task<ApplicationUserDTO> CreateAsync(ApplicationUserDTO userDto, string baseStoragePath)
        {
            //Vérifications de cohérence
            if (userDto == null) throw new ArgumentNullException(nameof(userDto));
            if (userDto.Id > 0) throw new EntityAlreadyExistsException<ApplicationUser>();

            return await this.Repository.TransactionalExecutionAsync(
                action: async (newUser, transaction) =>
                {
                    //On met les valeurs obligatoires
                    await newUser.SetMandatoryValuesAsync(this.UserManager);

                    //Ajout en bdd
                    var result = await this.UserManager.CreateAsync(newUser);
                    if (!result.Succeeded)
                    {
                        var errorBuilder = new StringBuilder();
                        foreach (var error in result.Errors)
                        {
                            errorBuilder.Append(error.Description);
                        }

                        throw new CreateUserException(errorBuilder.ToString());
                    }

                    //On déplace l'image du dossier temp au dossier de l'utilisateur
                    if (newUser.Avatar != null)
                    {
                        var avatar =
                            new FileInfo(
                                fileName: Path.Combine(
                                    this.GetTempImageDirectoryPath(baseStoragePath,
                                        this.Mapper.Map<ApplicationUserDTO>(newUser)).FullName,
                                    newUser.Avatar));
                        if (avatar.Exists)
                        {
                            var avatarName = this.GetImageNameFromTempImageName(newUser.Avatar);
                            var newFile = new FileInfo(Path.Combine(
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
                    var applicationUserDto = this.Mapper.Map<ApplicationUserDTO>(newUser);
                },
                obj: this.Mapper.Map<ApplicationUser>(userDto),
                onSuccessFunc: updatedUser => this.Mapper.Map<ApplicationUserDTO>(updatedUser));
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
                ImapServerName,
                ImapServerPort,
                SmtpUsername,
                SmtpPassword,
                SmtpUsername,
                user.NormalizedEmail,
                "Reset password",
                $"Please click here : ${token}"
            );
        }

        /// <inheritdoc />
        public async Task DeleteAsync(long userId)
        {
            var user = await this.UserManager.FindByIdAsync(userId.ToString());
            if (user == null) throw new EntityNotFoundException<ApplicationUser>(userId);

            await this.Repository.TransactionalExecutionAsync(
                async (id, transaction) => { await this.UserManager.DeleteAsync(user); }, userId);
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
        /// <param name="applicationUserDto">Utilisateur concerné</param>
        /// <returns></returns>
        private DirectoryInfo GetUserImageDirectoryPath(string baseStoragePath, ApplicationUserDTO applicationUserDto)
        {
            if (applicationUserDto == null) throw new EntityNotFoundException<ApplicationUser>();
            return new DirectoryInfo(Path.Combine(baseStoragePath, "data", "users",
                applicationUserDto.NormalizedEmail));
        }

        // /// <summary>
        // /// Récupère le nom de l'image temporaire selon le nom de l'image de base
        // /// </summary>
        // /// <param name="fileName"></param>
        // /// <returns></returns>
        // private string GetTempImageName(string fileName)
        // {
        //     return Path.GetFileNameWithoutExtension(fileName) + TempSalt + Path.GetExtension(fileName);
        // }

        /// <summary>
        /// Récupérer le nom de l'image à stocker sans le salt de l'image temporaire
        /// </summary>
        /// <param name="tempImageName">Nom de l'image temporaire actuel</param>
        /// <returns></returns>
        private string GetImageNameFromTempImageName(string tempImageName)
        {
            if (tempImageName == null) throw new ArgumentNullException(nameof(tempImageName));

            var currentDateTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            return Path.GetFileNameWithoutExtension(tempImageName).Replace(TempSalt, string.Empty) + currentDateTime +
                   Path.GetExtension(tempImageName);
        }

        /// <summary>
        /// Récupère le chemin du dossier ou sont stockés les images temporaires
        /// </summary>
        /// <remarks>Si l'utilisateur est null, il n'éxiste pas, ou recevra donc le chemin du dossier temporaire commun</remarks>
        /// <param name="baseStoragePath">Chemin de base ou sont stockés les fichiers</param>
        /// <param name="applicationUserDto">Utilisateur concerné</param>
        /// <returns></returns>
        private DirectoryInfo GetTempImageDirectoryPath(string baseStoragePath, ApplicationUserDTO applicationUserDto)
        {
            DirectoryInfo directoryInfo;

            if (applicationUserDto != null && applicationUserDto.Id > 0)
            {
                //On renvoi le lien du dossier de l'utilisateur
                directoryInfo = this.GetUserImageDirectoryPath(baseStoragePath, applicationUserDto);
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