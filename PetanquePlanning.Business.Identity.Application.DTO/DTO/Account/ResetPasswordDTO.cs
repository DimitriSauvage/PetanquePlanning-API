using DimitriSauvageTools.Application.Abstractions;

namespace PetanquePlanning.Business.Identity.Application.DTO.DTO.Account
{
    public class ResetPasswordDTO : BaseDTO
    {
        #region Properties

        /// <summary>
        /// Token code to reset the password
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// New user password
        /// </summary>
        public string Password { get; set; }

        #endregion
    }
}