using System;
using System.Collections.Generic;
using System.Text;

namespace Abalone.Business.Identity.Application.DTO.Account
{
    public class ResetPasswordDTO
    {
        #region Properties
        /// <summary>
        /// Affecte ou obtient le code de confirmation qui a été envoyé à l'utilisateur par email
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Affecte ou obtient le nouveau mot de passe de l'utilisateur
        /// </summary>
        public string Password { get; set; }
        #endregion

        #region Constructors
        public ResetPasswordDTO()
        {

        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="code">Code de confirmation de réinitialisation de mot de passe</param>
        /// <param name="password">Nouveau mot de passe de l'utilisateur</param>
        public ResetPasswordDTO(string code, string password)
        {
            this.Code = code;
            this.Password = password;
        }
        #endregion

    }
}
