using System;
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

            builder.HasData(
                new Department()
                {
                    Name = "Ain", Code = "01", RegionId = Guid.Parse("bbfa939b-d5c7-4428-9537-dc063457270a"),
                    Id = Guid.Parse("1ef7fde0-47b6-4fda-810c-44c33d1fbee8")
                },
                new Department()
                {
                    Name = "Aisne", Code = "02", RegionId = Guid.Parse("3a008295-2e8f-42e9-aa87-485d150d58db"),
                    Id = Guid.Parse("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee")
                },
                new Department()
                {
                    Name = "Allier", Code = "03", RegionId = Guid.Parse("bbfa939b-d5c7-4428-9537-dc063457270a"),
                    Id = Guid.Parse("cc023a01-8a9b-4ed6-b41c-9388c363db49")
                },
                new Department()
                {
                    Name = "Alpes-de-Haute-Provence", Code = "04",
                    RegionId = Guid.Parse("00d9720b-6f64-477d-8651-304b74c2f4c3"),
                    Id = Guid.Parse("1bf0a210-c750-4e98-9151-7eaefa8185c7")
                },
                new Department()
                {
                    Name = "Hautes-Alpes", Code = "05", RegionId = Guid.Parse("00d9720b-6f64-477d-8651-304b74c2f4c3"),
                    Id = Guid.Parse("85ef4758-c7a8-4cbc-9416-caaea32e4d05")
                },
                new Department()
                {
                    Name = "Alpes-Maritimes", Code = "06",
                    RegionId = Guid.Parse("00d9720b-6f64-477d-8651-304b74c2f4c3"),
                    Id = Guid.Parse("6b787904-7e30-450b-aac4-2867a6f72100")
                },
                new Department()
                {
                    Name = "Ardèche", Code = "07", RegionId = Guid.Parse("bbfa939b-d5c7-4428-9537-dc063457270a"),
                    Id = Guid.Parse("c1aed70b-666e-4f32-bee2-f52722d89b1f")
                },
                new Department()
                {
                    Name = "Ardennes", Code = "08", RegionId = Guid.Parse("5823a48a-b05e-47cb-91eb-f1d0877a07b5"),
                    Id = Guid.Parse("16cd59b4-3971-45ec-bd68-d26ac70d2da0")
                },
                new Department()
                {
                    Name = "Ariège", Code = "09", RegionId = Guid.Parse("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15"),
                    Id = Guid.Parse("77d7dc5d-545b-4f53-8db2-bf3245f3c131")
                },
                new Department()
                {
                    Name = "Aube", Code = "10", RegionId = Guid.Parse("5823a48a-b05e-47cb-91eb-f1d0877a07b5"),
                    Id = Guid.Parse("30ba0a20-3568-4484-9df1-151de6fd36c2")
                },
                new Department()
                {
                    Name = "Aude", Code = "11", RegionId = Guid.Parse("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15"),
                    Id = Guid.Parse("aec85880-4ac9-43c9-be3f-a47a41d0e88e")
                },
                new Department()
                {
                    Name = "Aveyron", Code = "12", RegionId = Guid.Parse("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15"),
                    Id = Guid.Parse("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd")
                },
                new Department()
                {
                    Name = "Bouches-du-Rhône", Code = "13",
                    RegionId = Guid.Parse("00d9720b-6f64-477d-8651-304b74c2f4c3"),
                    Id = Guid.Parse("95f28447-33e7-449f-8bd7-ecdabaae501f")
                },
                new Department()
                {
                    Name = "Calvados", Code = "14", RegionId = Guid.Parse("26a3ed8e-ef43-46df-8722-38d48170c391"),
                    Id = Guid.Parse("785e7ff9-229a-426c-b664-479312d4cf8d")
                },
                new Department()
                {
                    Name = "Cantal", Code = "15", RegionId = Guid.Parse("bbfa939b-d5c7-4428-9537-dc063457270a"),
                    Id = Guid.Parse("95295597-7518-4999-bdd7-52ef36bd24c0")
                },
                new Department()
                {
                    Name = "Charente", Code = "16", RegionId = Guid.Parse("554a957c-4b70-4893-8ed7-4c8e09ad2b00"),
                    Id = Guid.Parse("cbfb8d4a-5fad-4c9e-8faa-d035cd093928")
                },
                new Department()
                {
                    Name = "Charente-Maritime", Code = "17",
                    RegionId = Guid.Parse("554a957c-4b70-4893-8ed7-4c8e09ad2b00"),
                    Id = Guid.Parse("8963790c-6864-429c-bd8b-35338c53a170")
                },
                new Department()
                {
                    Name = "Cher", Code = "18", RegionId = Guid.Parse("6651a27f-e548-4404-a7a5-c8b956d4906e"),
                    Id = Guid.Parse("5cc49bd4-a1bf-4f4b-9744-13668eae12f0")
                },
                new Department()
                {
                    Name = "Corrèze", Code = "19", RegionId = Guid.Parse("554a957c-4b70-4893-8ed7-4c8e09ad2b00"),
                    Id = Guid.Parse("c1bd362f-88bd-4e6a-8928-ad6d29ee549a")
                },
                new Department()
                {
                    Name = "Côte-d'Or", Code = "21", RegionId = Guid.Parse("c1524a03-e7c5-4959-ac10-4e569196e743"),
                    Id = Guid.Parse("dbde4b03-bd9c-4b18-81c3-9b24e0558003")
                },
                new Department()
                {
                    Name = "Côtes-d'Armor", Code = "22", RegionId = Guid.Parse("14225638-c769-458b-995e-53629890d38d"),
                    Id = Guid.Parse("f351db6b-828b-462a-a032-1354a73733e8")
                },
                new Department()
                {
                    Name = "Creuse", Code = "23", RegionId = Guid.Parse("554a957c-4b70-4893-8ed7-4c8e09ad2b00"),
                    Id = Guid.Parse("28cce0f5-1692-4db3-af74-e4efc3aef1e6")
                },
                new Department()
                {
                    Name = "Dordogne", Code = "24", RegionId = Guid.Parse("554a957c-4b70-4893-8ed7-4c8e09ad2b00"),
                    Id = Guid.Parse("44cc60d3-d233-4bf1-92c1-539961e5be6b")
                },
                new Department()
                {
                    Name = "Doubs", Code = "25", RegionId = Guid.Parse("c1524a03-e7c5-4959-ac10-4e569196e743"),
                    Id = Guid.Parse("2acb1828-07a0-45fd-b52e-15b7eb6e02ce")
                },
                new Department()
                {
                    Name = "Drôme", Code = "26", RegionId = Guid.Parse("bbfa939b-d5c7-4428-9537-dc063457270a"),
                    Id = Guid.Parse("6a16c6c6-4b11-4651-b291-739fd143cb19")
                },
                new Department()
                {
                    Name = "Eure", Code = "27", RegionId = Guid.Parse("26a3ed8e-ef43-46df-8722-38d48170c391"),
                    Id = Guid.Parse("a2ba1fd9-47c5-4938-b8b3-ab01bc245859")
                },
                new Department()
                {
                    Name = "Eure-et-Loir", Code = "28", RegionId = Guid.Parse("6651a27f-e548-4404-a7a5-c8b956d4906e"),
                    Id = Guid.Parse("c8851fc2-7704-412d-b272-130cbed5f422")
                },
                new Department()
                {
                    Name = "Finistère", Code = "29", RegionId = Guid.Parse("14225638-c769-458b-995e-53629890d38d"),
                    Id = Guid.Parse("57eb6e76-cfe4-491a-8c5b-2cbbf5d44217")
                },
                new Department()
                {
                    Name = "Corse-du-Sud", Code = "2A", RegionId = Guid.Parse("7ce01654-58a0-4c59-b5af-62351080e52f"),
                    Id = Guid.Parse("8cf0438a-cb72-4ff1-9caa-7a40f4cc400a")
                },
                new Department()
                {
                    Name = "Haute-Corse", Code = "2B", RegionId = Guid.Parse("7ce01654-58a0-4c59-b5af-62351080e52f"),
                    Id = Guid.Parse("2a24196d-0a4c-4928-9f79-bd498bcfc219")
                },
                new Department()
                {
                    Name = "Gard", Code = "30", RegionId = Guid.Parse("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15"),
                    Id = Guid.Parse("11d695a1-9893-4f18-a2ab-f61078233585")
                },
                new Department()
                {
                    Name = "Haute-Garonne", Code = "31", RegionId = Guid.Parse("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15"),
                    Id = Guid.Parse("d56fc07c-39f9-42c6-aaf5-640b2b5f6124")
                },
                new Department()
                {
                    Name = "Gers", Code = "32", RegionId = Guid.Parse("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15"),
                    Id = Guid.Parse("e007dcb1-8678-47ab-90dd-441f76873b9e")
                },
                new Department()
                {
                    Name = "Gironde", Code = "33", RegionId = Guid.Parse("554a957c-4b70-4893-8ed7-4c8e09ad2b00"),
                    Id = Guid.Parse("e7931a2e-e969-43a2-9c71-542549fc41aa")
                },
                new Department()
                {
                    Name = "Hérault", Code = "34", RegionId = Guid.Parse("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15"),
                    Id = Guid.Parse("1632f86b-846f-4a69-b4a2-e5f6dd7d4742")
                },
                new Department()
                {
                    Name = "Ille-et-Vilaine", Code = "35",
                    RegionId = Guid.Parse("14225638-c769-458b-995e-53629890d38d"),
                    Id = Guid.Parse("906ac8fa-ce00-4194-8d13-f517242777f4")
                },
                new Department()
                {
                    Name = "Indre", Code = "36", RegionId = Guid.Parse("6651a27f-e548-4404-a7a5-c8b956d4906e"),
                    Id = Guid.Parse("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e")
                },
                new Department()
                {
                    Name = "Indre-et-Loire", Code = "37", RegionId = Guid.Parse("6651a27f-e548-4404-a7a5-c8b956d4906e"),
                    Id = Guid.Parse("fbcf13f8-24f2-4f89-a9c0-bcada6f4ba62")
                },
                new Department()
                {
                    Name = "Isère", Code = "38", RegionId = Guid.Parse("bbfa939b-d5c7-4428-9537-dc063457270a"),
                    Id = Guid.Parse("8ce39bf5-92de-48db-bb8b-30892a4a090f")
                },
                new Department()
                {
                    Name = "Jura", Code = "39", RegionId = Guid.Parse("c1524a03-e7c5-4959-ac10-4e569196e743"),
                    Id = Guid.Parse("4258f49d-10e3-4428-a398-66ffc5faa23f")
                },
                new Department()
                {
                    Name = "Landes", Code = "40", RegionId = Guid.Parse("554a957c-4b70-4893-8ed7-4c8e09ad2b00"),
                    Id = Guid.Parse("d3cb1fd0-444e-4e2a-82a2-7382536b1770")
                },
                new Department()
                {
                    Name = "Loir-et-Cher", Code = "41", RegionId = Guid.Parse("6651a27f-e548-4404-a7a5-c8b956d4906e"),
                    Id = Guid.Parse("b59aa9c6-9441-4b8f-aabf-031eae7ef550")
                },
                new Department()
                {
                    Name = "Loire", Code = "42", RegionId = Guid.Parse("bbfa939b-d5c7-4428-9537-dc063457270a"),
                    Id = Guid.Parse("dd1e3ba1-385c-4941-8d5b-dfbfa1554154")
                },
                new Department()
                {
                    Name = "Haute-Loire", Code = "43", RegionId = Guid.Parse("bbfa939b-d5c7-4428-9537-dc063457270a"),
                    Id = Guid.Parse("470669cc-1d05-4d07-838e-3aea8923d7c6")
                },
                new Department()
                {
                    Name = "Loire-Atlantique", Code = "44",
                    RegionId = Guid.Parse("e3a4faa4-4582-40d9-b5ac-154d66170041"),
                    Id = Guid.Parse("73d7b3b6-1018-4b19-a57b-d189d75c7c81")
                },
                new Department()
                {
                    Name = "Loiret", Code = "45", RegionId = Guid.Parse("6651a27f-e548-4404-a7a5-c8b956d4906e"),
                    Id = Guid.Parse("1c05a510-8e08-4e61-94f1-d5b9661a2b08")
                },
                new Department()
                {
                    Name = "Lot", Code = "46", RegionId = Guid.Parse("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15"),
                    Id = Guid.Parse("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b")
                },
                new Department()
                {
                    Name = "Lot-et-Garonne", Code = "47", RegionId = Guid.Parse("554a957c-4b70-4893-8ed7-4c8e09ad2b00"),
                    Id = Guid.Parse("cbf1b899-4d3d-4155-bae7-07915a6b8c09")
                },
                new Department()
                {
                    Name = "Lozère", Code = "48", RegionId = Guid.Parse("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15"),
                    Id = Guid.Parse("82973925-433a-4f55-89c8-f41fc398a0c2")
                },
                new Department()
                {
                    Name = "Maine-et-Loire", Code = "49", RegionId = Guid.Parse("e3a4faa4-4582-40d9-b5ac-154d66170041"),
                    Id = Guid.Parse("5f5ba403-ae25-440b-9f38-809881781211")
                },
                new Department()
                {
                    Name = "Manche", Code = "50", RegionId = Guid.Parse("26a3ed8e-ef43-46df-8722-38d48170c391"),
                    Id = Guid.Parse("75020b4c-5dac-447f-941b-470fc5019eac")
                },
                new Department()
                {
                    Name = "Marne", Code = "51", RegionId = Guid.Parse("5823a48a-b05e-47cb-91eb-f1d0877a07b5"),
                    Id = Guid.Parse("9498c4a1-398d-4c06-8b49-aa84290cf2ca")
                },
                new Department()
                {
                    Name = "Haute-Marne", Code = "52", RegionId = Guid.Parse("5823a48a-b05e-47cb-91eb-f1d0877a07b5"),
                    Id = Guid.Parse("3577171f-2b34-4d53-9aff-17885e7d4679")
                },
                new Department()
                {
                    Name = "Mayenne", Code = "53", RegionId = Guid.Parse("e3a4faa4-4582-40d9-b5ac-154d66170041"),
                    Id = Guid.Parse("f1cfaa9c-44cc-4685-af6f-45ae258efb07")
                },
                new Department()
                {
                    Name = "Meurthe-et-Moselle", Code = "54",
                    RegionId = Guid.Parse("5823a48a-b05e-47cb-91eb-f1d0877a07b5"),
                    Id = Guid.Parse("a435415d-d1f2-4af1-8de9-93af2ce43747")
                },
                new Department()
                {
                    Name = "Meuse", Code = "55", RegionId = Guid.Parse("5823a48a-b05e-47cb-91eb-f1d0877a07b5"),
                    Id = Guid.Parse("310e87ad-0b29-470e-9120-b025a3a46c9f")
                },
                new Department()
                {
                    Name = "Morbihan", Code = "56", RegionId = Guid.Parse("14225638-c769-458b-995e-53629890d38d"),
                    Id = Guid.Parse("c9220a79-ac83-4e46-a397-0830b052769e")
                },
                new Department()
                {
                    Name = "Moselle", Code = "57", RegionId = Guid.Parse("5823a48a-b05e-47cb-91eb-f1d0877a07b5"),
                    Id = Guid.Parse("6b921a7d-143a-4014-b113-862ded825b60")
                },
                new Department()
                {
                    Name = "Nièvre", Code = "58", RegionId = Guid.Parse("c1524a03-e7c5-4959-ac10-4e569196e743"),
                    Id = Guid.Parse("52f1f21c-bea3-498b-bafa-26846d550230")
                },
                new Department()
                {
                    Name = "Nord", Code = "59", RegionId = Guid.Parse("3a008295-2e8f-42e9-aa87-485d150d58db"),
                    Id = Guid.Parse("9e8fd57a-abe9-4cd6-958c-53ec0ba6be80")
                },
                new Department()
                {
                    Name = "Oise", Code = "60", RegionId = Guid.Parse("3a008295-2e8f-42e9-aa87-485d150d58db"),
                    Id = Guid.Parse("78476d14-2f28-4e95-874e-09f1d4fd0171")
                },
                new Department()
                {
                    Name = "Orne", Code = "61", RegionId = Guid.Parse("26a3ed8e-ef43-46df-8722-38d48170c391"),
                    Id = Guid.Parse("3489baa7-b17e-4003-a78f-cb156dee058e")
                },
                new Department()
                {
                    Name = "Pas-de-Calais", Code = "62", RegionId = Guid.Parse("3a008295-2e8f-42e9-aa87-485d150d58db"),
                    Id = Guid.Parse("7591742b-97d3-4b0a-81a6-20a4247d47ca")
                },
                new Department()
                {
                    Name = "Puy-de-Dôme", Code = "63", RegionId = Guid.Parse("bbfa939b-d5c7-4428-9537-dc063457270a"),
                    Id = Guid.Parse("11560417-8292-4dfd-b345-9e4a207ee6ca")
                },
                new Department()
                {
                    Name = "Pyrénées-Atlantiques", Code = "64",
                    RegionId = Guid.Parse("554a957c-4b70-4893-8ed7-4c8e09ad2b00"),
                    Id = Guid.Parse("895ce97a-633b-4782-b060-f276b4141e90")
                },
                new Department()
                {
                    Name = "Hautes-Pyrénées", Code = "65",
                    RegionId = Guid.Parse("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15"),
                    Id = Guid.Parse("4c3a1f47-f735-4390-ae4d-f979e16c562c")
                },
                new Department()
                {
                    Name = "Pyrénées-Orientales", Code = "66",
                    RegionId = Guid.Parse("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15"),
                    Id = Guid.Parse("caa74253-c115-4cb7-8b63-ee23545a62ff")
                },
                new Department()
                {
                    Name = "Bas-Rhin", Code = "67", RegionId = Guid.Parse("5823a48a-b05e-47cb-91eb-f1d0877a07b5"),
                    Id = Guid.Parse("5614ee02-1939-4ab9-94a7-c64070908c65")
                },
                new Department()
                {
                    Name = "Haut-Rhin", Code = "68", RegionId = Guid.Parse("5823a48a-b05e-47cb-91eb-f1d0877a07b5"),
                    Id = Guid.Parse("d7c383af-e3b6-468c-a4cb-e20f08856972")
                },
                new Department()
                {
                    Name = "Rhône", Code = "69", RegionId = Guid.Parse("bbfa939b-d5c7-4428-9537-dc063457270a"),
                    Id = Guid.Parse("069da2fe-b9c4-49d8-9ae6-77530d8d85ee")
                },
                new Department()
                {
                    Name = "Haute-Saône", Code = "70", RegionId = Guid.Parse("c1524a03-e7c5-4959-ac10-4e569196e743"),
                    Id = Guid.Parse("52ee48da-49f3-4701-93de-f113946380c9")
                },
                new Department()
                {
                    Name = "Saône-et-Loire", Code = "71", RegionId = Guid.Parse("c1524a03-e7c5-4959-ac10-4e569196e743"),
                    Id = Guid.Parse("63a854d0-a738-4684-9853-f83f051a88fc")
                },
                new Department()
                {
                    Name = "Sarthe", Code = "72", RegionId = Guid.Parse("e3a4faa4-4582-40d9-b5ac-154d66170041"),
                    Id = Guid.Parse("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51")
                },
                new Department()
                {
                    Name = "Savoie", Code = "73", RegionId = Guid.Parse("bbfa939b-d5c7-4428-9537-dc063457270a"),
                    Id = Guid.Parse("661ba9ad-e1e9-413c-bdfe-66401edd5596")
                },
                new Department()
                {
                    Name = "Haute-Savoie", Code = "74", RegionId = Guid.Parse("bbfa939b-d5c7-4428-9537-dc063457270a"),
                    Id = Guid.Parse("97a9f4b4-e8d4-4c1a-b6e7-e05426969f58")
                },
                new Department()
                {
                    Name = "Paris", Code = "75", RegionId = Guid.Parse("b6f686d0-13a7-47db-9e8e-d888e36cdce8"),
                    Id = Guid.Parse("961e1f7f-fc6f-440e-b11a-426bd93c32f0")
                },
                new Department()
                {
                    Name = "Seine-Maritime", Code = "76", RegionId = Guid.Parse("26a3ed8e-ef43-46df-8722-38d48170c391"),
                    Id = Guid.Parse("b96c0bc3-abbb-49cc-a672-5ec6af45ca63")
                },
                new Department()
                {
                    Name = "Seine-et-Marne", Code = "77", RegionId = Guid.Parse("b6f686d0-13a7-47db-9e8e-d888e36cdce8"),
                    Id = Guid.Parse("11e3ebec-bf5b-4f1b-8488-aa509b066f2e")
                },
                new Department()
                {
                    Name = "Yvelines", Code = "78", RegionId = Guid.Parse("b6f686d0-13a7-47db-9e8e-d888e36cdce8"),
                    Id = Guid.Parse("55b6f5bd-de1f-435f-a30d-e212e2684eb6")
                },
                new Department()
                {
                    Name = "Deux-Sèvres", Code = "79", RegionId = Guid.Parse("554a957c-4b70-4893-8ed7-4c8e09ad2b00"),
                    Id = Guid.Parse("479db9d5-9d65-473c-94c9-c84bfe8a9efc")
                },
                new Department()
                {
                    Name = "Somme", Code = "80", RegionId = Guid.Parse("3a008295-2e8f-42e9-aa87-485d150d58db"),
                    Id = Guid.Parse("343e77cb-a854-416b-aeac-86c9ffad82ce")
                },
                new Department()
                {
                    Name = "Tarn", Code = "81", RegionId = Guid.Parse("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15"),
                    Id = Guid.Parse("7285b039-3ac9-4a21-9dcd-9fc96164e600")
                },
                new Department()
                {
                    Name = "Tarn-et-Garonne", Code = "82",
                    RegionId = Guid.Parse("0a887b0a-c29e-41b6-bf2d-5d14fa8c2a15"),
                    Id = Guid.Parse("2d75fb26-8926-4607-b618-1d727cd31fe8")
                },
                new Department()
                {
                    Name = "Var", Code = "83", RegionId = Guid.Parse("00d9720b-6f64-477d-8651-304b74c2f4c3"),
                    Id = Guid.Parse("7fdeabb6-fdd2-49ff-ad5d-b35f56f9db5b")
                },
                new Department()
                {
                    Name = "Vaucluse", Code = "84", RegionId = Guid.Parse("00d9720b-6f64-477d-8651-304b74c2f4c3"),
                    Id = Guid.Parse("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1")
                },
                new Department()
                {
                    Name = "Vendée", Code = "85", RegionId = Guid.Parse("e3a4faa4-4582-40d9-b5ac-154d66170041"),
                    Id = Guid.Parse("f8c9d891-e9c5-43a1-8bfb-62f2cf51ab79")
                },
                new Department()
                {
                    Name = "Vienne", Code = "86", RegionId = Guid.Parse("554a957c-4b70-4893-8ed7-4c8e09ad2b00"),
                    Id = Guid.Parse("394ed11a-fe64-4163-b9da-eed89db9d732")
                },
                new Department()
                {
                    Name = "Haute-Vienne", Code = "87", RegionId = Guid.Parse("554a957c-4b70-4893-8ed7-4c8e09ad2b00"),
                    Id = Guid.Parse("6af0ad8b-b789-4e9c-a191-e39711617d83")
                },
                new Department()
                {
                    Name = "Vosges", Code = "88", RegionId = Guid.Parse("5823a48a-b05e-47cb-91eb-f1d0877a07b5"),
                    Id = Guid.Parse("ff2b1187-63bf-46fa-a70c-4db6b323babb")
                },
                new Department()
                {
                    Name = "Yonne", Code = "89", RegionId = Guid.Parse("c1524a03-e7c5-4959-ac10-4e569196e743"),
                    Id = Guid.Parse("667fec95-c40d-4289-b5d9-4760525509f3")
                },
                new Department()
                {
                    Name = "Territoire de Belfort", Code = "90",
                    RegionId = Guid.Parse("c1524a03-e7c5-4959-ac10-4e569196e743"),
                    Id = Guid.Parse("0bbca13e-e227-4aaa-a078-265c9133f278")
                },
                new Department()
                {
                    Name = "Essonne", Code = "91", RegionId = Guid.Parse("b6f686d0-13a7-47db-9e8e-d888e36cdce8"),
                    Id = Guid.Parse("b508db1d-d8dc-4998-bbce-b110e00ac954")
                },
                new Department()
                {
                    Name = "Hauts-de-Seine", Code = "92", RegionId = Guid.Parse("b6f686d0-13a7-47db-9e8e-d888e36cdce8"),
                    Id = Guid.Parse("a484a81b-fcf0-42ea-82c2-ef353da33667")
                },
                new Department()
                {
                    Name = "Seine-Saint-Denis", Code = "93",
                    RegionId = Guid.Parse("b6f686d0-13a7-47db-9e8e-d888e36cdce8"),
                    Id = Guid.Parse("7c7b530a-ff06-4ee3-bcfd-8a79bf094a9b")
                },
                new Department()
                {
                    Name = "Val-de-Marne", Code = "94", RegionId = Guid.Parse("b6f686d0-13a7-47db-9e8e-d888e36cdce8"),
                    Id = Guid.Parse("b10b8258-66e2-421a-bad5-cc76e1a3bb77")
                },
                new Department()
                {
                    Name = "Val-d'Oise", Code = "95", RegionId = Guid.Parse("b6f686d0-13a7-47db-9e8e-d888e36cdce8"),
                    Id = Guid.Parse("24e44487-3f98-42b9-9b44-818e5d8d7bbd")
                },
                new Department()
                {
                    Name = "Guadeloupe", Code = "971", RegionId = Guid.Parse("4357815c-da7e-4919-8f2e-6df3228cddbe"),
                    Id = Guid.Parse("5c2f93c4-a0f6-407d-8aae-5fb2a4e3f35b")
                },
                new Department()
                {
                    Name = "Martinique", Code = "972", RegionId = Guid.Parse("a4798a24-c3d0-4311-8735-e93a30fdeec7"),
                    Id = Guid.Parse("9a1cbd06-f1e9-4987-bef5-92987784887e")
                },
                new Department()
                {
                    Name = "Guyane", Code = "973", RegionId = Guid.Parse("6ac78d8f-1ec7-48fb-a9da-a41e6223fa9b"),
                    Id = Guid.Parse("8456ebcd-f507-4429-bdbc-376935ebd982")
                },
                new Department()
                {
                    Name = "La Réunion", Code = "974", RegionId = Guid.Parse("966edde0-a3fa-4f4a-8a27-7231c2ebf181"),
                    Id = Guid.Parse("24c47aad-db8a-4631-b9a4-68a5245228be")
                },
                new Department()
                {
                    Name = "Mayotte", Code = "976", RegionId = Guid.Parse("0ffa1f77-f8dc-427c-a5f7-95dbba89310f"),
                    Id = Guid.Parse("2159f71c-6099-4830-88c4-cc986d0e4186")
                });
        }
    }
}