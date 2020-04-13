using Abalone.Business.Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tools.Infrastructure.EntityFramework.Abstractions;

namespace PetanquePlanning.Business.Identity.Infrastructure.Abstractions.Maps
{
    public class ApplicationUserTokenMap : EntityWithIdMap<ApplicationUserToken>
    {
        public override void Configure(EntityTypeBuilder<ApplicationUserToken> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.LoginProvider).HasMaxLength(50);
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Value);
        }
    }
}