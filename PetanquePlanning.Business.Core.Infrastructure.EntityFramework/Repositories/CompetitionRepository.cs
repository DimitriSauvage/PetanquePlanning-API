using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetanquePlanning.Business.Core.Domain.Entities;
using PetanquePlanning.Business.Core.Infrastructure.Abstractions.Abstractions;
using Tools.Infrastructure.EntityFramework.Abstractions;

namespace PetanquePlanning.Business.Core.Infrastructure.EntityFramework.Repositories
{
    public class CompetitionRepository : DbRepository<Competition>, ICompetitionRepository
    {
        #region Constructor

        public CompetitionRepository(DbContext dbContext) : base(dbContext)
        {
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<IEnumerable<Competition>> GetAsync(IEnumerable<string> departmentCodes = null)
        {
            var result = this.Query();
            if (departmentCodes != null)
            {
                result = this.FilterWithDepartments(result, departmentCodes);
            }

            return await result.ToListAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Competition>> GetAsync(DateTimeOffset startDate, DateTimeOffset endDate,
            IEnumerable<string> departmentCodes = null)
        {
            var result = this.Query()
                .Where(x => x.Date >= startDate && x.Date <= endDate);
            result = this.FilterWithDepartments(result, departmentCodes);
            return await result.ToListAsync();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Add the filter for the departmentns
        /// </summary>
        /// <param name="competitions">Competitions to filter</param>
        /// <param name="departmentCodes">Department codes to use</param>
        /// <returns>Filtered competitions</returns>
        private IQueryable<Competition> FilterWithDepartments(IQueryable<Competition> competitions,
            IEnumerable<string> departmentCodes)
        {
            var result = competitions;
            if (departmentCodes != null)
            {
                result = result.Where(x =>
                    x.Address.ZipCode != null
                    && x.Address.ZipCode.Length > 1
                    && departmentCodes.Contains(x.Address.ZipCode.Substring(0, 2)));
            }

            return result;
        }

        #endregion
    }
}