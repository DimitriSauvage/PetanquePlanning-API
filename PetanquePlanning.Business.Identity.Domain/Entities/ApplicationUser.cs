using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PetanquePlanning.Business.Identity.Domain.Enumerations;
using Tools.Domain.Abstractions;
using Tools.Domain.Extensions;
using Tools.Domain.Helpers;

namespace PetanquePlanning.Business.Identity.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>, IEntityWithId, IComparable<ApplicationUser>,
        IEquatable<ApplicationUser>
    {
        #region Fields

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
        public Guid ClubId { get; set; }

        /// <summary>
        /// Favorite department codes
        /// </summary>
        public IEnumerable<ApplicationUserFavoriteDepartment> FavoriteDepartments { get; set; }

        /// <summary>
        /// User gender
        /// </summary>
        public GenderEnum Gender { get; set; }

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
        public IEnumerable<ApplicationUserRole> Roles { get; set; }


        /// <summary>
        /// If the user has to change his password
        /// </summary>
        public bool MustChangePassword { get; set; }

        /// <summary>
        /// Full name
        /// </summary>
        public string FullName => $"{this.LastName} {this.FirstName}";

        #endregion

        #region Methods

        /// <summary>
        /// Sert de fonction de hachage pour l'objet en cours.
        /// </summary>
        /// <returns>Code de hachage pour l'objet en cours.</returns>
        public override int GetHashCode()
        {
            return HashCodeHelper.GetHashCode(this.NormalizedEmail);
        }

        /// <summary>
        /// Détermine si l'objet spécifié est identique à l'objet actuel.
        /// </summary>
        /// <param name="obj">Objet à comparer avec l'objet actif. </param>
        /// <returns>true si l'objet spécifié est égal à l'objet actif ; sinon, false.</returns>
        public override bool Equals(object obj)
        {
            return GetHashCode().Equals(obj?.GetHashCode());
        }

        /// <summary>
        /// Compare l'objet en cours à un autre objet du même type.
        /// </summary>
        /// <param name="other">Objet à comparer avec cet objet.</param>
        /// <returns>Valeur qui indique l'ordre relatif des objets comparés.</returns>
        public virtual int CompareTo(ApplicationUser other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }

        /// <summary>
        /// Indique si l'objet actuel est égal à un autre objet du même type.
        /// </summary>
        /// <param name="other">Objet à comparer avec cet objet.</param>
        /// <returns>true si l'objet en cours est égal au paramètre other ; sinon, false.</returns>
        public virtual bool Equals(ApplicationUser other)
        {
            return Equals(other as object);
        }

        ///// <summary>
        ///// Recopie l'ensemble des propriétés simples (membres par valeur).
        ///// Ne recopie par les champs qui composent la clé unique ainsi que l'identifiant.
        ///// </summary>
        ///// <param name="other">objet à recopier</param>
        ///// <returns>Copie</returns>
        public void CopyFrom(IEntity other)
        {
            this.ShallowCopy(other);
        }

        /// <summary>
        /// Remplit les valeurs obligatories de l'utilisateur
        /// </summary>
        /// <param name="userManager">User manager to use to realize</param>
        /// <returns></returns>
        public async Task SetMandatoryValuesAsync(UserManager<ApplicationUser> userManager)
        {
            this.NormalizedEmail = this.Email?.ToUpper();
            this.LockoutEnabled = false;
            this.PhoneNumberConfirmed = false;
            this.TwoFactorEnabled = false;
            this.AccessFailedCount = 0;
            this.SecurityStamp = Guid.NewGuid().ToString();
            this.ConcurrencyStamp = await userManager.GenerateConcurrencyStampAsync(this);
            if (this.MustChangePassword)
                this.PasswordHash = userManager.PasswordHasher.HashPassword(this, this.PasswordHash);
        }

        #endregion
    }
}