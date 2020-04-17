using System;
using Microsoft.AspNetCore.Identity;
using PetanquePlanning.Business.Identity.Application.DTO.DTO.Roles;
using Tools.Domain.Abstractions;
using Tools.Domain.Extensions;
using Tools.Domain.Helpers;

namespace PetanquePlanning.Business.Identity.Application.DTO.DTO.Users
{
    public class ApplicationUserRoleDTO
    {
        #region Properties

        /// <inheritdoc />
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the primary key of the user that is linked to a role.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the user that is linked to a role.
        /// </summary>
        public virtual ApplicationUserDTO User { get; set; }

        /// <summary>
        /// Gets or sets the primary key of the role that is linked to the user.
        /// </summary>
        public virtual long RoleId { get; set; }

        /// <summary>
        /// Gets or sets the role that is linked to the user.
        /// </summary>
        public virtual ApplicationRoleDTO Role { get; set; }

        #endregion
    }
}