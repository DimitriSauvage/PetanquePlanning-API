using System;
using DimitriSauvageTools.Domain.Abstractions;

namespace PetanquePlanning.Business.Location.Domain.Entities
{
    public class AdjacentDepartments : EntityWithId
    {
        /// <summary>
        /// First adjacent department
        /// </summary>
        public Department FirstDepartment { get; set; }

        /// <summary>
        /// First department id
        /// </summary>
        public Guid FirstDepartmentId { get; set; }

        /// <summary>
        /// Second adjacent department
        /// </summary>
        public Department SecondDepartment { get; set; }

        /// <summary>
        /// Second department id
        /// </summary>
        public Guid SecondDepartmentId { get; set; }
    }
}