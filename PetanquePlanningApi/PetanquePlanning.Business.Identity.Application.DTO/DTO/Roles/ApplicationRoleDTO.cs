using Tools.Application.Abstractions;
using Tools.Application.DTOs;

namespace PetanquePlanning.Business.Identity.Application.DTO.DTO.Roles
{
    public class ApplicationRoleDTO : BaseDTO
    {
        #region Properties

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Identifier
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Normalized name
        /// </summary>
        public string NormalizedName { get; set; }

        #endregion
    }
}