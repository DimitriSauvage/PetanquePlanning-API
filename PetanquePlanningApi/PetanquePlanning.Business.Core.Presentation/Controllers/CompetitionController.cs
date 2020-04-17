using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetanquePlanning.Business.Core.Application.DTO.DTO;
using PetanquePlanning.Business.Core.Application.Services;
using Tools.Mvc.Abstractions;

namespace PetanquePlanning.Business.Core.Presentation.Controllers
{
    [Route("[controller]")]
    public class CompetitionController : ApiController
    {
        #region Fields

        /// <summary>
        /// Competition manager
        /// </summary>
        private CompetitionService CompetitionService { get; }

        #endregion

        #region Constructor

        public CompetitionController(CompetitionService competitionService)
        {
            this.CompetitionService = competitionService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get competitions
        /// </summary>
        /// <param name="startDate">Max start date of the competition</param>
        /// <param name="endDate">Max end date of the competition</param>
        /// <param name="departmentCodes">Departments codes where the competitions are located</param>
        /// <returns>Competitions</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CompetitionDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CompetitionDTO>>> GetAsync(
            [FromQuery] DateTimeOffset startDate,
            [FromQuery] DateTimeOffset endDate,
            [FromQuery] IEnumerable<string> departmentCodes)
        {
            IEnumerable<CompetitionDTO> result = null;
            if (startDate != default(DateTimeOffset) && endDate != default(DateTimeOffset))
            {
                result = await this.CompetitionService.GetAsync(startDate, endDate, departmentCodes);
            }
            else
            {
                result = await this.CompetitionService.GetAsync(departmentCodes);
            }

            return this.Ok(result);
        }


        /// <summary>
        /// Get a competition by his id
        /// </summary>
        /// <param name="id">Id to found</param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException{TEntity}<Competition>"></exception>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CompetitionDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<CompetitionDTO>> GetByIdAsync([FromRoute] long id)
        {
            var competition = await this.CompetitionService.GetByIdAsync(id);
            return this.Ok(competition);
        }

        /// <summary>
        /// Create a new competition
        /// </summary>
        /// <param name="competitionDto">Competition to crate</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="EntityAlreadyExistsException{TEntity}"<Competition>"></exception>
        [HttpPost]
        [ProducesResponseType(typeof(CompetitionDTO), StatusCodes.Status201Created)]
        public async Task<ActionResult<CompetitionDTO>> CreateAsync(CompetitionDTO competitionDto)
        {
            var addedCompetition = await this.CompetitionService.CreateAsync(competitionDto);
            return this.Created($"{HttpContext.Request.Path}/{addedCompetition.Id}", addedCompetition);
        }

        /// <summary>
        /// Update a competition
        /// </summary>
        /// <param name="competitionDto">Competition to update</param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException<Competition>"></exception>
        [HttpPut]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateAsync(CompetitionDTO competitionDto)
        {
            await this.CompetitionService.UpdateAsync(competitionDto);
            return this.NoContent();
        }

        #endregion
    }
}