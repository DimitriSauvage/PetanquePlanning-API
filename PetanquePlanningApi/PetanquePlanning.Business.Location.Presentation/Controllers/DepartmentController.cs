using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetanquePlanning.Business.Location.Application.DTO.DTO;
using PetanquePlanning.Business.Location.Application.Services;
using Tools.Mvc.Abstractions;

namespace PetanquePlanning.Business.Location.Presentation.Controllers
{
    [Route("[controller]")]
    public class DepartmentController : ApiController
    {
        #region Fields

        private DepartmentService DepartmentService { get; }

        #endregion

        #region Constructor

        public DepartmentController(DepartmentService departmentService)
        {
            this.DepartmentService = departmentService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get the departments
        /// </summary>
        /// <param name="withAdjacentDepartments">Include adjacent departments</param>
        /// <param name="withRegion">Include department region</param>
        /// <returns>Departments</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DepartmentDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DepartmentDTO>>> GetAsync(
            [FromQuery] bool withAdjacentDepartments = false,
            [FromQuery] bool withRegion = false)
        {
            return this.Ok(await this.DepartmentService.GetAsync(withAdjacentDepartments, withRegion));
        }

        #endregion
    }
}