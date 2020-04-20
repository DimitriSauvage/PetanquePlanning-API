using Tools.Application.Abstractions;
using Tools.Application.DTOs;

namespace PetanquePlanning.Business.Identity.Application.DTO.DTO.Account
{
    public class LoginDTO : BaseDTO
    {
        #region Properties

        /// <summary>
        /// Login email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Login password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// If we keep the user authentication
        /// </summary>
        public bool RememberMe { get; set; }

        #endregion
    }
}