using Abalone.Business.Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tools.Infrastructure.EntityFramework.Abstractions;

namespace PetanquePlanning.Business.Identity.Infrastructure.Abstractions.Maps
{
    public class ApplicationUserRoleMap : EntityWithCompositeIdMap<ApplicationUserRole>
    {
        public override void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            base.Configure(builder);
        }
    }
}