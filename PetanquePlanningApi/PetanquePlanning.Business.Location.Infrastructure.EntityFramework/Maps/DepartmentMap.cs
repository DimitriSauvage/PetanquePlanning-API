using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetanquePlanning.Business.Location.Domain.Entities;
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

            builder.HasData(new Department() {Name = "Ain", Code = "01", RegionCode = "84", Id = 1},
                new Department() {Name = "Aisne", Code = "02", RegionCode = "32", Id = 2},
                new Department() {Name = "Allier", Code = "03", RegionCode = "84", Id = 3},
                new Department() {Name = "Alpes-de-Haute-Provence", Code = "04", RegionCode = "93", Id = 4},
                new Department() {Name = "Hautes-Alpes", Code = "05", RegionCode = "93", Id = 5},
                new Department() {Name = "Alpes-Maritimes", Code = "06", RegionCode = "93", Id = 6},
                new Department() {Name = "Ardèche", Code = "07", RegionCode = "84", Id = 7},
                new Department() {Name = "Ardennes", Code = "08", RegionCode = "44", Id = 8},
                new Department() {Name = "Ariège", Code = "09", RegionCode = "76", Id = 9},
                new Department() {Name = "Aube", Code = "10", RegionCode = "44", Id = 10},
                new Department() {Name = "Aude", Code = "11", RegionCode = "76", Id = 11},
                new Department() {Name = "Aveyron", Code = "12", RegionCode = "76", Id = 12},
                new Department() {Name = "Bouches-du-Rhône", Code = "13", RegionCode = "93", Id = 13},
                new Department() {Name = "Calvados", Code = "14", RegionCode = "28", Id = 14},
                new Department() {Name = "Cantal", Code = "15", RegionCode = "84", Id = 15},
                new Department() {Name = "Charente", Code = "16", RegionCode = "75", Id = 16},
                new Department() {Name = "Charente-Maritime", Code = "17", RegionCode = "75", Id = 17},
                new Department() {Name = "Cher", Code = "18", RegionCode = "24", Id = 18},
                new Department() {Name = "Corrèze", Code = "19", RegionCode = "75", Id = 19},
                new Department() {Name = "Côte-d'Or", Code = "21", RegionCode = "27", Id = 20},
                new Department() {Name = "Côtes-d'Armor", Code = "22", RegionCode = "53", Id = 21},
                new Department() {Name = "Creuse", Code = "23", RegionCode = "75", Id = 22},
                new Department() {Name = "Dordogne", Code = "24", RegionCode = "75", Id = 23},
                new Department() {Name = "Doubs", Code = "25", RegionCode = "27", Id = 24},
                new Department() {Name = "Drôme", Code = "26", RegionCode = "84", Id = 25},
                new Department() {Name = "Eure", Code = "27", RegionCode = "28", Id = 26},
                new Department() {Name = "Eure-et-Loir", Code = "28", RegionCode = "24", Id = 27},
                new Department() {Name = "Finistère", Code = "29", RegionCode = "53", Id = 28},
                new Department() {Name = "Corse-du-Sud", Code = "2A", RegionCode = "94", Id = 29},
                new Department() {Name = "Haute-Corse", Code = "2B", RegionCode = "94", Id = 30},
                new Department() {Name = "Gard", Code = "30", RegionCode = "76", Id = 31},
                new Department() {Name = "Haute-Garonne", Code = "31", RegionCode = "76", Id = 32},
                new Department() {Name = "Gers", Code = "32", RegionCode = "76", Id = 33},
                new Department() {Name = "Gironde", Code = "33", RegionCode = "75", Id = 34},
                new Department() {Name = "Hérault", Code = "34", RegionCode = "76", Id = 35},
                new Department() {Name = "Ille-et-Vilaine", Code = "35", RegionCode = "53", Id = 36},
                new Department() {Name = "Indre", Code = "36", RegionCode = "24", Id = 37},
                new Department() {Name = "Indre-et-Loire", Code = "37", RegionCode = "24", Id = 38},
                new Department() {Name = "Isère", Code = "38", RegionCode = "84", Id = 39},
                new Department() {Name = "Jura", Code = "39", RegionCode = "27", Id = 40},
                new Department() {Name = "Landes", Code = "40", RegionCode = "75", Id = 41},
                new Department() {Name = "Loir-et-Cher", Code = "41", RegionCode = "24", Id = 42},
                new Department() {Name = "Loire", Code = "42", RegionCode = "84", Id = 43},
                new Department() {Name = "Haute-Loire", Code = "43", RegionCode = "84", Id = 44},
                new Department() {Name = "Loire-Atlantique", Code = "44", RegionCode = "52", Id = 45},
                new Department() {Name = "Loiret", Code = "45", RegionCode = "24", Id = 46},
                new Department() {Name = "Lot", Code = "46", RegionCode = "76", Id = 47},
                new Department() {Name = "Lot-et-Garonne", Code = "47", RegionCode = "75", Id = 48},
                new Department() {Name = "Lozère", Code = "48", RegionCode = "76", Id = 49},
                new Department() {Name = "Maine-et-Loire", Code = "49", RegionCode = "52", Id = 50},
                new Department() {Name = "Manche", Code = "50", RegionCode = "28", Id = 51},
                new Department() {Name = "Marne", Code = "51", RegionCode = "44", Id = 52},
                new Department() {Name = "Haute-Marne", Code = "52", RegionCode = "44", Id = 53},
                new Department() {Name = "Mayenne", Code = "53", RegionCode = "52", Id = 54},
                new Department() {Name = "Meurthe-et-Moselle", Code = "54", RegionCode = "44", Id = 55},
                new Department() {Name = "Meuse", Code = "55", RegionCode = "44", Id = 56},
                new Department() {Name = "Morbihan", Code = "56", RegionCode = "53", Id = 57},
                new Department() {Name = "Moselle", Code = "57", RegionCode = "44", Id = 58},
                new Department() {Name = "Nièvre", Code = "58", RegionCode = "27", Id = 59},
                new Department() {Name = "Nord", Code = "59", RegionCode = "32", Id = 60},
                new Department() {Name = "Oise", Code = "60", RegionCode = "32", Id = 61},
                new Department() {Name = "Orne", Code = "61", RegionCode = "28", Id = 62},
                new Department() {Name = "Pas-de-Calais", Code = "62", RegionCode = "32", Id = 63},
                new Department() {Name = "Puy-de-Dôme", Code = "63", RegionCode = "84", Id = 64},
                new Department() {Name = "Pyrénées-Atlantiques", Code = "64", RegionCode = "75", Id = 65},
                new Department() {Name = "Hautes-Pyrénées", Code = "65", RegionCode = "76", Id = 66},
                new Department() {Name = "Pyrénées-Orientales", Code = "66", RegionCode = "76", Id = 67},
                new Department() {Name = "Bas-Rhin", Code = "67", RegionCode = "44", Id = 68},
                new Department() {Name = "Haut-Rhin", Code = "68", RegionCode = "44", Id = 69},
                new Department() {Name = "Rhône", Code = "69", RegionCode = "84", Id = 70},
                new Department() {Name = "Haute-Saône", Code = "70", RegionCode = "27", Id = 71},
                new Department() {Name = "Saône-et-Loire", Code = "71", RegionCode = "27", Id = 72},
                new Department() {Name = "Sarthe", Code = "72", RegionCode = "52", Id = 73},
                new Department() {Name = "Savoie", Code = "73", RegionCode = "84", Id = 74},
                new Department() {Name = "Haute-Savoie", Code = "74", RegionCode = "84", Id = 75},
                new Department() {Name = "Paris", Code = "75", RegionCode = "11", Id = 76},
                new Department() {Name = "Seine-Maritime", Code = "76", RegionCode = "28", Id = 77},
                new Department() {Name = "Seine-et-Marne", Code = "77", RegionCode = "11", Id = 78},
                new Department() {Name = "Yvelines", Code = "78", RegionCode = "11", Id = 79},
                new Department() {Name = "Deux-Sèvres", Code = "79", RegionCode = "75", Id = 80},
                new Department() {Name = "Somme", Code = "80", RegionCode = "32", Id = 81},
                new Department() {Name = "Tarn", Code = "81", RegionCode = "76", Id = 82},
                new Department() {Name = "Tarn-et-Garonne", Code = "82", RegionCode = "76", Id = 83},
                new Department() {Name = "Var", Code = "83", RegionCode = "93", Id = 84},
                new Department() {Name = "Vaucluse", Code = "84", RegionCode = "93", Id = 85},
                new Department() {Name = "Vendée", Code = "85", RegionCode = "52", Id = 86},
                new Department() {Name = "Vienne", Code = "86", RegionCode = "75", Id = 87},
                new Department() {Name = "Haute-Vienne", Code = "87", RegionCode = "75", Id = 88},
                new Department() {Name = "Vosges", Code = "88", RegionCode = "44", Id = 89},
                new Department() {Name = "Yonne", Code = "89", RegionCode = "27", Id = 90},
                new Department() {Name = "Territoire de Belfort", Code = "90", RegionCode = "27", Id = 91},
                new Department() {Name = "Essonne", Code = "91", RegionCode = "11", Id = 92},
                new Department() {Name = "Hauts-de-Seine", Code = "92", RegionCode = "11", Id = 93},
                new Department() {Name = "Seine-Saint-Denis", Code = "93", RegionCode = "11", Id = 94},
                new Department() {Name = "Val-de-Marne", Code = "94", RegionCode = "11", Id = 95},
                new Department() {Name = "Val-d'Oise", Code = "95", RegionCode = "11", Id = 96},
                new Department() {Name = "Guadeloupe", Code = "971", RegionCode = "01", Id = 97},
                new Department() {Name = "Martinique", Code = "972", RegionCode = "02", Id = 98},
                new Department() {Name = "Guyane", Code = "973", RegionCode = "03", Id = 99},
                new Department() {Name = "La Réunion", Code = "974", RegionCode = "04", Id = 100},
                new Department() {Name = "Mayotte", Code = "976", RegionCode = "06", Id = 101});
        }
    }
}