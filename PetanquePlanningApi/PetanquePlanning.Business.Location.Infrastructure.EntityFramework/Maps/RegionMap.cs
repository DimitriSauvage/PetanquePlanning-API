using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetanquePlanning.Business.Location.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Tools.Infrastructure.EntityFramework.Abstractions;

namespace PetanquePlanning.Business.Location.Infrastructure.EntityFramework.Maps
{
    public class RegionMap : EntityWithIdMap<Region>
    {
        public override void Configure(EntityTypeBuilder<Region> builder)
        {
            base.Configure(builder);

            //Fields
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Code).IsRequired();

            //Index
            builder.HasIndex(x => x.Code).IsUnique().HasName("UX_Region_Code");
        }
    }
}
