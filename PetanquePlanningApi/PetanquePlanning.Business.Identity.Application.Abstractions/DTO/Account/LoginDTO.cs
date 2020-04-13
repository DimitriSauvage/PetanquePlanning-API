﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace Abalone.Business.Identity.Application.DTO.Account
{
    public class LoginDTO
    {
        #region Properties
        /// <summary>
        /// Affecte ou obtient l'email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Affecte ou obtient le mot de passe
        /// </summary>
        public string Password { get; set; }
        #endregion
    }
}
