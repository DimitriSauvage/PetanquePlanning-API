using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetanquePlanning.Business.Location.Application.Abstractions.Abstractions;
using PetanquePlanning.Business.Location.Application.Abstractions.DTO;
using Tools.Mvc.Abstractions;

namespace PetanquePlanning.Business.Location.Presentation.Controllers
{
    [Route("[controller]")]
    public class RegionController : ApiController
    {
        #region Fields

        public IRegionService RegionService { get; }

        #endregion

        #region Constructor

        public RegionController(IRegionService regionService)
        {
            this.RegionService = regionService;
        }

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
            return this.Ok(await this.RegionService.GetAsync(includeDepartments));
        }

        #endregion
    }
}