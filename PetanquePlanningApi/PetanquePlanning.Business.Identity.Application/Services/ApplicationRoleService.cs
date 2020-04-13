using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Abalone.Business.Identity.Application.Abstractions;
using Abalone.Business.Identity.Application.DTO;
using Abalone.Business.Identity.Application.DTO.Account;
using Abalone.Business.Identity.Application.DTO.Users;
using Abalone.Business.Identity.Domain.Entities;
using Abalone.Business.Identity.Domain.Exceptions;
using Abalone.Business.Identity.Infrastructure.Abstractions;
using Abalone.Tools.Exceptions;
using Abalone.Tools.Http.Extensions;
using Abalone.Tools.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Abalone.Business.Identity.Application.Abstractions.Abstractions;
using Abalone.Business.Identity.Infrastructure.Abstractions.Features;
using Abalone.Business.Identity.Domain.Entities.Features;
using Abalone.Business.Identity.Application.Abstractions.DTO.Features;
using Abalone.Business.Identity.Application.Abstractions.Abstractions.Features;
using PetanquePlanning.Business.Identity.Domain.Entities;
using PetanquePlanning.Business.Identity.Infrastructure.Abstractions.Abstractions;
using Tools.Infrastructure.Exceptions;

namespace Abalone.Business.Identity.Application.Services
{
    public class ApplicationRoleService : IApplicationRoleService
    {
        #region Private attributes

        private IApplicationRoleRepository ApplicationRoleRepository { get; }
        private readonly IApplicationRoleRepository applicationRoleRepository;
        private readonly IMapper mapper;
        private readonly IApplicationUserRepository applicationUserRepository;
        private readonly IFeatureApplicationRoleRightService featureApplicationRoleRightService = null;

        #endregion

        #region Constructors

        public ApplicationRoleService(IApplicationRoleRepository applicationRoleRepository,
            IMapper mapper,
            IApplicationUserRepository applicationUserRepository,
            IFeatureApplicationRoleRightService featureApplicationRoleRightService)
        {
            this.applicationRoleRepository = applicationRoleRepository;
            this.mapper = mapper;
            this.applicationUserRepository = applicationUserRepository;
            this.featureApplicationRoleRightService = featureApplicationRoleRightService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Supprime un rôle
        /// </summary>
        /// <param name="roleId">Identifiant du rôle</param>
        /// <param name="newRoleForUsers">Rôle à affecter aux utilisateurs ayant le rôle à supprimer</param>
        /// <returns></returns>
        public async Task DeleteAsync(long roleId, ApplicationRoleDTO newRoleForUsers)
        {
            using (var transaction = this.applicationRoleRepository.BeginTransaction())
            {
                try
                {
                    //On vérifie que le nouveau rôle n'est pas nul et qu'il existe
                    if (newRoleForUsers == null) throw new ArgumentNullException(nameof(newRoleForUsers));
                    var newRole = await this.applicationRoleRepository.GetByIdAsync(newRoleForUsers.Id);
                    if (newRole == null) throw new EntityNotFoundException<ApplicationRole>(newRoleForUsers.Id);

                    //Récupération du rôle à supprimer
                    var roleToDelete = await this.applicationRoleRepository.GetByIdAsync(roleId);
                    if (newRole == null) throw new EntityNotFoundException<ApplicationRole>(roleId);

                    //On récupère tous les utilisateurs ayant le rôle à supprimer
                    IEnumerable<ApplicationUser> users = await this.applicationUserRepository.GetByRoleAsync(roleId);

                    //Mise à jour des utilisateurs
                    foreach (var user in users)
                    {
                        user.ApplicationRoleId = newRole.Id;
                    }

                    await this.applicationUserRepository.SaveChangesAsync();

                    //On supprime le rôle
                    await this.applicationRoleRepository.DeleteAsync(roleToDelete);

                    //Sauvegarde 
                    await this.applicationRoleRepository.SaveChangesAsync();
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
        /// Créé un nouveau rôle
        /// </summary>
        /// <param name="dto">Rôle à créer</param>
        /// <returns></returns>
        public async Task<ApplicationRoleDTO> Create(ApplicationRoleDTO dto)
        {
            using (var transaction = applicationRoleRepository.BeginTransaction())
            {
                try
                {
                    if (dto == null) throw new ArgumentNullException(nameof(dto));

                    var profileToCreate = this.mapper.Map<ApplicationRole>(dto);

                    // Vérification de l'existence d'un autre enregistrement pour la clé unique
                    var existingProfile = await applicationRoleRepository.GetByUniqueKeyAsync(profileToCreate);
                    if (existingProfile != null)
                        throw new EntityAlreadyExistsException<ApplicationRole>(existingProfile);

                    // Sauvegarde
                    profileToCreate.NormalizedName = profileToCreate.Name.Normalize();
                    profileToCreate = await applicationRoleRepository.AddAsync(profileToCreate);
                    await applicationRoleRepository.SaveChangesAsync();
                    transaction.Commit();

                    return this.mapper.Map<ApplicationRoleDTO>(profileToCreate);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Récupère tous les rôles
        /// </summary>
        /// <param name="includeRights">Inclure ou non les droits</param>
        /// <returns>Liste des rôles</returns>
        public async Task<ICollection<ApplicationRoleDTO>> GetAllAsync(bool includeRights = false)
        {
            var result = new List<ApplicationRoleDTO>();
            var roles = await applicationRoleRepository.GetAllAsync(includeRights);
            foreach (var role in roles)
            {
                result.Add(mapper.Map<ApplicationRoleDTO>(role));
            }

            return result;
        }

        /// <summary>
        /// Obtient l'identifiant d'un role par son nom
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<long> GetRoleId(string role)
        {
            return (await applicationRoleRepository.GetByName(role)).Id;
        }

        /// <inheritDoc/>
        /// <summary>
        /// Obtient un rôle par son identifiant
        /// </summary>
        /// <param name="roleId">Identifiant du rôle</param>
        /// <param name="includeRights">Inclure ou non les droits</param>
        /// <returns>Rôle correspondant à l'identifiant</returns>
        public async Task<ApplicationRoleDTO> GetByIdAsync(long roleId, bool includeRights = false)
        {
            var role = await this.applicationRoleRepository.GetByIdAsync(roleId, includeRights);
            return this.mapper.Map<ApplicationRoleDTO>(role);
        }

        /// <summary>
        /// Met à jour un rôle
        /// </summary>
        /// <param name="applicationRoleDTO">Rôle à mettre à jour</param>
        /// <param name="updateRights">Mettre à jour ou non les droits</param>
        /// <returns></returns>
        public async Task<ApplicationRoleDTO> UpdateAsync(ApplicationRoleDTO applicationRoleDTO,
            bool updateRights = false)
        {
            using (var transaction = this.applicationRoleRepository.BeginTransaction())
            {
                try
                {
                    if (applicationRoleDTO == null) throw new ArgumentNullException(nameof(applicationRoleDTO));

                    //Recherche de l'entité
                    var role = await this.applicationRoleRepository.GetByIdAsync(applicationRoleDTO.Id);
                    if (role == null) throw new EntityNotFoundException<ApplicationRole>(applicationRoleDTO.Id);

                    //On recopie les valeurs
                    role.CopyFrom(this.mapper.Map<ApplicationRole>(applicationRoleDTO));
                    role.NormalizedName = role.Name.Normalize();

                    #region Gestion des droits du profil

                    if (updateRights)
                    {
                        var rights =
                            await this.featureApplicationRoleRightService.UpdateAsync(role.Id,
                                applicationRoleDTO.Rights, transaction);
                        role.Rights = rights.Select(x => this.mapper.Map<FeatureApplicationRoleRight>(x)).ToList();
                    }

                    #endregion

                    //Sauvegarde
                    await this.applicationRoleRepository.SaveChangesAsync();
                    transaction.Commit();

                    return this.mapper.Map<ApplicationRoleDTO>(role);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }
        }

        #endregion

        #region Private methods

        #endregion
    }
}