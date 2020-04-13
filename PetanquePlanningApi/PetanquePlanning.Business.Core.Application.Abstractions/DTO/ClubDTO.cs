using Tools.Domain.Abstractions;
using Tools.Domain.DataAnnotations;

namespace PetanquePlanning.Business.Core.Domain.Entities
{
    public class ClubDTO
    {
        /// <summary>
        /// Address
        /// </summary>
        public AddressDTO Address { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Short name
        /// </summary>
        public string ShortName { get; set; }
    }
}
