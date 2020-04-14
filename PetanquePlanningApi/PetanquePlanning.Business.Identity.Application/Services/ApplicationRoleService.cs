using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abalone.Business.Identity.Application.Abstractions.Abstractions;
using Abalone.Business.Identity.Application.DTO;
using PetanquePlanning.Business.Identity.Domain.Entities;
using PetanquePlanning.Business.Identity.Infrastructure.Abstractions.Abstractions;
using Tools.Application.Abstractions.Abstractions;
using Tools.Infrastructure.Exceptions;

namespace PetanquePlanning.Business.Identity.Application.Services
{
    public class ApplicationRoleService : BaseService<ApplicationRole, IApplicationRoleRepository>,
        IApplicationRoleService
    {
        #region Private attributes

        /// <summary>
        /// User manager
        /// </summary>
        private IApplicationUserRepository ApplicationUserRepository { get; }

        #endregion

        #region Constructor

        public ApplicationRoleService(IApplicationUserRepository applicationUserRepository)
        {
            this.ApplicationUserRepository = applicationUserRepository;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<IEnumerable<ApplicationRoleDTO>> GetAllAsync()
        {
            var roles = await this.Repository.ListAsync();
            return roles.Select(x => this.Mapper.Map<ApplicationRoleDTO>(x));
        }

        /// <inheritdoc />
        public async Task<ApplicationRoleDTO> CreateAsync(ApplicationRoleDTO roleDto)
        {
            using (var transaction = this.Repository.BeginTransaction())
            {
                try
                {
                    if (roleDto == null) throw new ArgumentNullException(nameof(roleDto));

                    var roleToCreate = this.Mapper.Map<ApplicationRole>(roleDto);

                    // Vérification de l'existence d'un autre enregistrement pour la clé unique
                    var existingProfile = await this.Repository.GetByUniqueKeyAsync(roleToCreate);
                    if (existingProfile != null)
                        throw new EntityAlreadyExistsException<ApplicationRole>(existingProfile);

                    // Sauvegarde
                    roleToCreate.NormalizedName = roleToCreate.Name.Normalize();
                    await this.Repository.AddAsync(roleToCreate);
                    await this.Repository.SaveChangesAsync();

                    //Validate transaction
                    transaction.Commit();

                    return this.Mapper.Map<ApplicationRoleDTO>(roleDto);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        /// <inheritdoc />
        public async Task<ApplicationRoleDTO> UpdateAsync(ApplicationRoleDTO applicationRoleDto)
        {
            using (var transaction = this.Repository.BeginTransaction())
            {
                try
                {
                    if (applicationRoleDto == null) throw new ArgumentNullException(nameof(applicationRoleDto));

                    //Recherche de l'entité
                    var role = await this.Repository.GetByIdAsync(applicationRoleDto.Id);
                    if (role == null) throw new EntityNotFoundException<ApplicationRole>(applicationRoleDto.Id);

                    //On recopie les valeurs
                    role.CopyFrom(this.Mapper.Map<ApplicationRole>(applicationRoleDto));
                    role.NormalizedName = role.Name.Normalize();


                    //Sauvegarde
                    await this.Repository.SaveChangesAsync();
                    transaction.Commit();

                    return this.Mapper.Map<ApplicationRoleDTO>(role);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        /// <inheritdoc />
        public async Task DeleteAsync(long roleId, ApplicationRoleDTO newRoleForUsers)
        {
            using (var transaction = this.Repository.BeginTransaction())
            {
                try
                {
                    //On vérifie que le nouveau rôle n'est pas nul et qu'il existe
                    if (newRoleForUsers == null) throw new ArgumentNullException(nameof(newRoleForUsers));
                    var newRole = await this.Repository.GetByIdAsync(newRoleForUsers.Id);
                    if (newRole == null) throw new EntityNotFoundException<ApplicationRole>(newRoleForUsers.Id);

                    //Récupération du rôle à supprimer
                    var roleToDelete = await this.Repository.GetByIdAsync(roleId);
                    if (roleToDelete == null) throw new EntityNotFoundException<ApplicationRole>(roleId);

                    //On récupère tous les utilisateurs ayant le rôle à supprimer
                    IEnumerable<ApplicationUser> users = await this.ApplicationUserRepository.GetByRoleAsync(roleId);

                    //Mise à jour des utilisateurs
                    foreach (var user in users)
                    {
                        user.ApplicationRoleId = newRole.Id;
                    }

                    await this.ApplicationUserRepository.SaveChangesAsync();

                    //On supprime le rôle
                    await this.Repository.DeleteAsync(roleToDelete);

                    //Sauvegarde 
                    await this.Repository.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        /// <inheritdoc />
        public async Task<long> GetRoleIdAsync(string role)
        {
            return (await this.Repository.GetByName(role)).Id;
        }

        #endregion
    }
}