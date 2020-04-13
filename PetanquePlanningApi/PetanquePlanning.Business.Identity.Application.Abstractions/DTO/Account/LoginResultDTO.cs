﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Abalone.Business.Identity.Application.Abstractions.DTO.Account
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
        public long UserId { get; set; }
        #endregion
    }
}
