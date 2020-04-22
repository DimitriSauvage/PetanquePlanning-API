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
                    Id = table.Column<Guid>(nullable: false),
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
                    Id = table.Column<Guid>(nullable: false),
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
                    ClubId = table.Column<Guid>(nullable: false),
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
                    Id = table.Column<Guid>(nullable: false),
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
                    Id = table.Column<Guid>(nullable: false),
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
                    RoleId = table.Column<Guid>(nullable: false),
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
                    UserId = table.Column<Guid>(nullable: false),
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
                    Id = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 50, nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(maxLength: 100, nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
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
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
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
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
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
                    Id = table.Column<Guid>(nullable: false),
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
                    FK_Competition_Club_Organizer = table.Column<Guid>(nullable: false),
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
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    RegionId = table.Column<Guid>(nullable: false)
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
                    Id = table.Column<Guid>(nullable: false),
                    FirstDepartmentId = table.Column<Guid>(nullable: false),
                    SecondDepartmentId = table.Column<Guid>(nullable: false)
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
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserFavoriteDepartment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DepartmentId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
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
                    { new Guid("7c40912e-1f5d-43d5-8ff7-77bb0be94b0d"), "0469fddd-36a7-4601-a255-a07c1727e51b", null, "Administrateur", "Administrateur" },
                    { new Guid("f2138dc1-eb75-4057-8f6b-80e3baa02ddf"), "1469fddd-36a7-4601-a255-a07c1727e51b", null, "Utilisateur", "Utilisateur" }
                });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("bbfa939b-d5c7-4428-9537-dc063457270a"), "84", "Auvergne-Rhône-Alpes" },
                    { new Guid("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15"), "76", "Occitanie" },
                    { new Guid("554a957c-4b70-4893-8ed7-4c8e09ad2b00"), "75", "Nouvelle-Aquitaine" },
                    { new Guid("14225638-c769-458b-995e-53629890d38d"), "53", "Bretagne" },
                    { new Guid("e3a4faa4-4582-40d9-b5ac-154d66170041"), "52", "Pays de la Loire" },
                    { new Guid("5823a48a-b05e-47cb-91eb-f1d0877a07b5"), "44", "Grand Est" },
                    { new Guid("3a008295-2e8f-42e9-aa87-485d150d58db"), "32", "Hauts-de-France" },
                    { new Guid("26a3ed8e-ef43-46df-8722-38d48170c391"), "28", "Normandie" },
                    { new Guid("c1524a03-e7c5-4959-ac10-4e569196e743"), "27", "Bourgogne-Franche-Comté" },
                    { new Guid("6651a27f-e548-4404-a7a5-c8b956d4906e"), "24", "Centre-Val de Loire" },
                    { new Guid("b6f686d0-13a7-47db-9e8e-d888e36cdce8"), "11", "Île-de-France" },
                    { new Guid("0ffa1f77-f8dc-427c-a5f7-95dbba89310f"), "06", "Mayotte" },
                    { new Guid("966edde0-a3fa-4f4a-8a27-7231c2ebf181"), "04", "La Réunion" },
                    { new Guid("6ac78d8f-1ec7-48fb-a9da-a41e6223fa9b"), "03", "Guyane" },
                    { new Guid("a4798a24-c3d0-4311-8735-e93a30fdeec7"), "02", "Martinique" },
                    { new Guid("4357815c-da7e-4919-8f2e-6df3228cddbe"), "01", "Guadeloupe" },
                    { new Guid("00d9720b-6f64-477d-8651-304b74c2f4c3"), "93", "Provence-Alpes-Côte d'Azur" },
                    { new Guid("7ce01654-58a0-4c59-b5af-62351080e52f"), "94", "Corse" }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Code", "Name", "RegionId" },
                values: new object[,]
                {
                    { new Guid("5c2f93c4-a0f6-407d-8aae-5fb2a4e3f35b"), "971", "Guadeloupe", new Guid("4357815c-da7e-4919-8f2e-6df3228cddbe") },
                    { new Guid("d56fc07c-39f9-42c6-aaf5-640b2b5f6124"), "31", "Haute-Garonne", new Guid("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15") },
                    { new Guid("11d695a1-9893-4f18-a2ab-f61078233585"), "30", "Gard", new Guid("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15") },
                    { new Guid("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd"), "12", "Aveyron", new Guid("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15") },
                    { new Guid("aec85880-4ac9-43c9-be3f-a47a41d0e88e"), "11", "Aude", new Guid("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15") },
                    { new Guid("77d7dc5d-545b-4f53-8db2-bf3245f3c131"), "09", "Ariège", new Guid("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15") },
                    { new Guid("6af0ad8b-b789-4e9c-a191-e39711617d83"), "87", "Haute-Vienne", new Guid("554a957c-4b70-4893-8ed7-4c8e09ad2b00") },
                    { new Guid("394ed11a-fe64-4163-b9da-eed89db9d732"), "86", "Vienne", new Guid("554a957c-4b70-4893-8ed7-4c8e09ad2b00") },
                    { new Guid("479db9d5-9d65-473c-94c9-c84bfe8a9efc"), "79", "Deux-Sèvres", new Guid("554a957c-4b70-4893-8ed7-4c8e09ad2b00") },
                    { new Guid("895ce97a-633b-4782-b060-f276b4141e90"), "64", "Pyrénées-Atlantiques", new Guid("554a957c-4b70-4893-8ed7-4c8e09ad2b00") },
                    { new Guid("cbf1b899-4d3d-4155-bae7-07915a6b8c09"), "47", "Lot-et-Garonne", new Guid("554a957c-4b70-4893-8ed7-4c8e09ad2b00") },
                    { new Guid("d3cb1fd0-444e-4e2a-82a2-7382536b1770"), "40", "Landes", new Guid("554a957c-4b70-4893-8ed7-4c8e09ad2b00") },
                    { new Guid("e7931a2e-e969-43a2-9c71-542549fc41aa"), "33", "Gironde", new Guid("554a957c-4b70-4893-8ed7-4c8e09ad2b00") },
                    { new Guid("44cc60d3-d233-4bf1-92c1-539961e5be6b"), "24", "Dordogne", new Guid("554a957c-4b70-4893-8ed7-4c8e09ad2b00") },
                    { new Guid("28cce0f5-1692-4db3-af74-e4efc3aef1e6"), "23", "Creuse", new Guid("554a957c-4b70-4893-8ed7-4c8e09ad2b00") },
                    { new Guid("c1bd362f-88bd-4e6a-8928-ad6d29ee549a"), "19", "Corrèze", new Guid("554a957c-4b70-4893-8ed7-4c8e09ad2b00") },
                    { new Guid("8963790c-6864-429c-bd8b-35338c53a170"), "17", "Charente-Maritime", new Guid("554a957c-4b70-4893-8ed7-4c8e09ad2b00") },
                    { new Guid("cbfb8d4a-5fad-4c9e-8faa-d035cd093928"), "16", "Charente", new Guid("554a957c-4b70-4893-8ed7-4c8e09ad2b00") },
                    { new Guid("c9220a79-ac83-4e46-a397-0830b052769e"), "56", "Morbihan", new Guid("14225638-c769-458b-995e-53629890d38d") },
                    { new Guid("906ac8fa-ce00-4194-8d13-f517242777f4"), "35", "Ille-et-Vilaine", new Guid("14225638-c769-458b-995e-53629890d38d") },
                    { new Guid("57eb6e76-cfe4-491a-8c5b-2cbbf5d44217"), "29", "Finistère", new Guid("14225638-c769-458b-995e-53629890d38d") },
                    { new Guid("f351db6b-828b-462a-a032-1354a73733e8"), "22", "Côtes-d'Armor", new Guid("14225638-c769-458b-995e-53629890d38d") },
                    { new Guid("e007dcb1-8678-47ab-90dd-441f76873b9e"), "32", "Gers", new Guid("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15") },
                    { new Guid("1632f86b-846f-4a69-b4a2-e5f6dd7d4742"), "34", "Hérault", new Guid("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15") },
                    { new Guid("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b"), "46", "Lot", new Guid("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15") },
                    { new Guid("82973925-433a-4f55-89c8-f41fc398a0c2"), "48", "Lozère", new Guid("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15") },
                    { new Guid("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1"), "84", "Vaucluse", new Guid("00d9720b-6f64-477d-8651-304b74c2f4c3") },
                    { new Guid("7fdeabb6-fdd2-49ff-ad5d-b35f56f9db5b"), "83", "Var", new Guid("00d9720b-6f64-477d-8651-304b74c2f4c3") },
                    { new Guid("95f28447-33e7-449f-8bd7-ecdabaae501f"), "13", "Bouches-du-Rhône", new Guid("00d9720b-6f64-477d-8651-304b74c2f4c3") },
                    { new Guid("6b787904-7e30-450b-aac4-2867a6f72100"), "06", "Alpes-Maritimes", new Guid("00d9720b-6f64-477d-8651-304b74c2f4c3") },
                    { new Guid("85ef4758-c7a8-4cbc-9416-caaea32e4d05"), "05", "Hautes-Alpes", new Guid("00d9720b-6f64-477d-8651-304b74c2f4c3") },
                    { new Guid("1bf0a210-c750-4e98-9151-7eaefa8185c7"), "04", "Alpes-de-Haute-Provence", new Guid("00d9720b-6f64-477d-8651-304b74c2f4c3") },
                    { new Guid("97a9f4b4-e8d4-4c1a-b6e7-e05426969f58"), "74", "Haute-Savoie", new Guid("bbfa939b-d5c7-4428-9537-dc063457270a") },
                    { new Guid("661ba9ad-e1e9-413c-bdfe-66401edd5596"), "73", "Savoie", new Guid("bbfa939b-d5c7-4428-9537-dc063457270a") },
                    { new Guid("069da2fe-b9c4-49d8-9ae6-77530d8d85ee"), "69", "Rhône", new Guid("bbfa939b-d5c7-4428-9537-dc063457270a") },
                    { new Guid("11560417-8292-4dfd-b345-9e4a207ee6ca"), "63", "Puy-de-Dôme", new Guid("bbfa939b-d5c7-4428-9537-dc063457270a") },
                    { new Guid("f8c9d891-e9c5-43a1-8bfb-62f2cf51ab79"), "85", "Vendée", new Guid("e3a4faa4-4582-40d9-b5ac-154d66170041") },
                    { new Guid("470669cc-1d05-4d07-838e-3aea8923d7c6"), "43", "Haute-Loire", new Guid("bbfa939b-d5c7-4428-9537-dc063457270a") },
                    { new Guid("8ce39bf5-92de-48db-bb8b-30892a4a090f"), "38", "Isère", new Guid("bbfa939b-d5c7-4428-9537-dc063457270a") },
                    { new Guid("6a16c6c6-4b11-4651-b291-739fd143cb19"), "26", "Drôme", new Guid("bbfa939b-d5c7-4428-9537-dc063457270a") },
                    { new Guid("95295597-7518-4999-bdd7-52ef36bd24c0"), "15", "Cantal", new Guid("bbfa939b-d5c7-4428-9537-dc063457270a") },
                    { new Guid("c1aed70b-666e-4f32-bee2-f52722d89b1f"), "07", "Ardèche", new Guid("bbfa939b-d5c7-4428-9537-dc063457270a") },
                    { new Guid("cc023a01-8a9b-4ed6-b41c-9388c363db49"), "03", "Allier", new Guid("bbfa939b-d5c7-4428-9537-dc063457270a") },
                    { new Guid("1ef7fde0-47b6-4fda-810c-44c33d1fbee8"), "01", "Ain", new Guid("bbfa939b-d5c7-4428-9537-dc063457270a") },
                    { new Guid("2d75fb26-8926-4607-b618-1d727cd31fe8"), "82", "Tarn-et-Garonne", new Guid("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15") },
                    { new Guid("7285b039-3ac9-4a21-9dcd-9fc96164e600"), "81", "Tarn", new Guid("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15") },
                    { new Guid("caa74253-c115-4cb7-8b63-ee23545a62ff"), "66", "Pyrénées-Orientales", new Guid("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15") },
                    { new Guid("4c3a1f47-f735-4390-ae4d-f979e16c562c"), "65", "Hautes-Pyrénées", new Guid("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15") },
                    { new Guid("dd1e3ba1-385c-4941-8d5b-dfbfa1554154"), "42", "Loire", new Guid("bbfa939b-d5c7-4428-9537-dc063457270a") },
                    { new Guid("8cf0438a-cb72-4ff1-9caa-7a40f4cc400a"), "2A", "Corse-du-Sud", new Guid("7ce01654-58a0-4c59-b5af-62351080e52f") },
                    { new Guid("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51"), "72", "Sarthe", new Guid("e3a4faa4-4582-40d9-b5ac-154d66170041") },
                    { new Guid("5f5ba403-ae25-440b-9f38-809881781211"), "49", "Maine-et-Loire", new Guid("e3a4faa4-4582-40d9-b5ac-154d66170041") },
                    { new Guid("4258f49d-10e3-4428-a398-66ffc5faa23f"), "39", "Jura", new Guid("c1524a03-e7c5-4959-ac10-4e569196e743") },
                    { new Guid("2acb1828-07a0-45fd-b52e-15b7eb6e02ce"), "25", "Doubs", new Guid("c1524a03-e7c5-4959-ac10-4e569196e743") },
                    { new Guid("dbde4b03-bd9c-4b18-81c3-9b24e0558003"), "21", "Côte-d'Or", new Guid("c1524a03-e7c5-4959-ac10-4e569196e743") },
                    { new Guid("1c05a510-8e08-4e61-94f1-d5b9661a2b08"), "45", "Loiret", new Guid("6651a27f-e548-4404-a7a5-c8b956d4906e") },
                    { new Guid("b59aa9c6-9441-4b8f-aabf-031eae7ef550"), "41", "Loir-et-Cher", new Guid("6651a27f-e548-4404-a7a5-c8b956d4906e") },
                    { new Guid("fbcf13f8-24f2-4f89-a9c0-bcada6f4ba62"), "37", "Indre-et-Loire", new Guid("6651a27f-e548-4404-a7a5-c8b956d4906e") },
                    { new Guid("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e"), "36", "Indre", new Guid("6651a27f-e548-4404-a7a5-c8b956d4906e") },
                    { new Guid("c8851fc2-7704-412d-b272-130cbed5f422"), "28", "Eure-et-Loir", new Guid("6651a27f-e548-4404-a7a5-c8b956d4906e") },
                    { new Guid("5cc49bd4-a1bf-4f4b-9744-13668eae12f0"), "18", "Cher", new Guid("6651a27f-e548-4404-a7a5-c8b956d4906e") },
                    { new Guid("24e44487-3f98-42b9-9b44-818e5d8d7bbd"), "95", "Val-d'Oise", new Guid("b6f686d0-13a7-47db-9e8e-d888e36cdce8") },
                    { new Guid("b10b8258-66e2-421a-bad5-cc76e1a3bb77"), "94", "Val-de-Marne", new Guid("b6f686d0-13a7-47db-9e8e-d888e36cdce8") },
                    { new Guid("7c7b530a-ff06-4ee3-bcfd-8a79bf094a9b"), "93", "Seine-Saint-Denis", new Guid("b6f686d0-13a7-47db-9e8e-d888e36cdce8") },
                    { new Guid("a484a81b-fcf0-42ea-82c2-ef353da33667"), "92", "Hauts-de-Seine", new Guid("b6f686d0-13a7-47db-9e8e-d888e36cdce8") },
                    { new Guid("b508db1d-d8dc-4998-bbce-b110e00ac954"), "91", "Essonne", new Guid("b6f686d0-13a7-47db-9e8e-d888e36cdce8") },
                    { new Guid("55b6f5bd-de1f-435f-a30d-e212e2684eb6"), "78", "Yvelines", new Guid("b6f686d0-13a7-47db-9e8e-d888e36cdce8") },
                    { new Guid("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"), "77", "Seine-et-Marne", new Guid("b6f686d0-13a7-47db-9e8e-d888e36cdce8") },
                    { new Guid("961e1f7f-fc6f-440e-b11a-426bd93c32f0"), "75", "Paris", new Guid("b6f686d0-13a7-47db-9e8e-d888e36cdce8") },
                    { new Guid("2159f71c-6099-4830-88c4-cc986d0e4186"), "976", "Mayotte", new Guid("0ffa1f77-f8dc-427c-a5f7-95dbba89310f") },
                    { new Guid("24c47aad-db8a-4631-b9a4-68a5245228be"), "974", "La Réunion", new Guid("966edde0-a3fa-4f4a-8a27-7231c2ebf181") },
                    { new Guid("8456ebcd-f507-4429-bdbc-376935ebd982"), "973", "Guyane", new Guid("6ac78d8f-1ec7-48fb-a9da-a41e6223fa9b") },
                    { new Guid("9a1cbd06-f1e9-4987-bef5-92987784887e"), "972", "Martinique", new Guid("a4798a24-c3d0-4311-8735-e93a30fdeec7") },
                    { new Guid("52f1f21c-bea3-498b-bafa-26846d550230"), "58", "Nièvre", new Guid("c1524a03-e7c5-4959-ac10-4e569196e743") },
                    { new Guid("52ee48da-49f3-4701-93de-f113946380c9"), "70", "Haute-Saône", new Guid("c1524a03-e7c5-4959-ac10-4e569196e743") },
                    { new Guid("63a854d0-a738-4684-9853-f83f051a88fc"), "71", "Saône-et-Loire", new Guid("c1524a03-e7c5-4959-ac10-4e569196e743") },
                    { new Guid("667fec95-c40d-4289-b5d9-4760525509f3"), "89", "Yonne", new Guid("c1524a03-e7c5-4959-ac10-4e569196e743") },
                    { new Guid("73d7b3b6-1018-4b19-a57b-d189d75c7c81"), "44", "Loire-Atlantique", new Guid("e3a4faa4-4582-40d9-b5ac-154d66170041") },
                    { new Guid("ff2b1187-63bf-46fa-a70c-4db6b323babb"), "88", "Vosges", new Guid("5823a48a-b05e-47cb-91eb-f1d0877a07b5") },
                    { new Guid("d7c383af-e3b6-468c-a4cb-e20f08856972"), "68", "Haut-Rhin", new Guid("5823a48a-b05e-47cb-91eb-f1d0877a07b5") },
                    { new Guid("5614ee02-1939-4ab9-94a7-c64070908c65"), "67", "Bas-Rhin", new Guid("5823a48a-b05e-47cb-91eb-f1d0877a07b5") },
                    { new Guid("6b921a7d-143a-4014-b113-862ded825b60"), "57", "Moselle", new Guid("5823a48a-b05e-47cb-91eb-f1d0877a07b5") },
                    { new Guid("310e87ad-0b29-470e-9120-b025a3a46c9f"), "55", "Meuse", new Guid("5823a48a-b05e-47cb-91eb-f1d0877a07b5") },
                    { new Guid("a435415d-d1f2-4af1-8de9-93af2ce43747"), "54", "Meurthe-et-Moselle", new Guid("5823a48a-b05e-47cb-91eb-f1d0877a07b5") },
                    { new Guid("3577171f-2b34-4d53-9aff-17885e7d4679"), "52", "Haute-Marne", new Guid("5823a48a-b05e-47cb-91eb-f1d0877a07b5") },
                    { new Guid("9498c4a1-398d-4c06-8b49-aa84290cf2ca"), "51", "Marne", new Guid("5823a48a-b05e-47cb-91eb-f1d0877a07b5") },
                    { new Guid("30ba0a20-3568-4484-9df1-151de6fd36c2"), "10", "Aube", new Guid("5823a48a-b05e-47cb-91eb-f1d0877a07b5") },
                    { new Guid("f1cfaa9c-44cc-4685-af6f-45ae258efb07"), "53", "Mayenne", new Guid("e3a4faa4-4582-40d9-b5ac-154d66170041") },
                    { new Guid("16cd59b4-3971-45ec-bd68-d26ac70d2da0"), "08", "Ardennes", new Guid("5823a48a-b05e-47cb-91eb-f1d0877a07b5") },
                    { new Guid("7591742b-97d3-4b0a-81a6-20a4247d47ca"), "62", "Pas-de-Calais", new Guid("3a008295-2e8f-42e9-aa87-485d150d58db") },
                    { new Guid("78476d14-2f28-4e95-874e-09f1d4fd0171"), "60", "Oise", new Guid("3a008295-2e8f-42e9-aa87-485d150d58db") },
                    { new Guid("9e8fd57a-abe9-4cd6-958c-53ec0ba6be80"), "59", "Nord", new Guid("3a008295-2e8f-42e9-aa87-485d150d58db") },
                    { new Guid("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee"), "02", "Aisne", new Guid("3a008295-2e8f-42e9-aa87-485d150d58db") },
                    { new Guid("b96c0bc3-abbb-49cc-a672-5ec6af45ca63"), "76", "Seine-Maritime", new Guid("26a3ed8e-ef43-46df-8722-38d48170c391") },
                    { new Guid("3489baa7-b17e-4003-a78f-cb156dee058e"), "61", "Orne", new Guid("26a3ed8e-ef43-46df-8722-38d48170c391") },
                    { new Guid("75020b4c-5dac-447f-941b-470fc5019eac"), "50", "Manche", new Guid("26a3ed8e-ef43-46df-8722-38d48170c391") },
                    { new Guid("a2ba1fd9-47c5-4938-b8b3-ab01bc245859"), "27", "Eure", new Guid("26a3ed8e-ef43-46df-8722-38d48170c391") },
                    { new Guid("785e7ff9-229a-426c-b664-479312d4cf8d"), "14", "Calvados", new Guid("26a3ed8e-ef43-46df-8722-38d48170c391") },
                    { new Guid("0bbca13e-e227-4aaa-a078-265c9133f278"), "90", "Territoire de Belfort", new Guid("c1524a03-e7c5-4959-ac10-4e569196e743") },
                    { new Guid("343e77cb-a854-416b-aeac-86c9ffad82ce"), "80", "Somme", new Guid("3a008295-2e8f-42e9-aa87-485d150d58db") },
                    { new Guid("2a24196d-0a4c-4928-9f79-bd498bcfc219"), "2B", "Haute-Corse", new Guid("7ce01654-58a0-4c59-b5af-62351080e52f") }
                });

            migrationBuilder.InsertData(
                table: "AdjacentDepartments",
                columns: new[] { "Id", "FirstDepartmentId", "SecondDepartmentId" },
                values: new object[,]
                {
                    { new Guid("747e0743-f48a-4f30-a452-ca90930a49d1"), new Guid("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"), new Guid("b508db1d-d8dc-4998-bbce-b110e00ac954") },
                    { new Guid("a15d15ea-7c9a-4e88-88cb-763e2503bb28"), new Guid("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd"), new Guid("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b") },
                    { new Guid("999ecc8a-3b95-4bfa-8806-0ef1ed75fd34"), new Guid("1632f86b-846f-4a69-b4a2-e5f6dd7d4742"), new Guid("11d695a1-9893-4f18-a2ab-f61078233585") },
                    { new Guid("e327229a-0f5a-45d0-ab17-8e59407071c2"), new Guid("1632f86b-846f-4a69-b4a2-e5f6dd7d4742"), new Guid("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd") },
                    { new Guid("c7ee3fd9-74d5-47b0-8b51-4bdaef0bf28b"), new Guid("1632f86b-846f-4a69-b4a2-e5f6dd7d4742"), new Guid("aec85880-4ac9-43c9-be3f-a47a41d0e88e") },
                    { new Guid("130a715d-e555-4f08-ab8f-77e71ca7c9f1"), new Guid("11d695a1-9893-4f18-a2ab-f61078233585"), new Guid("1632f86b-846f-4a69-b4a2-e5f6dd7d4742") },
                    { new Guid("b7b67b05-4841-4227-8ba1-34ed27cd4041"), new Guid("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd"), new Guid("1632f86b-846f-4a69-b4a2-e5f6dd7d4742") },
                    { new Guid("12e75442-3606-4a32-a27a-1336b4b52615"), new Guid("aec85880-4ac9-43c9-be3f-a47a41d0e88e"), new Guid("1632f86b-846f-4a69-b4a2-e5f6dd7d4742") },
                    { new Guid("9a8b7a2d-ccac-499c-ae29-d42e135d3672"), new Guid("895ce97a-633b-4782-b060-f276b4141e90"), new Guid("e007dcb1-8678-47ab-90dd-441f76873b9e") },
                    { new Guid("ca81544e-95ab-4b2c-b40a-433514dfad73"), new Guid("cbf1b899-4d3d-4155-bae7-07915a6b8c09"), new Guid("e007dcb1-8678-47ab-90dd-441f76873b9e") },
                    { new Guid("00cc3796-815f-4d68-ad4b-609909684b58"), new Guid("d3cb1fd0-444e-4e2a-82a2-7382536b1770"), new Guid("e007dcb1-8678-47ab-90dd-441f76873b9e") },
                    { new Guid("b38f93bc-6fb4-426f-a744-ddf2e554928b"), new Guid("e007dcb1-8678-47ab-90dd-441f76873b9e"), new Guid("895ce97a-633b-4782-b060-f276b4141e90") },
                    { new Guid("fc51d3b0-d4dd-415c-8d50-ff27742b8b11"), new Guid("e007dcb1-8678-47ab-90dd-441f76873b9e"), new Guid("cbf1b899-4d3d-4155-bae7-07915a6b8c09") },
                    { new Guid("703b816c-361a-48ff-988f-a50eb66f4df3"), new Guid("e007dcb1-8678-47ab-90dd-441f76873b9e"), new Guid("d3cb1fd0-444e-4e2a-82a2-7382536b1770") },
                    { new Guid("cb3e7c5a-efd2-40c4-ab75-cb66df34c763"), new Guid("e007dcb1-8678-47ab-90dd-441f76873b9e"), new Guid("d56fc07c-39f9-42c6-aaf5-640b2b5f6124") },
                    { new Guid("04effb87-77e2-452a-af46-8703fecd1e09"), new Guid("d56fc07c-39f9-42c6-aaf5-640b2b5f6124"), new Guid("e007dcb1-8678-47ab-90dd-441f76873b9e") },
                    { new Guid("421830c5-77dd-4306-933e-e972c2ea4eef"), new Guid("d56fc07c-39f9-42c6-aaf5-640b2b5f6124"), new Guid("aec85880-4ac9-43c9-be3f-a47a41d0e88e") },
                    { new Guid("b82272de-846a-4c01-85a6-f15dce4d188a"), new Guid("d56fc07c-39f9-42c6-aaf5-640b2b5f6124"), new Guid("77d7dc5d-545b-4f53-8db2-bf3245f3c131") },
                    { new Guid("18b14374-ab40-4c06-8b67-d46c8cecc8ba"), new Guid("aec85880-4ac9-43c9-be3f-a47a41d0e88e"), new Guid("d56fc07c-39f9-42c6-aaf5-640b2b5f6124") },
                    { new Guid("f9a1cc9b-f637-442e-8fa2-ad816379f6a7"), new Guid("77d7dc5d-545b-4f53-8db2-bf3245f3c131"), new Guid("d56fc07c-39f9-42c6-aaf5-640b2b5f6124") },
                    { new Guid("262d8b28-b8b0-4091-bd7a-f3fbb9782f0c"), new Guid("11d695a1-9893-4f18-a2ab-f61078233585"), new Guid("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd") },
                    { new Guid("01204847-8a56-4c1f-8de3-8a42ee27808a"), new Guid("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd"), new Guid("11d695a1-9893-4f18-a2ab-f61078233585") },
                    { new Guid("b737aa71-56b0-4a0e-9ad1-b67f14dbe401"), new Guid("aec85880-4ac9-43c9-be3f-a47a41d0e88e"), new Guid("77d7dc5d-545b-4f53-8db2-bf3245f3c131") },
                    { new Guid("e3e0a4da-cc02-403d-97b5-4bf1277d398f"), new Guid("77d7dc5d-545b-4f53-8db2-bf3245f3c131"), new Guid("aec85880-4ac9-43c9-be3f-a47a41d0e88e") },
                    { new Guid("eb2366df-92af-4a5e-a979-eb9046ee965d"), new Guid("6af0ad8b-b789-4e9c-a191-e39711617d83"), new Guid("394ed11a-fe64-4163-b9da-eed89db9d732") },
                    { new Guid("c3520e64-ef8d-4014-ba8d-3d7812ebe5af"), new Guid("6af0ad8b-b789-4e9c-a191-e39711617d83"), new Guid("44cc60d3-d233-4bf1-92c1-539961e5be6b") },
                    { new Guid("339c93ae-2e00-4c81-89a8-638562047b98"), new Guid("c1bd362f-88bd-4e6a-8928-ad6d29ee549a"), new Guid("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b") },
                    { new Guid("98488684-649d-4279-8953-e1b77ffbc05f"), new Guid("44cc60d3-d233-4bf1-92c1-539961e5be6b"), new Guid("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b") },
                    { new Guid("daf2a88b-2506-4e17-8e13-50b6f30d2e80"), new Guid("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b"), new Guid("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd") },
                    { new Guid("aacc9db7-301c-4d08-87dd-571dcae62db3"), new Guid("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b"), new Guid("c1bd362f-88bd-4e6a-8928-ad6d29ee549a") },
                    { new Guid("cc3b4e79-0cce-43bb-b07a-5532ad5d9247"), new Guid("d56fc07c-39f9-42c6-aaf5-640b2b5f6124"), new Guid("2d75fb26-8926-4607-b618-1d727cd31fe8") },
                    { new Guid("e000bcab-c340-4719-b00f-c0a7aa78eaee"), new Guid("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd"), new Guid("2d75fb26-8926-4607-b618-1d727cd31fe8") },
                    { new Guid("7c9d87d7-a35f-4d36-95ad-44e2fea7be49"), new Guid("7285b039-3ac9-4a21-9dcd-9fc96164e600"), new Guid("1632f86b-846f-4a69-b4a2-e5f6dd7d4742") },
                    { new Guid("58c8cd03-09fe-4b8b-aad6-95f1be471bf6"), new Guid("7285b039-3ac9-4a21-9dcd-9fc96164e600"), new Guid("d56fc07c-39f9-42c6-aaf5-640b2b5f6124") },
                    { new Guid("72dced46-584f-4a40-ba78-e87572a36cb8"), new Guid("7285b039-3ac9-4a21-9dcd-9fc96164e600"), new Guid("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd") },
                    { new Guid("71e68d7a-c454-4f64-a0db-61ee196e54f4"), new Guid("7285b039-3ac9-4a21-9dcd-9fc96164e600"), new Guid("aec85880-4ac9-43c9-be3f-a47a41d0e88e") },
                    { new Guid("2786ccc7-bc75-4698-b060-d94c1336c23d"), new Guid("1632f86b-846f-4a69-b4a2-e5f6dd7d4742"), new Guid("7285b039-3ac9-4a21-9dcd-9fc96164e600") },
                    { new Guid("763dfe4a-f0c9-4069-8f85-71d48198ae1c"), new Guid("d56fc07c-39f9-42c6-aaf5-640b2b5f6124"), new Guid("7285b039-3ac9-4a21-9dcd-9fc96164e600") },
                    { new Guid("189b3e61-cb8b-45fc-8bef-31909bb4d742"), new Guid("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd"), new Guid("7285b039-3ac9-4a21-9dcd-9fc96164e600") },
                    { new Guid("bf711c33-5b64-4f36-bb28-cdacbb66fa33"), new Guid("aec85880-4ac9-43c9-be3f-a47a41d0e88e"), new Guid("7285b039-3ac9-4a21-9dcd-9fc96164e600") },
                    { new Guid("3e491213-453a-4063-ac60-39189a9f32ef"), new Guid("caa74253-c115-4cb7-8b63-ee23545a62ff"), new Guid("aec85880-4ac9-43c9-be3f-a47a41d0e88e") },
                    { new Guid("7c3d373d-7c7d-47ef-9dd5-ad75773cbf00"), new Guid("caa74253-c115-4cb7-8b63-ee23545a62ff"), new Guid("77d7dc5d-545b-4f53-8db2-bf3245f3c131") },
                    { new Guid("f54891ad-fcf7-4e7a-9f1a-25c116dc6248"), new Guid("6af0ad8b-b789-4e9c-a191-e39711617d83"), new Guid("28cce0f5-1692-4db3-af74-e4efc3aef1e6") },
                    { new Guid("cf051888-36b0-4710-8540-4d549d6cf13b"), new Guid("77d7dc5d-545b-4f53-8db2-bf3245f3c131"), new Guid("caa74253-c115-4cb7-8b63-ee23545a62ff") },
                    { new Guid("5596172c-969a-4c35-b836-95661a607e9b"), new Guid("4c3a1f47-f735-4390-ae4d-f979e16c562c"), new Guid("e007dcb1-8678-47ab-90dd-441f76873b9e") },
                    { new Guid("67c92055-65ff-4f49-b941-34e939207ade"), new Guid("4c3a1f47-f735-4390-ae4d-f979e16c562c"), new Guid("d56fc07c-39f9-42c6-aaf5-640b2b5f6124") },
                    { new Guid("4aa0c76e-257d-4646-9753-cfa30c84e4df"), new Guid("895ce97a-633b-4782-b060-f276b4141e90"), new Guid("4c3a1f47-f735-4390-ae4d-f979e16c562c") },
                    { new Guid("64b4319d-6dfa-48f4-b9b7-da00c22d64d7"), new Guid("e007dcb1-8678-47ab-90dd-441f76873b9e"), new Guid("4c3a1f47-f735-4390-ae4d-f979e16c562c") },
                    { new Guid("662660de-66f2-45e3-ae3a-dbeb5272ba28"), new Guid("d56fc07c-39f9-42c6-aaf5-640b2b5f6124"), new Guid("4c3a1f47-f735-4390-ae4d-f979e16c562c") },
                    { new Guid("623c94c1-b7f3-4d44-b85d-dbda9dbcdee2"), new Guid("82973925-433a-4f55-89c8-f41fc398a0c2"), new Guid("11d695a1-9893-4f18-a2ab-f61078233585") },
                    { new Guid("574a511e-063d-4f62-9bdd-ce6bf0222a3c"), new Guid("82973925-433a-4f55-89c8-f41fc398a0c2"), new Guid("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd") },
                    { new Guid("2bee244c-ed72-4ad0-9ff2-560e7275d788"), new Guid("11d695a1-9893-4f18-a2ab-f61078233585"), new Guid("82973925-433a-4f55-89c8-f41fc398a0c2") },
                    { new Guid("e72f5cb1-35ad-4bb6-8077-3a2936b81b70"), new Guid("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd"), new Guid("82973925-433a-4f55-89c8-f41fc398a0c2") },
                    { new Guid("3e0d08f1-9fd6-4a9c-bcba-13660f6e1257"), new Guid("cbf1b899-4d3d-4155-bae7-07915a6b8c09"), new Guid("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b") },
                    { new Guid("97b5b037-0586-4ff7-a31c-07ba412d8387"), new Guid("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b"), new Guid("cbf1b899-4d3d-4155-bae7-07915a6b8c09") },
                    { new Guid("25cc4851-49fa-40ff-8e6d-70c62ba734cb"), new Guid("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b"), new Guid("44cc60d3-d233-4bf1-92c1-539961e5be6b") },
                    { new Guid("711fa6a7-c288-4922-91af-592b9ac84d08"), new Guid("4c3a1f47-f735-4390-ae4d-f979e16c562c"), new Guid("895ce97a-633b-4782-b060-f276b4141e90") },
                    { new Guid("3cb381ed-d98a-4227-a015-bf859219fe7b"), new Guid("6af0ad8b-b789-4e9c-a191-e39711617d83"), new Guid("c1bd362f-88bd-4e6a-8928-ad6d29ee549a") },
                    { new Guid("23315763-2c12-4026-8ec1-d764226d1985"), new Guid("6af0ad8b-b789-4e9c-a191-e39711617d83"), new Guid("cbfb8d4a-5fad-4c9e-8faa-d035cd093928") },
                    { new Guid("5884dc07-0f6a-4214-ad4c-1610e157b6c5"), new Guid("394ed11a-fe64-4163-b9da-eed89db9d732"), new Guid("6af0ad8b-b789-4e9c-a191-e39711617d83") },
                    { new Guid("b6e43650-5e15-4881-9d7b-e16c4ea0d3b6"), new Guid("44cc60d3-d233-4bf1-92c1-539961e5be6b"), new Guid("cbf1b899-4d3d-4155-bae7-07915a6b8c09") },
                    { new Guid("8721aff8-b478-4d6b-8cb5-2952c900d1e9"), new Guid("d3cb1fd0-444e-4e2a-82a2-7382536b1770"), new Guid("e7931a2e-e969-43a2-9c71-542549fc41aa") },
                    { new Guid("b0d07411-b863-4735-9415-5d871a493547"), new Guid("e7931a2e-e969-43a2-9c71-542549fc41aa"), new Guid("d3cb1fd0-444e-4e2a-82a2-7382536b1770") },
                    { new Guid("e021ab07-01aa-41b1-a5c2-4557214dc46f"), new Guid("e7931a2e-e969-43a2-9c71-542549fc41aa"), new Guid("44cc60d3-d233-4bf1-92c1-539961e5be6b") },
                    { new Guid("dd9a0ef1-2d23-465e-8234-afcb081992a3"), new Guid("e7931a2e-e969-43a2-9c71-542549fc41aa"), new Guid("8963790c-6864-429c-bd8b-35338c53a170") },
                    { new Guid("34693ac8-57ac-4e88-8ab4-9f2096165d26"), new Guid("44cc60d3-d233-4bf1-92c1-539961e5be6b"), new Guid("e7931a2e-e969-43a2-9c71-542549fc41aa") },
                    { new Guid("4aff88b6-69c9-4495-a960-b4b108a80f28"), new Guid("8963790c-6864-429c-bd8b-35338c53a170"), new Guid("e7931a2e-e969-43a2-9c71-542549fc41aa") },
                    { new Guid("25008dc9-6aad-4600-aeee-94abb80c05c5"), new Guid("44cc60d3-d233-4bf1-92c1-539961e5be6b"), new Guid("c1bd362f-88bd-4e6a-8928-ad6d29ee549a") },
                    { new Guid("47c4694e-9c5e-493b-8cd2-435b7d448d6b"), new Guid("44cc60d3-d233-4bf1-92c1-539961e5be6b"), new Guid("8963790c-6864-429c-bd8b-35338c53a170") },
                    { new Guid("3e32cba3-ac8b-4bec-8252-d78049e0c210"), new Guid("44cc60d3-d233-4bf1-92c1-539961e5be6b"), new Guid("cbfb8d4a-5fad-4c9e-8faa-d035cd093928") },
                    { new Guid("5e20466f-419c-46ce-ac22-c1407f5e93b3"), new Guid("c1bd362f-88bd-4e6a-8928-ad6d29ee549a"), new Guid("44cc60d3-d233-4bf1-92c1-539961e5be6b") },
                    { new Guid("62d1cc69-7975-4667-82a9-dd59ae0aad4a"), new Guid("cbfb8d4a-5fad-4c9e-8faa-d035cd093928"), new Guid("44cc60d3-d233-4bf1-92c1-539961e5be6b") },
                    { new Guid("08d560df-57b3-46ac-8e9f-f71106fb6bd9"), new Guid("e7931a2e-e969-43a2-9c71-542549fc41aa"), new Guid("cbf1b899-4d3d-4155-bae7-07915a6b8c09") },
                    { new Guid("41ba73e6-0d41-4ac3-828f-3d0b17d2d03c"), new Guid("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e"), new Guid("28cce0f5-1692-4db3-af74-e4efc3aef1e6") },
                    { new Guid("1630ed58-0733-4a1e-9d60-19433c20a93b"), new Guid("28cce0f5-1692-4db3-af74-e4efc3aef1e6"), new Guid("c1bd362f-88bd-4e6a-8928-ad6d29ee549a") },
                    { new Guid("bd11768c-90f7-4606-ad9a-1814d472440a"), new Guid("28cce0f5-1692-4db3-af74-e4efc3aef1e6"), new Guid("5cc49bd4-a1bf-4f4b-9744-13668eae12f0") },
                    { new Guid("821720a5-e7e3-4079-becc-0573a1843dd1"), new Guid("c1bd362f-88bd-4e6a-8928-ad6d29ee549a"), new Guid("28cce0f5-1692-4db3-af74-e4efc3aef1e6") },
                    { new Guid("836b9897-3e7e-40d4-b356-a0e4a88d7c28"), new Guid("5cc49bd4-a1bf-4f4b-9744-13668eae12f0"), new Guid("28cce0f5-1692-4db3-af74-e4efc3aef1e6") },
                    { new Guid("37dec65c-b521-4151-9a5b-91c90a21dae6"), new Guid("f8c9d891-e9c5-43a1-8bfb-62f2cf51ab79"), new Guid("8963790c-6864-429c-bd8b-35338c53a170") },
                    { new Guid("c60656e6-55a6-4593-9b0e-9743e0f60a4a"), new Guid("8963790c-6864-429c-bd8b-35338c53a170"), new Guid("f8c9d891-e9c5-43a1-8bfb-62f2cf51ab79") },
                    { new Guid("10d6f6a3-88da-4a99-8a58-4f717c6bb075"), new Guid("8963790c-6864-429c-bd8b-35338c53a170"), new Guid("cbfb8d4a-5fad-4c9e-8faa-d035cd093928") },
                    { new Guid("d6fed2f0-7aac-4ef1-8da8-2fb7eb57eb70"), new Guid("cbfb8d4a-5fad-4c9e-8faa-d035cd093928"), new Guid("8963790c-6864-429c-bd8b-35338c53a170") },
                    { new Guid("a85609fc-ef32-4363-8f71-7001c1f691ff"), new Guid("c9220a79-ac83-4e46-a397-0830b052769e"), new Guid("73d7b3b6-1018-4b19-a57b-d189d75c7c81") },
                    { new Guid("ae7565df-0a08-4156-8b8b-ee762ced170c"), new Guid("c9220a79-ac83-4e46-a397-0830b052769e"), new Guid("906ac8fa-ce00-4194-8d13-f517242777f4") },
                    { new Guid("56ff6e61-3e91-4ee6-8c7c-5ffed016ae84"), new Guid("c9220a79-ac83-4e46-a397-0830b052769e"), new Guid("57eb6e76-cfe4-491a-8c5b-2cbbf5d44217") },
                    { new Guid("6053dd86-7b8d-400a-bd59-a2fed35b5608"), new Guid("c9220a79-ac83-4e46-a397-0830b052769e"), new Guid("f351db6b-828b-462a-a032-1354a73733e8") },
                    { new Guid("4ae69218-d9ca-49e2-8f08-314a236e9d51"), new Guid("28cce0f5-1692-4db3-af74-e4efc3aef1e6"), new Guid("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e") },
                    { new Guid("a86b0eb8-584e-4feb-8951-f6f425eb7209"), new Guid("e007dcb1-8678-47ab-90dd-441f76873b9e"), new Guid("2d75fb26-8926-4607-b618-1d727cd31fe8") },
                    { new Guid("dfa2ef90-cb87-49ce-97b1-a01613488014"), new Guid("d3cb1fd0-444e-4e2a-82a2-7382536b1770"), new Guid("cbf1b899-4d3d-4155-bae7-07915a6b8c09") },
                    { new Guid("2e9065f5-bf95-4053-bd59-366226cd342c"), new Guid("cbf1b899-4d3d-4155-bae7-07915a6b8c09"), new Guid("e7931a2e-e969-43a2-9c71-542549fc41aa") },
                    { new Guid("73f1121b-a768-4dd1-b5ff-c856a8281c8f"), new Guid("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e"), new Guid("6af0ad8b-b789-4e9c-a191-e39711617d83") },
                    { new Guid("753478b6-fd9b-4e84-a7f2-ec34d535c0c7"), new Guid("44cc60d3-d233-4bf1-92c1-539961e5be6b"), new Guid("6af0ad8b-b789-4e9c-a191-e39711617d83") },
                    { new Guid("8a0259c2-2240-4fde-9c0f-867a4d51514a"), new Guid("28cce0f5-1692-4db3-af74-e4efc3aef1e6"), new Guid("6af0ad8b-b789-4e9c-a191-e39711617d83") },
                    { new Guid("440f239e-de07-475e-bfcc-2181439da5eb"), new Guid("c1bd362f-88bd-4e6a-8928-ad6d29ee549a"), new Guid("6af0ad8b-b789-4e9c-a191-e39711617d83") },
                    { new Guid("0347055f-7df5-4151-a6b9-31dd6c740e4f"), new Guid("cbfb8d4a-5fad-4c9e-8faa-d035cd093928"), new Guid("6af0ad8b-b789-4e9c-a191-e39711617d83") },
                    { new Guid("c418cbec-a129-45c9-b969-c7a1c518484f"), new Guid("394ed11a-fe64-4163-b9da-eed89db9d732"), new Guid("479db9d5-9d65-473c-94c9-c84bfe8a9efc") },
                    { new Guid("fa8ff58e-0f57-4afa-bfdf-b0a082519b90"), new Guid("394ed11a-fe64-4163-b9da-eed89db9d732"), new Guid("5f5ba403-ae25-440b-9f38-809881781211") },
                    { new Guid("a569cffb-8746-4c7d-ac22-cbe982e0b720"), new Guid("394ed11a-fe64-4163-b9da-eed89db9d732"), new Guid("fbcf13f8-24f2-4f89-a9c0-bcada6f4ba62") },
                    { new Guid("c89dd020-1376-44dd-b8a7-6833e5dc6fe8"), new Guid("394ed11a-fe64-4163-b9da-eed89db9d732"), new Guid("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e") },
                    { new Guid("50ed74d7-8bd7-4943-a535-a836ad339d76"), new Guid("394ed11a-fe64-4163-b9da-eed89db9d732"), new Guid("cbfb8d4a-5fad-4c9e-8faa-d035cd093928") },
                    { new Guid("c694885c-43c0-4ce5-a2c7-b978d5f6e2fe"), new Guid("479db9d5-9d65-473c-94c9-c84bfe8a9efc"), new Guid("394ed11a-fe64-4163-b9da-eed89db9d732") },
                    { new Guid("a3f96857-541c-471f-8aa4-96649394585e"), new Guid("5f5ba403-ae25-440b-9f38-809881781211"), new Guid("394ed11a-fe64-4163-b9da-eed89db9d732") },
                    { new Guid("61612971-503f-4640-8d66-7d1fe05da734"), new Guid("cbf1b899-4d3d-4155-bae7-07915a6b8c09"), new Guid("44cc60d3-d233-4bf1-92c1-539961e5be6b") },
                    { new Guid("09119b31-46a2-4af4-aa1f-d5d56bd20e83"), new Guid("fbcf13f8-24f2-4f89-a9c0-bcada6f4ba62"), new Guid("394ed11a-fe64-4163-b9da-eed89db9d732") },
                    { new Guid("efe7de6d-2e10-490e-9207-7e3a19808254"), new Guid("cbfb8d4a-5fad-4c9e-8faa-d035cd093928"), new Guid("394ed11a-fe64-4163-b9da-eed89db9d732") },
                    { new Guid("5cf3fb55-3005-44c4-9f3a-9a417d77f45d"), new Guid("f8c9d891-e9c5-43a1-8bfb-62f2cf51ab79"), new Guid("479db9d5-9d65-473c-94c9-c84bfe8a9efc") },
                    { new Guid("6139bfa4-0da7-41db-b279-a160ff950f50"), new Guid("479db9d5-9d65-473c-94c9-c84bfe8a9efc"), new Guid("f8c9d891-e9c5-43a1-8bfb-62f2cf51ab79") },
                    { new Guid("8acdf24e-acc7-432e-b0a4-7fde70ce3f24"), new Guid("479db9d5-9d65-473c-94c9-c84bfe8a9efc"), new Guid("5f5ba403-ae25-440b-9f38-809881781211") },
                    { new Guid("6cb3cee5-74d5-494c-8405-7465ff5d33d5"), new Guid("479db9d5-9d65-473c-94c9-c84bfe8a9efc"), new Guid("8963790c-6864-429c-bd8b-35338c53a170") },
                    { new Guid("613cc6bd-0891-4898-b6e8-2e8b91d0db3f"), new Guid("479db9d5-9d65-473c-94c9-c84bfe8a9efc"), new Guid("cbfb8d4a-5fad-4c9e-8faa-d035cd093928") },
                    { new Guid("3a98382f-58a5-4d2f-8601-c0cdd884efbd"), new Guid("5f5ba403-ae25-440b-9f38-809881781211"), new Guid("479db9d5-9d65-473c-94c9-c84bfe8a9efc") },
                    { new Guid("22d27ff2-32b9-4efc-8c56-f2b5ce6296db"), new Guid("8963790c-6864-429c-bd8b-35338c53a170"), new Guid("479db9d5-9d65-473c-94c9-c84bfe8a9efc") },
                    { new Guid("263c2038-7f63-4c6a-b7ce-2203cdfda809"), new Guid("cbfb8d4a-5fad-4c9e-8faa-d035cd093928"), new Guid("479db9d5-9d65-473c-94c9-c84bfe8a9efc") },
                    { new Guid("6f773ae3-7f24-47ec-8632-48b9b2945bc1"), new Guid("895ce97a-633b-4782-b060-f276b4141e90"), new Guid("d3cb1fd0-444e-4e2a-82a2-7382536b1770") },
                    { new Guid("4aa0c7d2-3f61-4489-9fbc-585a0818ddcd"), new Guid("d3cb1fd0-444e-4e2a-82a2-7382536b1770"), new Guid("895ce97a-633b-4782-b060-f276b4141e90") },
                    { new Guid("41e890e7-b0ea-428c-b245-187b522d0af0"), new Guid("cbf1b899-4d3d-4155-bae7-07915a6b8c09"), new Guid("d3cb1fd0-444e-4e2a-82a2-7382536b1770") },
                    { new Guid("0fc0a7f3-ca1b-4062-9584-ffa7f7c0932e"), new Guid("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e"), new Guid("394ed11a-fe64-4163-b9da-eed89db9d732") },
                    { new Guid("af5d6f4e-77b7-4ec8-a78c-6a4d484dee5a"), new Guid("73d7b3b6-1018-4b19-a57b-d189d75c7c81"), new Guid("c9220a79-ac83-4e46-a397-0830b052769e") },
                    { new Guid("aadecebb-51c2-4f26-b7a4-53f2b3bb1fd1"), new Guid("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b"), new Guid("2d75fb26-8926-4607-b618-1d727cd31fe8") },
                    { new Guid("5242a269-7792-41e0-862f-2016144bf934"), new Guid("7285b039-3ac9-4a21-9dcd-9fc96164e600"), new Guid("2d75fb26-8926-4607-b618-1d727cd31fe8") },
                    { new Guid("2ac88622-117b-4048-b2ae-574b00cabac0"), new Guid("97a9f4b4-e8d4-4c1a-b6e7-e05426969f58"), new Guid("661ba9ad-e1e9-413c-bdfe-66401edd5596") },
                    { new Guid("1d5e45b8-6390-416a-b24a-2725089c624d"), new Guid("97a9f4b4-e8d4-4c1a-b6e7-e05426969f58"), new Guid("1ef7fde0-47b6-4fda-810c-44c33d1fbee8") },
                    { new Guid("18f771b9-93cc-46fb-aa5a-79d37be8b349"), new Guid("661ba9ad-e1e9-413c-bdfe-66401edd5596"), new Guid("97a9f4b4-e8d4-4c1a-b6e7-e05426969f58") },
                    { new Guid("4261d03f-c7c4-4f38-b0f5-9b906e17aad7"), new Guid("1ef7fde0-47b6-4fda-810c-44c33d1fbee8"), new Guid("97a9f4b4-e8d4-4c1a-b6e7-e05426969f58") },
                    { new Guid("13167d18-0093-4b37-950f-10e35f11d892"), new Guid("661ba9ad-e1e9-413c-bdfe-66401edd5596"), new Guid("8ce39bf5-92de-48db-bb8b-30892a4a090f") },
                    { new Guid("dd2c3bc3-ff96-4c8d-9dd7-21fb8bcf84a8"), new Guid("661ba9ad-e1e9-413c-bdfe-66401edd5596"), new Guid("1ef7fde0-47b6-4fda-810c-44c33d1fbee8") },
                    { new Guid("0d36f9de-3afc-4fdb-881b-0b1ace558652"), new Guid("8ce39bf5-92de-48db-bb8b-30892a4a090f"), new Guid("661ba9ad-e1e9-413c-bdfe-66401edd5596") },
                    { new Guid("77e1f331-8890-436c-b41e-708abbe7f4f2"), new Guid("1ef7fde0-47b6-4fda-810c-44c33d1fbee8"), new Guid("661ba9ad-e1e9-413c-bdfe-66401edd5596") },
                    { new Guid("7551fd1e-8a98-4716-8a0c-f892aba201a6"), new Guid("63a854d0-a738-4684-9853-f83f051a88fc"), new Guid("069da2fe-b9c4-49d8-9ae6-77530d8d85ee") },
                    { new Guid("77e18b9c-2668-4b09-90c3-dc8a88509bc6"), new Guid("069da2fe-b9c4-49d8-9ae6-77530d8d85ee"), new Guid("63a854d0-a738-4684-9853-f83f051a88fc") },
                    { new Guid("eae236e6-cf55-4564-892f-132c0ff215d0"), new Guid("069da2fe-b9c4-49d8-9ae6-77530d8d85ee"), new Guid("470669cc-1d05-4d07-838e-3aea8923d7c6") },
                    { new Guid("e4eafa51-43be-417c-8800-a6182fc28f83"), new Guid("069da2fe-b9c4-49d8-9ae6-77530d8d85ee"), new Guid("dd1e3ba1-385c-4941-8d5b-dfbfa1554154") },
                    { new Guid("24b7db7f-c008-46de-ad93-c8fa2200efd6"), new Guid("069da2fe-b9c4-49d8-9ae6-77530d8d85ee"), new Guid("8ce39bf5-92de-48db-bb8b-30892a4a090f") },
                    { new Guid("3bdd2e4c-6f01-4d66-ab4a-bd8494c94a9c"), new Guid("069da2fe-b9c4-49d8-9ae6-77530d8d85ee"), new Guid("6a16c6c6-4b11-4651-b291-739fd143cb19") },
                    { new Guid("12033f6e-a2eb-4bb3-b79d-ea386a56fe46"), new Guid("069da2fe-b9c4-49d8-9ae6-77530d8d85ee"), new Guid("c1aed70b-666e-4f32-bee2-f52722d89b1f") },
                    { new Guid("af4dcf9c-92de-46ac-80d1-a036af068ade"), new Guid("069da2fe-b9c4-49d8-9ae6-77530d8d85ee"), new Guid("1ef7fde0-47b6-4fda-810c-44c33d1fbee8") },
                    { new Guid("3950ea6e-7642-4324-b30f-a9753bea30b6"), new Guid("470669cc-1d05-4d07-838e-3aea8923d7c6"), new Guid("069da2fe-b9c4-49d8-9ae6-77530d8d85ee") },
                    { new Guid("a628e329-0ec7-4da8-8a4f-386c75c52cce"), new Guid("dd1e3ba1-385c-4941-8d5b-dfbfa1554154"), new Guid("069da2fe-b9c4-49d8-9ae6-77530d8d85ee") },
                    { new Guid("07f9fcc2-f128-4f76-b72e-98b297645e31"), new Guid("8ce39bf5-92de-48db-bb8b-30892a4a090f"), new Guid("069da2fe-b9c4-49d8-9ae6-77530d8d85ee") },
                    { new Guid("4162caab-0f39-43a4-8dd0-117d3296e865"), new Guid("6a16c6c6-4b11-4651-b291-739fd143cb19"), new Guid("069da2fe-b9c4-49d8-9ae6-77530d8d85ee") },
                    { new Guid("4a575ed6-bcd0-4c3f-ab66-50ff688d2f7b"), new Guid("c1aed70b-666e-4f32-bee2-f52722d89b1f"), new Guid("069da2fe-b9c4-49d8-9ae6-77530d8d85ee") },
                    { new Guid("be73d783-1211-4d13-b53f-3ffb5d0f822f"), new Guid("1ef7fde0-47b6-4fda-810c-44c33d1fbee8"), new Guid("069da2fe-b9c4-49d8-9ae6-77530d8d85ee") },
                    { new Guid("bc6a10c2-a651-4efc-abc9-fddb5882751e"), new Guid("11560417-8292-4dfd-b345-9e4a207ee6ca"), new Guid("470669cc-1d05-4d07-838e-3aea8923d7c6") },
                    { new Guid("4d21e830-f356-491a-92a9-0babfc548dbc"), new Guid("11560417-8292-4dfd-b345-9e4a207ee6ca"), new Guid("dd1e3ba1-385c-4941-8d5b-dfbfa1554154") },
                    { new Guid("a1d22de4-d568-4926-bf25-1ecdf17ebf46"), new Guid("11560417-8292-4dfd-b345-9e4a207ee6ca"), new Guid("28cce0f5-1692-4db3-af74-e4efc3aef1e6") },
                    { new Guid("cff423f4-fb51-4add-b99a-4b0fe0e2a981"), new Guid("1bf0a210-c750-4e98-9151-7eaefa8185c7"), new Guid("6a16c6c6-4b11-4651-b291-739fd143cb19") },
                    { new Guid("4c41b414-084c-485b-aa56-0c7148438a56"), new Guid("6a16c6c6-4b11-4651-b291-739fd143cb19"), new Guid("1bf0a210-c750-4e98-9151-7eaefa8185c7") },
                    { new Guid("475b6443-84dc-4a31-83b7-cf5dfa19fe08"), new Guid("1bf0a210-c750-4e98-9151-7eaefa8185c7"), new Guid("85ef4758-c7a8-4cbc-9416-caaea32e4d05") },
                    { new Guid("d2fe1210-3850-4907-bcd2-c38e11d9b53a"), new Guid("85ef4758-c7a8-4cbc-9416-caaea32e4d05"), new Guid("1bf0a210-c750-4e98-9151-7eaefa8185c7") },
                    { new Guid("dafa8e73-8551-4692-9cd4-7d6d914d18a0"), new Guid("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1"), new Guid("95f28447-33e7-449f-8bd7-ecdabaae501f") },
                    { new Guid("087895e8-b656-4627-96a1-4ac853c86808"), new Guid("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1"), new Guid("c1aed70b-666e-4f32-bee2-f52722d89b1f") },
                    { new Guid("6f8dd392-e0ca-4df9-9e07-ff8c6de40d59"), new Guid("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1"), new Guid("1bf0a210-c750-4e98-9151-7eaefa8185c7") },
                    { new Guid("71aee0c1-97dd-4286-90d8-6ff43cccc917"), new Guid("7fdeabb6-fdd2-49ff-ad5d-b35f56f9db5b"), new Guid("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1") },
                    { new Guid("efe043d5-4aa0-4f64-b107-65861380b37e"), new Guid("11d695a1-9893-4f18-a2ab-f61078233585"), new Guid("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1") },
                    { new Guid("e03c2d9a-93b0-4f6f-ab44-c6a303b40972"), new Guid("6a16c6c6-4b11-4651-b291-739fd143cb19"), new Guid("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1") },
                    { new Guid("c1baa58e-af93-4001-a6a7-7082b4b2b1f3"), new Guid("95f28447-33e7-449f-8bd7-ecdabaae501f"), new Guid("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1") },
                    { new Guid("1a25b2d0-4105-43f2-8f6b-b7dfff3a2bc3"), new Guid("c1aed70b-666e-4f32-bee2-f52722d89b1f"), new Guid("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1") },
                    { new Guid("fa995ff5-a4d4-417c-942f-478e36c69e64"), new Guid("1bf0a210-c750-4e98-9151-7eaefa8185c7"), new Guid("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1") },
                    { new Guid("c4279d96-75fb-442a-8873-40bfad5e318b"), new Guid("7fdeabb6-fdd2-49ff-ad5d-b35f56f9db5b"), new Guid("95f28447-33e7-449f-8bd7-ecdabaae501f") },
                    { new Guid("25351a4f-8ee2-4e88-9295-062d5e2689dd"), new Guid("7fdeabb6-fdd2-49ff-ad5d-b35f56f9db5b"), new Guid("6b787904-7e30-450b-aac4-2867a6f72100") },
                    { new Guid("2bbdf023-321b-430f-862c-43797460ae6c"), new Guid("7fdeabb6-fdd2-49ff-ad5d-b35f56f9db5b"), new Guid("1bf0a210-c750-4e98-9151-7eaefa8185c7") },
                    { new Guid("a4d768d1-3787-40b2-a5ab-bdd81d4a23fd"), new Guid("11560417-8292-4dfd-b345-9e4a207ee6ca"), new Guid("c1bd362f-88bd-4e6a-8928-ad6d29ee549a") },
                    { new Guid("dd2a3d91-24b0-4ea4-b8c8-8f730338cb12"), new Guid("95f28447-33e7-449f-8bd7-ecdabaae501f"), new Guid("7fdeabb6-fdd2-49ff-ad5d-b35f56f9db5b") },
                    { new Guid("9d9a03b2-7fe7-4df1-bdfb-4826df687911"), new Guid("1bf0a210-c750-4e98-9151-7eaefa8185c7"), new Guid("7fdeabb6-fdd2-49ff-ad5d-b35f56f9db5b") },
                    { new Guid("04070ce3-aeab-4741-b8c4-561169a492c8"), new Guid("11d695a1-9893-4f18-a2ab-f61078233585"), new Guid("95f28447-33e7-449f-8bd7-ecdabaae501f") },
                    { new Guid("172918ae-2918-4259-9aee-00262fb0fca0"), new Guid("95f28447-33e7-449f-8bd7-ecdabaae501f"), new Guid("11d695a1-9893-4f18-a2ab-f61078233585") },
                    { new Guid("63c5d6db-fc7d-4db3-8dc3-356b97f03f00"), new Guid("1bf0a210-c750-4e98-9151-7eaefa8185c7"), new Guid("95f28447-33e7-449f-8bd7-ecdabaae501f") },
                    { new Guid("6e53290b-c56b-4c99-8288-0271e2533a5a"), new Guid("6b787904-7e30-450b-aac4-2867a6f72100"), new Guid("1bf0a210-c750-4e98-9151-7eaefa8185c7") },
                    { new Guid("54900730-57cd-47ef-bd2c-a7eb8823a1a3"), new Guid("1bf0a210-c750-4e98-9151-7eaefa8185c7"), new Guid("6b787904-7e30-450b-aac4-2867a6f72100") },
                    { new Guid("08a1eb75-7d45-47f0-83eb-784503e436f3"), new Guid("661ba9ad-e1e9-413c-bdfe-66401edd5596"), new Guid("85ef4758-c7a8-4cbc-9416-caaea32e4d05") },
                    { new Guid("11037b25-e908-4bd4-942d-05d6e4034268"), new Guid("8ce39bf5-92de-48db-bb8b-30892a4a090f"), new Guid("85ef4758-c7a8-4cbc-9416-caaea32e4d05") },
                    { new Guid("829d59ae-c7f3-4d52-a00f-30837cc197ea"), new Guid("6a16c6c6-4b11-4651-b291-739fd143cb19"), new Guid("85ef4758-c7a8-4cbc-9416-caaea32e4d05") },
                    { new Guid("c0c30649-c931-47b0-a813-8a2403335337"), new Guid("85ef4758-c7a8-4cbc-9416-caaea32e4d05"), new Guid("661ba9ad-e1e9-413c-bdfe-66401edd5596") },
                    { new Guid("ab62640b-3962-4cad-9944-f298e60e5efe"), new Guid("85ef4758-c7a8-4cbc-9416-caaea32e4d05"), new Guid("8ce39bf5-92de-48db-bb8b-30892a4a090f") },
                    { new Guid("9965f8a8-028d-49bb-a005-0af68aacab24"), new Guid("85ef4758-c7a8-4cbc-9416-caaea32e4d05"), new Guid("6a16c6c6-4b11-4651-b291-739fd143cb19") },
                    { new Guid("adc913e4-f9aa-4b31-91d4-8376f77937ba"), new Guid("6b787904-7e30-450b-aac4-2867a6f72100"), new Guid("7fdeabb6-fdd2-49ff-ad5d-b35f56f9db5b") },
                    { new Guid("a3591601-ce98-4900-9dd0-09db91768b9f"), new Guid("11560417-8292-4dfd-b345-9e4a207ee6ca"), new Guid("95295597-7518-4999-bdd7-52ef36bd24c0") },
                    { new Guid("c0db2cce-6264-41fd-a042-364ac0988152"), new Guid("11560417-8292-4dfd-b345-9e4a207ee6ca"), new Guid("cc023a01-8a9b-4ed6-b41c-9388c363db49") },
                    { new Guid("2328be8d-33e4-4e83-ab6b-356134d7635b"), new Guid("470669cc-1d05-4d07-838e-3aea8923d7c6"), new Guid("11560417-8292-4dfd-b345-9e4a207ee6ca") },
                    { new Guid("04ac601d-3d64-43f6-a997-d8e7db39e26c"), new Guid("95295597-7518-4999-bdd7-52ef36bd24c0"), new Guid("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b") },
                    { new Guid("33ef1165-d933-4a0d-892f-123896605201"), new Guid("95295597-7518-4999-bdd7-52ef36bd24c0"), new Guid("c1bd362f-88bd-4e6a-8928-ad6d29ee549a") },
                    { new Guid("3f53db8e-9c37-4524-8740-7eff88f0fdcd"), new Guid("95295597-7518-4999-bdd7-52ef36bd24c0"), new Guid("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd") },
                    { new Guid("a3bfd4cd-c3bc-454d-832a-0e26eca6efc4"), new Guid("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd"), new Guid("95295597-7518-4999-bdd7-52ef36bd24c0") },
                    { new Guid("64a00cf7-3fd2-488f-af0a-9994bff82910"), new Guid("82973925-433a-4f55-89c8-f41fc398a0c2"), new Guid("c1aed70b-666e-4f32-bee2-f52722d89b1f") },
                    { new Guid("5679bae3-4f4f-4955-bc7e-574a426268dd"), new Guid("11d695a1-9893-4f18-a2ab-f61078233585"), new Guid("c1aed70b-666e-4f32-bee2-f52722d89b1f") },
                    { new Guid("18044867-5fe1-473a-b262-b0bfb2c45a2f"), new Guid("c1aed70b-666e-4f32-bee2-f52722d89b1f"), new Guid("82973925-433a-4f55-89c8-f41fc398a0c2") },
                    { new Guid("4a0eb214-3473-4869-afdc-55d3b6d7da2e"), new Guid("c1aed70b-666e-4f32-bee2-f52722d89b1f"), new Guid("11d695a1-9893-4f18-a2ab-f61078233585") },
                    { new Guid("fc351383-032a-43a6-a655-950b131ce5f7"), new Guid("63a854d0-a738-4684-9853-f83f051a88fc"), new Guid("cc023a01-8a9b-4ed6-b41c-9388c363db49") },
                    { new Guid("313c874a-c9dc-4d38-9a29-eb0fe578cf64"), new Guid("52f1f21c-bea3-498b-bafa-26846d550230"), new Guid("cc023a01-8a9b-4ed6-b41c-9388c363db49") },
                    { new Guid("9ce6cfe6-677b-4089-bebb-3faee31e6efa"), new Guid("28cce0f5-1692-4db3-af74-e4efc3aef1e6"), new Guid("cc023a01-8a9b-4ed6-b41c-9388c363db49") },
                    { new Guid("d0d81006-5481-45f3-b76c-96399fea6cb4"), new Guid("5cc49bd4-a1bf-4f4b-9744-13668eae12f0"), new Guid("cc023a01-8a9b-4ed6-b41c-9388c363db49") },
                    { new Guid("ed9bcff7-deaf-4c44-bf1e-052f8ba74be6"), new Guid("95295597-7518-4999-bdd7-52ef36bd24c0"), new Guid("82973925-433a-4f55-89c8-f41fc398a0c2") },
                    { new Guid("c75fe996-477f-4c35-9a6b-34986ecdb530"), new Guid("cc023a01-8a9b-4ed6-b41c-9388c363db49"), new Guid("63a854d0-a738-4684-9853-f83f051a88fc") },
                    { new Guid("8e7523ef-521e-4055-a732-ce1be12b6dc8"), new Guid("cc023a01-8a9b-4ed6-b41c-9388c363db49"), new Guid("28cce0f5-1692-4db3-af74-e4efc3aef1e6") },
                    { new Guid("6c15e273-f793-4cde-bce9-d3468434cafe"), new Guid("cc023a01-8a9b-4ed6-b41c-9388c363db49"), new Guid("5cc49bd4-a1bf-4f4b-9744-13668eae12f0") },
                    { new Guid("ccb62f98-835f-4759-8da4-d5af16705dca"), new Guid("63a854d0-a738-4684-9853-f83f051a88fc"), new Guid("1ef7fde0-47b6-4fda-810c-44c33d1fbee8") },
                    { new Guid("25c6f0c3-a69e-4132-947d-b2dc8e97d849"), new Guid("4258f49d-10e3-4428-a398-66ffc5faa23f"), new Guid("1ef7fde0-47b6-4fda-810c-44c33d1fbee8") },
                    { new Guid("d023f2aa-6118-4850-99cf-0083917dab6e"), new Guid("1ef7fde0-47b6-4fda-810c-44c33d1fbee8"), new Guid("63a854d0-a738-4684-9853-f83f051a88fc") },
                    { new Guid("bc4e4367-dc8e-4b08-8065-cb78eb1040bc"), new Guid("1ef7fde0-47b6-4fda-810c-44c33d1fbee8"), new Guid("4258f49d-10e3-4428-a398-66ffc5faa23f") },
                    { new Guid("5c6b1813-d575-4b85-a70f-2d740e5b5fe7"), new Guid("2d75fb26-8926-4607-b618-1d727cd31fe8"), new Guid("7285b039-3ac9-4a21-9dcd-9fc96164e600") },
                    { new Guid("2ad409de-7036-4771-b2bc-63e345fb4a5c"), new Guid("2d75fb26-8926-4607-b618-1d727cd31fe8"), new Guid("cbf1b899-4d3d-4155-bae7-07915a6b8c09") },
                    { new Guid("be24a341-618b-4e03-8a16-6c7c62496827"), new Guid("2d75fb26-8926-4607-b618-1d727cd31fe8"), new Guid("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b") },
                    { new Guid("395f153a-e534-4a03-badb-1ec5d53c2bbf"), new Guid("2d75fb26-8926-4607-b618-1d727cd31fe8"), new Guid("e007dcb1-8678-47ab-90dd-441f76873b9e") },
                    { new Guid("cd6c146b-5340-43ee-8439-b02abc5bd11f"), new Guid("2d75fb26-8926-4607-b618-1d727cd31fe8"), new Guid("d56fc07c-39f9-42c6-aaf5-640b2b5f6124") },
                    { new Guid("a9f52ba5-d74a-41b8-9f7a-fe94c735cdbf"), new Guid("2d75fb26-8926-4607-b618-1d727cd31fe8"), new Guid("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd") },
                    { new Guid("83550d3f-6072-4da8-bcd6-e59e7fcf6d43"), new Guid("cc023a01-8a9b-4ed6-b41c-9388c363db49"), new Guid("52f1f21c-bea3-498b-bafa-26846d550230") },
                    { new Guid("1fcd7aea-3903-43e3-b43c-ae1ac806d8d1"), new Guid("cbf1b899-4d3d-4155-bae7-07915a6b8c09"), new Guid("2d75fb26-8926-4607-b618-1d727cd31fe8") },
                    { new Guid("bc3421ad-a832-47c1-bee3-7ad7c5fee183"), new Guid("c1bd362f-88bd-4e6a-8928-ad6d29ee549a"), new Guid("95295597-7518-4999-bdd7-52ef36bd24c0") },
                    { new Guid("11bdfe2c-b9f2-4890-86a1-919d0a4dfbdd"), new Guid("82973925-433a-4f55-89c8-f41fc398a0c2"), new Guid("95295597-7518-4999-bdd7-52ef36bd24c0") },
                    { new Guid("2467bd94-9fd8-4fce-954e-3769cf8fe629"), new Guid("dd1e3ba1-385c-4941-8d5b-dfbfa1554154"), new Guid("11560417-8292-4dfd-b345-9e4a207ee6ca") },
                    { new Guid("5d21f340-19dd-44e9-a4b3-0861df059e69"), new Guid("28cce0f5-1692-4db3-af74-e4efc3aef1e6"), new Guid("11560417-8292-4dfd-b345-9e4a207ee6ca") },
                    { new Guid("4ecc55b2-c3c1-4586-833c-4907faa2735b"), new Guid("c1bd362f-88bd-4e6a-8928-ad6d29ee549a"), new Guid("11560417-8292-4dfd-b345-9e4a207ee6ca") },
                    { new Guid("a5453fac-dbdd-4ac1-bcba-d1d373c64248"), new Guid("95295597-7518-4999-bdd7-52ef36bd24c0"), new Guid("11560417-8292-4dfd-b345-9e4a207ee6ca") },
                    { new Guid("b11b90d6-f615-4d59-8ff9-f17697905432"), new Guid("cc023a01-8a9b-4ed6-b41c-9388c363db49"), new Guid("11560417-8292-4dfd-b345-9e4a207ee6ca") },
                    { new Guid("9274807d-3a47-4579-8284-7f7842d62073"), new Guid("82973925-433a-4f55-89c8-f41fc398a0c2"), new Guid("470669cc-1d05-4d07-838e-3aea8923d7c6") },
                    { new Guid("61e8cdcd-8be5-484b-af0a-f4789e1407df"), new Guid("470669cc-1d05-4d07-838e-3aea8923d7c6"), new Guid("82973925-433a-4f55-89c8-f41fc398a0c2") },
                    { new Guid("aedb2427-f0de-4e00-bc44-1036a637e5bc"), new Guid("470669cc-1d05-4d07-838e-3aea8923d7c6"), new Guid("dd1e3ba1-385c-4941-8d5b-dfbfa1554154") },
                    { new Guid("f07b3c3e-e812-4689-872c-eaaa54a7b54c"), new Guid("470669cc-1d05-4d07-838e-3aea8923d7c6"), new Guid("95295597-7518-4999-bdd7-52ef36bd24c0") },
                    { new Guid("782eb5a7-df78-47b7-b9e6-0a13091935f3"), new Guid("470669cc-1d05-4d07-838e-3aea8923d7c6"), new Guid("c1aed70b-666e-4f32-bee2-f52722d89b1f") },
                    { new Guid("e67deed2-3900-4bb5-9e16-a768b686bab2"), new Guid("dd1e3ba1-385c-4941-8d5b-dfbfa1554154"), new Guid("470669cc-1d05-4d07-838e-3aea8923d7c6") },
                    { new Guid("d3430172-ef77-45b8-9b2d-e071a92342af"), new Guid("95295597-7518-4999-bdd7-52ef36bd24c0"), new Guid("470669cc-1d05-4d07-838e-3aea8923d7c6") },
                    { new Guid("6dd16790-9f69-4a32-a112-732ba6b31e72"), new Guid("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b"), new Guid("95295597-7518-4999-bdd7-52ef36bd24c0") },
                    { new Guid("4f4a0854-0ca6-45a0-9f82-3c1103853f93"), new Guid("c1aed70b-666e-4f32-bee2-f52722d89b1f"), new Guid("470669cc-1d05-4d07-838e-3aea8923d7c6") },
                    { new Guid("317ce829-6b7f-4ed1-b2cd-f105b7984b06"), new Guid("dd1e3ba1-385c-4941-8d5b-dfbfa1554154"), new Guid("63a854d0-a738-4684-9853-f83f051a88fc") },
                    { new Guid("0603a080-e002-47d4-9d8c-73ca19f3d1d6"), new Guid("dd1e3ba1-385c-4941-8d5b-dfbfa1554154"), new Guid("cc023a01-8a9b-4ed6-b41c-9388c363db49") },
                    { new Guid("76e014dd-afbc-49c7-af6c-856a183359fc"), new Guid("cc023a01-8a9b-4ed6-b41c-9388c363db49"), new Guid("dd1e3ba1-385c-4941-8d5b-dfbfa1554154") },
                    { new Guid("89152243-b25c-4bd8-87e3-03716d664150"), new Guid("8ce39bf5-92de-48db-bb8b-30892a4a090f"), new Guid("6a16c6c6-4b11-4651-b291-739fd143cb19") },
                    { new Guid("e46604a6-8c6d-472d-be6b-fd38df05474d"), new Guid("8ce39bf5-92de-48db-bb8b-30892a4a090f"), new Guid("c1aed70b-666e-4f32-bee2-f52722d89b1f") },
                    { new Guid("38c9605b-dac3-46b7-8943-86d9574d0953"), new Guid("8ce39bf5-92de-48db-bb8b-30892a4a090f"), new Guid("1ef7fde0-47b6-4fda-810c-44c33d1fbee8") },
                    { new Guid("331daf6d-8470-4aa6-b8fd-97fbf64fd812"), new Guid("6a16c6c6-4b11-4651-b291-739fd143cb19"), new Guid("8ce39bf5-92de-48db-bb8b-30892a4a090f") },
                    { new Guid("cdf2ebb4-d3b7-447e-9931-fc1e91dfae17"), new Guid("c1aed70b-666e-4f32-bee2-f52722d89b1f"), new Guid("8ce39bf5-92de-48db-bb8b-30892a4a090f") },
                    { new Guid("58488f2b-ff67-49f7-aab5-26dedcf7892b"), new Guid("1ef7fde0-47b6-4fda-810c-44c33d1fbee8"), new Guid("8ce39bf5-92de-48db-bb8b-30892a4a090f") },
                    { new Guid("1191531f-6298-4e65-a532-5441064f24c1"), new Guid("11d695a1-9893-4f18-a2ab-f61078233585"), new Guid("6a16c6c6-4b11-4651-b291-739fd143cb19") },
                    { new Guid("e5751179-cd56-4c98-9fed-317c92a0c7b1"), new Guid("6a16c6c6-4b11-4651-b291-739fd143cb19"), new Guid("c1aed70b-666e-4f32-bee2-f52722d89b1f") },
                    { new Guid("1e48d46f-659f-4d31-b7c5-f1ce9bdd1108"), new Guid("c1aed70b-666e-4f32-bee2-f52722d89b1f"), new Guid("6a16c6c6-4b11-4651-b291-739fd143cb19") },
                    { new Guid("326cb680-ce60-4ff9-b16f-5acfbecf9e13"), new Guid("63a854d0-a738-4684-9853-f83f051a88fc"), new Guid("dd1e3ba1-385c-4941-8d5b-dfbfa1554154") },
                    { new Guid("34f412bb-8e22-4500-9c77-af784c94868b"), new Guid("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1"), new Guid("6a16c6c6-4b11-4651-b291-739fd143cb19") },
                    { new Guid("322d30ee-98d6-4dfe-93b6-ca1d23959ee2"), new Guid("906ac8fa-ce00-4194-8d13-f517242777f4"), new Guid("c9220a79-ac83-4e46-a397-0830b052769e") },
                    { new Guid("2a1e4392-2c13-49fe-9d87-92c7a90c7c6e"), new Guid("f351db6b-828b-462a-a032-1354a73733e8"), new Guid("c9220a79-ac83-4e46-a397-0830b052769e") },
                    { new Guid("bb404fac-a342-4fa8-873b-2f67d0c5e466"), new Guid("52ee48da-49f3-4701-93de-f113946380c9"), new Guid("0bbca13e-e227-4aaa-a078-265c9133f278") },
                    { new Guid("779a5558-d8d1-4fac-9392-2d1c45c860cd"), new Guid("2acb1828-07a0-45fd-b52e-15b7eb6e02ce"), new Guid("0bbca13e-e227-4aaa-a078-265c9133f278") },
                    { new Guid("8ef22aab-e7db-46b9-9643-c1424186323b"), new Guid("667fec95-c40d-4289-b5d9-4760525509f3"), new Guid("11e3ebec-bf5b-4f1b-8488-aa509b066f2e") },
                    { new Guid("519ec8d3-b565-4795-8110-1504a87b9e44"), new Guid("667fec95-c40d-4289-b5d9-4760525509f3"), new Guid("52f1f21c-bea3-498b-bafa-26846d550230") },
                    { new Guid("e8396360-678b-4a2e-810a-3ba3d3fc3f32"), new Guid("667fec95-c40d-4289-b5d9-4760525509f3"), new Guid("1c05a510-8e08-4e61-94f1-d5b9661a2b08") },
                    { new Guid("b25e4814-e9c8-436e-8630-238f2b0b95ef"), new Guid("667fec95-c40d-4289-b5d9-4760525509f3"), new Guid("dbde4b03-bd9c-4b18-81c3-9b24e0558003") },
                    { new Guid("3389a8cb-83eb-4da6-9108-ac10e747337f"), new Guid("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"), new Guid("667fec95-c40d-4289-b5d9-4760525509f3") },
                    { new Guid("283e8eec-be6a-470f-89d6-86b057f503d4"), new Guid("52f1f21c-bea3-498b-bafa-26846d550230"), new Guid("667fec95-c40d-4289-b5d9-4760525509f3") },
                    { new Guid("b95b6343-c6d9-45b0-b457-43d624cbd2e2"), new Guid("1c05a510-8e08-4e61-94f1-d5b9661a2b08"), new Guid("667fec95-c40d-4289-b5d9-4760525509f3") },
                    { new Guid("039340cf-740a-4eae-9eec-7afde9aaa554"), new Guid("dbde4b03-bd9c-4b18-81c3-9b24e0558003"), new Guid("667fec95-c40d-4289-b5d9-4760525509f3") },
                    { new Guid("c61755c1-1905-4541-bf3e-9fa517c5c13c"), new Guid("5cc49bd4-a1bf-4f4b-9744-13668eae12f0"), new Guid("667fec95-c40d-4289-b5d9-4760525509f3") },
                    { new Guid("7a76292f-5e81-47b1-8a6e-a06dcc7e727c"), new Guid("63a854d0-a738-4684-9853-f83f051a88fc"), new Guid("52f1f21c-bea3-498b-bafa-26846d550230") },
                    { new Guid("024b6614-1197-4741-9baa-21acb8b2e9b8"), new Guid("63a854d0-a738-4684-9853-f83f051a88fc"), new Guid("4258f49d-10e3-4428-a398-66ffc5faa23f") },
                    { new Guid("a32ce416-2df8-468e-b8e3-e21e09bae391"), new Guid("63a854d0-a738-4684-9853-f83f051a88fc"), new Guid("dbde4b03-bd9c-4b18-81c3-9b24e0558003") },
                    { new Guid("56831e06-0fa7-448a-96b1-9e57386e8673"), new Guid("52f1f21c-bea3-498b-bafa-26846d550230"), new Guid("63a854d0-a738-4684-9853-f83f051a88fc") },
                    { new Guid("625f2f55-7cfe-4704-a6ab-31b4860c8bc4"), new Guid("4258f49d-10e3-4428-a398-66ffc5faa23f"), new Guid("63a854d0-a738-4684-9853-f83f051a88fc") },
                    { new Guid("7bb5336e-1d20-4cf4-9384-79dd515939fe"), new Guid("dbde4b03-bd9c-4b18-81c3-9b24e0558003"), new Guid("63a854d0-a738-4684-9853-f83f051a88fc") },
                    { new Guid("13f425d9-7d60-400f-8678-4533677aad3c"), new Guid("52ee48da-49f3-4701-93de-f113946380c9"), new Guid("4258f49d-10e3-4428-a398-66ffc5faa23f") },
                    { new Guid("12ab0405-5362-4c75-b05f-075fb4bee082"), new Guid("52ee48da-49f3-4701-93de-f113946380c9"), new Guid("2acb1828-07a0-45fd-b52e-15b7eb6e02ce") },
                    { new Guid("c9e6c97b-fc3e-4413-ae00-a2c4eed72df7"), new Guid("52ee48da-49f3-4701-93de-f113946380c9"), new Guid("dbde4b03-bd9c-4b18-81c3-9b24e0558003") },
                    { new Guid("3637aa83-d99f-443b-9ebf-ebcc81380982"), new Guid("4258f49d-10e3-4428-a398-66ffc5faa23f"), new Guid("52ee48da-49f3-4701-93de-f113946380c9") },
                    { new Guid("1f073a90-5478-4733-b9fc-7de8da003ff3"), new Guid("2acb1828-07a0-45fd-b52e-15b7eb6e02ce"), new Guid("52ee48da-49f3-4701-93de-f113946380c9") },
                    { new Guid("0178256e-4dde-4e3a-b238-217055230923"), new Guid("dbde4b03-bd9c-4b18-81c3-9b24e0558003"), new Guid("52ee48da-49f3-4701-93de-f113946380c9") },
                    { new Guid("98fca573-5601-4ce8-b4ce-f126b3eb1679"), new Guid("52f1f21c-bea3-498b-bafa-26846d550230"), new Guid("1c05a510-8e08-4e61-94f1-d5b9661a2b08") },
                    { new Guid("0e8d5781-4994-43fa-a259-466c0d4d9e09"), new Guid("52f1f21c-bea3-498b-bafa-26846d550230"), new Guid("dbde4b03-bd9c-4b18-81c3-9b24e0558003") },
                    { new Guid("5eeb35b3-e419-445d-95fb-82ea173e23fd"), new Guid("0bbca13e-e227-4aaa-a078-265c9133f278"), new Guid("2acb1828-07a0-45fd-b52e-15b7eb6e02ce") },
                    { new Guid("9bd09708-fe3f-4252-97fc-7fafcb820782"), new Guid("0bbca13e-e227-4aaa-a078-265c9133f278"), new Guid("52ee48da-49f3-4701-93de-f113946380c9") },
                    { new Guid("7b0d6283-864c-4f9f-9f51-bb4c452fdbe5"), new Guid("785e7ff9-229a-426c-b664-479312d4cf8d"), new Guid("a2ba1fd9-47c5-4938-b8b3-ab01bc245859") },
                    { new Guid("fea898eb-0d0d-45dc-b132-16586a78378f"), new Guid("a2ba1fd9-47c5-4938-b8b3-ab01bc245859"), new Guid("785e7ff9-229a-426c-b664-479312d4cf8d") },
                    { new Guid("e9b9d352-5f85-4761-a444-b8bd617422ca"), new Guid("78476d14-2f28-4e95-874e-09f1d4fd0171"), new Guid("a2ba1fd9-47c5-4938-b8b3-ab01bc245859") },
                    { new Guid("6ce59bbb-302e-4eeb-91fb-729236c22c92"), new Guid("78476d14-2f28-4e95-874e-09f1d4fd0171"), new Guid("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee") },
                    { new Guid("48d19e18-e4ec-460f-86e2-24442aefa9e4"), new Guid("a2ba1fd9-47c5-4938-b8b3-ab01bc245859"), new Guid("78476d14-2f28-4e95-874e-09f1d4fd0171") },
                    { new Guid("7007de1e-8e82-4dfd-87dd-7686307ac404"), new Guid("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee"), new Guid("78476d14-2f28-4e95-874e-09f1d4fd0171") },
                    { new Guid("eec0fb93-8805-4591-bff8-f478283daac8"), new Guid("9e8fd57a-abe9-4cd6-958c-53ec0ba6be80"), new Guid("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee") },
                    { new Guid("87ff6f21-797b-4c2f-89f6-0c00d1d37c4e"), new Guid("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee"), new Guid("9e8fd57a-abe9-4cd6-958c-53ec0ba6be80") },
                    { new Guid("054851ea-9db7-4c01-a6dd-69b2918dd48e"), new Guid("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"), new Guid("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee") },
                    { new Guid("b13d6430-ceea-476a-8068-1c255e6d656c"), new Guid("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee"), new Guid("11e3ebec-bf5b-4f1b-8488-aa509b066f2e") },
                    { new Guid("8413afa8-0686-431d-972c-c4033a58b6c4"), new Guid("b96c0bc3-abbb-49cc-a672-5ec6af45ca63"), new Guid("a2ba1fd9-47c5-4938-b8b3-ab01bc245859") },
                    { new Guid("a5616837-d90b-4745-b331-027ae44df2d8"), new Guid("a2ba1fd9-47c5-4938-b8b3-ab01bc245859"), new Guid("b96c0bc3-abbb-49cc-a672-5ec6af45ca63") },
                    { new Guid("2cb8bc3d-1a4f-45e5-8576-914028671133"), new Guid("3489baa7-b17e-4003-a78f-cb156dee058e"), new Guid("75020b4c-5dac-447f-941b-470fc5019eac") },
                    { new Guid("98760679-efa4-481c-ac9e-d349f0829162"), new Guid("3489baa7-b17e-4003-a78f-cb156dee058e"), new Guid("c8851fc2-7704-412d-b272-130cbed5f422") },
                    { new Guid("f6d6f9bb-c447-48f5-8b71-4c5395a69a28"), new Guid("52f1f21c-bea3-498b-bafa-26846d550230"), new Guid("5cc49bd4-a1bf-4f4b-9744-13668eae12f0") },
                    { new Guid("a5e290b6-d7ce-4da7-96d9-1e2dc8f62a4e"), new Guid("3489baa7-b17e-4003-a78f-cb156dee058e"), new Guid("a2ba1fd9-47c5-4938-b8b3-ab01bc245859") },
                    { new Guid("ad3c2e1f-1fc7-4c10-a393-2eb566c89743"), new Guid("75020b4c-5dac-447f-941b-470fc5019eac"), new Guid("3489baa7-b17e-4003-a78f-cb156dee058e") },
                    { new Guid("688c1023-d681-42e4-8fc9-ec5b693271f6"), new Guid("c8851fc2-7704-412d-b272-130cbed5f422"), new Guid("3489baa7-b17e-4003-a78f-cb156dee058e") },
                    { new Guid("e2919a55-8b5c-4f10-96ff-0de8d4565f78"), new Guid("a2ba1fd9-47c5-4938-b8b3-ab01bc245859"), new Guid("3489baa7-b17e-4003-a78f-cb156dee058e") },
                    { new Guid("571edfaf-5a51-4eef-ad91-bba8362b5aa9"), new Guid("785e7ff9-229a-426c-b664-479312d4cf8d"), new Guid("3489baa7-b17e-4003-a78f-cb156dee058e") },
                    { new Guid("9d38470d-37d0-42c4-9474-28ca7c9a56fe"), new Guid("75020b4c-5dac-447f-941b-470fc5019eac"), new Guid("785e7ff9-229a-426c-b664-479312d4cf8d") },
                    { new Guid("e867fc49-50ac-48e2-a52a-5ef2286897b8"), new Guid("785e7ff9-229a-426c-b664-479312d4cf8d"), new Guid("75020b4c-5dac-447f-941b-470fc5019eac") },
                    { new Guid("420e7c7a-2027-412b-83bb-f926c36bd14f"), new Guid("24e44487-3f98-42b9-9b44-818e5d8d7bbd"), new Guid("a2ba1fd9-47c5-4938-b8b3-ab01bc245859") },
                    { new Guid("45248194-8c88-42fd-b298-9186148c25c9"), new Guid("55b6f5bd-de1f-435f-a30d-e212e2684eb6"), new Guid("a2ba1fd9-47c5-4938-b8b3-ab01bc245859") },
                    { new Guid("5f6165cf-abaa-44c3-ac4b-95dea15de4d5"), new Guid("c8851fc2-7704-412d-b272-130cbed5f422"), new Guid("a2ba1fd9-47c5-4938-b8b3-ab01bc245859") },
                    { new Guid("0f79425e-9bcf-4bf8-bfe3-10e7cf414fbe"), new Guid("a2ba1fd9-47c5-4938-b8b3-ab01bc245859"), new Guid("24e44487-3f98-42b9-9b44-818e5d8d7bbd") },
                    { new Guid("f9c30f43-7280-43f2-880d-ebfc0ccb1b26"), new Guid("a2ba1fd9-47c5-4938-b8b3-ab01bc245859"), new Guid("55b6f5bd-de1f-435f-a30d-e212e2684eb6") },
                    { new Guid("f6f66706-c94b-4ac3-a7f2-6a5071f16ed4"), new Guid("a2ba1fd9-47c5-4938-b8b3-ab01bc245859"), new Guid("c8851fc2-7704-412d-b272-130cbed5f422") },
                    { new Guid("3011e2b3-e903-45d4-8471-a0130a885376"), new Guid("3489baa7-b17e-4003-a78f-cb156dee058e"), new Guid("785e7ff9-229a-426c-b664-479312d4cf8d") },
                    { new Guid("4177d2ec-cbc8-454a-9652-3c92397c44df"), new Guid("1c05a510-8e08-4e61-94f1-d5b9661a2b08"), new Guid("52f1f21c-bea3-498b-bafa-26846d550230") },
                    { new Guid("bc7c4701-d9b2-4168-9ca5-480bc8d3eae9"), new Guid("dbde4b03-bd9c-4b18-81c3-9b24e0558003"), new Guid("52f1f21c-bea3-498b-bafa-26846d550230") },
                    { new Guid("89affb92-0fcb-44e9-bf38-1c176a9f1a29"), new Guid("5cc49bd4-a1bf-4f4b-9744-13668eae12f0"), new Guid("52f1f21c-bea3-498b-bafa-26846d550230") },
                    { new Guid("329846a0-2eef-48ef-a449-a6ee7f4865cc"), new Guid("24e44487-3f98-42b9-9b44-818e5d8d7bbd"), new Guid("7c7b530a-ff06-4ee3-bcfd-8a79bf094a9b") },
                    { new Guid("6fc9081c-5971-4503-aca0-d04b5555526b"), new Guid("24e44487-3f98-42b9-9b44-818e5d8d7bbd"), new Guid("a484a81b-fcf0-42ea-82c2-ef353da33667") },
                    { new Guid("0b1ef2f5-cc6f-4759-b4e7-5448c0408542"), new Guid("24e44487-3f98-42b9-9b44-818e5d8d7bbd"), new Guid("55b6f5bd-de1f-435f-a30d-e212e2684eb6") },
                    { new Guid("91758849-e48e-4ba7-ba3f-1aefd4d87bfb"), new Guid("7c7b530a-ff06-4ee3-bcfd-8a79bf094a9b"), new Guid("24e44487-3f98-42b9-9b44-818e5d8d7bbd") },
                    { new Guid("cce89109-d0ca-4045-b7e7-301cbca7bed7"), new Guid("a484a81b-fcf0-42ea-82c2-ef353da33667"), new Guid("24e44487-3f98-42b9-9b44-818e5d8d7bbd") },
                    { new Guid("6bca2eea-7f60-44a1-bd09-281f39566f47"), new Guid("55b6f5bd-de1f-435f-a30d-e212e2684eb6"), new Guid("24e44487-3f98-42b9-9b44-818e5d8d7bbd") },
                    { new Guid("684c100e-fbd0-484a-a077-49feafe48521"), new Guid("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"), new Guid("24e44487-3f98-42b9-9b44-818e5d8d7bbd") },
                    { new Guid("20b1e983-c7c1-4b7f-8a51-9e8ba2d48b81"), new Guid("b10b8258-66e2-421a-bad5-cc76e1a3bb77"), new Guid("7c7b530a-ff06-4ee3-bcfd-8a79bf094a9b") },
                    { new Guid("de2a1eae-8797-4eae-938f-db5735394d50"), new Guid("b10b8258-66e2-421a-bad5-cc76e1a3bb77"), new Guid("a484a81b-fcf0-42ea-82c2-ef353da33667") },
                    { new Guid("ab2e8e9e-f24a-43d1-b19a-960963dd4c05"), new Guid("b10b8258-66e2-421a-bad5-cc76e1a3bb77"), new Guid("b508db1d-d8dc-4998-bbce-b110e00ac954") },
                    { new Guid("4981049a-a08d-4bbe-853d-4378267343e4"), new Guid("b10b8258-66e2-421a-bad5-cc76e1a3bb77"), new Guid("11e3ebec-bf5b-4f1b-8488-aa509b066f2e") },
                    { new Guid("79deab25-433c-4724-9677-5b65a4784119"), new Guid("b10b8258-66e2-421a-bad5-cc76e1a3bb77"), new Guid("961e1f7f-fc6f-440e-b11a-426bd93c32f0") },
                    { new Guid("72db4585-de18-475b-bb9a-901f62dff5c4"), new Guid("c8851fc2-7704-412d-b272-130cbed5f422"), new Guid("55b6f5bd-de1f-435f-a30d-e212e2684eb6") },
                    { new Guid("9f73e772-8239-4ee6-887b-e7163e348737"), new Guid("7c7b530a-ff06-4ee3-bcfd-8a79bf094a9b"), new Guid("b10b8258-66e2-421a-bad5-cc76e1a3bb77") },
                    { new Guid("287edf49-563f-4957-8a6c-a936406dd819"), new Guid("961e1f7f-fc6f-440e-b11a-426bd93c32f0"), new Guid("b10b8258-66e2-421a-bad5-cc76e1a3bb77") },
                    { new Guid("a535fb4c-2a81-49dd-8052-c13c7bc7a131"), new Guid("7c7b530a-ff06-4ee3-bcfd-8a79bf094a9b"), new Guid("a484a81b-fcf0-42ea-82c2-ef353da33667") },
                    { new Guid("9dafd18a-889a-42f7-aebb-446d29c40593"), new Guid("a484a81b-fcf0-42ea-82c2-ef353da33667"), new Guid("7c7b530a-ff06-4ee3-bcfd-8a79bf094a9b") },
                    { new Guid("064ab579-119b-45e9-a1f0-70fb3e35821f"), new Guid("961e1f7f-fc6f-440e-b11a-426bd93c32f0"), new Guid("7c7b530a-ff06-4ee3-bcfd-8a79bf094a9b") },
                    { new Guid("fee2d664-f1b7-4bb5-9cbf-ec4f3b3e68ea"), new Guid("a484a81b-fcf0-42ea-82c2-ef353da33667"), new Guid("55b6f5bd-de1f-435f-a30d-e212e2684eb6") },
                    { new Guid("a26f885b-c6a6-48cd-870e-0e937eb62022"), new Guid("a484a81b-fcf0-42ea-82c2-ef353da33667"), new Guid("961e1f7f-fc6f-440e-b11a-426bd93c32f0") },
                    { new Guid("b9bfeb92-43ab-4ad2-8a91-9234f0e39a9c"), new Guid("b508db1d-d8dc-4998-bbce-b110e00ac954"), new Guid("a484a81b-fcf0-42ea-82c2-ef353da33667") },
                    { new Guid("d86760f9-2c6a-4681-b62f-65de2bd3c6c3"), new Guid("55b6f5bd-de1f-435f-a30d-e212e2684eb6"), new Guid("a484a81b-fcf0-42ea-82c2-ef353da33667") },
                    { new Guid("ae4a5d51-1ee4-4a00-b8f3-e46a4b509702"), new Guid("961e1f7f-fc6f-440e-b11a-426bd93c32f0"), new Guid("a484a81b-fcf0-42ea-82c2-ef353da33667") },
                    { new Guid("9d25b3a3-23b4-4b39-8693-b7200c0a3b8f"), new Guid("b508db1d-d8dc-4998-bbce-b110e00ac954"), new Guid("55b6f5bd-de1f-435f-a30d-e212e2684eb6") },
                    { new Guid("35490311-fe1e-4ec4-89b5-0c8a54cf2f62"), new Guid("b508db1d-d8dc-4998-bbce-b110e00ac954"), new Guid("11e3ebec-bf5b-4f1b-8488-aa509b066f2e") },
                    { new Guid("e8b6928d-1479-49c7-a346-eb6f51df48bc"), new Guid("55b6f5bd-de1f-435f-a30d-e212e2684eb6"), new Guid("b508db1d-d8dc-4998-bbce-b110e00ac954") },
                    { new Guid("4c1078a9-eea0-4ec1-87f4-1ddf3387eaa7"), new Guid("b508db1d-d8dc-4998-bbce-b110e00ac954"), new Guid("b10b8258-66e2-421a-bad5-cc76e1a3bb77") },
                    { new Guid("2f3b0e70-0bb0-41bb-8d2c-cf722ead7159"), new Guid("78476d14-2f28-4e95-874e-09f1d4fd0171"), new Guid("b96c0bc3-abbb-49cc-a672-5ec6af45ca63") },
                    { new Guid("ebf02ae5-4462-44d4-9b35-9bd4cd37b575"), new Guid("c8851fc2-7704-412d-b272-130cbed5f422"), new Guid("b508db1d-d8dc-4998-bbce-b110e00ac954") },
                    { new Guid("9cd868e9-1164-428b-b6f9-499a7a6ec46e"), new Guid("b508db1d-d8dc-4998-bbce-b110e00ac954"), new Guid("c8851fc2-7704-412d-b272-130cbed5f422") },
                    { new Guid("9cc1e057-4f04-45c6-ad61-c069582b7455"), new Guid("4258f49d-10e3-4428-a398-66ffc5faa23f"), new Guid("2acb1828-07a0-45fd-b52e-15b7eb6e02ce") },
                    { new Guid("583f0108-be6b-43c5-9b82-85a492bbc18c"), new Guid("4258f49d-10e3-4428-a398-66ffc5faa23f"), new Guid("dbde4b03-bd9c-4b18-81c3-9b24e0558003") },
                    { new Guid("c5a3ff7f-4c3a-4b61-9151-ca9425afd94e"), new Guid("2acb1828-07a0-45fd-b52e-15b7eb6e02ce"), new Guid("4258f49d-10e3-4428-a398-66ffc5faa23f") },
                    { new Guid("11bf5592-d37b-4b1f-b54a-2104b3dc528e"), new Guid("dbde4b03-bd9c-4b18-81c3-9b24e0558003"), new Guid("4258f49d-10e3-4428-a398-66ffc5faa23f") },
                    { new Guid("6e422965-aced-42b9-b9cd-2665d32e8149"), new Guid("b508db1d-d8dc-4998-bbce-b110e00ac954"), new Guid("1c05a510-8e08-4e61-94f1-d5b9661a2b08") },
                    { new Guid("0e78dcac-a566-4e1e-b794-8bdbf641f9b6"), new Guid("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"), new Guid("1c05a510-8e08-4e61-94f1-d5b9661a2b08") },
                    { new Guid("e1004aab-8cd7-44c1-9693-0cc82cde43f6"), new Guid("1c05a510-8e08-4e61-94f1-d5b9661a2b08"), new Guid("b508db1d-d8dc-4998-bbce-b110e00ac954") },
                    { new Guid("aba375e7-b6f7-416a-bfe2-89ca11710ba8"), new Guid("1c05a510-8e08-4e61-94f1-d5b9661a2b08"), new Guid("11e3ebec-bf5b-4f1b-8488-aa509b066f2e") },
                    { new Guid("85e04383-89db-41a6-b0d1-8196db784b82"), new Guid("1c05a510-8e08-4e61-94f1-d5b9661a2b08"), new Guid("b59aa9c6-9441-4b8f-aabf-031eae7ef550") },
                    { new Guid("c50bac80-f011-4fe8-ad4a-c919c3e15e95"), new Guid("1c05a510-8e08-4e61-94f1-d5b9661a2b08"), new Guid("c8851fc2-7704-412d-b272-130cbed5f422") },
                    { new Guid("bc4bd17b-e660-4324-acf1-93a89ce41381"), new Guid("1c05a510-8e08-4e61-94f1-d5b9661a2b08"), new Guid("5cc49bd4-a1bf-4f4b-9744-13668eae12f0") },
                    { new Guid("231c9de1-cced-4328-b3a8-da02be157721"), new Guid("b59aa9c6-9441-4b8f-aabf-031eae7ef550"), new Guid("1c05a510-8e08-4e61-94f1-d5b9661a2b08") },
                    { new Guid("8982e7af-a014-4328-9dcb-7b7572399abd"), new Guid("55b6f5bd-de1f-435f-a30d-e212e2684eb6"), new Guid("c8851fc2-7704-412d-b272-130cbed5f422") },
                    { new Guid("8e1e8f45-9b84-4850-86ed-0d3184b37377"), new Guid("c8851fc2-7704-412d-b272-130cbed5f422"), new Guid("1c05a510-8e08-4e61-94f1-d5b9661a2b08") },
                    { new Guid("46919d99-61f2-4fb3-8b88-e3d532b81204"), new Guid("b59aa9c6-9441-4b8f-aabf-031eae7ef550"), new Guid("fbcf13f8-24f2-4f89-a9c0-bcada6f4ba62") },
                    { new Guid("7722b570-6b9a-4216-b690-f25b9ad1cef2"), new Guid("b59aa9c6-9441-4b8f-aabf-031eae7ef550"), new Guid("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e") },
                    { new Guid("64d90025-4ad2-4bd1-80ee-e86a7f6784f9"), new Guid("b59aa9c6-9441-4b8f-aabf-031eae7ef550"), new Guid("c8851fc2-7704-412d-b272-130cbed5f422") },
                    { new Guid("ee39859a-2cf1-4b44-8d92-31ae12785833"), new Guid("b59aa9c6-9441-4b8f-aabf-031eae7ef550"), new Guid("5cc49bd4-a1bf-4f4b-9744-13668eae12f0") },
                    { new Guid("32fd6686-e0e0-48c9-9261-f58b1773f87b"), new Guid("fbcf13f8-24f2-4f89-a9c0-bcada6f4ba62"), new Guid("b59aa9c6-9441-4b8f-aabf-031eae7ef550") },
                    { new Guid("d2311e93-f514-433d-b4d0-08897860d26e"), new Guid("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e"), new Guid("b59aa9c6-9441-4b8f-aabf-031eae7ef550") },
                    { new Guid("7df0233b-09c6-4c7a-9da4-f5a7c1061f4f"), new Guid("c8851fc2-7704-412d-b272-130cbed5f422"), new Guid("b59aa9c6-9441-4b8f-aabf-031eae7ef550") },
                    { new Guid("69db79f3-e2da-4e16-b377-9d4851d1aaba"), new Guid("5cc49bd4-a1bf-4f4b-9744-13668eae12f0"), new Guid("b59aa9c6-9441-4b8f-aabf-031eae7ef550") },
                    { new Guid("3de84467-75cc-427b-a0b8-379cc97a3d9f"), new Guid("fbcf13f8-24f2-4f89-a9c0-bcada6f4ba62"), new Guid("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e") },
                    { new Guid("4843c44f-04df-4300-877f-826522a64691"), new Guid("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e"), new Guid("fbcf13f8-24f2-4f89-a9c0-bcada6f4ba62") },
                    { new Guid("38d6249c-8c9a-4dcd-8a55-8ae525a7a5e9"), new Guid("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e"), new Guid("5cc49bd4-a1bf-4f4b-9744-13668eae12f0") },
                    { new Guid("a81e6def-12e4-4bc0-8de3-c7cc52b7d5ca"), new Guid("5cc49bd4-a1bf-4f4b-9744-13668eae12f0"), new Guid("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e") },
                    { new Guid("77da9467-6a95-4eff-a469-b067487f691f"), new Guid("5cc49bd4-a1bf-4f4b-9744-13668eae12f0"), new Guid("1c05a510-8e08-4e61-94f1-d5b9661a2b08") },
                    { new Guid("a5519133-2c3c-4d9d-a89a-63bba2462e47"), new Guid("57eb6e76-cfe4-491a-8c5b-2cbbf5d44217"), new Guid("c9220a79-ac83-4e46-a397-0830b052769e") },
                    { new Guid("9f080c1d-8c9b-4781-8600-7754c0f3392f"), new Guid("78476d14-2f28-4e95-874e-09f1d4fd0171"), new Guid("11e3ebec-bf5b-4f1b-8488-aa509b066f2e") },
                    { new Guid("372fb118-77db-4f2b-9713-4012efdec3b9"), new Guid("b96c0bc3-abbb-49cc-a672-5ec6af45ca63"), new Guid("78476d14-2f28-4e95-874e-09f1d4fd0171") },
                    { new Guid("7d147d42-db15-4680-a229-5b8a6526f21d"), new Guid("f1cfaa9c-44cc-4685-af6f-45ae258efb07"), new Guid("5f5ba403-ae25-440b-9f38-809881781211") },
                    { new Guid("b0a70e21-bd2e-4c69-839a-44423da9c27d"), new Guid("f1cfaa9c-44cc-4685-af6f-45ae258efb07"), new Guid("73d7b3b6-1018-4b19-a57b-d189d75c7c81") },
                    { new Guid("0483bf0d-f593-43a8-8552-3964259a92c2"), new Guid("75020b4c-5dac-447f-941b-470fc5019eac"), new Guid("f1cfaa9c-44cc-4685-af6f-45ae258efb07") },
                    { new Guid("c9fb13de-65c5-4a67-bdc1-6ed5dd77b18e"), new Guid("5f5ba403-ae25-440b-9f38-809881781211"), new Guid("f1cfaa9c-44cc-4685-af6f-45ae258efb07") },
                    { new Guid("8f60689a-c5fc-43df-a8f5-eececa7dd62f"), new Guid("73d7b3b6-1018-4b19-a57b-d189d75c7c81"), new Guid("f1cfaa9c-44cc-4685-af6f-45ae258efb07") },
                    { new Guid("fe194d6d-b5ba-401b-b232-dcf3a575dbb9"), new Guid("5f5ba403-ae25-440b-9f38-809881781211"), new Guid("73d7b3b6-1018-4b19-a57b-d189d75c7c81") },
                    { new Guid("3226f3ef-89db-4af3-9d72-15d0a18e4a8f"), new Guid("5f5ba403-ae25-440b-9f38-809881781211"), new Guid("fbcf13f8-24f2-4f89-a9c0-bcada6f4ba62") },
                    { new Guid("adb5a3ac-712b-4835-8963-d27f6b6a4fb1"), new Guid("73d7b3b6-1018-4b19-a57b-d189d75c7c81"), new Guid("5f5ba403-ae25-440b-9f38-809881781211") },
                    { new Guid("74dffb4b-bd39-435a-824e-920c47165fee"), new Guid("fbcf13f8-24f2-4f89-a9c0-bcada6f4ba62"), new Guid("5f5ba403-ae25-440b-9f38-809881781211") },
                    { new Guid("c4925045-7235-46c1-9408-23268ac2d7ba"), new Guid("0bbca13e-e227-4aaa-a078-265c9133f278"), new Guid("ff2b1187-63bf-46fa-a70c-4db6b323babb") },
                    { new Guid("165c3cdf-ba83-4042-b523-ed60d7b7c7c5"), new Guid("ff2b1187-63bf-46fa-a70c-4db6b323babb"), new Guid("0bbca13e-e227-4aaa-a078-265c9133f278") },
                    { new Guid("fe2a50cf-ce8c-4c4f-b62b-9fad861a97e1"), new Guid("ff2b1187-63bf-46fa-a70c-4db6b323babb"), new Guid("52ee48da-49f3-4701-93de-f113946380c9") },
                    { new Guid("9a8da0fa-f5b4-4437-8afe-80ce40928e3e"), new Guid("ff2b1187-63bf-46fa-a70c-4db6b323babb"), new Guid("d7c383af-e3b6-468c-a4cb-e20f08856972") },
                    { new Guid("d9969192-c237-4b98-ba37-83d9897556ef"), new Guid("ff2b1187-63bf-46fa-a70c-4db6b323babb"), new Guid("5614ee02-1939-4ab9-94a7-c64070908c65") },
                    { new Guid("ebe159e7-3b03-478c-b2f7-ddcdf20e0abd"), new Guid("ff2b1187-63bf-46fa-a70c-4db6b323babb"), new Guid("6b921a7d-143a-4014-b113-862ded825b60") },
                    { new Guid("949ac9f0-bfd4-45c7-bf70-707eb32d66ca"), new Guid("ff2b1187-63bf-46fa-a70c-4db6b323babb"), new Guid("310e87ad-0b29-470e-9120-b025a3a46c9f") },
                    { new Guid("ff0f64ea-a649-4af0-bf36-aedd3414a87e"), new Guid("ff2b1187-63bf-46fa-a70c-4db6b323babb"), new Guid("a435415d-d1f2-4af1-8de9-93af2ce43747") },
                    { new Guid("1fa0749c-03c3-44a5-a680-a530080a5d41"), new Guid("ff2b1187-63bf-46fa-a70c-4db6b323babb"), new Guid("3577171f-2b34-4d53-9aff-17885e7d4679") },
                    { new Guid("1c2ceb9b-e852-44c9-b5dd-39fae5b42f43"), new Guid("52ee48da-49f3-4701-93de-f113946380c9"), new Guid("ff2b1187-63bf-46fa-a70c-4db6b323babb") },
                    { new Guid("1cac38d1-d8ae-4b93-9a98-ebe2781bfbbb"), new Guid("d7c383af-e3b6-468c-a4cb-e20f08856972"), new Guid("ff2b1187-63bf-46fa-a70c-4db6b323babb") },
                    { new Guid("7f9baf91-c2cb-4c16-99c4-1ab9df8cc5ce"), new Guid("5614ee02-1939-4ab9-94a7-c64070908c65"), new Guid("ff2b1187-63bf-46fa-a70c-4db6b323babb") },
                    { new Guid("0e894842-4226-4fe9-be3c-796014cd4175"), new Guid("6b921a7d-143a-4014-b113-862ded825b60"), new Guid("ff2b1187-63bf-46fa-a70c-4db6b323babb") },
                    { new Guid("7509d07b-6d3d-449a-a5eb-3b36c8575e1a"), new Guid("310e87ad-0b29-470e-9120-b025a3a46c9f"), new Guid("ff2b1187-63bf-46fa-a70c-4db6b323babb") },
                    { new Guid("ea1f75d8-9486-4a32-bf21-0acb90e47914"), new Guid("a435415d-d1f2-4af1-8de9-93af2ce43747"), new Guid("ff2b1187-63bf-46fa-a70c-4db6b323babb") },
                    { new Guid("327375e1-4d80-4b21-8e63-78f059035d69"), new Guid("3577171f-2b34-4d53-9aff-17885e7d4679"), new Guid("ff2b1187-63bf-46fa-a70c-4db6b323babb") },
                    { new Guid("e2760a2d-9e70-4cbc-b2d0-fa17820c0f26"), new Guid("f1cfaa9c-44cc-4685-af6f-45ae258efb07"), new Guid("75020b4c-5dac-447f-941b-470fc5019eac") },
                    { new Guid("41a52d33-f0ae-4bec-9efc-503851093a17"), new Guid("f1cfaa9c-44cc-4685-af6f-45ae258efb07"), new Guid("3489baa7-b17e-4003-a78f-cb156dee058e") },
                    { new Guid("887c90aa-2335-48a9-980c-1381c56ce4e6"), new Guid("3489baa7-b17e-4003-a78f-cb156dee058e"), new Guid("f1cfaa9c-44cc-4685-af6f-45ae258efb07") },
                    { new Guid("7bc9269a-e943-4d67-b624-f7f9f99f92b0"), new Guid("c8851fc2-7704-412d-b272-130cbed5f422"), new Guid("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51") },
                    { new Guid("fe3a33d4-e1d3-44b7-8992-a361b57e603f"), new Guid("f1cfaa9c-44cc-4685-af6f-45ae258efb07"), new Guid("906ac8fa-ce00-4194-8d13-f517242777f4") },
                    { new Guid("23ba6106-a12e-4151-b944-46f081441056"), new Guid("75020b4c-5dac-447f-941b-470fc5019eac"), new Guid("906ac8fa-ce00-4194-8d13-f517242777f4") },
                    { new Guid("9b49a9da-0ccc-4f66-8cba-16e89ee4cd0f"), new Guid("73d7b3b6-1018-4b19-a57b-d189d75c7c81"), new Guid("906ac8fa-ce00-4194-8d13-f517242777f4") },
                    { new Guid("9e41459f-6b02-4d3f-904e-4c1c7790ad3d"), new Guid("906ac8fa-ce00-4194-8d13-f517242777f4"), new Guid("f1cfaa9c-44cc-4685-af6f-45ae258efb07") },
                    { new Guid("00793ff5-fee6-4492-962f-9c7218bb8ef3"), new Guid("906ac8fa-ce00-4194-8d13-f517242777f4"), new Guid("75020b4c-5dac-447f-941b-470fc5019eac") },
                    { new Guid("78ee4e2c-0fce-431e-a7a6-e3f9103cdf7a"), new Guid("906ac8fa-ce00-4194-8d13-f517242777f4"), new Guid("5f5ba403-ae25-440b-9f38-809881781211") },
                    { new Guid("da317893-b054-41c1-8202-8fbf181be878"), new Guid("906ac8fa-ce00-4194-8d13-f517242777f4"), new Guid("73d7b3b6-1018-4b19-a57b-d189d75c7c81") },
                    { new Guid("3a9017cd-2a0d-4798-8a7a-e72eb4e6b59e"), new Guid("906ac8fa-ce00-4194-8d13-f517242777f4"), new Guid("f351db6b-828b-462a-a032-1354a73733e8") },
                    { new Guid("e89eaa0a-3951-4ad9-b169-f7bf56c77c94"), new Guid("f351db6b-828b-462a-a032-1354a73733e8"), new Guid("906ac8fa-ce00-4194-8d13-f517242777f4") },
                    { new Guid("40fb68d7-e349-4737-ad03-7ef42acd410b"), new Guid("57eb6e76-cfe4-491a-8c5b-2cbbf5d44217"), new Guid("f351db6b-828b-462a-a032-1354a73733e8") },
                    { new Guid("8d5f694f-ada2-49f3-92dd-ff087c1011b8"), new Guid("f351db6b-828b-462a-a032-1354a73733e8"), new Guid("57eb6e76-cfe4-491a-8c5b-2cbbf5d44217") },
                    { new Guid("f9bd3243-9e12-4b39-b878-58d4ca00170f"), new Guid("f8c9d891-e9c5-43a1-8bfb-62f2cf51ab79"), new Guid("5f5ba403-ae25-440b-9f38-809881781211") },
                    { new Guid("c2b35904-4f17-4b93-9f4d-4f6f23856a22"), new Guid("0bbca13e-e227-4aaa-a078-265c9133f278"), new Guid("d7c383af-e3b6-468c-a4cb-e20f08856972") },
                    { new Guid("a5b25cd3-f9a1-4d5f-83b8-19426199ac09"), new Guid("f8c9d891-e9c5-43a1-8bfb-62f2cf51ab79"), new Guid("73d7b3b6-1018-4b19-a57b-d189d75c7c81") },
                    { new Guid("7e0bec02-3e2c-422d-bdd6-4b77fba2c848"), new Guid("73d7b3b6-1018-4b19-a57b-d189d75c7c81"), new Guid("f8c9d891-e9c5-43a1-8bfb-62f2cf51ab79") },
                    { new Guid("69b9774d-5869-48ab-a3cf-46468ba8f26e"), new Guid("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51"), new Guid("3489baa7-b17e-4003-a78f-cb156dee058e") },
                    { new Guid("db58b31b-e2be-4185-8b1c-7da8b3a0aea2"), new Guid("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51"), new Guid("f1cfaa9c-44cc-4685-af6f-45ae258efb07") },
                    { new Guid("bc2c9c9c-17be-45d6-a19c-deff1ded4326"), new Guid("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51"), new Guid("5f5ba403-ae25-440b-9f38-809881781211") },
                    { new Guid("0a88f956-54c5-4ca7-a27f-cd7405a1610c"), new Guid("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51"), new Guid("b59aa9c6-9441-4b8f-aabf-031eae7ef550") },
                    { new Guid("5785e758-59f9-464d-b142-667ce83c03e1"), new Guid("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51"), new Guid("fbcf13f8-24f2-4f89-a9c0-bcada6f4ba62") },
                    { new Guid("852b1824-c454-4837-86bc-0a25f349f345"), new Guid("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51"), new Guid("c8851fc2-7704-412d-b272-130cbed5f422") },
                    { new Guid("ec843a22-975b-4a86-a273-93a5d190bff0"), new Guid("3489baa7-b17e-4003-a78f-cb156dee058e"), new Guid("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51") },
                    { new Guid("91b2c0c8-d905-4326-adca-39eee5dedebd"), new Guid("f1cfaa9c-44cc-4685-af6f-45ae258efb07"), new Guid("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51") },
                    { new Guid("ab521b63-e84e-4393-9488-67a99be13e93"), new Guid("5f5ba403-ae25-440b-9f38-809881781211"), new Guid("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51") },
                    { new Guid("d76e1818-dc26-4698-891c-1dd11a0a61ff"), new Guid("b59aa9c6-9441-4b8f-aabf-031eae7ef550"), new Guid("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51") },
                    { new Guid("45d76ed9-89a3-456b-b6ba-e806ef84e3ea"), new Guid("fbcf13f8-24f2-4f89-a9c0-bcada6f4ba62"), new Guid("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51") },
                    { new Guid("897db842-32f0-48f4-aff4-d68a653dacb9"), new Guid("5f5ba403-ae25-440b-9f38-809881781211"), new Guid("f8c9d891-e9c5-43a1-8bfb-62f2cf51ab79") },
                    { new Guid("5275cb4e-cb9c-4d08-86f1-511ca8f8d042"), new Guid("d7c383af-e3b6-468c-a4cb-e20f08856972"), new Guid("0bbca13e-e227-4aaa-a078-265c9133f278") },
                    { new Guid("5a6c585a-9976-4ae4-97a5-49b94e3d3899"), new Guid("d7c383af-e3b6-468c-a4cb-e20f08856972"), new Guid("52ee48da-49f3-4701-93de-f113946380c9") },
                    { new Guid("7608e18d-fcbd-46d0-bd61-c07f4895b7b7"), new Guid("d7c383af-e3b6-468c-a4cb-e20f08856972"), new Guid("5614ee02-1939-4ab9-94a7-c64070908c65") },
                    { new Guid("709132d0-3f86-47e9-8cce-376cee0fc5a8"), new Guid("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee"), new Guid("9498c4a1-398d-4c06-8b49-aa84290cf2ca") },
                    { new Guid("6a26b526-77c1-40ef-a2c7-4d730e7d1188"), new Guid("667fec95-c40d-4289-b5d9-4760525509f3"), new Guid("30ba0a20-3568-4484-9df1-151de6fd36c2") },
                    { new Guid("4b9a878e-aa00-4130-9820-8f51741f8094"), new Guid("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"), new Guid("30ba0a20-3568-4484-9df1-151de6fd36c2") },
                    { new Guid("9512a2f5-b5e7-45d2-bb9a-26c5db59e96e"), new Guid("dbde4b03-bd9c-4b18-81c3-9b24e0558003"), new Guid("30ba0a20-3568-4484-9df1-151de6fd36c2") },
                    { new Guid("1815ea82-0d83-4baa-8ddc-4a7e45da757d"), new Guid("30ba0a20-3568-4484-9df1-151de6fd36c2"), new Guid("667fec95-c40d-4289-b5d9-4760525509f3") },
                    { new Guid("23662f53-6fad-4fb2-a0b1-79481ef38421"), new Guid("30ba0a20-3568-4484-9df1-151de6fd36c2"), new Guid("11e3ebec-bf5b-4f1b-8488-aa509b066f2e") },
                    { new Guid("7913432b-0e57-4510-94cd-ce7fcc8ccc53"), new Guid("30ba0a20-3568-4484-9df1-151de6fd36c2"), new Guid("dbde4b03-bd9c-4b18-81c3-9b24e0558003") },
                    { new Guid("d71aaf35-48c4-491c-8df0-ec13c46e243b"), new Guid("9e8fd57a-abe9-4cd6-958c-53ec0ba6be80"), new Guid("16cd59b4-3971-45ec-bd68-d26ac70d2da0") },
                    { new Guid("6434b6e1-62b2-42ef-855e-90abc21cd82e"), new Guid("16cd59b4-3971-45ec-bd68-d26ac70d2da0"), new Guid("9e8fd57a-abe9-4cd6-958c-53ec0ba6be80") },
                    { new Guid("715e6af2-6c62-42da-9d17-330d143f668d"), new Guid("16cd59b4-3971-45ec-bd68-d26ac70d2da0"), new Guid("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee") },
                    { new Guid("a15565de-ff40-4bc6-87ea-4e1a04494f1f"), new Guid("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee"), new Guid("16cd59b4-3971-45ec-bd68-d26ac70d2da0") },
                    { new Guid("ee40ea3b-70d4-4738-b432-c728c6bd31d0"), new Guid("343e77cb-a854-416b-aeac-86c9ffad82ce"), new Guid("b96c0bc3-abbb-49cc-a672-5ec6af45ca63") },
                    { new Guid("3be82052-6d2e-4bfb-b4e3-2980d7e14090"), new Guid("16cd59b4-3971-45ec-bd68-d26ac70d2da0"), new Guid("9498c4a1-398d-4c06-8b49-aa84290cf2ca") },
                    { new Guid("b4e291f7-a623-4327-893f-c8d0a269d890"), new Guid("343e77cb-a854-416b-aeac-86c9ffad82ce"), new Guid("7591742b-97d3-4b0a-81a6-20a4247d47ca") },
                    { new Guid("9d019691-495d-4916-9d66-92cdbc25ae89"), new Guid("343e77cb-a854-416b-aeac-86c9ffad82ce"), new Guid("9e8fd57a-abe9-4cd6-958c-53ec0ba6be80") },
                    { new Guid("ab0eb70d-4da6-4ec3-a03a-85a3652daceb"), new Guid("343e77cb-a854-416b-aeac-86c9ffad82ce"), new Guid("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee") },
                    { new Guid("de662deb-75e0-4a9f-bf27-d518d566a71d"), new Guid("b96c0bc3-abbb-49cc-a672-5ec6af45ca63"), new Guid("343e77cb-a854-416b-aeac-86c9ffad82ce") },
                    { new Guid("abffdbb3-f135-48a6-a636-c6d4b2d379bb"), new Guid("7591742b-97d3-4b0a-81a6-20a4247d47ca"), new Guid("343e77cb-a854-416b-aeac-86c9ffad82ce") },
                    { new Guid("fd087bc4-d301-43ec-8e0e-31f9b03636ed"), new Guid("78476d14-2f28-4e95-874e-09f1d4fd0171"), new Guid("343e77cb-a854-416b-aeac-86c9ffad82ce") },
                    { new Guid("defd3ab6-05e7-45b3-aad1-053a2ea3b6bf"), new Guid("9e8fd57a-abe9-4cd6-958c-53ec0ba6be80"), new Guid("343e77cb-a854-416b-aeac-86c9ffad82ce") },
                    { new Guid("89053b2d-8b2c-4c97-8206-637f9edba134"), new Guid("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee"), new Guid("343e77cb-a854-416b-aeac-86c9ffad82ce") },
                    { new Guid("a23e8d41-7155-4060-848b-a8366c307b7c"), new Guid("7591742b-97d3-4b0a-81a6-20a4247d47ca"), new Guid("9e8fd57a-abe9-4cd6-958c-53ec0ba6be80") },
                    { new Guid("86c0279e-3ea7-424a-b46b-026be94fc653"), new Guid("7591742b-97d3-4b0a-81a6-20a4247d47ca"), new Guid("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee") },
                    { new Guid("9a4e2046-e430-4f87-aff4-b82cc8eee701"), new Guid("9e8fd57a-abe9-4cd6-958c-53ec0ba6be80"), new Guid("7591742b-97d3-4b0a-81a6-20a4247d47ca") },
                    { new Guid("1feb5caf-7282-48e3-aa52-ca774df049dc"), new Guid("24e44487-3f98-42b9-9b44-818e5d8d7bbd"), new Guid("78476d14-2f28-4e95-874e-09f1d4fd0171") },
                    { new Guid("e0fb8a07-04f0-4a80-a62e-51b5bac445ee"), new Guid("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"), new Guid("78476d14-2f28-4e95-874e-09f1d4fd0171") },
                    { new Guid("c7d4d8d6-477f-4c7e-9a09-d161a89b7822"), new Guid("343e77cb-a854-416b-aeac-86c9ffad82ce"), new Guid("78476d14-2f28-4e95-874e-09f1d4fd0171") },
                    { new Guid("08fa9c60-f101-4a0b-bdc7-3b18f2f2020b"), new Guid("78476d14-2f28-4e95-874e-09f1d4fd0171"), new Guid("24e44487-3f98-42b9-9b44-818e5d8d7bbd") },
                    { new Guid("9a0157d0-9241-415e-b7da-1e85e2a81a3b"), new Guid("30ba0a20-3568-4484-9df1-151de6fd36c2"), new Guid("9498c4a1-398d-4c06-8b49-aa84290cf2ca") },
                    { new Guid("0324b024-802e-443a-8b54-c8f8e18be841"), new Guid("9498c4a1-398d-4c06-8b49-aa84290cf2ca"), new Guid("16cd59b4-3971-45ec-bd68-d26ac70d2da0") },
                    { new Guid("81889e2e-c2b5-4673-aeef-c243411b79af"), new Guid("5614ee02-1939-4ab9-94a7-c64070908c65"), new Guid("d7c383af-e3b6-468c-a4cb-e20f08856972") },
                    { new Guid("37e7fcfb-48cf-49ec-b9a5-0fbd54c5b1bc"), new Guid("5614ee02-1939-4ab9-94a7-c64070908c65"), new Guid("6b921a7d-143a-4014-b113-862ded825b60") },
                    { new Guid("47c385d0-7a8e-47e5-9375-cce879ba543e"), new Guid("5614ee02-1939-4ab9-94a7-c64070908c65"), new Guid("a435415d-d1f2-4af1-8de9-93af2ce43747") },
                    { new Guid("efbfed22-1049-4e4c-883c-1da8bd878818"), new Guid("6b921a7d-143a-4014-b113-862ded825b60"), new Guid("5614ee02-1939-4ab9-94a7-c64070908c65") },
                    { new Guid("224be211-ed91-4651-9aa8-59aca75dad42"), new Guid("a435415d-d1f2-4af1-8de9-93af2ce43747"), new Guid("5614ee02-1939-4ab9-94a7-c64070908c65") },
                    { new Guid("0d495d85-551c-4b26-8952-694fe306e5d4"), new Guid("6b921a7d-143a-4014-b113-862ded825b60"), new Guid("a435415d-d1f2-4af1-8de9-93af2ce43747") },
                    { new Guid("1b7a6348-97ac-4b73-b292-8c0d558e5ec3"), new Guid("a435415d-d1f2-4af1-8de9-93af2ce43747"), new Guid("6b921a7d-143a-4014-b113-862ded825b60") },
                    { new Guid("018dc9c9-43e1-41bf-b731-4efef4acbeda"), new Guid("310e87ad-0b29-470e-9120-b025a3a46c9f"), new Guid("a435415d-d1f2-4af1-8de9-93af2ce43747") },
                    { new Guid("dc3497d5-4ba4-4605-9454-822c1f6ba515"), new Guid("310e87ad-0b29-470e-9120-b025a3a46c9f"), new Guid("3577171f-2b34-4d53-9aff-17885e7d4679") },
                    { new Guid("c41e06c7-3e53-4ff6-9c44-5d16b59123ca"), new Guid("310e87ad-0b29-470e-9120-b025a3a46c9f"), new Guid("9498c4a1-398d-4c06-8b49-aa84290cf2ca") },
                    { new Guid("a96af417-4320-4935-a4ef-247cff00286f"), new Guid("310e87ad-0b29-470e-9120-b025a3a46c9f"), new Guid("16cd59b4-3971-45ec-bd68-d26ac70d2da0") },
                    { new Guid("afb84516-86d5-4adb-b961-19b559f379c5"), new Guid("a435415d-d1f2-4af1-8de9-93af2ce43747"), new Guid("310e87ad-0b29-470e-9120-b025a3a46c9f") },
                    { new Guid("822a4cb4-63cf-4d87-adab-b063375f5ef2"), new Guid("9498c4a1-398d-4c06-8b49-aa84290cf2ca"), new Guid("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee") },
                    { new Guid("8c26080c-c2a1-471d-9604-e759d4468a3f"), new Guid("3577171f-2b34-4d53-9aff-17885e7d4679"), new Guid("310e87ad-0b29-470e-9120-b025a3a46c9f") },
                    { new Guid("04721c73-9ab1-4bdc-8589-bbf263955df6"), new Guid("16cd59b4-3971-45ec-bd68-d26ac70d2da0"), new Guid("310e87ad-0b29-470e-9120-b025a3a46c9f") },
                    { new Guid("e85675a1-53f7-4f73-865d-df02534db9cd"), new Guid("52ee48da-49f3-4701-93de-f113946380c9"), new Guid("3577171f-2b34-4d53-9aff-17885e7d4679") },
                    { new Guid("bb16b787-957d-477e-923d-99ad7aa73c65"), new Guid("3577171f-2b34-4d53-9aff-17885e7d4679"), new Guid("52ee48da-49f3-4701-93de-f113946380c9") },
                    { new Guid("21b6ad05-77f4-4c61-8ef7-a4fa388e5440"), new Guid("3577171f-2b34-4d53-9aff-17885e7d4679"), new Guid("9498c4a1-398d-4c06-8b49-aa84290cf2ca") },
                    { new Guid("33c4170a-c527-47dc-af21-03a1d19ea0df"), new Guid("3577171f-2b34-4d53-9aff-17885e7d4679"), new Guid("dbde4b03-bd9c-4b18-81c3-9b24e0558003") },
                    { new Guid("8e4998f5-f7bf-40ad-a324-20633fa4b723"), new Guid("3577171f-2b34-4d53-9aff-17885e7d4679"), new Guid("30ba0a20-3568-4484-9df1-151de6fd36c2") },
                    { new Guid("2b5dc953-6d50-43ff-b0de-358d18c68f99"), new Guid("9498c4a1-398d-4c06-8b49-aa84290cf2ca"), new Guid("3577171f-2b34-4d53-9aff-17885e7d4679") },
                    { new Guid("b44d9835-c952-435f-af10-2286f51cb106"), new Guid("dbde4b03-bd9c-4b18-81c3-9b24e0558003"), new Guid("3577171f-2b34-4d53-9aff-17885e7d4679") },
                    { new Guid("eaea3587-e956-4b01-ae03-7b00c2f79dce"), new Guid("30ba0a20-3568-4484-9df1-151de6fd36c2"), new Guid("3577171f-2b34-4d53-9aff-17885e7d4679") },
                    { new Guid("7b307636-80bc-4bd3-b927-8693e161b8fe"), new Guid("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"), new Guid("9498c4a1-398d-4c06-8b49-aa84290cf2ca") },
                    { new Guid("5cbdd9c8-4867-43c1-8014-024ce945d774"), new Guid("9498c4a1-398d-4c06-8b49-aa84290cf2ca"), new Guid("11e3ebec-bf5b-4f1b-8488-aa509b066f2e") },
                    { new Guid("fb730aa1-c03c-418d-aad7-13fcf7fd1623"), new Guid("9498c4a1-398d-4c06-8b49-aa84290cf2ca"), new Guid("30ba0a20-3568-4484-9df1-151de6fd36c2") },
                    { new Guid("c2fe02df-3b9a-4e68-a35f-f844ed7a362e"), new Guid("9498c4a1-398d-4c06-8b49-aa84290cf2ca"), new Guid("310e87ad-0b29-470e-9120-b025a3a46c9f") },
                    { new Guid("2426e1cd-e8a9-48ff-aa07-675829d2a485"), new Guid("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1"), new Guid("11d695a1-9893-4f18-a2ab-f61078233585") }
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
