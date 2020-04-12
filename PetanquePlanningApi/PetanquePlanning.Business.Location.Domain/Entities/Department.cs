using System;
using System.Collections.Generic;
using System.Text;
using Tools.Domain.Abstractions;

namespace PetanquePlanning.Business.Location.Domain.Entities
{
    public class Department : EntityWithId, IEntityWithId
    {
        
        /// <summary>
        /// Adjacent departments
        /// </summary>
        public List<Department> AdjacentDepartments { get; set; } = new List<Department>();

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
        public Region Region { get; set; }

        /// <summary>
        /// Region code
        /// </summary>
        public string RegionCode { get; set; }
    }
}
