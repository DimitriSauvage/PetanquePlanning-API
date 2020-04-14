using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetanquePlanning.Business.Core.Application.Abstractions.Abstractions;
using PetanquePlanning.Business.Core.Application.Abstractions.DTO;
using PetanquePlanning.Business.Core.Domain.Entities;
using Tools.Api.Abstractions;

namespace PetanquePlanning.Business.Core.Presentation.Controllers
{
    [Route("[controller]")]
    public class CompetitionController : ApiController
    {
        #region Fields

        private ICompetitionService CompetitionService { get; }

        #endregion

        #region Constructor

        public CompetitionController(ICompetitionService competitionService)
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
    }

    #endregion
}