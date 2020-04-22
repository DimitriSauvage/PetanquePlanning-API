using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetanquePlanning.Business.Core.Application.DTO.DTO;
using PetanquePlanning.Business.Core.Application.Services;
using Tools.Infrastructure.Exceptions;
using Tools.Mvc.Abstractions;

namespace PetanquePlanning.Business.Core.Presentation.Controllers
{
    [Route("[controller]")]
    public class ClubsController : ApiController<ClubService>
    {
        #region Fields

        #endregion

        #region Constructor

        #endregion

        #region Methods

        /// <summary>
        /// Get all competitions
        /// </summary>
        /// <returns>Competitions</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClubDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ClubDTO>>> GetAllAsync()
        {
            var clubs = await this.Service.GetAllAsync();
            return this.Ok(clubs);
        }

        /// <summary>
        /// Create a new club
        /// </summary>
        /// <param name="clubDto"></param>
        /// <returns>Created club</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ClubDTO), StatusCodes.Status201Created)]
        public async Task<ActionResult<ClubDTO>> CreateAsync([FromBody] ClubDTO clubDto)
        {
            var addedClub = await this.Service.CreateAsync(clubDto);
            return this.Created($"{HttpContext.Request.Path}/{addedClub.Id}", addedClub);
        }

        /// <summary>
        /// Update a club
        /// </summary>
        /// <param name="clubDto">Club to update</param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException{TEntity}<Club>"></exception>
        [HttpPut]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateAsync([FromBody] ClubDTO clubDto)
        {
            await this.Service.UpdateAsync(clubDto);
            return this.NoContent();
        }

        /// <summary>
        /// Get a club by his id
        /// </summary>
        /// <param name="id">Club id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClubDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<ClubDTO>> GetByIdAsync([FromRoute] Guid id)
        {
            var club = await this.Service.GetByIdAsync(id);
            return this.Ok(club);
        }

        #endregion
    }
}