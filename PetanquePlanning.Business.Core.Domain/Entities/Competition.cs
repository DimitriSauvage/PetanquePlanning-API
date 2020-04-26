using System;
using DimitriSauvageTools.Domain.Abstractions;
using DimitriSauvageTools.Domain.DataAnnotations;
using PetanquePlanning.Business.Core.Domain.Enumerations;

namespace PetanquePlanning.Business.Core.Domain.Entities
{
    [UniqueBy(nameof(Organizer), nameof(OrganizerId), nameof(Date))]
    public class Competition : EntityWithId, IEntityWithId
    {
        /// <summary>
        /// Address of the competition
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Authorized gender
        /// </summary>
        public CompetitionGenderEnum CompetitionGender { get; set; }

        /// <summary>
        /// Competition level
        /// </summary>
        public CompetitionLevelEnum CompetitionLevel { get; set; }

        /// <summary>
        /// Sport (Petanque or provencal game)
        /// </summary>
        public CompetitionSportEnum CompetitionSport { get; set; }

        /// <summary>
        /// Competition type
        /// </summary>
        public CompetitionTypeEnum CompetitionType { get; set; }

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
        public Club Organizer { get; set; }

        /// <summary>
        /// Competition organizer identifier
        /// </summary>
        public string OrganizerId { get; set; }
    }
}