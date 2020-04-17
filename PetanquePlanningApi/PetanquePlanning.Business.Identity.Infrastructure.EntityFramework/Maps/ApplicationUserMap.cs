using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetanquePlanning.Business.Identity.Domain.Entities;
using Tools.Infrastructure.EntityFramework.Abstractions;

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
        }
    }
}