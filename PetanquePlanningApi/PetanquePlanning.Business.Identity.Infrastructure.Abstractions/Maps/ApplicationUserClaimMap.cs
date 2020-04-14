using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetanquePlanning.Business.Identity.Domain.Entities;
using Tools.Infrastructure.EntityFramework.Abstractions;

namespace PetanquePlanning.Business.Identity.Infrastructure.Abstractions.Maps
{
    public class ApplicationUserClaimMap : EntityWithIdMap<ApplicationUserClaim, int>
    {
        public override void Configure(EntityTypeBuilder<ApplicationUserClaim> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.ClaimType).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ClaimValue);
            builder.Property(x => x.CanCreate).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.CanUpdate).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.CanDelete).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.CanRead).IsRequired().HasDefaultValue(false);
        }
    }
}