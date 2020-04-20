using Tools.Application.Abstractions;
using Tools.Application.DTOs;

namespace PetanquePlanning.Business.Location.Application.DTO.DTO
{
    public class AdjacentDepartmentsDTO : BaseDTO
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