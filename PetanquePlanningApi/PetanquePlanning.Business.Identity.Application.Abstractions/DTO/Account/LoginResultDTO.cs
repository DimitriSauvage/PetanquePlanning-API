using System;
using System.Collections.Generic;
using System.Text;
using Abalone.Business.Identity.Application.DTO.Users;

namespace PetanquePlanning.Business.Identity.Application.Abstractions.DTO.Account
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