using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetanquePlanning.Business.Identity.Domain.Entities;
using PetanquePlanning.Business.Identity.Infrastructure.Abstractions.Abstractions;
using Tools.Infrastructure.EntityFramework.Abstractions;

namespace PetanquePlanning.Business.Identity.Infrastructure.EntityFramework.Repositories
{
    public class ApplicationUserRepository : DbRepository<ApplicationUser>, IApplicationUserRepository
    {
        #region Constructors

        public ApplicationUserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Récupération de tous les utilisateurs ayant le rôle demandé
        /// </summary>
        /// <param name="roleId">Identifiant du rôle</param>
        /// <returns></returns>
        public async Task<IEnumerable<ApplicationUser>> GetByRoleAsync(long roleId)
        {
            return await Query()
                .Where(x => x.ApplicationRoleId == roleId)
                .ToListAsync();
        }

        #endregion
    }
}