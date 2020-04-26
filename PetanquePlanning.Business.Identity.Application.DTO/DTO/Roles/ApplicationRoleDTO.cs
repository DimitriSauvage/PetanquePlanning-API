using System;
using DimitriSauvageTools.Application.Abstractions;

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
        public Guid Id { get; set; }

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