using System;
using System.Collections.Generic;
using System.Text;

namespace PetanquePlanning.Business.Location.Application.Abstractions.DTO
{
    public class DepartmentDTO
    {
        /// <summary>
        /// Adjacent departments
        /// </summary>
        public List<DepartmentDTO> AdjacentDepartments { get; set; } = new List<DepartmentDTO>();

        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Region
        /// </summary>
        public RegionDTO Region { get; set; }

        /// <summary>
        /// Region code
        /// </summary>
        public string RegionCode { get; set; }
    }
}
