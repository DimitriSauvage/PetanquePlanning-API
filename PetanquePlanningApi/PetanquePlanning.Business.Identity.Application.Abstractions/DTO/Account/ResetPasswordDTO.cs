using System;
using System.Collections.Generic;
using System.Text;

namespace PetanquePlanning.Business.Identity.Application.Abstractions.DTO.Account
{
    public class ResetPasswordDTO
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