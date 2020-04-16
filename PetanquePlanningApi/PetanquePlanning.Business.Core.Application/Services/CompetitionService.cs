using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetanquePlanning.Business.Core.Application.DTO.DTO;
using PetanquePlanning.Business.Core.Domain.Entities;
using PetanquePlanning.Business.Core.Infrastructure.Abstractions.Abstractions;
using Tools.Application.Abstractions;

namespace PetanquePlanning.Business.Core.Application.Services
{
    public class CompetitionService : BaseService<Competition, ICompetitionRepository>
    {
        #region Fields

        #endregion

        #region Constructor

        #endregion

        #region Methods
        
        /// <summary>
        /// Get all competitions in specifies departments
        /// </summary>
        /// <param name="departmentCodes">Codes of the departments</param>
        /// <returns>Competitions in the departments</returns>
        public async Task<IEnumerable<CompetitionDTO>> GetAsync(IEnumerable<string> departmentCodes = null)
        {
            var competitions = await this.Repository.GetAsync(departmentCodes);
            return competitions.Select(x => this.Mapper.Map<CompetitionDTO>(x));
        }

        /// <summary>
        /// Get all competitions in specifies departments
        /// </summary>
        /// <param name="startDate">Start date for the competition</param>
        /// <param name="endDate"></param>
        /// <param name="departmentCodes">Codes of the departments</param>
        /// <returns>Competitions in the departments</returns>
        public async Task<IEnumerable<CompetitionDTO>> GetAsync(DateTimeOffset startDate, DateTimeOffset endDate,
            IEnumerable<string> departmentCodes = null)
        {
            var competitions = await this.Repository.GetAsync(startDate, endDate, departmentCodes);
            return competitions.Select(x => this.Mapper.Map<CompetitionDTO>(x));
        }

        #endregion
    }
}