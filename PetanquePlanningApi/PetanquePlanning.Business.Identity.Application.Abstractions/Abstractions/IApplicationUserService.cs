using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using PetanquePlanning.Business.Identity.Application.Abstractions.DTO.Users;

namespace PetanquePlanning.Business.Identity.Application.Abstractions.Abstractions
{
    public interface IApplicationUserService
    {
        /// <summary>
        /// Get a user by his email
        /// </summary>
        /// <param name="email">Email to search</param>
        /// <returns>Found user</returns>
        Task<ApplicationUserDTO> GetByEmailAsync(string email);

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
        /// <param name="baseStoragePath">Chemin de base des fichiers</param>
        /// <returns>Aucun retour</returns>
        Task<ApplicationUserDTO> UpdateAsync(ApplicationUserDTO user, string baseStoragePath);

        /// <summary>
        /// Met à jour un utilisateur en base de données
        /// </summary>
        /// <param name="user">Utilisateur à ajouter</param>
        /// <param name="baseStoragePath">Chemin de base des fichiers</param>
        /// <param name="transaction">Transaction dans laquelle effectuer le traitement</param>
        /// <returns>Aucun retour</returns>
        Task<ApplicationUserDTO> UpdateAsync(ApplicationUserDTO user, string baseStoragePath,
            IDbContextTransaction transaction);

        /// <summary>
        /// Ajoute un utilisateur
        /// </summary>
        /// <param name="user">Utilisateur a ajouter</param>
        /// <param name="baseStoragePath">Chemin de base des fichiers</param>
        /// <returns>Utilisateur ajouté</returns>
        Task<ApplicationUserDTO> CreateAsync(ApplicationUserDTO user, string baseStoragePath);

        /// <summary>
        /// Réinitialise le mot de passe de l'utilisateur
        /// </summary>
        /// <param name="id">Identifiant de l'utilisateur</param>
        /// <returns>Aucun retour</returns>
        Task ReinitializePasswordAsync(long id);

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