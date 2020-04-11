using Microsoft.AspNetCore.Identity;
using PetanquePlanning.Business.Identity.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;
using Tools.Domain.Abstractions;
using Tools.Domain.Extensions;
using Tools.Domain.Helpers;

namespace PetanquePlanning.Business.Identity.Domain.Entities
{
    public class User : IdentityUser<long>, IEntityWithId, IComparable<User>, IEquatable<User>, IEntity
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
        public long ClubId { get; set; }

        /// <summary>
        /// Favorite department codes
        /// </summary>
        public List<string> FavoriteDepartmentCodes { get; } = new List<string>();

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Profile
        /// </summary>
        public ProfileEnum Profile { get; set; }

        /// <summary>
        /// Subscription date
        /// </summary>
        public DateTimeOffset SubscriptionDate { get; set; }
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
            return GetHashCode().Equals(obj.GetHashCode());
        }

        /// <summary>
        /// Compare l'objet en cours à un autre objet du même type.
        /// </summary>
        /// <param name="other">Objet à comparer avec cet objet.</param>
        /// <returns>Valeur qui indique l'ordre relatif des objets comparés.</returns>
        public virtual int CompareTo(User other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }

        /// <summary>
        /// Indique si l'objet actuel est égal à un autre objet du même type.
        /// </summary>
        /// <param name="other">Objet à comparer avec cet objet.</param>
        /// <returns>true si l'objet en cours est égal au paramètre other ; sinon, false.</returns>
        public virtual bool Equals(User other)
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
        #endregion
    }
}
