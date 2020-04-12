using System;
using System.Collections.Generic;
using System.Text;
using Tools.Domain.Abstractions;

namespace PetanquePlanning.Business.Location.Domain.Entities
{
    public class Region : EntityWithId, IEntityWithId
    {
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Departments of the region
        /// </summary>
        public List<Department> Departments { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
    }
}
