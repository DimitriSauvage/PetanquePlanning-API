using System.Collections.Generic;
using PetanquePlanning.Business.Location.Domain.Entities;

namespace PetanquePlanning.Business.Location.Application.DTO.DTO
{
    public class DepartmentDTO
    {
        /// <summary>
        /// Adjacent departments
        /// </summary>
        public IEnumerable<AdjacentDepartmentsDTO> AdjacentDepartments { get; set; }

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
        public long RegionId { get; set; }
    }
}