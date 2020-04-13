using System.Collections.Generic;
using System.Threading.Tasks;
using Abalone.Business.Identity.Application.DTO.Users;

namespace Abalone.Business.Identity.Application.Abstractions.Abstractions
{
    public interface IApplicationUserService
    {
        /// <summary>
        /// Récupère la liste de tous les utilisateurs
        /// </summary>
        /// <returns>liste de tous les utilisateurs</returns>
        Task<IEnumerable<ApplicationUserDTO>> GetAllAsync();

        /// <summary>
        /// Obtient un utilisateur depuis son identifiant
        /// </summary>
        /// <param name="userId">Identifiant de l'utilisateur à récupérer</param>
        /// <returns>Utilisateur trouvé</returns>
        Task<ApplicationUserDTO> GetByIdAsync(long userId);

        /// <summary>
        /// Met à jour un utilisateur en base de données
        /// </summary>
        /// <param name="user">Utilisateur à ajouter</param>
        /// <returns>Aucun retour</returns>
        Task<ApplicationUserDTO> UpdateAsync(ApplicationUserDTO user);

        /// <summary>
        /// Ajoute un utilisateur
        /// </summary>
        /// <param name="user">Utilisateur a ajouter</param>
        /// <returns>Utilisateur ajouté</returns>
        Task<ApplicationUserDTO> CreateAsync(ApplicationUserDTO user);

        /// <summary>
        /// Réinitialise le mot de passe de l'utilisateur
        /// </summary>
        /// <param name="id">Identifiant de l'utilisateur</param>
        /// <param name="cultureShortName">Nom de la culture en version courte (FR, EN, ES...)</param>
        /// <returns>Aucun retour</returns>
        Task ReinitializePasswordAsync(long id, string cultureShortName);

        /// <summary>
        /// Supprime un utilisateur
        /// </summary>
        /// <param name="userId">Identifiant de l'utilisateur à supprimer</param>
        /// <returns></returns>
        Task DeleteAsync(long userId);

        /// <summary>
        /// Récupération de tous les utilisateurs ayant le rôle demandé
        /// </summary>
        /// <param name="roleId">Identifiant du rôle</param>
        /// <returns></returns>
        Task<IEnumerable<ApplicationUserDTO>> GetByRoleAsync(long roleId);
    }
}