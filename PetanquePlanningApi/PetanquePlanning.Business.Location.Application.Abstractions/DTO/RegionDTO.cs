using System.Collections.Generic;

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
        public IEnumerable<DepartmentDTO> Departments { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
    }
}