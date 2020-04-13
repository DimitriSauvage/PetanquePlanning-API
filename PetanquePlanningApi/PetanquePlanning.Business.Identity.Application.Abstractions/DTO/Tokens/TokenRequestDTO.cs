using System;
using System.Collections.Generic;
using System.Text;

namespace Abalone.Business.Identity.Application.DTO.Tokens
{
    public class TokenRequestDTO
    {
        /// <summary>
        /// Affecte ou obtient l'email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Affecte ou obtient le mot de passe
        /// </summary>
        public string Password { get; set; }
    }
}
