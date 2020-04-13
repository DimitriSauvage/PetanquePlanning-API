using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Abalone.Business.Identity.Application.Abstractions.Abstractions;
using Abalone.Business.Identity.Application.DTO.Account;
using Abalone.Business.Identity.Application.DTO.Users;
using AutoMapper;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PetanquePlanning.Business.Identity.Application.Abstractionns.Abstractions;
using PetanquePlanning.Business.Identity.Domain.Entities;
using PetanquePlanning.Business.Identity.Domain.Exceptions;
using Tools.Http.Enums;
using Tools.Http.Extensions;
using Tools.Infrastructure.Exceptions;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace PetanquePlanning.Business.Identity.Application.Services
{
    public class AccountService : IAccountService
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
        private IApplicationRoleService ApplicationRoleService { get; }

        #endregion

        #region Constructors

        public AccountService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMapper mapper,
            IConfiguration configuration,
            IApplicationRoleService applicationRoleService)
        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
            this.Mapper = mapper;
            this.Configuration = configuration;
            this.ApplicationRoleService = applicationRoleService;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<TokenWithClaimsDTO> LoginAsync(LoginDTO model)
        {
            var result = await this.SignInManager.PasswordSignInAsync(model.Email, model.Password,
                isPersistent: true, lockoutOnFailure: false);
            return await this.GetTokenWithClaimsPrincipal(model);
        }

        /// <inheritdoc />
        public async Task<ApplicationUserDTO> FindByEmailAsync(string email)
        {
            var user = await this.UserManager.FindByEmailAsync(email);
            return this.Mapper.Map<ApplicationUserDTO>(user);
        }

        /// <inheritdoc />
        public async Task ResetPasswordAsync(long userId, string code, string password)
        {
            //Get the user
            var user = await this.UserManager.FindByIdAsync(userId.ToString());
            if (user == null) throw new EntityNotFoundException<ApplicationUser>(userId);

            //Reset the password
            await this.UserManager.ResetPasswordAsync(user, code, password);
        }

        /// <inheritdoc />
        public async Task<bool> IsEmailConfirmedAsync(long userId)
        {
            var user = await this.UserManager.FindByIdAsync(userId.ToString());
            if (user == null) throw new EntityNotFoundException<ApplicationUser>();
            return await this.UserManager.IsEmailConfirmedAsync(user);
        }

        /// <inheritdoc />
        public async Task<string> GeneratePasswordResetTokenAsync(long userId)
        {
            var user = await this.UserManager.FindByIdAsync(userId.ToString());
            if (user == null) throw new EntityNotFoundException<ApplicationUser>();
            return await this.UserManager.GeneratePasswordResetTokenAsync(user);
        }

        /// <inheritdoc />
        public bool EnsureTokenIsValid(string token)
        {
            return this.GetPrincipal(token) != null;
        }

        /// <inheritdoc />
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
                out SecurityToken securityToken);

            return result;
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
        public async Task<long> GetUserIdFromRequestAsync(HttpContext httpContext,
            JWTAuthorizeTokenSource source = JWTAuthorizeTokenSource.Header)
        {
            var token = httpContext.Request.GetJWTAuthorizeToken(source);
            if (string.IsNullOrEmpty(token))
                throw new NullReferenceException($"The token is null or empty");

            if (!EnsureTokenIsValid(token))
                throw new InvalidTokenException(token);

            var claims = GetPrincipal(token);
            var userIdClaim = claims.FindFirst(claim => claim.Type == ClaimTypes.Sid);
            return (long.TryParse(userIdClaim?.Value, out long x) ? x : 0);
        }

        /// <inheritdoc />
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
            return new TokenWithClaimsDTO(accessToken, claims.ToDictionary(k => k.Type, v => v.Value));
        }

        #endregion
    }
}