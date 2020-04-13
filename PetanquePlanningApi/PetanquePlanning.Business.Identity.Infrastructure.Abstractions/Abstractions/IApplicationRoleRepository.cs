using System.Collections.Generic;
using System.Threading.Tasks;
using PetanquePlanning.Business.Identity.Domain.Entities;
using Tools.Infrastructure.Abstraction;

namespace PetanquePlanning.Business.Identity.Infrastructure.Abstractions.Abstractions
{
    public interface IApplicationRoleRepository : IRepository<ApplicationRole>
    {
        /// <summary>
        /// Récupère un profil par son nom
        /// </summary>
        /// <param name="role">Nom du profil</param>
        /// <returns></returns>
        Task<ApplicationRole> GetByName(string role);
    }
}