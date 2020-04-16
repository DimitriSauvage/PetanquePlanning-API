using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetanquePlanning.Business.Core.Application.Abstractions.Abstractions;
using PetanquePlanning.Business.Core.Application.Abstractions.DTO;
using PetanquePlanning.Business.Core.Domain.Entities;
using PetanquePlanning.Business.Core.Infrastructure.Abstractions.Abstractions;
using Tools.Application.Abstractions;

namespace PetanquePlanning.Business.Core.Application.Services
{
    public class CompetitionService : BaseService<Competition, ICompetitionRepository>, ICompetitionService
    {
        #region Fields

        #endregion

        #region Constructor

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<IEnumerable<CompetitionDTO>> GetAsync(IEnumerable<string> departmentCodes = null)
        {
            var competitions = await this.Repository.GetAsync(departmentCodes);
            return competitions.Select(x => this.Mapper.Map<CompetitionDTO>(x));
        }

        /// <inheritdoc />
        public async Task<IEnumerable<CompetitionDTO>> GetAsync(DateTimeOffset startDate, DateTimeOffset endDate,
            IEnumerable<string> departmentCodes = null)
        {
            var competitions = await this.Repository.GetAsync(startDate, endDate, departmentCodes);
            return competitions.Select(x => this.Mapper.Map<CompetitionDTO>(x));
        }

        #endregion
    }
}