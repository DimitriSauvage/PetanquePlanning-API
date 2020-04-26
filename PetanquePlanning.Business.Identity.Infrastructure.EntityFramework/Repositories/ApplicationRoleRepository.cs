using System;
using System.Threading.Tasks;
using DimitriSauvageTools.Infrastructure.EntityFramework.Abstractions;
using Microsoft.EntityFrameworkCore;
using PetanquePlanning.Business.Identity.Domain.Entities;
using PetanquePlanning.Business.Identity.Infrastructure.Abstractions.Abstractions;

namespace PetanquePlanning.Business.Identity.Infrastructure.EntityFramework.Repositories
{
    public class ApplicationRoleRepository : DbRepository<ApplicationRole>, IApplicationRoleRepository
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