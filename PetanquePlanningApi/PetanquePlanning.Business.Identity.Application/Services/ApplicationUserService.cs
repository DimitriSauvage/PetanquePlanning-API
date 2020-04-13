﻿using Microsoft.AspNetCore.Identity;
using Abalone.Business.Identity.Domain.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abalone.Business.Identity.Application.Abstractions;
using Abalone.Tools.Helpers;
using Abalone.Business.Identity.Application.DTO.Users;
using Abalone.Business.Identity.Infrastructure.Abstractions;
using AutoMapper;
using Abalone.Business.Identity.Application.DTO;
using Abalone.Tools.Infrastructure.Exceptions;
using Abalone.Tools.Application.Exceptions;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using HtmlAgilityPack;
using Abalone.Business.I18n.Domain.Entities;
using Abalone.Business.Core.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Http;
using Abalone.Business.Identity.Domain.Enums;
using Abalone.Tools.Application.DTOs;
using Microsoft.EntityFrameworkCore.Storage;
using Abalone.Business.Identity.Application.Abstractions.Abstractions;
using Abalone.Business.Identity.Application.Abstractions.Abstractions.Features;
using Abalone.Business.Identity.Domain.Entities.Features;
using Abalone.Business.Identity.Infrastructure.Abstractions.Features;
using Abalone.Business.Identity.Application.Abstractions.DTO.Features;

namespace Abalone.Business.Identity.Application.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        #region Properties
        private readonly IHostingEnvironment hostingEnvironnement;
        private readonly UserManager<ApplicationUser> userManager = null;
        private readonly IApplicationUserRepository applicationUserRepository = null;
        private readonly IMapper mapper = null;
        private readonly IAccountService accountService = null;
        private readonly IApplicationUserCompanyFunctionService applicationUserCompanyFunctionService = null;
        private readonly IApplicationUserCompanyService applicationUserCompanyService = null;
        private readonly IApplicationCompanyFunctionService applicationCompanyFunctionService = null;
        private readonly IObjectSharedWithFunctionRepository objectSharedWithFunctionRepository = null;
        private readonly IApplicationUserCompanyRepository applicationUserCompanyRepository = null;
        private readonly IApplicationUserCompanyFunctionRepository applicationUserCompanyFunctionRepository = null;
        private readonly IFeatureApplicationUserRightService featureApplicationUserRightService = null;
        private readonly IFeatureApplicationRoleRightService featureApplicationRoleRightService = null;
        private readonly IApplicationRoleService applicationRoleService = null;
        private readonly IFeatureService featureService= null;
        private string email_templates_path = "data" + Path.DirectorySeparatorChar + "emails" + Path.DirectorySeparatorChar + "templates"; //Chemin du dossier contenant les 
        #endregion

        #region Constantes
        private const int PASSWORD_BASE_LENGTH = 10; //Taille de base du mot de passe
        private const string EMAIL_TEMPLATE_FILE_EXTENSION = ".html"; //Extension des fichiers de templating
        private const string RESET_PASSWORD_LINK_ALIAS = "RESET_PASSWORD_LINK_ALIAS"; //Alias pour changer le lien dans le templatetemplates de réinitialisation de mot de passe
        private const string RESET_PASSWORD_TITLE_ALIAS = "RESET_PASSWORD_TITLE_ALIAS"; //Alias pour récupérer le titre du document
        private const string IMAP_SERVER_NAME = "imap-mail.outlook.com";
        private const int IMAP_SERVER_PORT = 993;
        private const string SMTP_USERNAME = "soperf@outlook.com";
        private const string SMTP_PASSWORD = "8T4W~rP7]+gm";
        private const string TEMP_SALT = "_temp";

        #endregion
        
        #region Constructors
        public ApplicationUserService(
            IMapper mapper,
            IAccountService accountService,
            IApplicationUserCompanyFunctionService applicationUserCompanyFunctionService,
            IApplicationUserRepository applicationUserRepository,
            IApplicationUserCompanyService applicationUserCompanyService,
            IApplicationCompanyFunctionService applicationCompanyFunctionService,
            IObjectSharedWithFunctionRepository objectSharedWithFunctionRepository,
            UserManager<ApplicationUser> userManager,
            IHostingEnvironment hostingEnvironnement,
            IApplicationUserCompanyRepository applicationUserCompanyRepository,
            IApplicationUserCompanyFunctionRepository applicationUserCompanyFunctionRepository,
            IFeatureApplicationUserRightService featureApplicationUserRightService,
            IFeatureApplicationRoleRightService featureApplicationRoleRightService,
            IApplicationRoleService applicationRoleService,
            IFeatureService featureService)
        {
            this.mapper = mapper;
            this.accountService = accountService;
            this.applicationUserCompanyFunctionService = applicationUserCompanyFunctionService;
            this.applicationUserRepository = applicationUserRepository;
            this.applicationUserCompanyService = applicationUserCompanyService;
            this.applicationCompanyFunctionService = applicationCompanyFunctionService;
            this.userManager = userManager;
            this.hostingEnvironnement = hostingEnvironnement;
            this.objectSharedWithFunctionRepository = objectSharedWithFunctionRepository;
            this.applicationUserCompanyRepository = applicationUserCompanyRepository;
            this.applicationUserCompanyFunctionRepository = applicationUserCompanyFunctionRepository;
            this.featureApplicationUserRightService = featureApplicationUserRightService;
            this.featureApplicationRoleRightService = featureApplicationRoleRightService;
            this.applicationRoleService = applicationRoleService;
            this.featureService = featureService;
        }

        #endregion

        #region Methods    

        /// <summary>
        /// Récupère la liste de tous les utilisateurs
        /// </summary>
        /// <param name="includeFunctions">Inclure ou non les fonctions de l'utilisateur</param>
        /// <param name="includeSubFunctions">Inclure ou non les sous fonctions des fonctions</param>
        /// <param name="includeRights">Inclure ou non les droits</param>
        /// <returns>liste de tous les utilisateurs</returns>
        public async Task<IEnumerable<ApplicationUserDTO>> GetAllAsync(bool includeFunctions = false, bool includeSubFunctions = false, bool includeRights = false)
        {
            IEnumerable<ApplicationUser> users = await this.applicationUserRepository.GetUsersAsync(includeFunctions, includeRights);
            IEnumerable<ApplicationUserDTO> usersDTO = users.Select(x => this.mapper.Map<ApplicationUserDTO>(x)).ToList();


            //Chargement des droits du profil
            #region Chargement des droits
            if (includeRights)
            {
                foreach (var userDTO in usersDTO)
                {

                    userDTO.Rights = (await this.GetRightsAsync(userDTO, includeFeature: false)).ToList();
                }
            }
            #endregion


            //Chargement des sous fonctions
            #region Chargement des fonctions
            if (includeSubFunctions)
            {
                //Liste des fonctions pour ne pas avoir à les recharger
                ICollection<ApplicationCompanyFunctionDTO> functions = new HashSet<ApplicationCompanyFunctionDTO>();
                foreach (var userDTO in usersDTO)
                {
                    foreach (var userFunctionDTO in userDTO.Functions)
                    {
                        //On regarde si on l'a déjà chargée
                        var userFunctionLoaded = functions.FirstOrDefault(x => x.Id == userFunctionDTO.Function.Id);
                        if (userFunctionLoaded != null)
                        {
                            userFunctionDTO.Function = userFunctionLoaded;
                        }
                        else
                        {
                            //On charge les sous fonctions
                            userFunctionDTO.Function.Childs = (await this.applicationCompanyFunctionService.GetHierarchisedAsync(null, userFunctionDTO.FunctionId)).ToList();
                            functions.Add(userFunctionDTO.Function);
                        }
                    }
                }
            }
            #endregion


            return usersDTO;
        }

        //public async Task<ApplicationUserDTO> CreateUser(string firstName, string lastName, string email, string password)
        //{
        //    var applicationUser = new ApplicationUser() { Email = email, FirstName = firstName, LastName = lastName };
            
        //}

        /// <summary>
        /// Obtient la liste de tous les utilisateurs, ayant une fonction inferieur ou égale à celui de l'utilisateur, et ce dans toutes les sociétés ou l'utilisateur est présent
        /// </summary>
        /// <param name="userId">Identifiantde l'utilisateur</param>
        /// <returns>Liste de tous les utilisateurs</returns>
        public async Task<IEnumerable<ApplicationUserDTO>> GetLowerAndEqualUsersAsync(long userId)
        {
            //Récupération de l'utilisateur
            ApplicationUser currentUser = await this.userManager.FindByIdAsync(userId.ToString());
            if (currentUser == null)
            {
                throw new EntityNotFoundException<ApplicationUser>(userId);
            }

            //Récupération des fonctions de l'utilisateur
            IEnumerable<ApplicationCompanyFunctionDTO> userFunctions = (await this.applicationUserCompanyFunctionService.GetUserFunctionsAsync(userId)).Select(x => x.Function).ToList();

            return await this.GetAllUsersForFunctionsAsync(userFunctions);
        }

        /// <summary>
        /// Obtient la liste de tous les utilisateurs, ayant une fonction inferieur ou égale à celui de l'utilisateur, uniquement dans la société avec laquelle il est connecté
        /// </summary>
        /// <param name="userId">Identifiantde l'utilisateur</param>
        /// <param name="companyId">Identifiant de la societé pour laquelle l'utilisateur est connecté</param>
        /// <returns>Liste de tous les utilisateurs</returns>
        public async Task<IEnumerable<ApplicationUserDTO>> GetLowerAndEqualUsersAsync(long userId, long companyId)
        {
            //Récupération de l'utilisateur
            ApplicationUser currentUser = await this.userManager.FindByIdAsync(userId.ToString());
            if (currentUser == null)
            {
                throw new EntityNotFoundException<ApplicationUser>(userId);
            }

            //Récupération des fonctions de l'utilisateur dans la société actuelle
            IEnumerable<ApplicationCompanyFunctionDTO> userFunctions = (await this.applicationUserCompanyFunctionService.GetUserFunctionsAsync(userId))
                .Select(x => x.Function)
                .Where(x => x.CompanyId == companyId)
                .ToList();

            return await this.GetAllUsersForFunctionsAsync(userFunctions);
        }

        /// <summary>
        /// Obtient un utilisateur grâce à son identifiant
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ApplicationUserDTO> GetUserAsync(long userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            return this.mapper.Map<ApplicationUserDTO>(user);
        }

        /// <summary>
        /// Récupère la liste des utilisateurs de la fonction
        /// </summary>
        /// <param name="functionId">Identifiant de la fonction</param>
        /// <returns>Liste des utilisateurs de la fonction</returns>
        public async Task<IEnumerable<ApplicationUserDTO>> GetUsersByFunctionAsync(ApplicationCompanyFunctionDTO function)
        {
            var users = (await this.applicationUserRepository.GetByFunctionAsync(function.Id)).Select(x => this.mapper.Map<ApplicationUserDTO>(x)).ToList();

            return users;
        }

        /// <summary>
        /// Récupère la liste des utilisateurs de la fonction
        /// </summary>
        /// <param name="functionId">Identifiant de la fonction</param>
        /// <returns>Liste des utilisateurs de la fonction</returns>
        public async Task<ApplicationUserDTO> GetUserAsync(long userId, bool includeFunctions)
        {
            ApplicationUser user = null;

            if (includeFunctions)
                user = await applicationUserRepository.GetByIdWithFunctionsAsync(userId);
            else
                user = await applicationUserRepository.GetByIdAsync(userId);

            return this.mapper.Map<ApplicationUserDTO>(user);
        }

        /// <summary>
        /// Met à jour un utilisateur en base de données
        /// </summary>
        /// <param name="user">Utilisateur à ajouter</param>
        /// <param name="id">Identifiant de l'utilisateur</param>
        /// <param name="baseStoragePath">Chemin de base des fichiers</param>
        /// <param name="updateRights">Mettre à jour ou non les droits</param>
        /// <returns>Aucun retour</returns>
        public async Task<ApplicationUserDTO> UpdateUserAsync(long id, ApplicationUserDTO user, string baseStoragePath, bool updateRights = false)
        {
            using (var transaction = this.applicationUserRepository.BeginTransaction())
            {
                try
                {
                    ApplicationUserDTO applicationUserDTO = await this.UpdateUserAsync(id, user, baseStoragePath, transaction, updateRights);

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

        /// <summary>
        /// Met à jour un utilisateur en base de données
        /// </summary>
        /// <param name="user">Utilisateur à ajouter</param>
        /// <param name="id">Identifiant de l'utilisateur</param>
        /// <param name="baseStoragePath">Chemin de base des fichiers</param>
        /// <param name="transaction">Transaction dans laquelle effectuer le traitement</param>
        /// <param name="updateRights">Mettre à jour ou non les droits</param>
        /// <returns>Aucun retour</returns>
        public async Task<ApplicationUserDTO> UpdateUserAsync(long id, ApplicationUserDTO user, string baseStoragePath, IDbContextTransaction transaction, bool updateRights = false)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));

            if (id != user.Id)
            {
                throw new InconsitencyEntityWithIdException<ApplicationUser>(this.mapper.Map<ApplicationUser>(user), id);
            }

            //Récupération de l'utilisateur en base de données
            ApplicationUser userDb = await userManager.FindByIdAsync(user.Id.ToString());
            if (userDb == null)
            {
                throw new EntityNotFoundException<ApplicationUser>(user.Id);
            }

            //Mise à jour de l'image
            if (userDb.Avatar != user.Avatar)
            {
                //Je convertis l'utilisateur en DTO
                ApplicationUserDTO userDbDTO = this.mapper.Map<ApplicationUserDTO>(userDb);

                //Si l'utilisateur avait un avatar, on doit le supprimer
                if (userDbDTO.Avatar != null)
                {
                    FileInfo oldAvatar = new FileInfo(Path.Combine(baseStoragePath, userDbDTO.AvatarUrl));
                    if (oldAvatar.Exists) oldAvatar.Delete();
                }

                //On déplace la nouvelle image du dossier temp au dossier de l'utilisateur
                FileInfo tempFile = new FileInfo(Path.Combine(this.GetTempImageDirectoryPath(baseStoragePath, userDbDTO).FullName, user.Avatar));

                //Destination
                FileInfo destinationFile = new FileInfo(Path.Combine(this.GetUserImageDirectoryPath(baseStoragePath, userDbDTO).FullName, this.GetImageNameFromTempImageName(tempFile.Name)));

                //On déplace l'image temporaire
                tempFile.MoveTo(destinationFile.FullName);

                //On met le nouvel avatar à l'utilisateur
                user.Avatar = destinationFile.Name;
            }

            //Mise à jour de son contenu
            userDb.CopyFrom(this.mapper.Map<ApplicationUser>(user));
            await userDb.SetMandatoryValuesAsync(userManager);

            #region Gestion des sociétés de l'utilisateur
            //Récupération des sociétés liées à l'utilisateur
            var linkedCompanies = (await this.applicationUserCompanyRepository.GetByUserAsync(user.Id)).ToList();

            //Parcours des anciennes pour vérifier qu'elles existent toujours
            for (int i = linkedCompanies.Count() - 1; i >= 0; i--)
            {
                var linkedCompany = linkedCompanies.ElementAt(i);
                if (!user.Companies.Any(x => x.ApplicationCompanyId == linkedCompany.ApplicationCompanyId))
                {
                    //Suppression car elle n'est plus liée
                    await this.applicationUserCompanyRepository.DeleteAsync(linkedCompany);
                    await this.applicationUserCompanyRepository.SaveChangesAsync();
                    linkedCompanies.Remove(linkedCompany);
                }
            }

            //Parcours des sociétés pour ajouter les nouvelles
            for (int i = 0; i < user.Companies.Count; i++)
            {
                var userCompanyDTO = user.Companies.ElementAt(i);
                if (!linkedCompanies.Any(x => x.ApplicationCompanyId == userCompanyDTO.ApplicationCompanyId))
                {
                    //Ajout de la société car elle n'existe pas encore
                    var userCompany = await this.applicationUserCompanyRepository.AddAsync(this.mapper.Map<ApplicationUserCompany>(userCompanyDTO));
                    user.Companies.Remove(userCompanyDTO);
                    user.Companies.Add(this.mapper.Map<ApplicationUserCompanyDTO>(userCompany));
                }
            }
            #endregion

            #region Gestion des fonctions de l'utilisateur
            //Récupération des sociétés liées à l'utilisateur
            var userFunctions = (await this.applicationUserCompanyFunctionRepository.GetByUserAsync(user.Id)).ToList();

            //Parcours des anciennes pour vérifier qu'elles existent toujours
            for (int i = userFunctions.Count() - 1; i >= 0; i--)
            {
                var userFunction = userFunctions.ElementAt(i);
                if (!user.Functions.Any(x => x.FunctionId == userFunction.FunctionId))
                {
                    //Suppression car la fonction n'est plus liée
                    await this.applicationUserCompanyFunctionRepository.DeleteAsync(userFunction);
                    await this.applicationUserCompanyFunctionRepository.SaveChangesAsync();
                    userFunctions.Remove(userFunction);
                }
            }

            //Parcours des fonctions pour ajouter les nouvelles
            for (int i = 0; i < user.Functions.Count; i++)
            {
                var userFunctionDTO = user.Functions.ElementAt(i);
                if (!userFunctions.Any(x => x.FunctionId == userFunctionDTO.FunctionId))
                {
                    //Ajout de la société car elle n'existe pas encore
                    var userFunction = await this.applicationUserCompanyFunctionRepository.AddAsync(this.mapper.Map<ApplicationUserCompanyFunction>(userFunctionDTO));
                    user.Functions.Remove(userFunctionDTO);
                    user.Functions.Add(this.mapper.Map<ApplicationUserCompanyFunctionDTO>(userFunction));
                }
            }
            #endregion

            #region Gestion des droits de l'utilisateur                    
            if (updateRights)
            {
                var rights = await this.featureApplicationUserRightService.UpdateAsync(user.Id, user.Rights, transaction);
                user.Rights = rights.ToList();
            }
            #endregion

            //Mise à jour en base de données
            await userManager.UpdateAsync(userDb);

            return user;

        }

        /// <summary>
        /// Ajoute un utilisateur
        /// </summary>
        /// <param name="user">Urilisateur a ajouter</param>
        /// <param name="baseStoragePath">Chemin du stockage des fichiers</param>
        /// <returns>Utilisateur ajouté</returns>
        public async Task<ApplicationUserDTO> AddUserAsync(ApplicationUserDTO user, string baseStoragePath)
        {
            using (var transaction = this.applicationUserRepository.BeginTransaction())
            {
                try
                {
                    //Vérifications de cohérence
                    if (user == null)
                    {
                        throw new ArgumentNullException(nameof(user));
                    }
                    if (user.Id > 0)
                    {
                        throw new EntityAlreadyExistsException<ApplicationUser>();
                    }
                    
                    
                    //Création du nouvel utiliasteur
                    var newUser = this.mapper.Map<ApplicationUser>(user);

                    //On met les valeurs obligatoires
                    await newUser.SetMandatoryValuesAsync(this.userManager);

                    //Ajout en bdd
                    newUser = await this.applicationUserRepository.AddAsync(newUser);

                    


                    //On déplace l'image du dossier temp au dossier de l'utilisateur
                    if (user.Avatar != null)
                    {
                        FileInfo avatar = new FileInfo(Path.Combine(this.GetTempImageDirectoryPath(baseStoragePath, user).FullName, user.Avatar));
                        if (avatar.Exists)
                        {
                            string avatarName = this.GetImageNameFromTempImageName(newUser.Avatar);
                            FileInfo newFile = new FileInfo(Path.Combine(this.GetUserImageDirectoryPath(baseStoragePath, this.mapper.Map<ApplicationUserDTO>(newUser)).FullName, avatarName));
                            if (!newFile.Directory.Exists) newFile.Directory.Create();
                            avatar.MoveTo(newFile.FullName);

                            //On donne le lien et on sauvegarde l'utilisateur
                            newUser.Avatar = avatarName;
                            await this.applicationUserRepository.SaveChangesAsync();
                        }
                    }
                    
                    //Tranformation en DTO
                    ApplicationUserDTO applicationUserDTO = this.mapper.Map<ApplicationUserDTO>(newUser);
                    
                    //Ajout en base de données et renvoi
                    transaction.Commit();

                    return applicationUserDTO;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }
        }

        /// <summary>
        /// Réinitialise le mot de passe de l'utilisateur
        /// </summary>
        /// <param name="id">Identifiant de l'utilisateur</param>
        /// <param name="cultureShortName">Nom de la culture en version courte (FR, EN, ES...)</param>
        /// <returns>Aucun retour</returns>
        public async Task ReinitializePasswordAsync(long id, string cultureShortName)
        {
            if (cultureShortName == null)
            {
                throw new EntityNotFoundException<Culture>();
            }

            //Récupération de l'utilisateur
            var user = await this.userManager.FindByIdAsync(id.ToString());

            //Vérification qu'il éxiste
            if (user == null)
            {
                throw new EntityNotFoundException<ApplicationUser>(id);
            }

            //Génération du token
            var token = await userManager.GeneratePasswordResetTokenAsync(user);

            //Ouverture du fichier 
            var folderTemplatesPath = this.hostingEnvironnement.WebRootPath + Path.DirectorySeparatorChar + email_templates_path + Path.DirectorySeparatorChar;
            var filePath =  folderTemplatesPath + cultureShortName.ToUpper() + EMAIL_TEMPLATE_FILE_EXTENSION;
            if (!File.Exists(filePath))
            {
                filePath = folderTemplatesPath + "FR" + EMAIL_TEMPLATE_FILE_EXTENSION;
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("Content mail message not found");
                }
            }
            var htmlFile = new HtmlDocument();
            htmlFile.Load(filePath);

            //On remplace le lien dans le contenu
            string link = "/Settings/Security/users/" + user.Id + "/resetPassword?token=" + token;
            htmlFile.GetElementbyId(RESET_PASSWORD_LINK_ALIAS).SetAttributeValue("href", "/Settings/Security/users/" + user.Id + "/resetPassword"); 

            //Envoi d'un email à l'utilisateur pour l'informer de son nouveau mot de passe
            string header = htmlFile.GetElementbyId(RESET_PASSWORD_TITLE_ALIAS).InnerText;
            EmailHelper.SendMail(IMAP_SERVER_NAME, IMAP_SERVER_PORT, SMTP_USERNAME, SMTP_PASSWORD, SMTP_USERNAME, user.NormalizedEmail, header, htmlFile.ParsedText);

    }

        /// <summary>
        /// Récupère tous les utilisateurs assignables à un objet
        /// </summary>
        /// <param name="moduleId">Identifiant du module de l'objet</param>
        /// <param name="objectId">Identfiant de l'objet</param>
        /// <returns>Liste des utilisateurs assignables</returns>
        public async Task<IEnumerable<ApplicationUserDTO>> GetAssignableUsersForObjectAsync(long moduleId, long objectId)
        {
            try
            {
                ICollection<ApplicationUserDTO> applicationUsers = new HashSet<ApplicationUserDTO>();

                //Récupération des fonctions partageant l'objet
                var sharedFunctions = await this.objectSharedWithFunctionRepository.GetByObjectAsync(moduleId, objectId);

                //Pour toutes ces fonctions on récupère leurs utilisateurs
                foreach (var sharedFunction in sharedFunctions)
                {
                    var functionDTO = await this.applicationCompanyFunctionService.GetByIdAsync(sharedFunction.FunctionId);
                    var functions = await this.GetAllHierarchicalsUsersOfFunctionAsync(functionDTO);
                    foreach (var item in functions)
                    {
                        applicationUsers.Add(item);
                    }
                }
                return applicationUsers;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Sauvegarde temporairement l'image pour l'utilisateur spécifié
        /// </summary>
        /// <param name="userId">Identifiant de l'utilisateur pour lequel on enregistre temporairement l'image</param>
        /// <param name="avatar">Image à sauvegarder</param>
        /// <param name="baseStoragePath">Chemin de base du stockage</param>
        /// <returns></returns>
        public async Task<ApplicationUserDTO> SaveTempImageAsync(long userId, IFormFile avatar, string baseStoragePath)
        {
            //Récupération de l'utilisateur
            ApplicationUserDTO applicationUserDTO = await this.GetUserAsync(userId);

            //Récupération du dossier temporaire ou stocker l'image
            DirectoryInfo directoryInfo = this.GetTempImageDirectoryPath(baseStoragePath, applicationUserDTO);

            //Creation du fileInfo permettant d'avoir les informations sur le fichier
            FileInfo fileInfo = new FileInfo(Path.Combine(directoryInfo.FullName, this.GetTempImageName(avatar.FileName)));

            //Création des repertoires si besoin
            if (!fileInfo.Directory.Exists) fileInfo.Directory.Create();

            //Si une image existe deja alors on la supprime car une seule image temporaire pour l'utilisateur
            if (fileInfo.Exists) fileInfo.Delete();

            //Copie du fichier
            using (FileStream fileStream = new FileStream(fileInfo.FullName, FileMode.Create))
            {
                await avatar.CopyToAsync(fileStream);
            }

            //Si l'utilisateur est null alors on l'instancie pour le renvoyer avec le bon avatar
            if (applicationUserDTO == null)
            {
                //Instanciation d'un utilisateur sans information pour renvoyer les infos sur l'avatar
                applicationUserDTO = new ApplicationUserDTO();
            }

             
            //On donne l'adresse du chemin temporaire à l'utilisateur
            applicationUserDTO.Avatar = fileInfo.Name;
            while (applicationUserDTO.Avatar.StartsWith(Path.DirectorySeparatorChar.ToString()))
            {
                applicationUserDTO.Avatar = applicationUserDTO.Avatar.Substring(1);
            }

            return applicationUserDTO;
        }
        
        /// <summary>
        /// Récupérer les différentes genres disponibles
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EnumDTO<Gender>> GetGenders()
        {
            return EnumHelper.ToList<Gender>().Select(x => this.mapper.Map<EnumDTO<Gender>>(x));
        }

        /// <summary>
        /// Supprime un utilisateur
        /// </summary>
        /// <param name="userId">Identifiant de l'utilisateur à supprimer</param>
        /// <returns></returns>
        public async Task DeleteAsync(long userId)
        {
            using (var transaction = this.applicationUserRepository.BeginTransaction())
            {
                try
                {
                    var user = await this.userManager.FindByIdAsync(userId.ToString());
                    if (user == null) throw new EntityNotFoundException<ApplicationUser>(userId);

                    //Suppression
                    await this.userManager.DeleteAsync(user);
                    transaction.Commit();

                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }
        }

        /// <summary>
        /// Récupération de tous les utilisateurs ayant le rôle demandé
        /// </summary>
        /// <param name="roleId">Identifiant du rôle</param>
        /// <returns></returns>
        public async Task<IEnumerable<ApplicationUserDTO>> GetByRoleAsync(long roleId)
        {
            var users = await this.applicationUserRepository.GetByRoleAsync(roleId);

            return users.Select(x => this.mapper.Map<ApplicationUserDTO>(x));
        }

        /// <summary>
        /// Recherche un utilisateur selon son nom complet
        /// </summary>
        /// <param name="fullName">Nom de l'utilisateur à rechercher</param>
        /// <param name="ignoreCase">Ignorer la casse ou non</param>
        /// <param name="ignoreWhiteSpaces">Ignorer les espaces ou non</param>
        /// <param name="ignoreDiacritics">Ignorer les accents ou non</param>
        /// <returns></returns>
        public async Task<ApplicationUserDTO> GetByFullNameAsync(string fullName, bool ignoreCase = true, bool ignoreWhiteSpaces = false, bool ignoreDiacritics = false)
        {
            return this.mapper.Map<ApplicationUserDTO>(await this.applicationUserRepository.GetByFullNameAsync(fullName, ignoreCase, ignoreWhiteSpaces, ignoreDiacritics));
        }

        /// <summary>
        /// Récupérer la liste des droits de l'utilisateur
        /// </summary>
        /// <param name="applicationUserDTO">Utilisateur pour lequel récupérer les droits</param>
        /// <param name="includeFeature">Inclure ou non la fonctionnalité du droit</param>
        /// <param name="includeConcernedElement">Inclure ou non l'élement concerné par le droit</param>
        /// <returns></returns>
        public async Task<IEnumerable<FeatureApplicationUserRightDTO>> GetRightsAsync(ApplicationUserDTO applicationUserDTO, bool includeFeature = false, bool includeConcernedElement = false)
        {
            List<FeatureApplicationUserRightDTO> rights = (await this.featureApplicationUserRightService.GetByUserAsync(applicationUserDTO.Id, includeFeature, includeConcernedRightElement: false)).ToList();


            //On récupère le profil de l'utilisateur
            var profile = await this.applicationRoleService.GetByIdAsync(applicationUserDTO.ApplicationRoleId, includeRights: true);
            if (profile == null) throw new EntityNotFoundException<ApplicationRole>();

            foreach (var profileRight in profile.Rights)
            {
                // On regarde si ce droit n'éxiste pas encore
                if (!rights.Any(x => x.FeatureId == profileRight.FeatureId))
                {
                    //Ce droit n'a pas encore été défini pour l'utilsiateur alors on lui ajoute en héritage
                    var newRight = new FeatureApplicationUserRightDTO()
                    {
                        Allowed = true,
                        Feature = includeFeature ? await this.featureService.GetAsync(profileRight.FeatureId, false, false) : null,
                        FeatureId = profileRight.FeatureId,
                        ApplicationUserId = applicationUserDTO.Id,
                        ApplicationUser = includeConcernedElement ? applicationUserDTO : null,
                        Inherited = true
                    };
                    rights.Add(newRight);
                }
            }

            return rights;

        }

        /// <summary>
        /// Récupère les droits d'un utilisateur
        /// </summary>
        /// <param name="userId">Identifiant de l'utilisateur pour lequel récupérer les droits</param>
        /// <param name="includeFeature">Inclure ou non la fonctionnalité du droit</param>
        /// <param name="includeConcernedElement">Inclure ou non l'élement concerné par le droit</param>
        /// <returns></returns>
        public async Task<IEnumerable<FeatureApplicationUserRightDTO>> GetRightsAsync(long userId, bool includeFeature = false, bool includeConcernedElement = false)
        {
            var userDTO = await this.GetUserAsync(userId, includeFunctions: false);
            if (userDTO == null) throw new EntityNotFoundException<ApplicationUser>(userId);

            return await this.GetRightsAsync(userDTO, includeFeature, includeConcernedElement);
        }

        #endregion

        #region Private methods
        /// <summary>
        /// Récupère tous les utilisateurs hiérarchiquement supérieur à la fonction et ceux de la fonction
        /// </summary>
        /// <param name="function">Fonction pour laquelle on récupère les utlisateurs</param>
        /// <returns>Liste des utilisateurs de la fonction</returns>
        private async Task<IEnumerable<ApplicationUserDTO>> GetAllHierarchicalsUsersOfFunctionAsync(ApplicationCompanyFunctionDTO function)
        {

            //Récupération des utilisateurs de la fonction
            List<ApplicationUserDTO> users = (await this.GetUsersByFunctionAsync(function)).ToList();

            //Ajout des utilisateurs de tous les sous niveaux
            foreach (var subFunction in function.Childs)
            {
                users.AddRange(await this.GetAllHierarchicalsUsersOfFunctionAsync(subFunction));
            }

            return users;
        }

        /// <summary>
        /// Charge tous les utilisateurs des fonctions passées en paramètre
        /// </summary>
        /// <param name="userFunctions">Liste des fonctions pour lequels on va récupérer les utilisateurs</param>
        /// <returns></returns>
        private async Task<IEnumerable<ApplicationUserDTO>> GetAllUsersForFunctionsAsync(IEnumerable<ApplicationCompanyFunctionDTO> functions)
        {
            //Pour chaque fonction récupération des sous fonctions
            foreach (var function in functions)
            {
                function.Childs = (await this.applicationCompanyFunctionService.GetHierarchisedAsync(function.CompanyId, function.Id))?.ToList();
            }

            //Récupération des utilisateurs de toutes les fonctions
            List<ApplicationUserDTO> users = new List<ApplicationUserDTO>();
            foreach (var function in functions)
            {
                users.AddRange(await this.GetAllHierarchicalsUsersOfFunctionAsync(function));
            }

            return users;
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

        /// <summary>
        /// Récupère le chemin du dossier ou sont stockés les images de l'utilisateur
        /// </summary>
        /// <param name="baseStoragePath">Chemin de base ou sont stockés les fichiers</param>
        /// <param name="applicationUserDTO">Utilisateur concerné</param>
        /// <returns></returns>
        private DirectoryInfo GetUserImageDirectoryPath(string baseStoragePath, ApplicationUserDTO applicationUserDTO)
        {
            if (applicationUserDTO == null) throw new EntityNotFoundException<ApplicationUser>();
            return new DirectoryInfo(Path.Combine(baseStoragePath, "data", "users", applicationUserDTO.NormalizedEmail));
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
            return Path.GetFileNameWithoutExtension(tempImageName).Replace(TEMP_SALT, string.Empty) + currentDateTime + Path.GetExtension(tempImageName);    
        }
        #endregion
    }
}
