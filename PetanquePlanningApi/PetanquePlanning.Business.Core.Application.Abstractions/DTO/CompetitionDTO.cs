using System;
using PetanquePlanning.Business.Core.Domain.Entities;
using PetanquePlanning.Business.Core.Domain.Enumerations;
using Tools.Application.DTOs;

namespace PetanquePlanning.Business.Core.Application.Abstractions.DTO
{
    public class CompetitionDTO
    {
        /// <summary>
        /// Address of the competition
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Authorized gender
        /// </summary>
        public EnumDTO<CompetitionGenderEnum> CompetitionGender { get; set; }

        /// <summary>
        /// Competition level
        /// </summary>
        public EnumDTO<CompetitionLevelEnum> CompetitionLevel { get; set; }

        /// <summary>
        /// Sport (Petanque or provencal game)
        /// </summary>
        public EnumDTO<CompetitionSportEnum> CompetitionSport { get; set; }

        /// <summary>
        /// Competition type
        /// </summary>
        public EnumDTO<CompetitionTypeEnum> CompetitionType { get; set; }

        /// <summary>
        /// Date of the competition
        /// </summary>
        public DateTimeOffset Date { get; set; }

        /// <summary>
        /// Competition description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Name of the competition
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Organizer
        /// </summary>
        public ClubDTO Organizer { get; set; }

        /// <summary>
        /// Competition organizer identifier
        /// </summary>
        public string OrganizerId { get; set; }
    }
}