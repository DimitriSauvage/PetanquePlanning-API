using System.Text;
using Tools.Domain.Abstractions;
using Tools.GeoLocation.Domain.Entities;

namespace PetanquePlanning.Business.Core.Domain.Entities
{
    public class Address : ValueObject
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


        /// <summary>
        /// Get the full address
        /// </summary>
        public string FullAddress
        {
            get
            {
                var fullAddress = new StringBuilder();

                //Add each field in the address
                AddToAddress(this.Number);
                AddToAddress(this.Street);
                AddToAddress(this.ZipCode);
                AddToAddress(this.City);
                return fullAddress.ToString();

                //Add the value to the address
                void AddToAddress(string valueToAdd)
                {
                    if (valueToAdd == null) return;
                    if (fullAddress.Length != 0) fullAddress.Append(" ");
                    fullAddress.Append(valueToAdd);
                }
            }
        }
    }
}