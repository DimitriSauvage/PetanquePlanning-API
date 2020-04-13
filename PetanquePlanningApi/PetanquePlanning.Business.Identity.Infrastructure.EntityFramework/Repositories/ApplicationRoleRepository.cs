using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetanquePlanning.Business.Identity.Domain.Entities;
using PetanquePlanning.Business.Identity.Infrastructure.Abstractions.Abstractions;
using Tools.Infrastructure.EntityFramework.Abstractions;

namespace PetanquePlanning.Business.Identity.Infrastructure.EntityFramework.Repositories
{
    public class ApplicationRoleRepository : PetanquePlanningRepository<ApplicationRole>, IApplicationRoleRepository
    {
        #region Constructors

        public ApplicationRoleRepository(DbContext dbContext) : base(dbContext)
        {
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<ApplicationRole> GetByName(string role)
        {
            return await this.Query()
                .FirstOrDefaultAsync(x => x.Name.Equals(role, StringComparison.InvariantCultureIgnoreCase));
        }


        #endregion
    }
}