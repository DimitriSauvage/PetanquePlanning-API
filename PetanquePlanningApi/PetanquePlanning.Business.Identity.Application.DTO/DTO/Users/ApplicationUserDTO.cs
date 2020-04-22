using System;
using System.Collections.Generic;
using System.IO;
using PetanquePlanning.Business.Identity.Domain.Enumerations;
using Tools.Application.Abstractions;
using Tools.Application.DTOs;
using Tools.Helpers;

namespace PetanquePlanning.Business.Identity.Application.DTO.DTO.Users
{
    public class ApplicationUserDTO : BaseDTO
    {
        #region Properties

        /// <summary>
        /// Avatar
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// URL de l'image de l'avatar
        /// </summary>
        public string AvatarUrl
        {
            get
            {
                var result = string.Empty;
                if (this.Avatar.IsNotEmpty())
                {
                    result = Path.Combine("data", "users", this.Id.ToString().Trim().IsNotEmpty() ? this.NormalizedEmail : "temp", this.Avatar);
                }

                return result;
            }
        }

        /// <summary>
        /// Affecte ou obtient l'information si l'utilisateur doit obligatoirement changer son mot de passe
        /// </summary>
        public bool MustChangePassword { get; set; }

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
        public IEnumerable<ApplicationUserFavoriteDepartmentDTO> FavoriteDepartments { get; set; }

        /// <summary>
        /// User gender
        /// </summary>
        public EnumDTO<GenderEnum> Gender { get; set; } = new EnumDTO<GenderEnum>(GenderEnum.Unknown);

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Subscription date
        /// </summary>
        public DateTimeOffset SubscriptionDate { get; set; }

        /// <summary>
        /// User role
        /// </summary>
        public IEnumerable<ApplicationUserRoleDTO> Roles { get; set; }

        /// <summary>
        /// Affecte ou obtient l'id de l'utilisateur
        /// </summary>
        public Guid Id { get; set; }

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