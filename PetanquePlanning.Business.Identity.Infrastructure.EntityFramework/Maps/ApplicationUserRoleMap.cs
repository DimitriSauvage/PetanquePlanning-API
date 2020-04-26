using DimitriSauvageTools.Infrastructure.EntityFramework.Abstractions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetanquePlanning.Business.Identity.Domain.Entities;

namespace PetanquePlanning.Business.Identity.Infrastructure.EntityFramework.Maps
{
    public class ApplicationUserRoleMap : EntityWithCompositeIdMap<ApplicationUserRole>
    {
        public override void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            base.Configure(builder);
        }
    }
}