using System.Collections.Generic;
using System.Threading.Tasks;
using Abalone.Business.Identity.Application.Abstractions.Abstractions;
using Abalone.Business.Identity.Application.DTO.Users;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetanquePlanning.Business.Identity.Application.Abstractionns.Abstractions;
using PetanquePlanning.Business.Identity.Domain.Entities;
using Tools.Api.Abstractions;

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

        private readonly IMapper mapper;
        private readonly IAccountService accountService = null;
        private readonly IApplicationUserService applicationUserService = null;
        private readonly IHostingEnvironment hostingEnvironment = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Contrôleur par défaut
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        /// <param name="configuration"></param>
        public ApplicationUserController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMapper mapper,
            IApplicationUserService applicationUserService,
            IAccountService accountService,
            IHostingEnvironment hostingEnvironment)
        {
            this.mapper = mapper;
            this.applicationUserService = applicationUserService;
            this.accountService = accountService;
            this.hostingEnvironment = hostingEnvironment;
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
            return this.Ok(await this.applicationUserService.GetAllAsync());
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
            return Ok(await this.applicationUserService.GetByIdAsync(id));
        }

        /// <summary>
        /// Récupérer l'utilisateur actuellement connecté
        /// </summary>
        /// <returns></returns>
        [HttpGet("logged")]
        [ProducesResponseType(typeof(ApplicationUserDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLogged()
        {
            var userId = await this.accountService.GetUserIdFromRequestAsync(this.HttpContext);
            return Ok(await this.applicationUserService.GetByIdAsync(userId));
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
            var newUser = await this.applicationUserService.CreateAsync(user, this.hostingEnvironment.WebRootPath);
            return Created($"{HttpContext.Request.Path}/{newUser.Id}", newUser);
        }

        /// <summary>
        /// Met à jour un utilisateur en base de données
        /// </summary>
        /// <param name="id">Identifiant de l'utilisateur</param>
        /// <param name="user">Utilisateur à mettre à jour</param>
        /// <param name="updateRights">Mettre à jour ou non les droits</param>
        /// <returns>AUcun retour</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApplicationUserDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] ApplicationUserDTO userDto)
        {
            ApplicationUserDTO applicationUserDTO =
                await this.applicationUserService.UpdateAsync(userDto, this.hostingEnvironment.WebRootPath);
            return Ok(applicationUserDTO);
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

            await this.applicationUserService.ReinitializePasswordAsync(id);
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
            await this.applicationUserService.DeleteAsync(userId);
            return this.NoContent();
        }
    }
}