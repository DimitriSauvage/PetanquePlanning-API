using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetanquePlanning.Business.Identity.Application.Abstractions.Abstractions;
using PetanquePlanning.Business.Identity.Application.Abstractions.DTO.Account;
using PetanquePlanning.Business.Identity.Application.Abstractions.DTO.Users;
using PetanquePlanning.Business.Identity.Domain.Entities;
using Tools.Mvc.Abstractions;

namespace PetanquePlanning.Business.Identity.Presentation.Controllers
{
    /// <summary>
    /// Classe d'API chargée de gérer l'authentification d'un l'utilisateur
    /// </summary>
    /// <see>
    ///     <cref>https://digitalcontrol.me/blog/indentity-asp-net-core-2/</cref>
    /// </see>
    [Route("accounts")]
    public class AccountController : ApiController
    {
        #region Private properties

        /// <summary>
        /// Sign in manager
        /// </summary>
        private SignInManager<ApplicationUser> SignInManager { get; }

        /// <summary>
        /// Mapper
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        /// Account manager
        /// </summary>
        private IAccountService AccountService { get; }

        /// <summary>
        /// App user manager
        /// </summary>
        private IApplicationUserService ApplicationUserService { get; }


        /// <summary>
        /// Environment information
        /// </summary>
        private IHostingEnvironment HostingEnvironment { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public AccountController(SignInManager<ApplicationUser> signInManager,
            IAccountService accountService,
            IMapper mapper,
            IApplicationUserService applicationUserService,
            IHostingEnvironment hostingEnvironment)
        {
            this.SignInManager = signInManager;
            this.AccountService = accountService;
            this.Mapper = mapper;
            this.ApplicationUserService = applicationUserService;
            this.HostingEnvironment = hostingEnvironment;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Try to authenticate a user
        /// </summary>
        /// <param name="loginDto">Login information</param>
        /// <returns>Login result</returns>
        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(LoginResultDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<LoginResultDTO>> Login([FromBody] LoginDTO loginDto)
        {
            LoginResultDTO result = new LoginResultDTO();
            try
            {
                //On tente de s'authentifier
                var tokenWithClaimsPrincipal = await this.AccountService.LoginAsync(loginDto);

                //Si authentifier alors on enregistre les informationq dans les cookies
                if (tokenWithClaimsPrincipal != null && tokenWithClaimsPrincipal.IsValid)
                {
                    AuthenticationProperties authProperties = new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                        IsPersistent = loginDto.RememberMe,
                        ExpiresUtc = DateTime.UtcNow.AddDays(1)
                    };

                    var claims = tokenWithClaimsPrincipal.Claims.ToList();
                    claims.Add(new Claim("AccessToken", $"Bearer {tokenWithClaimsPrincipal.AccessToken}"));

                    Response.Cookies.Append("Authorization", tokenWithClaimsPrincipal.AccessToken);
                    await HttpContext.SignInAsync(
                        new ClaimsPrincipal(new ClaimsIdentity(claims,
                            CookieAuthenticationDefaults.AuthenticationScheme)), authProperties);

                    result.User = await this.ApplicationUserService.GetByEmailAsync(loginDto.Email);
                }
            }
            catch (Exception)
            {
                result.Error = "Login failed due to incorrect credentials";
            }


            return Ok(result);
        }

        /// <summary>
        /// Add a new user
        /// </summary>
        /// <param name="userDto">User to add</param>
        /// <returns></returns>
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] ApplicationUserDTO userDto)
        {
            var addedUserDto = await this.ApplicationUserService.CreateAsync(
                userDto,
                this.HostingEnvironment.WebRootPath);

            await this.SignInManager.SignInAsync(this.Mapper.Map<ApplicationUser>(addedUserDto), isPersistent: false);
            return Ok(addedUserDto);
        }

        #endregion
    }
}