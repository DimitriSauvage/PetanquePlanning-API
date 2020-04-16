using System.Collections.Generic;

namespace PetanquePlanning.Business.Location.Application.DTO.DTO
{
    public class DepartmentDTO
    {
        /// <summary>
        /// Adjacent departments
        /// </summary>
        public IEnumerable<DepartmentDTO> AdjacentDepartments { get; set; } = new List<DepartmentDTO>();

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