using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetanquePlanning.Business.Core.Application.DTO.DTO;
using PetanquePlanning.Business.Core.Domain.Entities;
using PetanquePlanning.Business.Core.Infrastructure.Abstractions.Abstractions;
using Tools.Application.Abstractions;
using Tools.Infrastructure.Exceptions;

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

        /// <summary>
        /// Get a competition by his id
        /// </summary>
        /// <param name="id">Id to found</param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException{TEntity}<Competition>"></exception>
        public async Task<CompetitionDTO> GetByIdAsync(long id)
        {
            var competition = await this.Repository.GetByIdAsync(id);
            if (competition == null) throw new EntityNotFoundException<Competition>();
            return this.Mapper.Map<CompetitionDTO>(competition);
        }

        /// <summary>
        /// Create a new competition
        /// </summary>
        /// <param name="competitionDto">Competition to crate</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="EntityAlreadyExistsException{TEntity}"<Competition>"></exception>
        public async Task<CompetitionDTO> CreateAsync(CompetitionDTO competitionDto)
        {
            if (competitionDto == null) throw new ArgumentNullException(nameof(competitionDto));

            return await this.Repository.TransactionalExecutionAsync(
                action: async (competition, transaction) =>
                {
                    //Check if the competition does not already exist
                    var searchedCompetition = await this.Repository.GetByUniqueKeyAsync(competition);
                    if (searchedCompetition != null) throw new EntityAlreadyExistsException<Competition>(competition);

                    //Add the competition
                    await this.Repository.AddAsync(competition);
                    await this.Repository.SaveChangesAsync();
                },
                obj: this.Mapper.Map<Competition>(competitionDto),
                onSuccessFunc: (createdCompetition => this.Mapper.Map<CompetitionDTO>(createdCompetition)));
        }

        /// <summary>
        /// Update a competition
        /// </summary>
        /// <param name="competitionDto">Competition to update</param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException<Competition>"></exception>
        public async Task UpdateAsync(CompetitionDTO competitionDto)
        {
            await this.Repository.TransactionalExecutionAsync(
                action: async (competition, transaction) =>
                {
                    //Check if the competition already exists
                    var toUpdateCompetition = await this.Repository.GetByIdAsync(competition.Id);
                    if (toUpdateCompetition == null) throw new EntityNotFoundException<Competition>();

                    toUpdateCompetition.CopyFrom(competition);

                    //Save the competition
                    await this.Repository.SaveChangesAsync();
                },
                obj: this.Mapper.Map<Competition>(competitionDto));
        }

        #endregion
    }
}