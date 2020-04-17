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

            builder.HasData(new Region() {Name = "Guadeloupe", Code = "01", Id = 1},
                new Region() {Name = "Martinique", Code = "02", Id = 2},
                new Region() {Name = "Guyane", Code = "03", Id = 3},
                new Region() {Name = "La Réunion", Code = "04", Id = 4},
                new Region() {Name = "Mayotte", Code = "06", Id = 5},
                new Region() {Name = "Île-de-France", Code = "11", Id = 6},
                new Region() {Name = "Centre-Val de Loire", Code = "24", Id = 7},
                new Region() {Name = "Bourgogne-Franche-Comté", Code = "27", Id = 8},
                new Region() {Name = "Normandie", Code = "28", Id = 9},
                new Region() {Name = "Hauts-de-France", Code = "32", Id = 10},
                new Region() {Name = "Grand Est", Code = "44", Id = 11},
                new Region() {Name = "Pays de la Loire", Code = "52", Id = 12},
                new Region() {Name = "Bretagne", Code = "53", Id = 13},
                new Region() {Name = "Nouvelle-Aquitaine", Code = "75", Id = 14},
                new Region() {Name = "Occitanie", Code = "76", Id = 15},
                new Region() {Name = "Auvergne-Rhône-Alpes", Code = "84", Id = 16},
                new Region() {Name = "Provence-Alpes-Côte d'Azur", Code = "93", Id = 17},
                new Region() {Name = "Corse", Code = "94", Id = 18});
        }
    }
}