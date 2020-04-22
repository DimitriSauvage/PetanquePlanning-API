using System.Collections.Generic;
using Tools.Application.Abstractions;
using Tools.Application.DTOs;

namespace PetanquePlanning.Business.Location.Application.DTO.DTO
{
    public class RegionDTO : BaseDTO
    {
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Departments of the region
        /// </summary>
        public IEnumerable<DepartmentDTO> Departments { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
    }
}