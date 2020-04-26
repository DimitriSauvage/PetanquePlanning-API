using System.Collections.Generic;
using DimitriSauvageTools.Domain.Abstractions;

namespace PetanquePlanning.Business.Location.Domain.Entities
{
    public class Region : EntityWithId
    {
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Departments of the region
        /// </summary>
        public IEnumerable<Department> Departments { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
    }
}