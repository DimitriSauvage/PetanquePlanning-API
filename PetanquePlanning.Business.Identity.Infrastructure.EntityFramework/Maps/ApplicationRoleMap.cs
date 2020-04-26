using System;
using DimitriSauvageTools.Infrastructure.EntityFramework.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetanquePlanning.Business.Identity.Domain.Entities;

namespace PetanquePlanning.Business.Identity.Infrastructure.EntityFramework.Maps
{
    public class ApplicationRoleMap : EntityWithIdMap<ApplicationRole>
    {
        public override void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.ConcurrencyStamp).IsConcurrencyToken();
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.NormalizedName).HasMaxLength(100);
            builder.Property(x => x.ConcurrencyStamp).IsConcurrencyToken();

            builder
                .HasMany(x => x.Users)
                .WithOne()
                .HasForeignKey(x => x.RoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Claims).WithOne().HasForeignKey(x => x.RoleId).IsRequired();
            builder.HasIndex(x => x.NormalizedName).HasName("IX_ApplicationRole_NormalizedName").IsUnique();

            builder.HasData(
                new ApplicationRole()
                {
                    Id = Guid.NewGuid(), ConcurrencyStamp = "0469fddd-36a7-4601-a255-a07c1727e51b",
                    Name = "Administrateur",
                    NormalizedName = "Administrateur"
                },
                new ApplicationRole()
                {
                    Id = Guid.NewGuid(), ConcurrencyStamp = "1469fddd-36a7-4601-a255-a07c1727e51b",
                    Name = "Utilisateur",
                    NormalizedName = "Utilisateur"
                }
            );
        }
    }
}