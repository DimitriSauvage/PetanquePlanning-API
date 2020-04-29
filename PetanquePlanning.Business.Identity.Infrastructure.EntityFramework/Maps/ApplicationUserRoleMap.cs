using System;
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

            builder.HasData(new ApplicationUserRole()
            {
                RoleId = Guid.Parse("7C40912E-1F5D-43D5-8FF7-77BB0BE94B0D"),
                UserId = Guid.Parse("85ee2e86-6fea-46a6-a4a8-93dbf1a6d50a")
            });
        }
    }
}