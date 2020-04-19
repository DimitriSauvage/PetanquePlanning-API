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
                .HasForeignKey(x => x.RegionId)
                .HasConstraintName("FK_Department_Region")
                .OnDelete(DeleteBehavior.Cascade);


            //Index
            builder.HasIndex(x => x.Code).IsUnique().HasName("UX_Department_Code");

            builder.HasData(new Department() {Name = "Ain", Code = "01", RegionId = 16, Id = 1},
                new Department() {Name = "Aisne", Code = "02", RegionId = 10, Id = 2},
                new Department() {Name = "Allier", Code = "03", RegionId = 16, Id = 3},
                new Department() {Name = "Alpes-de-Haute-Provence", Code = "04", RegionId = 17, Id = 4},
                new Department() {Name = "Hautes-Alpes", Code = "05", RegionId = 17, Id = 5},
                new Department() {Name = "Alpes-Maritimes", Code = "06", RegionId = 17, Id = 6},
                new Department() {Name = "Ardèche", Code = "07", RegionId = 16, Id = 7},
                new Department() {Name = "Ardennes", Code = "08", RegionId = 11, Id = 8},
                new Department() {Name = "Ariège", Code = "09", RegionId = 15, Id = 9},
                new Department() {Name = "Aube", Code = "10", RegionId = 11, Id = 10},
                new Department() {Name = "Aude", Code = "11", RegionId = 15, Id = 11},
                new Department() {Name = "Aveyron", Code = "12", RegionId = 15, Id = 12},
                new Department() {Name = "Bouches-du-Rhône", Code = "13", RegionId = 17, Id = 13},
                new Department() {Name = "Calvados", Code = "14", RegionId = 9, Id = 14},
                new Department() {Name = "Cantal", Code = "15", RegionId = 16, Id = 15},
                new Department() {Name = "Charente", Code = "16", RegionId = 14, Id = 16},
                new Department() {Name = "Charente-Maritime", Code = "17", RegionId = 14, Id = 17},
                new Department() {Name = "Cher", Code = "18", RegionId = 7, Id = 18},
                new Department() {Name = "Corrèze", Code = "19", RegionId = 14, Id = 19},
                new Department() {Name = "Côte-d'Or", Code = "21", RegionId = 8, Id = 20},
                new Department() {Name = "Côtes-d'Armor", Code = "22", RegionId = 13, Id = 21},
                new Department() {Name = "Creuse", Code = "23", RegionId = 14, Id = 22},
                new Department() {Name = "Dordogne", Code = "24", RegionId = 14, Id = 23},
                new Department() {Name = "Doubs", Code = "25", RegionId = 8, Id = 24},
                new Department() {Name = "Drôme", Code = "26", RegionId = 16, Id = 25},
                new Department() {Name = "Eure", Code = "27", RegionId = 9, Id = 26},
                new Department() {Name = "Eure-et-Loir", Code = "28", RegionId = 7, Id = 27},
                new Department() {Name = "Finistère", Code = "29", RegionId = 13, Id = 28},
                new Department() {Name = "Corse-du-Sud", Code = "2A", RegionId = 18, Id = 29},
                new Department() {Name = "Haute-Corse", Code = "2B", RegionId = 18, Id = 30},
                new Department() {Name = "Gard", Code = "30", RegionId = 15, Id = 31},
                new Department() {Name = "Haute-Garonne", Code = "31", RegionId = 15, Id = 32},
                new Department() {Name = "Gers", Code = "32", RegionId = 15, Id = 33},
                new Department() {Name = "Gironde", Code = "33", RegionId = 14, Id = 34},
                new Department() {Name = "Hérault", Code = "34", RegionId = 15, Id = 35},
                new Department() {Name = "Ille-et-Vilaine", Code = "35", RegionId = 13, Id = 36},
                new Department() {Name = "Indre", Code = "36", RegionId = 7, Id = 37},
                new Department() {Name = "Indre-et-Loire", Code = "37", RegionId = 7, Id = 38},
                new Department() {Name = "Isère", Code = "38", RegionId = 16, Id = 39},
                new Department() {Name = "Jura", Code = "39", RegionId = 8, Id = 40},
                new Department() {Name = "Landes", Code = "40", RegionId = 14, Id = 41},
                new Department() {Name = "Loir-et-Cher", Code = "41", RegionId = 7, Id = 42},
                new Department() {Name = "Loire", Code = "42", RegionId = 16, Id = 43},
                new Department() {Name = "Haute-Loire", Code = "43", RegionId = 16, Id = 44},
                new Department() {Name = "Loire-Atlantique", Code = "44", RegionId = 12, Id = 45},
                new Department() {Name = "Loiret", Code = "45", RegionId = 7, Id = 46},
                new Department() {Name = "Lot", Code = "46", RegionId = 15, Id = 47},
                new Department() {Name = "Lot-et-Garonne", Code = "47", RegionId = 14, Id = 48},
                new Department() {Name = "Lozère", Code = "48", RegionId = 15, Id = 49},
                new Department() {Name = "Maine-et-Loire", Code = "49", RegionId = 12, Id = 50},
                new Department() {Name = "Manche", Code = "50", RegionId = 9, Id = 51},
                new Department() {Name = "Marne", Code = "51", RegionId = 11, Id = 52},
                new Department() {Name = "Haute-Marne", Code = "52", RegionId = 11, Id = 53},
                new Department() {Name = "Mayenne", Code = "53", RegionId = 12, Id = 54},
                new Department() {Name = "Meurthe-et-Moselle", Code = "54", RegionId = 11, Id = 55},
                new Department() {Name = "Meuse", Code = "55", RegionId = 11, Id = 56},
                new Department() {Name = "Morbihan", Code = "56", RegionId = 13, Id = 57},
                new Department() {Name = "Moselle", Code = "57", RegionId = 11, Id = 58},
                new Department() {Name = "Nièvre", Code = "58", RegionId = 8, Id = 59},
                new Department() {Name = "Nord", Code = "59", RegionId = 10, Id = 60},
                new Department() {Name = "Oise", Code = "60", RegionId = 10, Id = 61},
                new Department() {Name = "Orne", Code = "61", RegionId = 9, Id = 62},
                new Department() {Name = "Pas-de-Calais", Code = "62", RegionId = 10, Id = 63},
                new Department() {Name = "Puy-de-Dôme", Code = "63", RegionId = 16, Id = 64},
                new Department() {Name = "Pyrénées-Atlantiques", Code = "64", RegionId = 14, Id = 65},
                new Department() {Name = "Hautes-Pyrénées", Code = "65", RegionId = 15, Id = 66},
                new Department() {Name = "Pyrénées-Orientales", Code = "66", RegionId = 15, Id = 67},
                new Department() {Name = "Bas-Rhin", Code = "67", RegionId = 11, Id = 68},
                new Department() {Name = "Haut-Rhin", Code = "68", RegionId = 11, Id = 69},
                new Department() {Name = "Rhône", Code = "69", RegionId = 16, Id = 70},
                new Department() {Name = "Haute-Saône", Code = "70", RegionId = 8, Id = 71},
                new Department() {Name = "Saône-et-Loire", Code = "71", RegionId = 8, Id = 72},
                new Department() {Name = "Sarthe", Code = "72", RegionId = 12, Id = 73},
                new Department() {Name = "Savoie", Code = "73", RegionId = 16, Id = 74},
                new Department() {Name = "Haute-Savoie", Code = "74", RegionId = 16, Id = 75},
                new Department() {Name = "Paris", Code = "75", RegionId = 6, Id = 76},
                new Department() {Name = "Seine-Maritime", Code = "76", RegionId = 9, Id = 77},
                new Department() {Name = "Seine-et-Marne", Code = "77", RegionId = 6, Id = 78},
                new Department() {Name = "Yvelines", Code = "78", RegionId = 6, Id = 79},
                new Department() {Name = "Deux-Sèvres", Code = "79", RegionId = 14, Id = 80},
                new Department() {Name = "Somme", Code = "80", RegionId = 10, Id = 81},
                new Department() {Name = "Tarn", Code = "81", RegionId = 15, Id = 82},
                new Department() {Name = "Tarn-et-Garonne", Code = "82", RegionId = 15, Id = 83},
                new Department() {Name = "Var", Code = "83", RegionId = 17, Id = 84},
                new Department() {Name = "Vaucluse", Code = "84", RegionId = 17, Id = 85},
                new Department() {Name = "Vendée", Code = "85", RegionId = 12, Id = 86},
                new Department() {Name = "Vienne", Code = "86", RegionId = 14, Id = 87},
                new Department() {Name = "Haute-Vienne", Code = "87", RegionId = 14, Id = 88},
                new Department() {Name = "Vosges", Code = "88", RegionId = 11, Id = 89},
                new Department() {Name = "Yonne", Code = "89", RegionId = 8, Id = 90},
                new Department() {Name = "Territoire de Belfort", Code = "90", RegionId = 8, Id = 91},
                new Department() {Name = "Essonne", Code = "91", RegionId = 6, Id = 92},
                new Department() {Name = "Hauts-de-Seine", Code = "92", RegionId = 6, Id = 93},
                new Department() {Name = "Seine-Saint-Denis", Code = "93", RegionId = 6, Id = 94},
                new Department() {Name = "Val-de-Marne", Code = "94", RegionId = 6, Id = 95},
                new Department() {Name = "Val-d'Oise", Code = "95", RegionId = 6, Id = 96},
                new Department() {Name = "Guadeloupe", Code = "971", RegionId = 1, Id = 97},
                new Department() {Name = "Martinique", Code = "972", RegionId = 2, Id = 98},
                new Department() {Name = "Guyane", Code = "973", RegionId = 3, Id = 99},
                new Department() {Name = "La Réunion", Code = "974", RegionId = 4, Id = 100},
                new Department() {Name = "Mayotte", Code = "976", RegionId = 5, Id = 101});
        }
    }
}