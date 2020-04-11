using System;
using System.Collections.Generic;
using System.Text;

namespace PetanquePlanning.Business.Core.Domain.Entities.Geo
{
    class Departement
    {
        /// <summary>
        /// Code of adjacent departements
        /// </summary>
        public List<string> AdjacentDepartements { get; set; }

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
