using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetanquePlanning.Business.Identity.Application.Abstractions.Abstractions;
using PetanquePlanning.Business.Identity.Application.Abstractions.DTO.Users;
using Tools.Mvc.Abstractions;

namespace PetanquePlanning.Business.Identity.Presentation.Controllers
{
    /// <summary>
    /// Controleur d'api chargé de la gestion des utilisateurs
    /// </summary>
    /// 
    [Route("users")]
    public class ApplicationUserController : ApiController
    {
        #region Private properties

        /// <summary>
        /// Account manager
        /// </summary>
        private IAccountService AccountService { get; }

        /// <summary>
        /// User manager
        /// </summary>
        private IApplicationUserService ApplicationUserService { get; }

        /// <summary>
        /// Environment information
        /// </summary>
        private IHostingEnvironment HostingEnvironment { get; }

        #endregion

        #region Constructors

        public ApplicationUserController(IApplicationUserService applicationUserService,
            IAccountService accountService,
            IHostingEnvironment hostingEnvironment)
        {
            this.ApplicationUserService = applicationUserService;
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
            return this.Ok(await this.ApplicationUserService.GetAllAsync());
        }


        /// <summary>
        /// Get a user by his id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(ApplicationUserDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(await this.ApplicationUserService.GetByIdAsync(id));
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
            return Ok(await this.ApplicationUserService.GetByIdAsync(userId));
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
            var newUser = await this.ApplicationUserService.CreateAsync(user, this.HostingEnvironment.WebRootPath);
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
                await this.ApplicationUserService.UpdateAsync(userDto, this.HostingEnvironment.WebRootPath);
            return Ok(applicationUserDto);
        }

        /// <summary>
        /// Reset the user password
        /// </summary>
        /// <param name="id">Identifier of the user for which reset the password</param>
        /// <returns></returns>
        [HttpPut("{id}/resetPassword")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ReinitializePassword(long id)
        {
            // var requestCultureFeature = this.HttpContext.Features.Get<IRequestCultureFeature>();
            // CultureInfo cultureInfo = requestCultureFeature.RequestCulture.Culture;

            await this.ApplicationUserService.ReinitializePasswordAsync(id);
            return NoContent();
        }


        /// <summary>
        /// Supprime un utilisateur
        /// </summary>
        /// <param name="userId">Id of the user to delete</param>
        /// <returns></returns>
        [HttpDelete("api/users/{userId}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync([FromRoute] long userId)
        {
            await this.ApplicationUserService.DeleteAsync(userId);
            return this.NoContent();
        }
    }
}