﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DimitriSauvageTools.Mvc.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetanquePlanning.Business.Location.Application.DTO.DTO;
using PetanquePlanning.Business.Location.Application.Services;

namespace PetanquePlanning.Business.Location.Presentation.Controllers
{
    public class DepartmentsController : ApiController<DepartmentService>
    {
        #region Fields

        #endregion

        #region Constructor

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
            return this.Ok(await this.Service.GetAsync(withAdjacentDepartments, withRegion));
        }

        #endregion
    }
}