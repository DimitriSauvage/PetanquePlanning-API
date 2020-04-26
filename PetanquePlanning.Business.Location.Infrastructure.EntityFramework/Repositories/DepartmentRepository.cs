using System.Collections.Generic;
using System.Threading.Tasks;
using DimitriSauvageTools.Infrastructure.EntityFramework.Abstractions;
using Microsoft.EntityFrameworkCore;
using PetanquePlanning.Business.Location.Domain.Entities;
using PetanquePlanning.Business.Location.Infrastructure.Abstractions.Abstractions;

namespace PetanquePlanning.Business.Location.Infrastructure.EntityFramework.Repositories
{
    public class DepartmentRepository : DbRepository<Department>, IDepartmentRepository
    {
        #region Constructor

        public DepartmentRepository(DbContext dbContext) : base(dbContext)
        {
        }

        #endregion

        #region Methods

        /// <inheritdoc/>
        public async Task<IEnumerable<Department>> GetAsync(bool withAdjacentDepartments = false,
            bool withRegion = false)
        {
            var result = this.Query();
            if (withAdjacentDepartments) result = result.Include(x => x.AdjacentDepartments);
            if (withRegion) result = result.Include(x => x.Region);

            return await result.ToListAsync();
        }

        #endregion
    }
}