using System;
using DimitriSauvageTools.Infrastructure.EntityFramework.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetanquePlanning.Business.Identity.Domain.Entities;
using PetanquePlanning.Business.Identity.Domain.Enumerations;

namespace PetanquePlanning.Business.Identity.Infrastructure.EntityFramework.Maps
{
    public class ApplicationUserMap : EntityWithIdMap<ApplicationUser>
    {
        public override void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.UserName).HasMaxLength(255);
            builder.Property(x => x.NormalizedUserName).HasMaxLength(255);
            builder.Property(x => x.Email).HasMaxLength(255).IsRequired();
            builder.Property(x => x.NormalizedEmail).HasMaxLength(255).IsRequired();
            builder.Property(x => x.ConcurrencyStamp).IsConcurrencyToken();
            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(50);
            builder.Property(x => x.AccessFailedCount);
            builder.Property(x => x.LockoutEnabled);
            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.Avatar);
            builder.Property(x => x.Gender);

            builder
                .HasMany(x => x.Roles)
                .WithOne()
                .HasForeignKey(ur => ur.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany<ApplicationUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
            builder.HasMany<ApplicationUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
            builder.HasMany<ApplicationUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();


            builder.HasIndex(x => x.NormalizedUserName).HasName("UK_ApplicationUser_NormalizedUserName").IsUnique();
            builder.HasIndex(x => x.NormalizedEmail).HasName("IX_ApplicationUser_NormalizedEmail");

            #region Initial data

            var addedUser = new ApplicationUser()
            {
                Email = "dimitri1993@live.fr",
                NormalizedEmail = "dimitri1993@live.fr".Normalize(),
                UserName = "dimitri1993@live.fr",
                NormalizedUserName = "dimitri1993@live.fr".Normalize(),
                Gender = GenderEnum.Mister,
                Id = Guid.Parse("85ee2e86-6fea-46a6-a4a8-93dbf1a6d50a"),
                BirthDate = new DateTimeOffset(new DateTime(1993, 09, 30)),
                EmailConfirmed = true,
                ConcurrencyStamp = "ConcurrencyStamp",
                FirstName = "Dimitri",
                LastName = "SAUVAGE",
                LockoutEnabled = false,
                PhoneNumber = "0645674984",
                PhoneNumberConfirmed = true,
                SecurityStamp = "SecurityStamp",
                SubscriptionDate = DateTimeOffset.Now,
                MustChangePassword = false,
                TwoFactorEnabled = false,
                Avatar = null,
                AccessFailedCount = 0
            };
            addedUser.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(addedUser, "Not24get");

            builder.HasData(addedUser);

            #endregion
        }
    }
}