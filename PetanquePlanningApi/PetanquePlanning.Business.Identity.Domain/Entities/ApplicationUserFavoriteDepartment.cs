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
        public long DepartmentId { get; set; }

        /// <summary>
        /// Associated user
        /// </summary>
        public ApplicationUser User { get; set; }

        /// <summary>
        /// Associated user id
        /// </summary>
        public long UserId { get; set; }
    }
}