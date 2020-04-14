using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetanquePlanning.Business.Core.Domain.Entities;
using PetanquePlanning.Business.Core.Infrastructure.Abstractions.Abstractions;
using Tools.Infrastructure.EntityFramework.Abstractions;

namespace PetanquePlanning.Business.Core.Infrastructure.EntityFramework.Repositories
{
    public class ClubRepository : DbRepository<Club>, IClubRepository
    {
        #region Constructor

        public ClubRepository(DbContext dbContext) : base(dbContext)
        {
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<IEnumerable<Club>> GetAsync()
        {
            return await this.ListAsync();
        }

        #endregion
    }
}