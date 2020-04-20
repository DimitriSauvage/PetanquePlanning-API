using PetanquePlanning.Business.Location.Application.DTO.DTO;
using Tools.Application.Abstractions;
using Tools.Application.DTOs;

namespace PetanquePlanning.Business.Identity.Application.DTO.DTO.Users
{
    public class ApplicationUserFavoriteDepartmentDTO : BaseDTO
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Associated department
        /// </summary>
        public DepartmentDTO Department { get; set; }

        /// <summary>
        /// Associated department id
        /// </summary>
        public long DepartmentId { get; set; }

        /// <summary>
        /// Associated user
        /// </summary>
        public ApplicationUserDTO User { get; set; }

        /// <summary>
        /// Associated user id
        /// </summary>
        public long UserId { get; set; }
    }
}