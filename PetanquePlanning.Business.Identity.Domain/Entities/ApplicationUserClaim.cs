﻿using System;
using DimitriSauvageTools.Domain.Abstractions;
using DimitriSauvageTools.Domain.Extensions;
using DimitriSauvageTools.Domain.Helpers;
using Microsoft.AspNetCore.Identity;

namespace PetanquePlanning.Business.Identity.Domain.Entities
{
    public class ApplicationUserClaim : IdentityUserClaim<Guid>, IEntityWithId<int>, IComparable<ApplicationUserClaim>,
        IEquatable<ApplicationUserClaim>
    {
        #region Properties

        /// <summary>
        /// Affecte ou obtient si le rôle dispose des droit de lecture sur la revendication
        /// </summary>
        public bool CanRead { get; set; }

        /// <summary>
        /// Affecte ou obtient si le rôle dispose des droit de création sur la revendication
        /// </summary>
        public bool CanCreate { get; set; }

        /// <summary>
        /// Affecte ou obtient si le rôle dispose des droit de mise à jour sur la revendication
        /// </summary>
        public bool CanUpdate { get; set; }

        /// <summary>
        /// Affecte ou obtient si le rôle dispose des droit de suppression sur la revendication
        /// </summary>
        public bool CanDelete { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public ApplicationUserClaim()
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
            return HashCodeHelper.GetHashCode(this.ClaimType, this.UserId);
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
        public virtual int CompareTo(ApplicationUserClaim other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }

        /// <summary>
        /// Indique si l'objet actuel est égal à un autre objet du même type.
        /// </summary>
        /// <param name="other">Objet à comparer avec cet objet.</param>
        /// <returns>true si l'objet en cours est égal au paramètre other ; sinon, false.</returns>
        public virtual bool Equals(ApplicationUserClaim other)
        {
            return Equals(other as object);
        }

        #endregion
    }
}