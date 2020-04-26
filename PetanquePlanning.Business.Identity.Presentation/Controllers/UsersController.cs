using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DimitriSauvageTools.Mvc.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetanquePlanning.Business.Identity.Application.DTO.DTO.Users;
using PetanquePlanning.Business.Identity.Application.Services;

namespace PetanquePlanning.Business.Identity.Presentation.Controllers
{
    [Route("[controller]")]
    public class
        UsersController : ApiController<ApplicationUserService>
    {
        #region Private properties

        /// <summary>
        /// Account manager
        /// </summary>
        private AccountService AccountService { get; }

        /// <summary>
        /// Environment information
        /// </summary>
        private IHostingEnvironment HostingEnvironment { get; }

        #endregion

        #region Constructors

        public UsersController(AccountService accountService,
            IHostingEnvironment hostingEnvironment)
        {
            this.AccountService = accountService;
            this.HostingEnvironment = hostingEnvironment;
        }

        #endregion

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<ApplicationUserDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            return this.Ok(await this.Service.GetAllAsync());
        }


        /// <summary>
        /// Get a user by his id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApplicationUserDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await this.Service.GetByIdAsync(id));
        }

        /// <summary>
        /// Récupérer l'utilisateur actuellement connecté
        /// </summary>
        /// <returns></returns>
        [HttpGet("logged")]
        [ProducesResponseType(typeof(ApplicationUserDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLogged()
        {
            var userId = await this.AccountService.GetUserIdFromRequestAsync(this.HttpContext);
            return Ok(await this.Service.GetByIdAsync(userId));
        }

        /// <summary>
        /// Ajoute un utilisateur en base de données
        /// </summary>
        /// <param name="user">Utilisateur à ajouter</param>
        /// <returns>Utilisateur ajouté</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApplicationUserDTO), StatusCodes.Status201Created)]
        public async Task<IActionResult> Add([FromBody] ApplicationUserDTO user)
        {
            var newUser = await this.Service.CreateAsync(user, this.HostingEnvironment.WebRootPath);
            return Created($"{HttpContext.Request.Path}/{newUser.Id}", newUser);
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="userDto">User to update</param>
        /// <returns>Added user</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApplicationUserDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] ApplicationUserDTO userDto)
        {
            ApplicationUserDTO applicationUserDto =
                await this.Service.UpdateAsync(userDto, this.HostingEnvironment.WebRootPath);
            return Ok(applicationUserDto);
        }

        /// <summary>
        /// Reset the user password
        /// </summary>
        /// <param name="id">Identifier of the user for which reset the password</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [HttpPut("{id}/resetPassword")]
        public async Task<IActionResult> ReinitializePassword(Guid id)
        {
            // var requestCultureFeature = this.HttpContext.Features.Get<IRequestCultureFeature>();
            // CultureInfo cultureInfo = requestCultureFeature.RequestCulture.Culture;

            await this.Service.ReinitializePasswordAsync(id);
            return NoContent();
        }


        /// <summary>
        /// Supprime un utilisateur
        /// </summary>
        /// <param name="userId">Id of the user to delete</param>
        /// <returns></returns>
        [HttpDelete("api/users/{userId}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid userId)
        {
            await this.Service.DeleteAsync(userId);
            return this.NoContent();
        }
    }
}