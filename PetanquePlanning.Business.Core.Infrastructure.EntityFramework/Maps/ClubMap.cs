using DimitriSauvageTools.Infrastructure.EntityFramework.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetanquePlanning.Business.Core.Domain.Entities;

namespace PetanquePlanning.Business.Core.Infrastructure.EntityFramework.Maps
{
    public class ClubMap : EntityWithIdMap<Club>
    {
        public override void Configure(EntityTypeBuilder<Club> builder)
        {
            base.Configure(builder);

            //Fields;
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ShortName);
            builder.OwnsOne(
                navigationExpression: x => x.Address,
                buildAction: AddressMapBuilder.GetAddressBuilderAction<Club>()
            );


            //Index
            builder.HasIndex(x => x.Name).HasName("IX_Club_Name");
            builder.HasIndex(x => x.ShortName).HasName("IX_Club_ShortName");
        }
    }
}