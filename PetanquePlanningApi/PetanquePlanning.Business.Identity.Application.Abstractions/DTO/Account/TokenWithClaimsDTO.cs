using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Newtonsoft.Json;

namespace PetanquePlanning.Business.Identity.Application.Abstractions.DTO.Account
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
        public IEnumerable<Claim> Claims { get; set; }

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

        public TokenWithClaimsDTO(string accessToken, IEnumerable<Claim> claimsPrincipal)
        {
            this.AccessToken = accessToken;
            this.Claims = claimsPrincipal;
        }

        #endregion
    }
}