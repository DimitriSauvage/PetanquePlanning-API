using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Abalone.Business.Identity.Application.DTO.Account
{
    /// <summary>
    /// Une instance de cette classe sera retournée après une authentification réussie de la part d'un utilisateur
    /// </summary>
    public class TokenWithClaimsDTO
    {
        #region Properties

        /// <summary>
        /// Affecte ou obtient le jeton d'authentification JWT
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// User claims
        /// </summary>
        public Dictionary<string, string> Claims { get; set; }

        /// <summary>
        /// Obtient un booléen qui indique que l'authentification s'est bien déroulée
        /// </summary>
        [JsonIgnore]
        public bool IsValid
        {
            get { return !string.IsNullOrEmpty(AccessToken) && (Claims != null && Claims.Any()); }
        }

        #endregion

        #region Constructors

        public TokenWithClaimsDTO()
        {
        }

        public TokenWithClaimsDTO(string accessToken, Dictionary<string, string> claimsPrincipal)
        {
            this.AccessToken = accessToken;
            this.Claims = claimsPrincipal;
        }

        #endregion
    }
}