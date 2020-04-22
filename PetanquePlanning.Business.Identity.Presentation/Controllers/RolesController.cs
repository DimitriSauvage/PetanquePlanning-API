using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetanquePlanning.Business.Identity.Application.DTO.DTO.Roles;
using PetanquePlanning.Business.Identity.Application.Services;
using Tools.Mvc.Abstractions;

namespace PetanquePlanning.Business.Identity.Presentation.Controllers
{
    [Route("[controller]")]
    public class
        RolesController : ApiController<ApplicationRoleService>
    {
        #region Private properties

        #endregion

        #region Constructors

        #endregion

        #region Methods

        /// <summary>
        /// Get roles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<ApplicationRoleDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await this.Service.GetAllAsync());
        }

        /// <summary>
        /// Create a new role
        /// </summary>
        /// <param name="roleDto">New role</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApplicationRoleDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateAsync([FromBody] ApplicationRoleDTO roleDto)
        {
            ApplicationRoleDTO result = await this.Service.CreateAsync(roleDto);
            return Created($"{HttpContext.Request.Path}/{result.Id}", result);
        }

        /// <summary>
        /// Deete a role
        /// </summary>
        /// <param name="roleId">Identifiant du rôle à supprimer</param>
        /// <param name="newRoleForUsers">Rôle de remplacement pour les utilisateurs</param>
        /// <returns></returns>
        [HttpDelete("{roleId}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid roleId,
            [FromBody] ApplicationRoleDTO newRoleForUsers)
        {
            await this.Service.DeleteAsync(roleId, newRoleForUsers);
            return this.NoContent();
        }

        /// <summary>
        /// Update a role
        /// </summary>
        /// <param name="roleDto">Objet modifié par l'utilisateur</param>
        /// <returns></returns>
        [HttpPut("{roleId}")]
        [ProducesResponseType(typeof(ApplicationRoleDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync([FromBody] ApplicationRoleDTO roleDto)
        {
            await Service.UpdateAsync(roleDto);
            return this.NoContent();
        }

        #endregion
    }
}