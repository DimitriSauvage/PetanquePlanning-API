using PetanquePlanning.Business.Location.Application.DTO.DTO;

namespace PetanquePlanning.Business.Location.Domain.Entities
{
    public class AdjacentDepartmentsDTO
    {
        /// <summary>
        /// First adjacent department
        /// </summary>
        public DepartmentDTO FirstDepartment { get; set; }


        /// <summary>
        /// First department id
        /// </summary>
        public long FirstDepartmentId { get; set; }

        /// <summary>
        /// Second adjacent department
        /// </summary>
        public DepartmentDTO SecondDepartment { get; set; }

        /// <summary>
        /// Second department id
        /// </summary>
        public long SecondDepartmentId { get; set; }
    }
}