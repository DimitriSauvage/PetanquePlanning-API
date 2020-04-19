using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetanquePlanningApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "identity");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 255, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    NormalizedEmail = table.Column<string>(maxLength: 255, nullable: false),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Avatar = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTimeOffset>(nullable: false),
                    ClubId = table.Column<long>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    SubscriptionDate = table.Column<DateTimeOffset>(nullable: false),
                    MustChangePassword = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address_Number = table.Column<string>(nullable: true),
                    Address_Street = table.Column<string>(nullable: true),
                    Address_ZipCode = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: true),
                    Address_Coordinate_Latitude = table.Column<double>(nullable: true),
                    Address_Coordinate_Longitude = table.Column<double>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationRoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(maxLength: 100, nullable: false),
                    ClaimValue = table.Column<string>(nullable: true),
                    CanRead = table.Column<bool>(nullable: false, defaultValue: false),
                    CanCreate = table.Column<bool>(nullable: false, defaultValue: false),
                    CanUpdate = table.Column<bool>(nullable: false, defaultValue: false),
                    CanDelete = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationRoleClaim_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(maxLength: 100, nullable: false),
                    ClaimValue = table.Column<string>(nullable: true),
                    CanRead = table.Column<bool>(nullable: false, defaultValue: false),
                    CanCreate = table.Column<bool>(nullable: false, defaultValue: false),
                    CanUpdate = table.Column<bool>(nullable: false, defaultValue: false),
                    CanDelete = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginProvider = table.Column<string>(maxLength: 50, nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(maxLength: 100, nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserRole",
                schema: "identity",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserRole_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationUserRole_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Competition",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address_Number = table.Column<string>(nullable: true),
                    Address_Street = table.Column<string>(nullable: true),
                    Address_ZipCode = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: true),
                    Address_Coordinate_Latitude = table.Column<double>(nullable: true),
                    Address_Coordinate_Longitude = table.Column<double>(nullable: true),
                    CompetitionGender = table.Column<int>(nullable: false),
                    CompetitionLevel = table.Column<int>(nullable: false),
                    CompetitionSport = table.Column<int>(nullable: false),
                    CompetitionType = table.Column<int>(nullable: false),
                    Date = table.Column<DateTimeOffset>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    FK_Competition_Club_Organizer = table.Column<long>(nullable: false),
                    OrganizerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competition_Club_FK_Competition_Club_Organizer",
                        column: x => x.FK_Competition_Club_Organizer,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    RegionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Region",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdjacentDepartments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstDepartmentId = table.Column<long>(nullable: false),
                    SecondDepartmentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdjacentDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdjacentDepartments_Department_FirstDepartmentId",
                        column: x => x.FirstDepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdjacentDepartments_Department_SecondDepartmentId",
                        column: x => x.SecondDepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserFavoriteDepartment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserFavoriteDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUserFavoriteDepartment_Depatment",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserFavoriteDepartment_ApplicationUser",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1L, "0469fddd-36a7-4601-a255-a07c1727e51b", null, "Administrateur", "Administrateur" },
                    { 2L, "1469fddd-36a7-4601-a255-a07c1727e51b", null, "Utilisateur", "Utilisateur" }
                });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 16L, "84", "Auvergne-Rhône-Alpes" },
                    { 15L, "76", "Occitanie" },
                    { 14L, "75", "Nouvelle-Aquitaine" },
                    { 13L, "53", "Bretagne" },
                    { 12L, "52", "Pays de la Loire" },
                    { 11L, "44", "Grand Est" },
                    { 10L, "32", "Hauts-de-France" },
                    { 9L, "28", "Normandie" },
                    { 8L, "27", "Bourgogne-Franche-Comté" },
                    { 7L, "24", "Centre-Val de Loire" },
                    { 6L, "11", "Île-de-France" },
                    { 5L, "06", "Mayotte" },
                    { 4L, "04", "La Réunion" },
                    { 3L, "03", "Guyane" },
                    { 2L, "02", "Martinique" },
                    { 1L, "01", "Guadeloupe" },
                    { 17L, "93", "Provence-Alpes-Côte d'Azur" },
                    { 18L, "94", "Corse" }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Code", "Name", "RegionId" },
                values: new object[,]
                {
                    { 97L, "971", "Guadeloupe", 1L },
                    { 32L, "31", "Haute-Garonne", 15L },
                    { 31L, "30", "Gard", 15L },
                    { 12L, "12", "Aveyron", 15L },
                    { 11L, "11", "Aude", 15L },
                    { 9L, "09", "Ariège", 15L },
                    { 88L, "87", "Haute-Vienne", 14L },
                    { 87L, "86", "Vienne", 14L },
                    { 80L, "79", "Deux-Sèvres", 14L },
                    { 65L, "64", "Pyrénées-Atlantiques", 14L },
                    { 48L, "47", "Lot-et-Garonne", 14L },
                    { 41L, "40", "Landes", 14L },
                    { 34L, "33", "Gironde", 14L },
                    { 23L, "24", "Dordogne", 14L },
                    { 22L, "23", "Creuse", 14L },
                    { 19L, "19", "Corrèze", 14L },
                    { 17L, "17", "Charente-Maritime", 14L },
                    { 16L, "16", "Charente", 14L },
                    { 57L, "56", "Morbihan", 13L },
                    { 36L, "35", "Ille-et-Vilaine", 13L },
                    { 28L, "29", "Finistère", 13L },
                    { 21L, "22", "Côtes-d'Armor", 13L },
                    { 33L, "32", "Gers", 15L },
                    { 35L, "34", "Hérault", 15L },
                    { 47L, "46", "Lot", 15L },
                    { 49L, "48", "Lozère", 15L },
                    { 85L, "84", "Vaucluse", 17L },
                    { 84L, "83", "Var", 17L },
                    { 13L, "13", "Bouches-du-Rhône", 17L },
                    { 6L, "06", "Alpes-Maritimes", 17L },
                    { 5L, "05", "Hautes-Alpes", 17L },
                    { 4L, "04", "Alpes-de-Haute-Provence", 17L },
                    { 75L, "74", "Haute-Savoie", 16L },
                    { 74L, "73", "Savoie", 16L },
                    { 70L, "69", "Rhône", 16L },
                    { 64L, "63", "Puy-de-Dôme", 16L },
                    { 86L, "85", "Vendée", 12L },
                    { 44L, "43", "Haute-Loire", 16L },
                    { 39L, "38", "Isère", 16L },
                    { 25L, "26", "Drôme", 16L },
                    { 15L, "15", "Cantal", 16L },
                    { 7L, "07", "Ardèche", 16L },
                    { 3L, "03", "Allier", 16L },
                    { 1L, "01", "Ain", 16L },
                    { 83L, "82", "Tarn-et-Garonne", 15L },
                    { 82L, "81", "Tarn", 15L },
                    { 67L, "66", "Pyrénées-Orientales", 15L },
                    { 66L, "65", "Hautes-Pyrénées", 15L },
                    { 43L, "42", "Loire", 16L },
                    { 29L, "2A", "Corse-du-Sud", 18L },
                    { 73L, "72", "Sarthe", 12L },
                    { 50L, "49", "Maine-et-Loire", 12L },
                    { 40L, "39", "Jura", 8L },
                    { 24L, "25", "Doubs", 8L },
                    { 20L, "21", "Côte-d'Or", 8L },
                    { 46L, "45", "Loiret", 7L },
                    { 42L, "41", "Loir-et-Cher", 7L },
                    { 38L, "37", "Indre-et-Loire", 7L },
                    { 37L, "36", "Indre", 7L },
                    { 27L, "28", "Eure-et-Loir", 7L },
                    { 18L, "18", "Cher", 7L },
                    { 96L, "95", "Val-d'Oise", 6L },
                    { 95L, "94", "Val-de-Marne", 6L },
                    { 94L, "93", "Seine-Saint-Denis", 6L },
                    { 93L, "92", "Hauts-de-Seine", 6L },
                    { 92L, "91", "Essonne", 6L },
                    { 79L, "78", "Yvelines", 6L },
                    { 78L, "77", "Seine-et-Marne", 6L },
                    { 76L, "75", "Paris", 6L },
                    { 101L, "976", "Mayotte", 5L },
                    { 100L, "974", "La Réunion", 4L },
                    { 99L, "973", "Guyane", 3L },
                    { 98L, "972", "Martinique", 2L },
                    { 59L, "58", "Nièvre", 8L },
                    { 71L, "70", "Haute-Saône", 8L },
                    { 72L, "71", "Saône-et-Loire", 8L },
                    { 90L, "89", "Yonne", 8L },
                    { 45L, "44", "Loire-Atlantique", 12L },
                    { 89L, "88", "Vosges", 11L },
                    { 69L, "68", "Haut-Rhin", 11L },
                    { 68L, "67", "Bas-Rhin", 11L },
                    { 58L, "57", "Moselle", 11L },
                    { 56L, "55", "Meuse", 11L },
                    { 55L, "54", "Meurthe-et-Moselle", 11L },
                    { 53L, "52", "Haute-Marne", 11L },
                    { 52L, "51", "Marne", 11L },
                    { 10L, "10", "Aube", 11L },
                    { 54L, "53", "Mayenne", 12L },
                    { 8L, "08", "Ardennes", 11L },
                    { 63L, "62", "Pas-de-Calais", 10L },
                    { 61L, "60", "Oise", 10L },
                    { 60L, "59", "Nord", 10L },
                    { 2L, "02", "Aisne", 10L },
                    { 77L, "76", "Seine-Maritime", 9L },
                    { 62L, "61", "Orne", 9L },
                    { 51L, "50", "Manche", 9L },
                    { 26L, "27", "Eure", 9L },
                    { 14L, "14", "Calvados", 9L },
                    { 91L, "90", "Territoire de Belfort", 8L },
                    { 81L, "80", "Somme", 10L },
                    { 30L, "2B", "Haute-Corse", 18L }
                });

            migrationBuilder.InsertData(
                table: "AdjacentDepartments",
                columns: new[] { "Id", "FirstDepartmentId", "SecondDepartmentId" },
                values: new object[,]
                {
                    { 385L, 78L, 92L },
                    { 92L, 19L, 47L },
                    { 57L, 12L, 47L },
                    { 168L, 35L, 31L },
                    { 167L, 35L, 12L },
                    { 166L, 35L, 11L },
                    { 147L, 31L, 35L },
                    { 56L, 12L, 35L },
                    { 52L, 11L, 35L },
                    { 325L, 65L, 33L },
                    { 239L, 48L, 33L },
                    { 199L, 41L, 33L },
                    { 159L, 33L, 65L },
                    { 158L, 33L, 48L },
                    { 157L, 33L, 41L },
                    { 156L, 33L, 32L },
                    { 152L, 32L, 33L },
                    { 151L, 32L, 11L },
                    { 150L, 32L, 9L },
                    { 51L, 11L, 32L },
                    { 43L, 9L, 32L },
                    { 144L, 31L, 12L },
                    { 55L, 12L, 31L },
                    { 50L, 11L, 9L },
                    { 42L, 9L, 11L },
                    { 436L, 88L, 87L },
                    { 115L, 23L, 47L },
                    { 232L, 47L, 12L },
                    { 234L, 47L, 19L },
                    { 235L, 47L, 23L },
                    { 161L, 33L, 83L },
                    { 155L, 32L, 83L },
                    { 60L, 12L, 83L },
                    { 405L, 82L, 35L },
                    { 404L, 82L, 32L },
                    { 403L, 82L, 12L },
                    { 402L, 82L, 11L },
                    { 169L, 35L, 82L },
                    { 154L, 32L, 82L },
                    { 59L, 12L, 82L },
                    { 53L, 11L, 82L },
                    { 332L, 67L, 11L },
                    { 435L, 88L, 23L },
                    { 331L, 67L, 9L },
                    { 330L, 66L, 65L },
                    { 329L, 66L, 33L },
                    { 328L, 66L, 32L },
                    { 327L, 65L, 66L },
                    { 160L, 33L, 66L },
                    { 153L, 32L, 66L },
                    { 247L, 49L, 31L },
                    { 245L, 49L, 12L },
                    { 148L, 31L, 49L },
                    { 58L, 12L, 49L },
                    { 242L, 48L, 47L },
                    { 236L, 47L, 48L },
                    { 44L, 9L, 67L },
                    { 434L, 88L, 22L },
                    { 433L, 88L, 19L },
                    { 432L, 88L, 16L },
                    { 165L, 34L, 48L },
                    { 116L, 23L, 48L },
                    { 200L, 41L, 34L },
                    { 164L, 34L, 41L },
                    { 163L, 34L, 23L },
                    { 162L, 34L, 17L },
                    { 114L, 23L, 34L },
                    { 79L, 17L, 34L },
                    { 113L, 23L, 19L },
                    { 112L, 23L, 17L },
                    { 111L, 23L, 16L },
                    { 91L, 19L, 23L },
                    { 201L, 41L, 48L },
                    { 74L, 16L, 23L },
                    { 108L, 22L, 37L },
                    { 107L, 22L, 19L },
                    { 106L, 22L, 18L },
                    { 90L, 19L, 22L },
                    { 83L, 18L, 22L },
                    { 422L, 86L, 17L },
                    { 81L, 17L, 86L },
                    { 78L, 17L, 16L },
                    { 73L, 16L, 17L },
                    { 290L, 57L, 45L },
                    { 289L, 57L, 36L },
                    { 288L, 57L, 28L },
                    { 177L, 37L, 22L },
                    { 237L, 47L, 83L },
                    { 238L, 48L, 23L },
                    { 241L, 48L, 41L },
                    { 431L, 87L, 88L },
                    { 181L, 37L, 88L },
                    { 117L, 23L, 88L },
                    { 110L, 22L, 88L },
                    { 94L, 19L, 88L },
                    { 77L, 16L, 88L },
                    { 430L, 87L, 80L },
                    { 429L, 87L, 50L },
                    { 428L, 87L, 38L },
                    { 427L, 87L, 37L },
                    { 426L, 87L, 16L },
                    { 396L, 80L, 87L },
                    { 240L, 48L, 34L },
                    { 255L, 50L, 87L },
                    { 180L, 37L, 87L },
                    { 76L, 16L, 87L },
                    { 425L, 86L, 80L },
                    { 395L, 80L, 86L },
                    { 394L, 80L, 50L },
                    { 393L, 80L, 17L },
                    { 392L, 80L, 16L },
                    { 253L, 50L, 80L },
                    { 80L, 17L, 80L },
                    { 75L, 16L, 80L },
                    { 326L, 65L, 41L },
                    { 202L, 41L, 65L },
                    { 186L, 38L, 87L },
                    { 287L, 57L, 21L },
                    { 243L, 48L, 83L },
                    { 407L, 83L, 12L },
                    { 22L, 4L, 25L },
                    { 372L, 75L, 74L },
                    { 371L, 75L, 1L },
                    { 370L, 74L, 75L },
                    { 6L, 1L, 75L },
                    { 369L, 74L, 39L },
                    { 367L, 74L, 1L },
                    { 193L, 39L, 74L },
                    { 5L, 1L, 74L },
                    { 360L, 72L, 70L },
                    { 347L, 70L, 72L },
                    { 346L, 70L, 44L },
                    { 345L, 70L, 43L },
                    { 344L, 70L, 39L },
                    { 343L, 70L, 25L },
                    { 342L, 70L, 7L },
                    { 341L, 70L, 1L },
                    { 219L, 44L, 70L },
                    { 212L, 43L, 70L },
                    { 192L, 39L, 70L },
                    { 125L, 25L, 70L },
                    { 36L, 7L, 70L },
                    { 3L, 1L, 70L },
                    { 324L, 64L, 44L },
                    { 323L, 64L, 43L },
                    { 121L, 25L, 4L },
                    { 19L, 4L, 5L },
                    { 25L, 5L, 4L },
                    { 26L, 5L, 25L },
                    { 419L, 85L, 13L },
                    { 418L, 85L, 7L },
                    { 417L, 85L, 4L },
                    { 416L, 84L, 85L },
                    { 149L, 31L, 85L },
                    { 126L, 25L, 85L },
                    { 63L, 13L, 85L },
                    { 37L, 7L, 85L },
                    { 24L, 4L, 85L },
                    { 415L, 84L, 13L },
                    { 414L, 84L, 6L },
                    { 413L, 84L, 4L },
                    { 322L, 64L, 22L },
                    { 62L, 13L, 84L },
                    { 23L, 4L, 84L },
                    { 145L, 31L, 13L },
                    { 61L, 13L, 31L },
                    { 21L, 4L, 13L },
                    { 29L, 6L, 4L },
                    { 20L, 4L, 6L },
                    { 368L, 74L, 5L },
                    { 189L, 39L, 5L },
                    { 188L, 39L, 5L },
                    { 122L, 25L, 5L },
                    { 28L, 5L, 74L },
                    { 27L, 5L, 39L },
                    { 30L, 6L, 84L },
                    { 321L, 64L, 19L },
                    { 320L, 64L, 15L },
                    { 319L, 64L, 3L },
                    { 71L, 15L, 49L },
                    { 70L, 15L, 47L },
                    { 68L, 15L, 19L },
                    { 67L, 15L, 12L },
                    { 54L, 12L, 15L },
                    { 244L, 49L, 7L },
                    { 143L, 31L, 7L },
                    { 35L, 7L, 49L },
                    { 32L, 7L, 31L },
                    { 355L, 72L, 3L },
                    { 294L, 59L, 3L },
                    { 105L, 22L, 3L },
                    { 89L, 19L, 15L },
                    { 82L, 18L, 3L },
                    { 16L, 3L, 59L },
                    { 14L, 3L, 22L },
                    { 13L, 3L, 18L },
                    { 354L, 72L, 1L },
                    { 194L, 40L, 1L },
                    { 4L, 1L, 72L },
                    { 2L, 1L, 40L },
                    { 412L, 83L, 82L },
                    { 411L, 83L, 48L },
                    { 410L, 83L, 47L },
                    { 409L, 83L, 33L },
                    { 408L, 83L, 32L },
                    { 18L, 3L, 72L },
                    { 406L, 82L, 83L },
                    { 233L, 47L, 15L },
                    { 31L, 7L, 25L },
                    { 218L, 44L, 64L },
                    { 211L, 43L, 64L },
                    { 109L, 22L, 64L },
                    { 93L, 19L, 64L },
                    { 72L, 15L, 64L },
                    { 17L, 3L, 64L },
                    { 248L, 49L, 44L },
                    { 217L, 44L, 49L },
                    { 216L, 44L, 43L },
                    { 215L, 44L, 15L },
                    { 214L, 44L, 7L },
                    { 210L, 43L, 44L },
                    { 246L, 49L, 15L },
                    { 69L, 15L, 44L },
                    { 358L, 72L, 43L },
                    { 213L, 43L, 72L },
                    { 209L, 43L, 3L },
                    { 15L, 3L, 43L },
                    { 191L, 39L, 25L },
                    { 190L, 39L, 7L },
                    { 187L, 39L, 1L },
                    { 124L, 25L, 39L },
                    { 33L, 7L, 39L },
                    { 1L, 1L, 39L },
                    { 146L, 31L, 25L },
                    { 123L, 25L, 7L },
                    { 34L, 7L, 44L },
                    { 223L, 45L, 57L },
                    { 175L, 36L, 57L },
                    { 142L, 28L, 57L },
                    { 353L, 71L, 91L },
                    { 120L, 24L, 91L },
                    { 449L, 90L, 78L },
                    { 448L, 90L, 59L },
                    { 447L, 90L, 46L },
                    { 446L, 90L, 20L },
                    { 384L, 78L, 90L },
                    { 299L, 59L, 90L },
                    { 230L, 46L, 90L },
                    { 101L, 20L, 90L },
                    { 88L, 18L, 90L },
                    { 359L, 72L, 59L },
                    { 357L, 72L, 40L },
                    { 356L, 72L, 20L },
                    { 298L, 59L, 72L },
                    { 198L, 40L, 72L },
                    { 100L, 20L, 72L },
                    { 350L, 71L, 40L },
                    { 349L, 71L, 24L },
                    { 348L, 71L, 20L },
                    { 197L, 40L, 71L },
                    { 119L, 24L, 71L },
                    { 99L, 20L, 71L },
                    { 297L, 59L, 46L },
                    { 296L, 59L, 20L },
                    { 450L, 91L, 24L },
                    { 452L, 91L, 71L },
                    { 64L, 14L, 26L },
                    { 127L, 26L, 14L },
                    { 305L, 61L, 26L },
                    { 304L, 61L, 2L },
                    { 129L, 26L, 61L },
                    { 10L, 2L, 61L },
                    { 300L, 60L, 2L },
                    { 9L, 2L, 60L },
                    { 379L, 78L, 2L },
                    { 11L, 2L, 78L },
                    { 376L, 77L, 26L },
                    { 131L, 26L, 77L },
                    { 313L, 62L, 51L },
                    { 312L, 62L, 27L },
                    { 295L, 59L, 18L },
                    { 311L, 62L, 26L },
                    { 259L, 51L, 62L },
                    { 137L, 27L, 62L },
                    { 130L, 26L, 62L },
                    { 66L, 14L, 62L },
                    { 256L, 51L, 14L },
                    { 65L, 14L, 51L },
                    { 472L, 96L, 26L },
                    { 387L, 79L, 26L },
                    { 134L, 27L, 26L },
                    { 133L, 26L, 96L },
                    { 132L, 26L, 79L },
                    { 128L, 26L, 27L },
                    { 310L, 62L, 14L },
                    { 228L, 46L, 59L },
                    { 98L, 20L, 59L },
                    { 87L, 18L, 59L },
                    { 476L, 96L, 94L },
                    { 475L, 96L, 93L },
                    { 474L, 96L, 79L },
                    { 466L, 94L, 96L },
                    { 463L, 93L, 96L },
                    { 391L, 79L, 96L },
                    { 386L, 78L, 96L },
                    { 471L, 95L, 94L },
                    { 470L, 95L, 93L },
                    { 469L, 95L, 92L },
                    { 468L, 95L, 78L },
                    { 467L, 95L, 76L },
                    { 139L, 27L, 79L },
                    { 465L, 94L, 95L },
                    { 375L, 76L, 95L },
                    { 464L, 94L, 93L },
                    { 462L, 93L, 94L },
                    { 374L, 76L, 94L },
                    { 461L, 93L, 79L },
                    { 460L, 93L, 76L },
                    { 458L, 92L, 93L },
                    { 390L, 79L, 93L },
                    { 373L, 76L, 93L },
                    { 457L, 92L, 79L },
                    { 456L, 92L, 78L },
                    { 389L, 79L, 92L },
                    { 459L, 92L, 95L },
                    { 306L, 61L, 77L },
                    { 140L, 27L, 92L },
                    { 454L, 92L, 27L },
                    { 196L, 40L, 24L },
                    { 195L, 40L, 20L },
                    { 118L, 24L, 40L },
                    { 96L, 20L, 40L },
                    { 455L, 92L, 46L },
                    { 381L, 78L, 46L },
                    { 231L, 46L, 92L },
                    { 229L, 46L, 78L },
                    { 227L, 46L, 42L },
                    { 226L, 46L, 27L },
                    { 225L, 46L, 18L },
                    { 207L, 42L, 46L },
                    { 388L, 79L, 27L },
                    { 136L, 27L, 46L },
                    { 206L, 42L, 38L },
                    { 205L, 42L, 37L },
                    { 204L, 42L, 27L },
                    { 203L, 42L, 18L },
                    { 183L, 38L, 42L },
                    { 179L, 37L, 42L },
                    { 135L, 27L, 42L },
                    { 85L, 18L, 42L },
                    { 182L, 38L, 37L },
                    { 178L, 37L, 38L },
                    { 176L, 37L, 18L },
                    { 84L, 18L, 37L },
                    { 86L, 18L, 46L },
                    { 307L, 61L, 78L },
                    { 309L, 61L, 96L },
                    { 377L, 77L, 61L },
                    { 275L, 54L, 51L },
                    { 274L, 54L, 50L },
                    { 273L, 54L, 45L },
                    { 258L, 51L, 54L },
                    { 251L, 50L, 54L },
                    { 222L, 45L, 54L },
                    { 250L, 50L, 45L },
                    { 249L, 50L, 38L },
                    { 221L, 45L, 50L },
                    { 184L, 38L, 50L },
                    { 453L, 91L, 89L },
                    { 444L, 89L, 91L },
                    { 276L, 54L, 62L },
                    { 443L, 89L, 71L },
                    { 441L, 89L, 68L },
                    { 440L, 89L, 58L },
                    { 439L, 89L, 56L },
                    { 438L, 89L, 55L },
                    { 437L, 89L, 53L },
                    { 352L, 71L, 89L },
                    { 339L, 69L, 89L },
                    { 336L, 68L, 89L },
                    { 293L, 58L, 89L },
                    { 286L, 56L, 89L },
                    { 281L, 55L, 89L },
                    { 271L, 53L, 89L },
                    { 442L, 89L, 69L },
                    { 451L, 91L, 69L },
                    { 314L, 62L, 54L },
                    { 185L, 38L, 73L },
                    { 104L, 21L, 57L },
                    { 272L, 54L, 36L },
                    { 257L, 51L, 36L },
                    { 220L, 45L, 36L },
                    { 174L, 36L, 54L },
                    { 173L, 36L, 51L },
                    { 172L, 36L, 50L },
                    { 171L, 36L, 45L },
                    { 170L, 36L, 21L },
                    { 103L, 21L, 36L },
                    { 141L, 28L, 21L },
                    { 102L, 21L, 28L },
                    { 138L, 27L, 73L },
                    { 424L, 86L, 50L },
                    { 254L, 50L, 86L },
                    { 224L, 45L, 86L },
                    { 366L, 73L, 62L },
                    { 365L, 73L, 54L },
                    { 364L, 73L, 50L },
                    { 363L, 73L, 42L },
                    { 362L, 73L, 38L },
                    { 361L, 73L, 27L },
                    { 315L, 62L, 73L },
                    { 277L, 54L, 73L },
                    { 252L, 50L, 73L },
                    { 208L, 42L, 73L },
                    { 423L, 86L, 45L },
                    { 420L, 85L, 25L },
                    { 340L, 69L, 91L },
                    { 337L, 69L, 68L },
                    { 8L, 2L, 52L },
                    { 445L, 90L, 10L },
                    { 380L, 78L, 10L },
                    { 95L, 20L, 10L },
                    { 49L, 10L, 90L },
                    { 48L, 10L, 78L },
                    { 45L, 10L, 20L },
                    { 301L, 60L, 8L },
                    { 41L, 8L, 60L },
                    { 38L, 8L, 2L },
                    { 7L, 2L, 8L },
                    { 401L, 81L, 77L },
                    { 39L, 8L, 52L },
                    { 400L, 81L, 63L },
                    { 398L, 81L, 60L },
                    { 397L, 81L, 2L },
                    { 378L, 77L, 81L },
                    { 318L, 63L, 81L },
                    { 308L, 61L, 81L },
                    { 303L, 60L, 81L },
                    { 12L, 2L, 81L },
                    { 317L, 63L, 60L },
                    { 316L, 63L, 2L },
                    { 302L, 60L, 63L },
                    { 473L, 96L, 61L },
                    { 383L, 78L, 61L },
                    { 399L, 81L, 61L },
                    { 338L, 69L, 71L },
                    { 46L, 10L, 52L },
                    { 261L, 52L, 8L },
                    { 335L, 68L, 69L },
                    { 334L, 68L, 58L },
                    { 333L, 68L, 55L },
                    { 292L, 58L, 68L },
                    { 280L, 55L, 68L },
                    { 291L, 58L, 55L },
                    { 279L, 55L, 58L },
                    { 285L, 56L, 55L },
                    { 284L, 56L, 53L },
                    { 283L, 56L, 52L },
                    { 282L, 56L, 8L },
                    { 278L, 55L, 56L },
                    { 260L, 52L, 2L },
                    { 269L, 53L, 56L },
                    { 40L, 8L, 56L },
                    { 351L, 71L, 53L },
                    { 270L, 53L, 71L },
                    { 268L, 53L, 52L },
                    { 267L, 53L, 20L },
                    { 266L, 53L, 10L },
                    { 263L, 52L, 53L },
                    { 97L, 20L, 53L },
                    { 47L, 10L, 53L },
                    { 382L, 78L, 52L },
                    { 265L, 52L, 78L },
                    { 262L, 52L, 10L },
                    { 264L, 52L, 56L },
                    { 421L, 85L, 31L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdjacentDepartments_SecondDepartmentId",
                table: "AdjacentDepartments",
                column: "SecondDepartmentId");

            migrationBuilder.CreateIndex(
                name: "UK_AdjacentDepartment_FirstDepartment_SecondDepartment",
                table: "AdjacentDepartments",
                columns: new[] { "FirstDepartmentId", "SecondDepartmentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRoleClaim_RoleId",
                table: "ApplicationRoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserFavoriteDepartment_UserId",
                table: "ApplicationUserFavoriteDepartment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UK_PrimaryKey",
                table: "ApplicationUserFavoriteDepartment",
                columns: new[] { "DepartmentId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRole_NormalizedName",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "ix_ApplicationUserLogin_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_NormalizedEmail",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UK_ApplicationUser_NormalizedUserName",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserTokens_UserId",
                table: "AspNetUserTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Club_Name",
                table: "Club",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Club_ShortName",
                table: "Club",
                column: "ShortName");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_Date",
                table: "Competition",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_FK_Competition_Club_Organizer",
                table: "Competition",
                column: "FK_Competition_Club_Organizer");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_Club_Organizer",
                table: "Competition",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "UX_Department_Code",
                table: "Department",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Department_RegionId",
                table: "Department",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "UX_Region_Code",
                table: "Region",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRole_RoleId",
                schema: "identity",
                table: "ApplicationUserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdjacentDepartments");

            migrationBuilder.DropTable(
                name: "ApplicationRoleClaim");

            migrationBuilder.DropTable(
                name: "ApplicationUserFavoriteDepartment");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Competition");

            migrationBuilder.DropTable(
                name: "ApplicationUserRole",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
