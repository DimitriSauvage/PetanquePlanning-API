using System.Security.Claims;
using System.Threading.Tasks;
using Abalone.Business.Identity.Application.DTO.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PetanquePlanning.Business.Identity.Application.Abstractions.DTO.Account;
using Tools.Http.Enums;

namespace PetanquePlanning.Business.Identity.Application.Abstractions.Abstractions
{
    public interface IAccountService
    {
        /// <summary>
        /// Connecte l'utilisateur si les informations saisies sont correctes
        /// </summary>
        /// <param name="model">Contient l'adresse email et le mot de passe saisi par l'utilisateur</param>
        /// <returns>Token de connexion</returns>
        Task<TokenWithClaimsDTO> LoginAsync(LoginDTO model);

        /// <summary>
        /// Obtient un utilisateur avec son email
        /// </summary>
        /// <param name="email">Email recherché</param>
        /// <returns>Utilisateur corresponsant à l'email</returns>
        Task<ApplicationUserDTO> FindByEmailAsync(string email);

        /// <summary>
        /// Reset the password for the user
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="code">Checking code</param>
        /// <param name="password">New password</param>
        Task ResetPasswordAsync(long userId, string code, string password);

        /// <summary>
        /// Check if the email is confirmed
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <returns>Is the email is confirmed</returns>
        Task<bool> IsEmailConfirmedAsync(long userId);

        /// <summary>
        /// Generate a new password for the user
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <returns></returns>
        Task<string> GeneratePasswordResetTokenAsync(long userId);

        /// <summary>
        /// Ensure the token is valid
        /// </summary>
        /// <param name="token">Token to check</param>
        /// <returns>If the token is valid</returns>
        bool EnsureTokenIsValid(string token);

        /// <summary>
        /// Get claims from token
        /// </summary>
        /// <param name="token">Token</param>
        /// <returns>Claims</returns>
        ClaimsPrincipal GetPrincipal(string token);

        /// <summary>
        /// Get the logged user name from the request
        /// </summary>
        /// <param name="httpContext">HTTP context</param>
        /// <param name="source">JWT source</param>
        /// <returns>User name</returns>
        string GetLoggedUserNameFromRequest(HttpContext httpContext,
            JWTAuthorizeTokenSource source = JWTAuthorizeTokenSource.Header);

        /// <summary>
        /// Get the user role id from the request
        /// </summary>
        /// <param name="httpContext">HTTP context</param>
        /// <param name="source">JWT source</param>
        /// <returns>Role id</returns>
        Task<long> GetRoleIdFromRequestAsync(HttpContext httpContext,
            JWTAuthorizeTokenSource source = JWTAuthorizeTokenSource.Header);

        /// <summary>
        /// Get the user id from the request
        /// </summary>
        /// <param name="httpContext">HTTP context</param>
        /// <param name="source">JWT source</param>
        /// <returns>User id</returns>
        Task<long> GetUserIdFromRequestAsync(HttpContext httpContext,
            JWTAuthorizeTokenSource source = JWTAuthorizeTokenSource.Header);

        /// <summary>
        /// Créé le comte utilisateur
        /// </summary>
        /// <param name="userDto">User to create</param>
        /// <param name="password">User password</param>
        /// <returns>Errors</returns>
        Task<IdentityResult>
            CreateAccount(ApplicationUserDTO userDto, string password);
    }
}