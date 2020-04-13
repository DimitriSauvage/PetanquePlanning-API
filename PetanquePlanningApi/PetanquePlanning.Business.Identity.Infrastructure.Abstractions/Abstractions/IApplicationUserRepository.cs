using System.Collections.Generic;
using System.Threading.Tasks;
using PetanquePlanning.Business.Identity.Domain.Entities;
using Tools.Infrastructure.Abstraction;

namespace PetanquePlanning.Business.Identity.Infrastructure.Abstractions.Abstractions
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        /// <summary>
        /// Récupération de tous les utilisateurs ayant le rôle demandé
        /// </summary>
        /// <param name="roleId">Identifiant du rôle</param>
        /// <returns></returns>
        Task<IEnumerable<ApplicationUser>> GetByRoleAsync(long roleId);
    }
}