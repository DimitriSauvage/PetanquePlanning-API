using PetanquePlanning.Business.Identity.Application.DTO.DTO.Users;

namespace PetanquePlanning.Business.Identity.Application.DTO.DTO.Account
{
    public class LoginResultDTO
    {
        #region Properties

        /// <summary>
        /// Error message
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Logged user
        /// </summary>
        public ApplicationUserDTO User { get; set; }

        #endregion
    }
}