using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetanquePlanning.Business.Location.Application.Abstractions.Abstractions;
using PetanquePlanning.Business.Location.Application.Abstractions.DTO;
using Tools.Api.Abstractions;

namespace PetanquePlanning.Business.Location.Presentation.Controllers
{
    [Route("[controller]")]
    public class DepartmentController : ApiController
    {
        #region Fields

        public IDepartmentService DepartmentService { get; }

        #endregion

        #region Constructor

        public DepartmentController(IDepartmentService departmentService)
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