using System;
using PetanquePlanning.Business.Location.Domain.Entities;
using Tools.Domain.Abstractions;

namespace PetanquePlanning.Business.Identity.Domain.Entities
{
    public class ApplicationUserFavoriteDepartment : EntityWithId
    {
        /// <summary>
        /// Associated department
        /// </summary>
        public Department Department { get; set; }

        /// <summary>
        /// Associated department id
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Associated user
        /// </summary>
        public ApplicationUser User { get; set; }

        /// <summary>
        /// Associated user id
        /// </summary>
        public Guid UserId { get; set; }
    }
}