using System.Collections.Generic;
using System.Threading.Tasks;
using DimitriSauvageTools.Mvc.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetanquePlanning.Business.Location.Application.DTO.DTO;
using PetanquePlanning.Business.Location.Application.Services;

namespace PetanquePlanning.Business.Location.Presentation.Controllers
{
    [Route("[controller]")]
    public class RegionsController : ApiController<RegionService>
    {
        #region Fields

        #endregion

        #region Constructor

        #endregion

        #region Methods

        /// <summary>
        /// Get the regions
        /// </summary>
        /// <param name="includeDepartments">Include the region departments</param>
        /// <returns>Regions</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DepartmentDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<RegionDTO>>> GetAsync(bool includeDepartments = false)
        {
            return this.Ok(await this.Service.GetAsync(includeDepartments));
        }

        #endregion
    }
}