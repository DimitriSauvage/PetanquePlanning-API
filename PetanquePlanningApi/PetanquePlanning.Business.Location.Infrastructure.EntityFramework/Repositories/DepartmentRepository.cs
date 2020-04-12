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
    public class DepartmentRepository : PetanquePlanningRepository<Department>, IDepartmentRepository
    {
        #region Constructor
        public DepartmentRepository(DbContext dbContext) : base(dbContext)
        {

        }
        #endregion

        #region Methods
        /// <inheritdoc/>
        public async Task<IEnumerable<Department>> GetAsync(bool withAdjacentDepartments = false, bool withRegion = false)
        {
            var result = this.Query();
            if (withAdjacentDepartments) result = result.Include(x => x.AdjacentDepartments);
            if (withRegion) result = result.Include(x => x.Region);

            return await result.ToListAsync();
        }

        #endregion
    }
}
