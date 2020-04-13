using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PetanquePlanning.Business.Core.Application.Abstractions.Abstractions;
using PetanquePlanning.Business.Core.Domain.Entities;
using PetanquePlanning.Business.Core.Infrastructure.Abstractions.Abstractions;

namespace PetanquePlanning.Business.Core.Application.Services
{
    public class CompetitionService : ICompetitionService
    {
        #region Fields

        /// <summary>
        /// Competition manager
        /// </summary>
        private ICompetitionRepository CompetitionRepository { get; }

        /// <summary>
        /// Mapping manager
        /// </summary>
        private IMapper Mapper { get; }

        #endregion

        #region Constructor

        public CompetitionService(ICompetitionRepository competitionRepository)
        {
            this.CompetitionRepository = competitionRepository;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<IEnumerable<CompetitionDTO>> GetAsync(IEnumerable<string> departmentCodes = null)
        {
            var competitions = await this.CompetitionRepository.GetAsync(departmentCodes);
            return competitions.Select(x => this.Mapper.Map<CompetitionDTO>(x));
        }

        /// <inheritdoc />
        public async Task<IEnumerable<CompetitionDTO>> GetAsync(DateTimeOffset startDate, DateTimeOffset endDate, IEnumerable<string> departmentCodes = null)
        {
            var competitions = await this.CompetitionRepository.GetAsync(startDate, endDate, departmentCodes);
            return competitions.Select(x => this.Mapper.Map<CompetitionDTO>(x));
        }

        #endregion
    }
}