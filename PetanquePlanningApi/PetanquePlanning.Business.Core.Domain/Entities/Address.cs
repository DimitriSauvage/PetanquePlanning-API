using System;
using System.Collections.Generic;
using System.Text;
using Tools.GeoLocation.Domain.Entities;

namespace PetanquePlanning.Business.Core.Domain.Entities
{
    public class Address
    {
        /// <summary>
        /// House number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Zip code
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// GPS Coordinate
        /// </summary>
        public LatLng Coordinate { get; set; }

    }
}
