﻿using PetanquePlanning.Business.Core.Domain.Entities;

namespace PetanquePlanning.Business.Core.Application.Abstractions.DTO
{
    public class ClubDTO
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