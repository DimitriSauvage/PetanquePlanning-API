using System;
using PetanquePlanning.Business.Core.Domain.Entities;
using Tools.Application.Abstractions;
using Tools.Application.DTOs;

namespace PetanquePlanning.Business.Core.Application.DTO.DTO
{
    public class ClubDTO : BaseDTO
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public Guid Id { get; set; }

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