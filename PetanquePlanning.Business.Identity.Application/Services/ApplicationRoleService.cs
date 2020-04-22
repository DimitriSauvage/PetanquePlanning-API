using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetanquePlanning.Business.Identity.Application.DTO.DTO.Roles;
using PetanquePlanning.Business.Identity.Domain.Entities;
using PetanquePlanning.Business.Identity.Infrastructure.Abstractions.Abstractions;
using Tools.Application.Abstractions;
using Tools.Infrastructure.Exceptions;

namespace PetanquePlanning.Business.Identity.Application.Services
{
    public class ApplicationRoleService : BaseService<ApplicationRole, IApplicationRoleRepository>
    {
        #region Private attributes

        #endregion

        #region Constructor

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
            if (roleDto == null) throw new ArgumentNullException(nameof(roleDto));
            var role = this.Mapper.Map<ApplicationRole>(roleDto);

            // Check if the element is unique
            var existingProfile = await this.Repository.GetByUniqueKeyAsync(role);
            if (existingProfile != null)
                throw new EntityAlreadyExistsException<ApplicationRole>(existingProfile);

            //Create the element
            return await this.Repository.TransactionalExecutionAsync(
                action: async (roleToCreate, transaction) =>
                {
                    // Save it
                    roleToCreate.NormalizedName = roleToCreate.Name.Normalize();
                    await this.Repository.AddAsync(roleToCreate);
                    await this.Repository.SaveChangesAsync();
                },
                obj: role,
                onSuccessFunc: createdRole => this.Mapper.Map<ApplicationRoleDTO>(createdRole));
        }

        /// <inheritdoc />
        public async Task<ApplicationRoleDTO> UpdateAsync(ApplicationRoleDTO applicationRoleDto)
        {
            if (applicationRoleDto == null) throw new ArgumentNullException(nameof(applicationRoleDto));

            return await this.Repository.TransactionalExecutionAsync(
                action: async (role, transaction) =>
                {
                    //Search the entity
                    var roleDb = await this.Repository.GetByIdAsync(role.Id);
                    if (roleDb == null) throw new EntityNotFoundException<ApplicationRole>(role.Id);

                    //Copy the values
                    roleDb.CopyFrom(this.Mapper.Map<ApplicationRole>(role));
                    roleDb.NormalizedName = roleDb.Name.Normalize();

                    //Save
                    await this.Repository.SaveChangesAsync();
                },
                obj: this.Mapper.Map<ApplicationRole>(applicationRoleDto),
                onSuccessFunc: role => this.Mapper.Map<ApplicationRoleDTO>(role));
        }

        /// <inheritdoc />
        public async Task DeleteAsync(Guid roleId, ApplicationRoleDTO newRoleForUsers)
        {
            //On vérifie que le nouveau rôle n'est pas nul et qu'il existe
            if (newRoleForUsers == null) throw new ArgumentNullException(nameof(newRoleForUsers));
            var newRole = await this.Repository.GetByIdAsync(newRoleForUsers.Id);
            if (newRole == null) throw new EntityNotFoundException<ApplicationRole>(newRoleForUsers.Id);

            //Récupération du rôle à supprimer
            var roleToDelete = await this.Repository.GetByIdAsync(roleId);
            if (roleToDelete == null) throw new EntityNotFoundException<ApplicationRole>(roleId);

            await this.Repository.TransactionalExecutionAsync(
                action: async (role, transaction) =>
                {
                    //Copy the values
                    role.CopyFrom(this.Mapper.Map<ApplicationRole>(role));
                    role.NormalizedName = role.Name.Normalize();

                    //Save
                    await this.Repository.SaveChangesAsync();
                },
                obj: this.Mapper.Map<ApplicationRole>(roleToDelete));
        }

        /// <inheritdoc />
        public async Task<Guid> GetRoleIdAsync(string role)
        {
            return (await this.Repository.GetByName(role)).Id;
        }

        #endregion
    }
}