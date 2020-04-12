using Microsoft.EntityFrameworkCore;
using PetanquePlanning.Business.Location.Domain.Entities;
using PetanquePlanning.Business.Location.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Infrastructure.EntityFramework.Abstractions;

namespace PetanquePlanning.Business.Location.Infrastructure.EntityFramework
{
    public class RegionRepository : PetanquePlanningRepository<Region>, IRegionRepository
    {
        #region Constructor
        public RegionRepository(DbContext dbContext) : base(dbContext)
        {

        }

        #endregion

        #region Methods
        ///<inheritdoc/>
        public async Task<IEnumerable<Region>> GetAsync(bool includeDepartments = false)
        {
            var result = this.Query();
            if (includeDepartments) result = result.Include(x => x.Departments);

            return await result.ToListAsync();
        }
        #endregion
    }
}
