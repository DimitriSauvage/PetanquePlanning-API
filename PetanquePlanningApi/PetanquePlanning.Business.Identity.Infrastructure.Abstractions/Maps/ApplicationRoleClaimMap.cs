using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using PetanquePlanning.Business.Identity.Domain.Entities;

namespace PetanquePlanning.Business.Identity.Infrastructure.Abstractions.Maps
{
    public class ApplicationRoleClaimMap : IEntityTypeConfiguration<ApplicationRoleClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationRoleClaim> builder)
        {
            builder.ToTable(nameof(ApplicationRoleClaim));
            //builder.HasKey(ar => ar.Id);
            builder.Property(x => x.ClaimType).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ClaimValue);
            builder.Property(x => x.CanCreate).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.CanUpdate).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.CanDelete).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.CanRead).IsRequired().HasDefaultValue(false);
        }
    }
}