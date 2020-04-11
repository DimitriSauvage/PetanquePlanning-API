using System;
using System.Collections.Generic;
using System.Text;

namespace PetanquePlanning.Business.Core.Domain.Entities.Geo
{
    class Region
    {
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Department codes
        /// </summary>
        public List<string> DepartmentCodes { get; set; }

        /// <summary>
        /// Departments of the region
        /// </summary>
        public List<Departement> Departments { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
    }
}
