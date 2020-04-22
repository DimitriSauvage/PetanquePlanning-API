using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetanquePlanning.Business.Location.Domain.Entities;
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

            builder.HasData(
                new Region()
                    {Name = "Guadeloupe", Code = "01", Id = Guid.Parse("4357815c-da7e-4919-8f2e-6df3228cddbe")},
                new Region()
                    {Name = "Martinique", Code = "02", Id = Guid.Parse("a4798a24-c3d0-4311-8735-e93a30fdeec7")},
                new Region() {Name = "Guyane", Code = "03", Id = Guid.Parse("6ac78d8f-1ec7-48fb-a9da-a41e6223fa9b")},
                new Region()
                    {Name = "La Réunion", Code = "04", Id = Guid.Parse("966edde0-a3fa-4f4a-8a27-7231c2ebf181")},
                new Region() {Name = "Mayotte", Code = "06", Id = Guid.Parse("0ffa1f77-f8dc-427c-a5f7-95dbba89310f")},
                new Region()
                    {Name = "Île-de-France", Code = "11", Id = Guid.Parse("b6f686d0-13a7-47db-9e8e-d888e36cdce8")},
                new Region()
                {
                    Name = "Centre-Val de Loire", Code = "24", Id = Guid.Parse("6651a27f-e548-4404-a7a5-c8b956d4906e")
                },
                new Region()
                {
                    Name = "Bourgogne-Franche-Comté", Code = "27",
                    Id = Guid.Parse("c1524a03-e7c5-4959-ac10-4e569196e743")
                },
                new Region() {Name = "Normandie", Code = "28", Id = Guid.Parse("26a3ed8e-ef43-46df-8722-38d48170c391")},
                new Region()
                    {Name = "Hauts-de-France", Code = "32", Id = Guid.Parse("3a008295-2e8f-42e9-aa87-485d150d58db")},
                new Region() {Name = "Grand Est", Code = "44", Id = Guid.Parse("5823a48a-b05e-47cb-91eb-f1d0877a07b5")},
                new Region()
                    {Name = "Pays de la Loire", Code = "52", Id = Guid.Parse("e3a4faa4-4582-40d9-b5ac-154d66170041")},
                new Region() {Name = "Bretagne", Code = "53", Id = Guid.Parse("14225638-c769-458b-995e-53629890d38d")},
                new Region()
                    {Name = "Nouvelle-Aquitaine", Code = "75", Id = Guid.Parse("554a957c-4b70-4893-8ed7-4c8e09ad2b00")},
                new Region() {Name = "Occitanie", Code = "76", Id = Guid.Parse("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15")},
                new Region()
                {
                    Name = "Auvergne-Rhône-Alpes", Code = "84", Id = Guid.Parse("bbfa939b-d5c7-4428-9537-dc063457270a")
                },
                new Region()
                {
                    Name = "Provence-Alpes-Côte d'Azur", Code = "93",
                    Id = Guid.Parse("00d9720b-6f64-477d-8651-304b74c2f4c3")
                }, new Region() {Name = "Corse", Code = "94", Id = Guid.Parse("7ce01654-58a0-4c59-b5af-62351080e52f")});
        }
    }
}