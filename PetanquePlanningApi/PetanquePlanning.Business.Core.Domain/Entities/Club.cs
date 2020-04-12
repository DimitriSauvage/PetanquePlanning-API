using Tools.Domain.Abstractions;
using Tools.Domain.DataAnnotations;

namespace PetanquePlanning.Business.Core.Domain.Entities
{
    [UniqueBy(nameof(Name))]
    public class Club : EntityWithId
    {
        /// <summary>
        /// Address
        /// </summary>
        public Address Address { get; set; }

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
