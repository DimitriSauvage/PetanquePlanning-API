using Abalone.Business.Identity.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Abalone.Business.Identity.Application.Abstractions.Abstractions
{
    public interface IApplicationRoleService
    {
        /// <summary>
        /// Récupère tous les rôles
        /// </summary>
        /// <returns>Liste des rôles</returns>
        Task<IEnumerable<ApplicationRoleDTO>> GetAllAsync();

        /// <inheritDoc/>
        /// <summary>
        /// Créer un nouveau rôle
        /// </summary>
        /// <param name="dto">Rôle à créer</param>
        /// <returns>Rôle créé</returns>
        Task<ApplicationRoleDTO> CreateAsync(ApplicationRoleDTO roleDto);

        /// <summary>
        /// Met à jour un rôle
        /// </summary>
        /// <param name="applicationRoleDto">Rôle à mettre à jour</param>
        /// <returns></returns>
        Task<ApplicationRoleDTO> UpdateAsync(ApplicationRoleDTO applicationRoleDto);
        
        /// <summary>
        /// Supprime un rôle
        /// </summary>
        /// <param name="roleId">Identifiant du rôle</param>
        /// <param name="newRoleForUsers">Rôle à affecter aux utilisateurs ayant le rôle à supprimer</param>
        /// <returns></returns>
        Task DeleteAsync(long roleId, ApplicationRoleDTO newRoleForUsers);
        
        /// <inheritDoc/>
        /// <summary>
        /// Récupère l'identifiant d'un rôle par son nom
        /// </summary>
        /// <param name="role">Nom du rôle</param>
        /// <returns>Identifiant du rôle</returns>
        Task<long> GetRoleIdAsync(string role);
    }
}
