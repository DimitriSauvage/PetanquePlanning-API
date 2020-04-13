using System;
using System.Collections.Generic;
using Abalone.Business.Identity.Domain.Enums;
using PetanquePlanning.Business.Identity.Domain.Entities;
using PetanquePlanning.Business.Identity.Domain.Enumerations;
using Tools.Application.DTOs;

namespace Abalone.Business.Identity.Application.DTO.Users
{
    public class ApplicationUserDTO
    {
        #region Properties

        /// <summary>
        /// Avatar
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// Birth date
        /// </summary>
        public DateTimeOffset BirthDate { get; set; }

        /// <summary>
        /// Club identifier
        /// </summary>
        public long ClubId { get; set; }

        /// <summary>
        /// Favorite department codes
        /// </summary>
        public List<string> FavoriteDepartmentCodes { get; } = new List<string>();

        /// <summary>
        /// User gender
        /// </summary>
        public EnumDTO<GenderEnum> Gender { get; set; } = new EnumDTO<GenderEnum>(GenderEnum.Unknow);

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Profile
        /// </summary>
        public EnumDTO<ProfileEnum> Profile { get; set; } = new EnumDTO<ProfileEnum>(ProfileEnum.Player);

        /// <summary>
        /// Subscription date
        /// </summary>
        public DateTimeOffset SubscriptionDate { get; set; }

        /// <summary>
        /// User role
        /// </summary>
        public ApplicationRole ApplicationRole { get; set; }

        /// <summary>
        /// Id of the application role
        /// </summary>
        public long ApplicationRoleId { get; set; }


        /// <summary>
        /// Affecte ou obtient l'id de l'utilisateur
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Affecte ou obtient le hash du mot de passe
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Affecte ou obtient le nom d'utilisateur
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Affecte ou obtient l'email de l'utilisateur
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Affecte ou obtient l'email normalisé de l'utilisateur
        /// </summary>
        public string NormalizedEmail { get; set; }

        /// <summary>
        /// Affecte ou obtient le numéro de téléphone de l'utilisateur
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Affecte ou obtient si le numéro de téléphone a été validé
        /// </summary>
        public bool PhoneNumberConfirmed { get; set; } = false;

        #endregion

        #region Constructors

        #endregion
    }
}