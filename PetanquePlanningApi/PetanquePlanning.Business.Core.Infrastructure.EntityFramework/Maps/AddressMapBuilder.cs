using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetanquePlanning.Business.Core.Domain.Entities;
using Tools.Domain.Abstractions;

namespace PetanquePlanning.Business.Core.Infrastructure.EntityFramework.Maps
{
    public static class AddressMapBuilder
    {
        /// <summary>
        /// Get the build action to map an address
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns></returns>
        public static Action<ReferenceOwnershipBuilder<TEntity, Address>> GetAddressBuilderAction<TEntity>()
            where TEntity : class, IEntity
        {
            return address =>
            {
                address.Property(x => x.City).IsRequired();
                address.Property(x => x.Number);
                address.Property(x => x.Street);
                address.Property(x => x.ZipCode).IsRequired();
                address.OwnsOne(
                    navigationExpression: x => x.Coordinate,
                    buildAction: coordinate =>
                    {
                        coordinate.Property(x => x.Latitude).IsRequired();
                        coordinate.Property(x => x.Longitude).IsRequired();
                    });
            };
        }
    }
}