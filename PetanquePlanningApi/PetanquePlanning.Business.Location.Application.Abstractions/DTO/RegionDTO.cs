using System;
using System.Collections.Generic;
using System.Text;

namespace PetanquePlanning.Business.Location.Application.Abstractions.DTO
{
    public class RegionDTO
    {
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Departments of the region
        /// </summary>
        public List<DepartmentDTO> Departments { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
    }
}
