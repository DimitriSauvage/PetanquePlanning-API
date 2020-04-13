using System;
using System.Collections.Generic;
using Abalone.Business.Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Tools.Domain.Abstractions;
using Tools.Domain.Extensions;
using Tools.Domain.Helpers;

namespace PetanquePlanning.Business.Identity.Domain.Entities
{
    public class ApplicationRole : IdentityRole<long>, IEntityWithId, IEquatable<ApplicationRole>,
        IComparable<ApplicationRole>
    {
        #region Properties

        /// <summary>
        /// Affecte ou obtient la description du role (profil)
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Affecte ou obtient la liste des utilisateurs rattachés à ce rôle
        /// </summary>
        public ICollection<ApplicationUserRole> Users { get; set; } = new HashSet<ApplicationUserRole>();

        /// <summary>
        /// Affecte ou obtient les revendications rattachées au rôle
        /// </summary>
        public ICollection<ApplicationRoleClaim> Claims { get; set; } = new HashSet<ApplicationRoleClaim>();

        #endregion

        #region Constructors

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public ApplicationRole()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// recopie l'ensemble des propriétés simples (membres par valeur).
        /// ne recopie par les champs qui composent la clé unique ainsi que l'identifiant.
        /// </summary>
        /// <param name="other">objet à recopier</param>
        /// <returns>copie</returns>
        public virtual void CopyFrom(IEntity other)
        {
            this.ShallowCopy(other);
        }

        #endregion

        #region Méthodes gérant les égalités et les comparaisons entre les objets

        /// <summary>
        /// Sert de fonction de hachage pour l'objet en cours.
        /// </summary>
        /// <returns>Code de hachage pour l'objet en cours.</returns>
        public override int GetHashCode()
        {
            return HashCodeHelper.GetHashCode(this.NormalizedName);
        }

        /// <summary>
        /// Détermine si l'objet spécifié est identique à l'objet actuel.
        /// </summary>
        /// <param name="obj">Objet à comparer avec l'objet actif. </param>
        /// <returns>true si l'objet spécifié est égal à l'objet actif ; sinon, false.</returns>
        public override bool Equals(object obj)
        {
            return this.GetHashCode().Equals(obj.GetHashCode());
        }

        /// <summary>
        /// Compare l'objet en cours à un autre objet du même type.
        /// </summary>
        /// <param name="other">Objet à comparer avec cet objet.</param>
        /// <returns>Valeur qui indique l'ordre relatif des objets comparés.</returns>
        public virtual int CompareTo(ApplicationRole other)
        {
            return this.GetHashCode().CompareTo(other.GetHashCode());
        }

        /// <summary>
        /// Indique si l'objet actuel est égal à un autre objet du même type.
        /// </summary>
        /// <param name="other">Objet à comparer avec cet objet.</param>
        /// <returns>true si l'objet en cours est égal au paramètre other ; sinon, false.</returns>
        public virtual bool Equals(ApplicationRole other)
        {
            return this.Equals(other as object);
        }

        #endregion
    }
}