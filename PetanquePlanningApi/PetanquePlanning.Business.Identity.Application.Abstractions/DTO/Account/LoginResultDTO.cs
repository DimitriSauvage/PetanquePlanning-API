using System;
using System.Collections.Generic;
using System.Text;
using Abalone.Business.Identity.Application.DTO.Users;

namespace PetanquePlanning.Business.Identity.Application.Abstractionns.DTO.Account
{
    public class LoginResultDTO
    {
        #region Properties

        /// <summary>
        /// Message d'erreur
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur
        /// </summary>
        public ApplicationUserDTO User { get; set; }

        #endregion
    }
}