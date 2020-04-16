namespace PetanquePlanning.Business.Identity.Application.Abstractions.DTO.Account
{
    public class LoginDTO
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