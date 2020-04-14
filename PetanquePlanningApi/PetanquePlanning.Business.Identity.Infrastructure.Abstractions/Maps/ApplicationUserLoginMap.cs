using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetanquePlanning.Business.Identity.Domain.Entities;
using Tools.Infrastructure.EntityFramework.Abstractions;

namespace PetanquePlanning.Business.Identity.Infrastructure.Abstractions.Maps
{
    public class ApplicationUserLoginMap : EntityWithIdMap<ApplicationUserLogin>
    {
        public override void Configure(EntityTypeBuilder<ApplicationUserLogin> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.LoginProvider).HasMaxLength(50);
            builder.Property(x => x.ProviderDisplayName).HasMaxLength(100);
            builder.Property(x => x.ProviderKey);

            builder.HasIndex(x => x.UserId).HasName("ix_ApplicationUserLogin_UserId");
        }
    }
}