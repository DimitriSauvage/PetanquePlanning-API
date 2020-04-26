using System;
using DimitriSauvageTools.Application.Abstractions;

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
        public Guid FirstDepartmentId { get; set; }

        /// <summary>
        /// Second adjacent department
        /// </summary>
        public DepartmentDTO SecondDepartment { get; set; }

        /// <summary>
        /// Second department id
        /// </summary>
        public Guid SecondDepartmentId { get; set; }
    }
}