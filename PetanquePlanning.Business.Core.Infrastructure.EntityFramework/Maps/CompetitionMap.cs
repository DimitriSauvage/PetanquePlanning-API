using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetanquePlanning.Business.Core.Domain.Entities;
using Tools.Infrastructure.EntityFramework.Abstractions;

namespace PetanquePlanning.Business.Core.Infrastructure.EntityFramework.Maps
{
    public class CompetitionMap : EntityWithIdMap<Competition>
    {
        public override void Configure(EntityTypeBuilder<Competition> builder)
        {
            base.Configure(builder);

            //Fields
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Description);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.CompetitionGender).IsRequired();
            builder.Property(x => x.CompetitionLevel).IsRequired();
            builder.Property(x => x.CompetitionSport).IsRequired();
            builder.Property(x => x.CompetitionType).IsRequired();
            builder
                .HasOne(x => x.Organizer)
                .WithMany()
                .HasForeignKey("FK_Competition_Club_Organizer")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsOne(
                navigationExpression: x => x.Address,
                buildAction: AddressMapBuilder.GetAddressBuilderAction<Competition>()
            );


            //Index
            builder.HasIndex(x => new {x.OrganizerId}).HasName("IX_Competition_Club_Organizer");
            builder.HasIndex(x => new {x.Date}).HasName("IX_Competition_Date");
        }
    }
}