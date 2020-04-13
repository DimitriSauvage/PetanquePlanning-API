namespace Abalone.Business.Identity.Application.DTO
{
    public class ApplicationRoleDTO
    {
        #region Properties

        /// <summary>
        /// Affecte ou obtient la description du role (profil)
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Affecte ou obtient l'identifiant
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Affecte ou obtient le nom du role
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Affecte ou obtient le nom normalisé du role
        /// </summary>
        public string NormalizedName { get; set; }

        #endregion
    }
}