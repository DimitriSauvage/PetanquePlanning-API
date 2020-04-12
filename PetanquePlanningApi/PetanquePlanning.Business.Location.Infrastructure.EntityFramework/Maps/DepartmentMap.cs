using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetanquePlanning.Business.Location.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Tools.Infrastructure.EntityFramework.Abstractions;

namespace PetanquePlanning.Business.Location.Infrastructure.EntityFramework.Maps
{
    public class DepartmentMap : EntityWithIdMap<Department>
    {
        public override void Configure(EntityTypeBuilder<Department> builder)
        {
            base.Configure(builder);

            //Fields
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Code).IsRequired();
            builder
                .HasOne(x => x.Region)
                .WithMany(x => x.Departments)
                .HasForeignKey(x => x.RegionCode)
                .HasConstraintName("FK_Department_Region")
                .OnDelete(DeleteBehavior.Cascade);

            //Index
            builder.HasIndex(x => x.Code).IsUnique().HasName("UX_Department_Code");
        }
    }
}
