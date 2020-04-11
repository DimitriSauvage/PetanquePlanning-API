using System;
using System.Collections.Generic;
using System.Text;
using Tools.Domain.Abstractions;

namespace PetanquePlanning.Business.Core.Domain.Entities
{
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
