using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PetanquePlanning.Business.Identity.Application.DTO.DTO.Account;
using PetanquePlanning.Business.Identity.Application.DTO.DTO.Users;
using PetanquePlanning.Business.Identity.Domain.Entities;
using PetanquePlanning.Business.Identity.Domain.Exceptions;
using Tools.Http.Enums;
using Tools.Http.Extensions;
using Tools.Infrastructure.Exceptions;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace PetanquePlanning.Business.Identity.Application.Services
{
    public class AccountService
    {
        #region Private attributes

        /// <summary>
        /// User manager
        /// </summary>
        private UserManager<ApplicationUser> UserManager { get; }

        /// <summary>
        /// Sign in manager
        /// </summary>
        private SignInManager<ApplicationUser> SignInManager { get; }

        /// <summary>
        /// Mapper
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        /// App conf
        /// </summary>
        private IConfiguration Configuration { get; }

        /// <summary>
        /// Role manager
        /// </summary>
        private ApplicationRoleService ApplicationRoleService { get; }

        #endregion

        #region Constructors

        public AccountService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMapper mapper,
            IConfiguration configuration,
            ApplicationRoleService applicationRoleService)
        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
            this.Mapper = mapper;
            this.Configuration = configuration;
            this.ApplicationRoleService = applicationRoleService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Connecte l'utilisateur si les informations saisies sont correctes
        /// </summary>
        /// <param name="model">Contient l'adresse email et le mot de passe saisi par l'utilisateur</param>
        /// <returns>Token de connexion</returns>
        public async Task<TokenWithClaimsDTO> LoginAsync(LoginDTO model)
        {
            var result = await this.SignInManager.PasswordSignInAsync(model.Email, model.Password,
                isPersistent: true, lockoutOnFailure: false);
            if (!result.Succeeded) throw new InvalidCredentialException();

            return await this.GetTokenWithClaimsPrincipal(model);
        }

        /// <summary>
        /// Obtient un utilisateur avec son email
        /// </summary>
        /// <param name="email">Email recherché</param>
        /// <returns>Utilisateur corresponsant à l'email</returns>
        public async Task<ApplicationUserDTO> FindByEmailAsync(string email)
        {
            var user = await this.UserManager.FindByEmailAsync(email);
            return this.Mapper.Map<ApplicationUserDTO>(user);
        }

        /// <summary>
        /// Reset the password for the user
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="code">Checking code</param>
        /// <param name="password">New password</param>
        public async Task ResetPasswordAsync(long userId, string code, string password)
        {
            //Get the user
            var user = await this.UserManager.FindByIdAsync(userId.ToString());
            if (user == null) throw new EntityNotFoundException<ApplicationUser>(userId);

            //Reset the password
            await this.UserManager.ResetPasswordAsync(user, code, password);
        }

        /// <summary>
        /// Check if the email is confirmed
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <returns>Is the email is confirmed</returns>
        public async Task<bool> IsEmailConfirmedAsync(long userId)
        {
            var user = await this.UserManager.FindByIdAsync(userId.ToString());
            if (user == null) throw new EntityNotFoundException<ApplicationUser>();
            return await this.UserManager.IsEmailConfirmedAsync(user);
        }

        /// <summary>
        /// Generate a new password for the user
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <returns></returns>
        public async Task<string> GeneratePasswordResetTokenAsync(long userId)
        {
            var user = await this.UserManager.FindByIdAsync(userId.ToString());
            if (user == null) throw new EntityNotFoundException<ApplicationUser>();
            return await this.UserManager.GeneratePasswordResetTokenAsync(user);
        }

        /// <summary>
        /// Ensure the token is valid
        /// </summary>
        /// <param name="token">Token to check</param>
        /// <returns>If the token is valid</returns>
        public bool EnsureTokenIsValid(string token)
        {
            return this.GetPrincipal(token) != null;
        }

        /// <summary>
        /// Get claims from token
        /// </summary>
        /// <param name="token">Token</param>
        /// <returns>Claims</returns>
        public ClaimsPrincipal GetPrincipal(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuer = this.Configuration["Security:Token:Issuer"],
                ValidAudience = this.Configuration["Security:Token:Audience"],
                IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Configuration["Security:Token:SecretKey"]))
            };

            var result = new JwtSecurityTokenHandler().ValidateToken(token, tokenValidationParameters,
                out _);

            return result;
        }

        /// <summary>
        /// Get the logged user name from the request
        /// </summary>
        /// <param name="httpContext">HTTP context</param>
        /// <param name="source">JWT source</param>
        /// <returns>User name</returns>
        public string GetLoggedUserNameFromRequest(HttpContext httpContext,
            JWTAuthorizeTokenSource source = JWTAuthorizeTokenSource.Header)
        {
            var token = httpContext.Request.GetJWTAuthorizeToken(source);
            if (string.IsNullOrEmpty(token))
                throw new NullReferenceException($"The token is null or empty");

            if (!EnsureTokenIsValid(token))
                throw new InvalidTokenException(token);

            var claims = GetPrincipal(token);
            return claims?.FindFirstValue(ClaimTypes.Name);
        }

        /// <summary>
        /// Get the user role id from the request
        /// </summary>
        /// <param name="httpContext">HTTP context</param>
        /// <param name="source">JWT source</param>
        /// <returns>Role id</returns>
        public async Task<long> GetRoleIdFromRequestAsync(HttpContext httpContext,
            JWTAuthorizeTokenSource source = JWTAuthorizeTokenSource.Header)
        {
            var token = httpContext.Request.GetJWTAuthorizeToken(source);
            if (string.IsNullOrEmpty(token))
                throw new NullReferenceException($"The token is null or empty");

            if (!EnsureTokenIsValid(token))
                throw new InvalidTokenException(token);

            var claims = GetPrincipal(token);
            var roleClaim = claims.FindFirst(claim => claim.Type == ClaimTypes.Role);
            return await this.ApplicationRoleService.GetRoleIdAsync(roleClaim?.Value);
        }

        /// <summary>
        /// Get the user id from the request
        /// </summary>
        /// <param name="httpContext">HTTP context</param>
        /// <param name="source">JWT source</param>
        /// <returns>User id</returns>
        public async Task<long> GetUserIdFromRequestAsync(HttpContext httpContext,
            JWTAuthorizeTokenSource source = JWTAuthorizeTokenSource.Header)
        {
            return await Task.Run(() =>
            {
                var token = httpContext.Request.GetJWTAuthorizeToken(source);
                if (string.IsNullOrEmpty(token))
                    throw new NullReferenceException($"The token is null or empty");

                if (!EnsureTokenIsValid(token))
                    throw new InvalidTokenException(token);

                var claims = GetPrincipal(token);
                var userIdClaim = claims.FindFirst(claim => claim.Type == ClaimTypes.Sid);
                return (long.TryParse(userIdClaim?.Value, out long x) ? x : 0);
            });
        }

        /// <summary>
        /// Créé le comte utilisateur
        /// </summary>
        /// <param name="userDto">User to create</param>
        /// <param name="password">User password</param>
        /// <returns>Errors</returns>
        public async Task<IdentityResult> CreateAccount(ApplicationUserDTO userDto, string password)
        {
            var user = this.Mapper.Map<ApplicationUser>(userDto);

            var result = await this.UserManager.CreateAsync(user, password);
            return result;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Génère un token JWT pour gérer les appels à l'API
        /// </summary>
        /// <param name="model">model utilisé pour la connexion</param>
        /// <returns></returns>
        private async Task<TokenWithClaimsDTO> GetTokenWithClaimsPrincipal(LoginDTO model)
        {
            var user = await this.UserManager.FindByEmailAsync(model.Email);

            if (user == null)
                throw new NullReferenceException($"No user was found for email {model.Email}");

            var result = await this.SignInManager.CheckPasswordSignInAsync
                (user, model.Password, lockoutOnFailure: false);

            if (!result.Succeeded)
                throw new UnauthorizedAccessException();

            var roles = await this.UserManager.GetRolesAsync(user);

            var claims = new[]
            {
                // Sub (subject) : https://tools.ietf.org/html/rfc7519#section-4.1.2
                new Claim(JwtRegisteredClaimNames.Sub, model.Email),
                // Jti (JWT Id) : https://tools.ietf.org/html/rfc7519#section-4.1.7
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Role, string.Join(", ", roles)),
            };

            var token = new JwtSecurityToken
            (
                issuer: this.Configuration["Security:Token:Issuer"],
                audience: this.Configuration["Security:Token:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(60),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(this.Configuration["Security:Token:SecretKey"])),
                    SecurityAlgorithms.HmacSha256)
            );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            return new TokenWithClaimsDTO(accessToken, claims);
        }

        #endregion
    }
}