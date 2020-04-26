using System;
using DimitriSauvageTools.Application.Abstractions;
using PetanquePlanning.Business.Identity.Application.DTO.DTO.Roles;

namespace PetanquePlanning.Business.Identity.Application.DTO.DTO.Users
{
    public class ApplicationUserRoleDTO : BaseDTO
    {
        #region Properties

        /// <inheritdoc />
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the primary key of the user that is linked to a role.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the user that is linked to a role.
        /// </summary>
        public virtual ApplicationUserDTO User { get; set; }

        /// <summary>
        /// Gets or sets the primary key of the role that is linked to the user.
        /// </summary>
        public virtual Guid RoleId { get; set; }

        /// <summary>
        /// Gets or sets the role that is linked to the user.
        /// </summary>
        public virtual ApplicationRoleDTO Role { get; set; }

        #endregion
    }
}