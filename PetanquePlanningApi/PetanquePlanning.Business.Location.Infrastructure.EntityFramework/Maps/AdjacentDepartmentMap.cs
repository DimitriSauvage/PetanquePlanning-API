using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetanquePlanning.Business.Location.Domain.Entities;
using Tools.Infrastructure.EntityFramework.Abstractions;

namespace PetanquePlanning.Business.Location.Infrastructure.EntityFramework.Maps
{
    public class AdjacentDepartmentMap : EntityWithIdMap<AdjacentDepartments>
    {
        public override void Configure(EntityTypeBuilder<AdjacentDepartments> builder)
        {
            base.Configure(builder);

            //Fields
            builder
                .HasOne(x => x.FirstDepartment)
                .WithMany(x => x.AdjacentDepartments)
                .HasForeignKey(x => x.FirstDepartmentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(x => x.SecondDepartment)
                .WithMany()
                .HasForeignKey(x => x.SecondDepartmentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasIndex(x => new {x.FirstDepartmentId, x.SecondDepartmentId})
                .HasName("UK_AdjacentDepartment_FirstDepartment_SecondDepartment")
                .IsUnique();

            builder.HasData(
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("1ef7fde0-47b6-4fda-810c-44c33d1fbee8"),
                    SecondDepartmentId = Guid.Parse("8ce39bf5-92de-48db-bb8b-30892a4a090f"),
                    Id = Guid.Parse("58488f2b-ff67-49f7-aab5-26dedcf7892b")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("1ef7fde0-47b6-4fda-810c-44c33d1fbee8"),
                    SecondDepartmentId = Guid.Parse("4258f49d-10e3-4428-a398-66ffc5faa23f"),
                    Id = Guid.Parse("bc4e4367-dc8e-4b08-8065-cb78eb1040bc")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("1ef7fde0-47b6-4fda-810c-44c33d1fbee8"),
                    SecondDepartmentId = Guid.Parse("069da2fe-b9c4-49d8-9ae6-77530d8d85ee"),
                    Id = Guid.Parse("be73d783-1211-4d13-b53f-3ffb5d0f822f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("1ef7fde0-47b6-4fda-810c-44c33d1fbee8"),
                    SecondDepartmentId = Guid.Parse("63a854d0-a738-4684-9853-f83f051a88fc"),
                    Id = Guid.Parse("d023f2aa-6118-4850-99cf-0083917dab6e")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("1ef7fde0-47b6-4fda-810c-44c33d1fbee8"),
                    SecondDepartmentId = Guid.Parse("661ba9ad-e1e9-413c-bdfe-66401edd5596"),
                    Id = Guid.Parse("77e1f331-8890-436c-b41e-708abbe7f4f2")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("1ef7fde0-47b6-4fda-810c-44c33d1fbee8"),
                    SecondDepartmentId = Guid.Parse("97a9f4b4-e8d4-4c1a-b6e7-e05426969f58"),
                    Id = Guid.Parse("4261d03f-c7c4-4f38-b0f5-9b906e17aad7")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee"),
                    SecondDepartmentId = Guid.Parse("16cd59b4-3971-45ec-bd68-d26ac70d2da0"),
                    Id = Guid.Parse("a15565de-ff40-4bc6-87ea-4e1a04494f1f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee"),
                    SecondDepartmentId = Guid.Parse("9498c4a1-398d-4c06-8b49-aa84290cf2ca"),
                    Id = Guid.Parse("709132d0-3f86-47e9-8cce-376cee0fc5a8")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee"),
                    SecondDepartmentId = Guid.Parse("9e8fd57a-abe9-4cd6-958c-53ec0ba6be80"),
                    Id = Guid.Parse("87ff6f21-797b-4c2f-89f6-0c00d1d37c4e")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee"),
                    SecondDepartmentId = Guid.Parse("78476d14-2f28-4e95-874e-09f1d4fd0171"),
                    Id = Guid.Parse("7007de1e-8e82-4dfd-87dd-7686307ac404")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee"),
                    SecondDepartmentId = Guid.Parse("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"),
                    Id = Guid.Parse("b13d6430-ceea-476a-8068-1c255e6d656c")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee"),
                    SecondDepartmentId = Guid.Parse("343e77cb-a854-416b-aeac-86c9ffad82ce"),
                    Id = Guid.Parse("89053b2d-8b2c-4c97-8206-637f9edba134")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("cc023a01-8a9b-4ed6-b41c-9388c363db49"),
                    SecondDepartmentId = Guid.Parse("5cc49bd4-a1bf-4f4b-9744-13668eae12f0"),
                    Id = Guid.Parse("6c15e273-f793-4cde-bce9-d3468434cafe")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("cc023a01-8a9b-4ed6-b41c-9388c363db49"),
                    SecondDepartmentId = Guid.Parse("28cce0f5-1692-4db3-af74-e4efc3aef1e6"),
                    Id = Guid.Parse("8e7523ef-521e-4055-a732-ce1be12b6dc8")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("cc023a01-8a9b-4ed6-b41c-9388c363db49"),
                    SecondDepartmentId = Guid.Parse("dd1e3ba1-385c-4941-8d5b-dfbfa1554154"),
                    Id = Guid.Parse("76e014dd-afbc-49c7-af6c-856a183359fc")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("cc023a01-8a9b-4ed6-b41c-9388c363db49"),
                    SecondDepartmentId = Guid.Parse("52f1f21c-bea3-498b-bafa-26846d550230"),
                    Id = Guid.Parse("83550d3f-6072-4da8-bcd6-e59e7fcf6d43")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("cc023a01-8a9b-4ed6-b41c-9388c363db49"),
                    SecondDepartmentId = Guid.Parse("11560417-8292-4dfd-b345-9e4a207ee6ca"),
                    Id = Guid.Parse("b11b90d6-f615-4d59-8ff9-f17697905432")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("cc023a01-8a9b-4ed6-b41c-9388c363db49"),
                    SecondDepartmentId = Guid.Parse("63a854d0-a738-4684-9853-f83f051a88fc"),
                    Id = Guid.Parse("c75fe996-477f-4c35-9a6b-34986ecdb530")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("1bf0a210-c750-4e98-9151-7eaefa8185c7"),
                    SecondDepartmentId = Guid.Parse("85ef4758-c7a8-4cbc-9416-caaea32e4d05"),
                    Id = Guid.Parse("475b6443-84dc-4a31-83b7-cf5dfa19fe08")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("1bf0a210-c750-4e98-9151-7eaefa8185c7"),
                    SecondDepartmentId = Guid.Parse("6b787904-7e30-450b-aac4-2867a6f72100"),
                    Id = Guid.Parse("54900730-57cd-47ef-bd2c-a7eb8823a1a3")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("1bf0a210-c750-4e98-9151-7eaefa8185c7"),
                    SecondDepartmentId = Guid.Parse("95f28447-33e7-449f-8bd7-ecdabaae501f"),
                    Id = Guid.Parse("63c5d6db-fc7d-4db3-8dc3-356b97f03f00")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("1bf0a210-c750-4e98-9151-7eaefa8185c7"),
                    SecondDepartmentId = Guid.Parse("6a16c6c6-4b11-4651-b291-739fd143cb19"),
                    Id = Guid.Parse("cff423f4-fb51-4add-b99a-4b0fe0e2a981")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("1bf0a210-c750-4e98-9151-7eaefa8185c7"),
                    SecondDepartmentId = Guid.Parse("7fdeabb6-fdd2-49ff-ad5d-b35f56f9db5b"),
                    Id = Guid.Parse("9d9a03b2-7fe7-4df1-bdfb-4826df687911")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("1bf0a210-c750-4e98-9151-7eaefa8185c7"),
                    SecondDepartmentId = Guid.Parse("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1"),
                    Id = Guid.Parse("fa995ff5-a4d4-417c-942f-478e36c69e64")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("85ef4758-c7a8-4cbc-9416-caaea32e4d05"),
                    SecondDepartmentId = Guid.Parse("1bf0a210-c750-4e98-9151-7eaefa8185c7"),
                    Id = Guid.Parse("d2fe1210-3850-4907-bcd2-c38e11d9b53a")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("85ef4758-c7a8-4cbc-9416-caaea32e4d05"),
                    SecondDepartmentId = Guid.Parse("6a16c6c6-4b11-4651-b291-739fd143cb19"),
                    Id = Guid.Parse("9965f8a8-028d-49bb-a005-0af68aacab24")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("85ef4758-c7a8-4cbc-9416-caaea32e4d05"),
                    SecondDepartmentId = Guid.Parse("8ce39bf5-92de-48db-bb8b-30892a4a090f"),
                    Id = Guid.Parse("ab62640b-3962-4cad-9944-f298e60e5efe")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("85ef4758-c7a8-4cbc-9416-caaea32e4d05"),
                    SecondDepartmentId = Guid.Parse("661ba9ad-e1e9-413c-bdfe-66401edd5596"),
                    Id = Guid.Parse("c0c30649-c931-47b0-a813-8a2403335337")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("6b787904-7e30-450b-aac4-2867a6f72100"),
                    SecondDepartmentId = Guid.Parse("1bf0a210-c750-4e98-9151-7eaefa8185c7"),
                    Id = Guid.Parse("6e53290b-c56b-4c99-8288-0271e2533a5a")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("6b787904-7e30-450b-aac4-2867a6f72100"),
                    SecondDepartmentId = Guid.Parse("7fdeabb6-fdd2-49ff-ad5d-b35f56f9db5b"),
                    Id = Guid.Parse("adc913e4-f9aa-4b31-91d4-8376f77937ba")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c1aed70b-666e-4f32-bee2-f52722d89b1f"),
                    SecondDepartmentId = Guid.Parse("6a16c6c6-4b11-4651-b291-739fd143cb19"),
                    Id = Guid.Parse("1e48d46f-659f-4d31-b7c5-f1ce9bdd1108")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c1aed70b-666e-4f32-bee2-f52722d89b1f"),
                    SecondDepartmentId = Guid.Parse("11d695a1-9893-4f18-a2ab-f61078233585"),
                    Id = Guid.Parse("4a0eb214-3473-4869-afdc-55d3b6d7da2e")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c1aed70b-666e-4f32-bee2-f52722d89b1f"),
                    SecondDepartmentId = Guid.Parse("8ce39bf5-92de-48db-bb8b-30892a4a090f"),
                    Id = Guid.Parse("cdf2ebb4-d3b7-447e-9931-fc1e91dfae17")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c1aed70b-666e-4f32-bee2-f52722d89b1f"),
                    SecondDepartmentId = Guid.Parse("470669cc-1d05-4d07-838e-3aea8923d7c6"),
                    Id = Guid.Parse("4f4a0854-0ca6-45a0-9f82-3c1103853f93")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c1aed70b-666e-4f32-bee2-f52722d89b1f"),
                    SecondDepartmentId = Guid.Parse("82973925-433a-4f55-89c8-f41fc398a0c2"),
                    Id = Guid.Parse("18044867-5fe1-473a-b262-b0bfb2c45a2f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c1aed70b-666e-4f32-bee2-f52722d89b1f"),
                    SecondDepartmentId = Guid.Parse("069da2fe-b9c4-49d8-9ae6-77530d8d85ee"),
                    Id = Guid.Parse("4a575ed6-bcd0-4c3f-ab66-50ff688d2f7b")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c1aed70b-666e-4f32-bee2-f52722d89b1f"),
                    SecondDepartmentId = Guid.Parse("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1"),
                    Id = Guid.Parse("1a25b2d0-4105-43f2-8f6b-b7dfff3a2bc3")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("16cd59b4-3971-45ec-bd68-d26ac70d2da0"),
                    SecondDepartmentId = Guid.Parse("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee"),
                    Id = Guid.Parse("715e6af2-6c62-42da-9d17-330d143f668d")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("16cd59b4-3971-45ec-bd68-d26ac70d2da0"),
                    SecondDepartmentId = Guid.Parse("9498c4a1-398d-4c06-8b49-aa84290cf2ca"),
                    Id = Guid.Parse("3be82052-6d2e-4bfb-b4e3-2980d7e14090")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("16cd59b4-3971-45ec-bd68-d26ac70d2da0"),
                    SecondDepartmentId = Guid.Parse("310e87ad-0b29-470e-9120-b025a3a46c9f"),
                    Id = Guid.Parse("04721c73-9ab1-4bdc-8589-bbf263955df6")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("16cd59b4-3971-45ec-bd68-d26ac70d2da0"),
                    SecondDepartmentId = Guid.Parse("9e8fd57a-abe9-4cd6-958c-53ec0ba6be80"),
                    Id = Guid.Parse("6434b6e1-62b2-42ef-855e-90abc21cd82e")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("77d7dc5d-545b-4f53-8db2-bf3245f3c131"),
                    SecondDepartmentId = Guid.Parse("aec85880-4ac9-43c9-be3f-a47a41d0e88e"),
                    Id = Guid.Parse("e3e0a4da-cc02-403d-97b5-4bf1277d398f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("77d7dc5d-545b-4f53-8db2-bf3245f3c131"),
                    SecondDepartmentId = Guid.Parse("d56fc07c-39f9-42c6-aaf5-640b2b5f6124"),
                    Id = Guid.Parse("f9a1cc9b-f637-442e-8fa2-ad816379f6a7")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("77d7dc5d-545b-4f53-8db2-bf3245f3c131"),
                    SecondDepartmentId = Guid.Parse("caa74253-c115-4cb7-8b63-ee23545a62ff"),
                    Id = Guid.Parse("cf051888-36b0-4710-8540-4d549d6cf13b")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("30ba0a20-3568-4484-9df1-151de6fd36c2"),
                    SecondDepartmentId = Guid.Parse("dbde4b03-bd9c-4b18-81c3-9b24e0558003"),
                    Id = Guid.Parse("7913432b-0e57-4510-94cd-ce7fcc8ccc53")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("30ba0a20-3568-4484-9df1-151de6fd36c2"),
                    SecondDepartmentId = Guid.Parse("9498c4a1-398d-4c06-8b49-aa84290cf2ca"),
                    Id = Guid.Parse("9a0157d0-9241-415e-b7da-1e85e2a81a3b")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("30ba0a20-3568-4484-9df1-151de6fd36c2"),
                    SecondDepartmentId = Guid.Parse("3577171f-2b34-4d53-9aff-17885e7d4679"),
                    Id = Guid.Parse("eaea3587-e956-4b01-ae03-7b00c2f79dce")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("30ba0a20-3568-4484-9df1-151de6fd36c2"),
                    SecondDepartmentId = Guid.Parse("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"),
                    Id = Guid.Parse("23662f53-6fad-4fb2-a0b1-79481ef38421")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("30ba0a20-3568-4484-9df1-151de6fd36c2"),
                    SecondDepartmentId = Guid.Parse("667fec95-c40d-4289-b5d9-4760525509f3"),
                    Id = Guid.Parse("1815ea82-0d83-4baa-8ddc-4a7e45da757d")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("aec85880-4ac9-43c9-be3f-a47a41d0e88e"),
                    SecondDepartmentId = Guid.Parse("77d7dc5d-545b-4f53-8db2-bf3245f3c131"),
                    Id = Guid.Parse("b737aa71-56b0-4a0e-9ad1-b67f14dbe401")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("aec85880-4ac9-43c9-be3f-a47a41d0e88e"),
                    SecondDepartmentId = Guid.Parse("d56fc07c-39f9-42c6-aaf5-640b2b5f6124"),
                    Id = Guid.Parse("18b14374-ab40-4c06-8b67-d46c8cecc8ba")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("aec85880-4ac9-43c9-be3f-a47a41d0e88e"),
                    SecondDepartmentId = Guid.Parse("1632f86b-846f-4a69-b4a2-e5f6dd7d4742"),
                    Id = Guid.Parse("12e75442-3606-4a32-a27a-1336b4b52615")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("aec85880-4ac9-43c9-be3f-a47a41d0e88e"),
                    SecondDepartmentId = Guid.Parse("7285b039-3ac9-4a21-9dcd-9fc96164e600"),
                    Id = Guid.Parse("bf711c33-5b64-4f36-bb28-cdacbb66fa33")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd"),
                    SecondDepartmentId = Guid.Parse("95295597-7518-4999-bdd7-52ef36bd24c0"),
                    Id = Guid.Parse("a3bfd4cd-c3bc-454d-832a-0e26eca6efc4")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd"),
                    SecondDepartmentId = Guid.Parse("11d695a1-9893-4f18-a2ab-f61078233585"),
                    Id = Guid.Parse("01204847-8a56-4c1f-8de3-8a42ee27808a")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd"),
                    SecondDepartmentId = Guid.Parse("1632f86b-846f-4a69-b4a2-e5f6dd7d4742"),
                    Id = Guid.Parse("b7b67b05-4841-4227-8ba1-34ed27cd4041")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd"),
                    SecondDepartmentId = Guid.Parse("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b"),
                    Id = Guid.Parse("a15d15ea-7c9a-4e88-88cb-763e2503bb28")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd"),
                    SecondDepartmentId = Guid.Parse("82973925-433a-4f55-89c8-f41fc398a0c2"),
                    Id = Guid.Parse("e72f5cb1-35ad-4bb6-8077-3a2936b81b70")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd"),
                    SecondDepartmentId = Guid.Parse("7285b039-3ac9-4a21-9dcd-9fc96164e600"),
                    Id = Guid.Parse("189b3e61-cb8b-45fc-8bef-31909bb4d742")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd"),
                    SecondDepartmentId = Guid.Parse("2d75fb26-8926-4607-b618-1d727cd31fe8"),
                    Id = Guid.Parse("e000bcab-c340-4719-b00f-c0a7aa78eaee")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("95f28447-33e7-449f-8bd7-ecdabaae501f"),
                    SecondDepartmentId = Guid.Parse("11d695a1-9893-4f18-a2ab-f61078233585"),
                    Id = Guid.Parse("172918ae-2918-4259-9aee-00262fb0fca0")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("95f28447-33e7-449f-8bd7-ecdabaae501f"),
                    SecondDepartmentId = Guid.Parse("7fdeabb6-fdd2-49ff-ad5d-b35f56f9db5b"),
                    Id = Guid.Parse("dd2a3d91-24b0-4ea4-b8c8-8f730338cb12")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("95f28447-33e7-449f-8bd7-ecdabaae501f"),
                    SecondDepartmentId = Guid.Parse("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1"),
                    Id = Guid.Parse("c1baa58e-af93-4001-a6a7-7082b4b2b1f3")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("785e7ff9-229a-426c-b664-479312d4cf8d"),
                    SecondDepartmentId = Guid.Parse("a2ba1fd9-47c5-4938-b8b3-ab01bc245859"),
                    Id = Guid.Parse("7b0d6283-864c-4f9f-9f51-bb4c452fdbe5")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("785e7ff9-229a-426c-b664-479312d4cf8d"),
                    SecondDepartmentId = Guid.Parse("75020b4c-5dac-447f-941b-470fc5019eac"),
                    Id = Guid.Parse("e867fc49-50ac-48e2-a52a-5ef2286897b8")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("785e7ff9-229a-426c-b664-479312d4cf8d"),
                    SecondDepartmentId = Guid.Parse("3489baa7-b17e-4003-a78f-cb156dee058e"),
                    Id = Guid.Parse("571edfaf-5a51-4eef-ad91-bba8362b5aa9")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("95295597-7518-4999-bdd7-52ef36bd24c0"),
                    SecondDepartmentId = Guid.Parse("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd"),
                    Id = Guid.Parse("3f53db8e-9c37-4524-8740-7eff88f0fdcd")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("95295597-7518-4999-bdd7-52ef36bd24c0"),
                    SecondDepartmentId = Guid.Parse("c1bd362f-88bd-4e6a-8928-ad6d29ee549a"),
                    Id = Guid.Parse("33ef1165-d933-4a0d-892f-123896605201")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("95295597-7518-4999-bdd7-52ef36bd24c0"),
                    SecondDepartmentId = Guid.Parse("470669cc-1d05-4d07-838e-3aea8923d7c6"),
                    Id = Guid.Parse("d3430172-ef77-45b8-9b2d-e071a92342af")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("95295597-7518-4999-bdd7-52ef36bd24c0"),
                    SecondDepartmentId = Guid.Parse("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b"),
                    Id = Guid.Parse("04ac601d-3d64-43f6-a997-d8e7db39e26c")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("95295597-7518-4999-bdd7-52ef36bd24c0"),
                    SecondDepartmentId = Guid.Parse("82973925-433a-4f55-89c8-f41fc398a0c2"),
                    Id = Guid.Parse("ed9bcff7-deaf-4c44-bf1e-052f8ba74be6")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("95295597-7518-4999-bdd7-52ef36bd24c0"),
                    SecondDepartmentId = Guid.Parse("11560417-8292-4dfd-b345-9e4a207ee6ca"),
                    Id = Guid.Parse("a5453fac-dbdd-4ac1-bcba-d1d373c64248")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("cbfb8d4a-5fad-4c9e-8faa-d035cd093928"),
                    SecondDepartmentId = Guid.Parse("8963790c-6864-429c-bd8b-35338c53a170"),
                    Id = Guid.Parse("d6fed2f0-7aac-4ef1-8da8-2fb7eb57eb70")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("cbfb8d4a-5fad-4c9e-8faa-d035cd093928"),
                    SecondDepartmentId = Guid.Parse("44cc60d3-d233-4bf1-92c1-539961e5be6b"),
                    Id = Guid.Parse("62d1cc69-7975-4667-82a9-dd59ae0aad4a")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("cbfb8d4a-5fad-4c9e-8faa-d035cd093928"),
                    SecondDepartmentId = Guid.Parse("479db9d5-9d65-473c-94c9-c84bfe8a9efc"),
                    Id = Guid.Parse("263c2038-7f63-4c6a-b7ce-2203cdfda809")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("cbfb8d4a-5fad-4c9e-8faa-d035cd093928"),
                    SecondDepartmentId = Guid.Parse("394ed11a-fe64-4163-b9da-eed89db9d732"),
                    Id = Guid.Parse("efe7de6d-2e10-490e-9207-7e3a19808254")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("cbfb8d4a-5fad-4c9e-8faa-d035cd093928"),
                    SecondDepartmentId = Guid.Parse("6af0ad8b-b789-4e9c-a191-e39711617d83"),
                    Id = Guid.Parse("0347055f-7df5-4151-a6b9-31dd6c740e4f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("8963790c-6864-429c-bd8b-35338c53a170"),
                    SecondDepartmentId = Guid.Parse("cbfb8d4a-5fad-4c9e-8faa-d035cd093928"),
                    Id = Guid.Parse("10d6f6a3-88da-4a99-8a58-4f717c6bb075")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("8963790c-6864-429c-bd8b-35338c53a170"),
                    SecondDepartmentId = Guid.Parse("e7931a2e-e969-43a2-9c71-542549fc41aa"),
                    Id = Guid.Parse("4aff88b6-69c9-4495-a960-b4b108a80f28")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("8963790c-6864-429c-bd8b-35338c53a170"),
                    SecondDepartmentId = Guid.Parse("479db9d5-9d65-473c-94c9-c84bfe8a9efc"),
                    Id = Guid.Parse("22d27ff2-32b9-4efc-8c56-f2b5ce6296db")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("8963790c-6864-429c-bd8b-35338c53a170"),
                    SecondDepartmentId = Guid.Parse("f8c9d891-e9c5-43a1-8bfb-62f2cf51ab79"),
                    Id = Guid.Parse("c60656e6-55a6-4593-9b0e-9743e0f60a4a")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("5cc49bd4-a1bf-4f4b-9744-13668eae12f0"),
                    SecondDepartmentId = Guid.Parse("cc023a01-8a9b-4ed6-b41c-9388c363db49"),
                    Id = Guid.Parse("d0d81006-5481-45f3-b76c-96399fea6cb4")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("5cc49bd4-a1bf-4f4b-9744-13668eae12f0"),
                    SecondDepartmentId = Guid.Parse("28cce0f5-1692-4db3-af74-e4efc3aef1e6"),
                    Id = Guid.Parse("836b9897-3e7e-40d4-b356-a0e4a88d7c28")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("5cc49bd4-a1bf-4f4b-9744-13668eae12f0"),
                    SecondDepartmentId = Guid.Parse("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e"),
                    Id = Guid.Parse("a81e6def-12e4-4bc0-8de3-c7cc52b7d5ca")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("5cc49bd4-a1bf-4f4b-9744-13668eae12f0"),
                    SecondDepartmentId = Guid.Parse("b59aa9c6-9441-4b8f-aabf-031eae7ef550"),
                    Id = Guid.Parse("69db79f3-e2da-4e16-b377-9d4851d1aaba")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("5cc49bd4-a1bf-4f4b-9744-13668eae12f0"),
                    SecondDepartmentId = Guid.Parse("1c05a510-8e08-4e61-94f1-d5b9661a2b08"),
                    Id = Guid.Parse("77da9467-6a95-4eff-a469-b067487f691f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("5cc49bd4-a1bf-4f4b-9744-13668eae12f0"),
                    SecondDepartmentId = Guid.Parse("52f1f21c-bea3-498b-bafa-26846d550230"),
                    Id = Guid.Parse("89affb92-0fcb-44e9-bf38-1c176a9f1a29")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("5cc49bd4-a1bf-4f4b-9744-13668eae12f0"),
                    SecondDepartmentId = Guid.Parse("667fec95-c40d-4289-b5d9-4760525509f3"),
                    Id = Guid.Parse("c61755c1-1905-4541-bf3e-9fa517c5c13c")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c1bd362f-88bd-4e6a-8928-ad6d29ee549a"),
                    SecondDepartmentId = Guid.Parse("95295597-7518-4999-bdd7-52ef36bd24c0"),
                    Id = Guid.Parse("bc3421ad-a832-47c1-bee3-7ad7c5fee183")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c1bd362f-88bd-4e6a-8928-ad6d29ee549a"),
                    SecondDepartmentId = Guid.Parse("28cce0f5-1692-4db3-af74-e4efc3aef1e6"),
                    Id = Guid.Parse("821720a5-e7e3-4079-becc-0573a1843dd1")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c1bd362f-88bd-4e6a-8928-ad6d29ee549a"),
                    SecondDepartmentId = Guid.Parse("44cc60d3-d233-4bf1-92c1-539961e5be6b"),
                    Id = Guid.Parse("5e20466f-419c-46ce-ac22-c1407f5e93b3")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c1bd362f-88bd-4e6a-8928-ad6d29ee549a"),
                    SecondDepartmentId = Guid.Parse("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b"),
                    Id = Guid.Parse("339c93ae-2e00-4c81-89a8-638562047b98")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c1bd362f-88bd-4e6a-8928-ad6d29ee549a"),
                    SecondDepartmentId = Guid.Parse("11560417-8292-4dfd-b345-9e4a207ee6ca"),
                    Id = Guid.Parse("4ecc55b2-c3c1-4586-833c-4907faa2735b")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c1bd362f-88bd-4e6a-8928-ad6d29ee549a"),
                    SecondDepartmentId = Guid.Parse("6af0ad8b-b789-4e9c-a191-e39711617d83"),
                    Id = Guid.Parse("440f239e-de07-475e-bfcc-2181439da5eb")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("dbde4b03-bd9c-4b18-81c3-9b24e0558003"),
                    SecondDepartmentId = Guid.Parse("30ba0a20-3568-4484-9df1-151de6fd36c2"),
                    Id = Guid.Parse("9512a2f5-b5e7-45d2-bb9a-26c5db59e96e")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("dbde4b03-bd9c-4b18-81c3-9b24e0558003"),
                    SecondDepartmentId = Guid.Parse("4258f49d-10e3-4428-a398-66ffc5faa23f"),
                    Id = Guid.Parse("11bf5592-d37b-4b1f-b54a-2104b3dc528e")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("dbde4b03-bd9c-4b18-81c3-9b24e0558003"),
                    SecondDepartmentId = Guid.Parse("3577171f-2b34-4d53-9aff-17885e7d4679"),
                    Id = Guid.Parse("b44d9835-c952-435f-af10-2286f51cb106")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("dbde4b03-bd9c-4b18-81c3-9b24e0558003"),
                    SecondDepartmentId = Guid.Parse("52f1f21c-bea3-498b-bafa-26846d550230"),
                    Id = Guid.Parse("bc7c4701-d9b2-4168-9ca5-480bc8d3eae9")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("dbde4b03-bd9c-4b18-81c3-9b24e0558003"),
                    SecondDepartmentId = Guid.Parse("52ee48da-49f3-4701-93de-f113946380c9"),
                    Id = Guid.Parse("0178256e-4dde-4e3a-b238-217055230923")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("dbde4b03-bd9c-4b18-81c3-9b24e0558003"),
                    SecondDepartmentId = Guid.Parse("63a854d0-a738-4684-9853-f83f051a88fc"),
                    Id = Guid.Parse("7bb5336e-1d20-4cf4-9384-79dd515939fe")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("dbde4b03-bd9c-4b18-81c3-9b24e0558003"),
                    SecondDepartmentId = Guid.Parse("667fec95-c40d-4289-b5d9-4760525509f3"),
                    Id = Guid.Parse("039340cf-740a-4eae-9eec-7afde9aaa554")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("f351db6b-828b-462a-a032-1354a73733e8"),
                    SecondDepartmentId = Guid.Parse("57eb6e76-cfe4-491a-8c5b-2cbbf5d44217"),
                    Id = Guid.Parse("8d5f694f-ada2-49f3-92dd-ff087c1011b8")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("f351db6b-828b-462a-a032-1354a73733e8"),
                    SecondDepartmentId = Guid.Parse("906ac8fa-ce00-4194-8d13-f517242777f4"),
                    Id = Guid.Parse("e89eaa0a-3951-4ad9-b169-f7bf56c77c94")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("f351db6b-828b-462a-a032-1354a73733e8"),
                    SecondDepartmentId = Guid.Parse("c9220a79-ac83-4e46-a397-0830b052769e"),
                    Id = Guid.Parse("2a1e4392-2c13-49fe-9d87-92c7a90c7c6e")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("28cce0f5-1692-4db3-af74-e4efc3aef1e6"),
                    SecondDepartmentId = Guid.Parse("cc023a01-8a9b-4ed6-b41c-9388c363db49"),
                    Id = Guid.Parse("9ce6cfe6-677b-4089-bebb-3faee31e6efa")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("28cce0f5-1692-4db3-af74-e4efc3aef1e6"),
                    SecondDepartmentId = Guid.Parse("5cc49bd4-a1bf-4f4b-9744-13668eae12f0"),
                    Id = Guid.Parse("bd11768c-90f7-4606-ad9a-1814d472440a")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("28cce0f5-1692-4db3-af74-e4efc3aef1e6"),
                    SecondDepartmentId = Guid.Parse("c1bd362f-88bd-4e6a-8928-ad6d29ee549a"),
                    Id = Guid.Parse("1630ed58-0733-4a1e-9d60-19433c20a93b")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("28cce0f5-1692-4db3-af74-e4efc3aef1e6"),
                    SecondDepartmentId = Guid.Parse("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e"),
                    Id = Guid.Parse("4ae69218-d9ca-49e2-8f08-314a236e9d51")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("28cce0f5-1692-4db3-af74-e4efc3aef1e6"),
                    SecondDepartmentId = Guid.Parse("11560417-8292-4dfd-b345-9e4a207ee6ca"),
                    Id = Guid.Parse("5d21f340-19dd-44e9-a4b3-0861df059e69")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("28cce0f5-1692-4db3-af74-e4efc3aef1e6"),
                    SecondDepartmentId = Guid.Parse("6af0ad8b-b789-4e9c-a191-e39711617d83"),
                    Id = Guid.Parse("8a0259c2-2240-4fde-9c0f-867a4d51514a")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("44cc60d3-d233-4bf1-92c1-539961e5be6b"),
                    SecondDepartmentId = Guid.Parse("cbfb8d4a-5fad-4c9e-8faa-d035cd093928"),
                    Id = Guid.Parse("3e32cba3-ac8b-4bec-8252-d78049e0c210")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("44cc60d3-d233-4bf1-92c1-539961e5be6b"),
                    SecondDepartmentId = Guid.Parse("8963790c-6864-429c-bd8b-35338c53a170"),
                    Id = Guid.Parse("47c4694e-9c5e-493b-8cd2-435b7d448d6b")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("44cc60d3-d233-4bf1-92c1-539961e5be6b"),
                    SecondDepartmentId = Guid.Parse("c1bd362f-88bd-4e6a-8928-ad6d29ee549a"),
                    Id = Guid.Parse("25008dc9-6aad-4600-aeee-94abb80c05c5")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("44cc60d3-d233-4bf1-92c1-539961e5be6b"),
                    SecondDepartmentId = Guid.Parse("e7931a2e-e969-43a2-9c71-542549fc41aa"),
                    Id = Guid.Parse("34693ac8-57ac-4e88-8ab4-9f2096165d26")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("44cc60d3-d233-4bf1-92c1-539961e5be6b"),
                    SecondDepartmentId = Guid.Parse("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b"),
                    Id = Guid.Parse("98488684-649d-4279-8953-e1b77ffbc05f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("44cc60d3-d233-4bf1-92c1-539961e5be6b"),
                    SecondDepartmentId = Guid.Parse("cbf1b899-4d3d-4155-bae7-07915a6b8c09"),
                    Id = Guid.Parse("b6e43650-5e15-4881-9d7b-e16c4ea0d3b6")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("44cc60d3-d233-4bf1-92c1-539961e5be6b"),
                    SecondDepartmentId = Guid.Parse("6af0ad8b-b789-4e9c-a191-e39711617d83"),
                    Id = Guid.Parse("753478b6-fd9b-4e84-a7f2-ec34d535c0c7")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("2acb1828-07a0-45fd-b52e-15b7eb6e02ce"),
                    SecondDepartmentId = Guid.Parse("4258f49d-10e3-4428-a398-66ffc5faa23f"),
                    Id = Guid.Parse("c5a3ff7f-4c3a-4b61-9151-ca9425afd94e")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("2acb1828-07a0-45fd-b52e-15b7eb6e02ce"),
                    SecondDepartmentId = Guid.Parse("52ee48da-49f3-4701-93de-f113946380c9"),
                    Id = Guid.Parse("1f073a90-5478-4733-b9fc-7de8da003ff3")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("2acb1828-07a0-45fd-b52e-15b7eb6e02ce"),
                    SecondDepartmentId = Guid.Parse("0bbca13e-e227-4aaa-a078-265c9133f278"),
                    Id = Guid.Parse("779a5558-d8d1-4fac-9392-2d1c45c860cd")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("6a16c6c6-4b11-4651-b291-739fd143cb19"),
                    SecondDepartmentId = Guid.Parse("1bf0a210-c750-4e98-9151-7eaefa8185c7"),
                    Id = Guid.Parse("4c41b414-084c-485b-aa56-0c7148438a56")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("6a16c6c6-4b11-4651-b291-739fd143cb19"),
                    SecondDepartmentId = Guid.Parse("85ef4758-c7a8-4cbc-9416-caaea32e4d05"),
                    Id = Guid.Parse("829d59ae-c7f3-4d52-a00f-30837cc197ea")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("6a16c6c6-4b11-4651-b291-739fd143cb19"),
                    SecondDepartmentId = Guid.Parse("c1aed70b-666e-4f32-bee2-f52722d89b1f"),
                    Id = Guid.Parse("e5751179-cd56-4c98-9fed-317c92a0c7b1")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("6a16c6c6-4b11-4651-b291-739fd143cb19"),
                    SecondDepartmentId = Guid.Parse("8ce39bf5-92de-48db-bb8b-30892a4a090f"),
                    Id = Guid.Parse("331daf6d-8470-4aa6-b8fd-97fbf64fd812")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("6a16c6c6-4b11-4651-b291-739fd143cb19"),
                    SecondDepartmentId = Guid.Parse("069da2fe-b9c4-49d8-9ae6-77530d8d85ee"),
                    Id = Guid.Parse("4162caab-0f39-43a4-8dd0-117d3296e865")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("6a16c6c6-4b11-4651-b291-739fd143cb19"),
                    SecondDepartmentId = Guid.Parse("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1"),
                    Id = Guid.Parse("e03c2d9a-93b0-4f6f-ab44-c6a303b40972")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("a2ba1fd9-47c5-4938-b8b3-ab01bc245859"),
                    SecondDepartmentId = Guid.Parse("785e7ff9-229a-426c-b664-479312d4cf8d"),
                    Id = Guid.Parse("fea898eb-0d0d-45dc-b132-16586a78378f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("a2ba1fd9-47c5-4938-b8b3-ab01bc245859"),
                    SecondDepartmentId = Guid.Parse("c8851fc2-7704-412d-b272-130cbed5f422"),
                    Id = Guid.Parse("f6f66706-c94b-4ac3-a7f2-6a5071f16ed4")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("a2ba1fd9-47c5-4938-b8b3-ab01bc245859"),
                    SecondDepartmentId = Guid.Parse("78476d14-2f28-4e95-874e-09f1d4fd0171"),
                    Id = Guid.Parse("48d19e18-e4ec-460f-86e2-24442aefa9e4")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("a2ba1fd9-47c5-4938-b8b3-ab01bc245859"),
                    SecondDepartmentId = Guid.Parse("3489baa7-b17e-4003-a78f-cb156dee058e"),
                    Id = Guid.Parse("e2919a55-8b5c-4f10-96ff-0de8d4565f78")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("a2ba1fd9-47c5-4938-b8b3-ab01bc245859"),
                    SecondDepartmentId = Guid.Parse("b96c0bc3-abbb-49cc-a672-5ec6af45ca63"),
                    Id = Guid.Parse("a5616837-d90b-4745-b331-027ae44df2d8")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("a2ba1fd9-47c5-4938-b8b3-ab01bc245859"),
                    SecondDepartmentId = Guid.Parse("55b6f5bd-de1f-435f-a30d-e212e2684eb6"),
                    Id = Guid.Parse("f9c30f43-7280-43f2-880d-ebfc0ccb1b26")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("a2ba1fd9-47c5-4938-b8b3-ab01bc245859"),
                    SecondDepartmentId = Guid.Parse("24e44487-3f98-42b9-9b44-818e5d8d7bbd"),
                    Id = Guid.Parse("0f79425e-9bcf-4bf8-bfe3-10e7cf414fbe")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c8851fc2-7704-412d-b272-130cbed5f422"),
                    SecondDepartmentId = Guid.Parse("a2ba1fd9-47c5-4938-b8b3-ab01bc245859"),
                    Id = Guid.Parse("5f6165cf-abaa-44c3-ac4b-95dea15de4d5")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c8851fc2-7704-412d-b272-130cbed5f422"),
                    SecondDepartmentId = Guid.Parse("b59aa9c6-9441-4b8f-aabf-031eae7ef550"),
                    Id = Guid.Parse("7df0233b-09c6-4c7a-9da4-f5a7c1061f4f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c8851fc2-7704-412d-b272-130cbed5f422"),
                    SecondDepartmentId = Guid.Parse("1c05a510-8e08-4e61-94f1-d5b9661a2b08"),
                    Id = Guid.Parse("8e1e8f45-9b84-4850-86ed-0d3184b37377")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c8851fc2-7704-412d-b272-130cbed5f422"),
                    SecondDepartmentId = Guid.Parse("3489baa7-b17e-4003-a78f-cb156dee058e"),
                    Id = Guid.Parse("688c1023-d681-42e4-8fc9-ec5b693271f6")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c8851fc2-7704-412d-b272-130cbed5f422"),
                    SecondDepartmentId = Guid.Parse("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51"),
                    Id = Guid.Parse("7bc9269a-e943-4d67-b624-f7f9f99f92b0")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c8851fc2-7704-412d-b272-130cbed5f422"),
                    SecondDepartmentId = Guid.Parse("55b6f5bd-de1f-435f-a30d-e212e2684eb6"),
                    Id = Guid.Parse("72db4585-de18-475b-bb9a-901f62dff5c4")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c8851fc2-7704-412d-b272-130cbed5f422"),
                    SecondDepartmentId = Guid.Parse("b508db1d-d8dc-4998-bbce-b110e00ac954"),
                    Id = Guid.Parse("ebf02ae5-4462-44d4-9b35-9bd4cd37b575")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("57eb6e76-cfe4-491a-8c5b-2cbbf5d44217"),
                    SecondDepartmentId = Guid.Parse("f351db6b-828b-462a-a032-1354a73733e8"),
                    Id = Guid.Parse("40fb68d7-e349-4737-ad03-7ef42acd410b")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("57eb6e76-cfe4-491a-8c5b-2cbbf5d44217"),
                    SecondDepartmentId = Guid.Parse("c9220a79-ac83-4e46-a397-0830b052769e"),
                    Id = Guid.Parse("a5519133-2c3c-4d9d-a89a-63bba2462e47")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("11d695a1-9893-4f18-a2ab-f61078233585"),
                    SecondDepartmentId = Guid.Parse("c1aed70b-666e-4f32-bee2-f52722d89b1f"),
                    Id = Guid.Parse("5679bae3-4f4f-4955-bc7e-574a426268dd")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("11d695a1-9893-4f18-a2ab-f61078233585"),
                    SecondDepartmentId = Guid.Parse("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd"),
                    Id = Guid.Parse("262d8b28-b8b0-4091-bd7a-f3fbb9782f0c")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("11d695a1-9893-4f18-a2ab-f61078233585"),
                    SecondDepartmentId = Guid.Parse("95f28447-33e7-449f-8bd7-ecdabaae501f"),
                    Id = Guid.Parse("04070ce3-aeab-4741-b8c4-561169a492c8")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("11d695a1-9893-4f18-a2ab-f61078233585"),
                    SecondDepartmentId = Guid.Parse("6a16c6c6-4b11-4651-b291-739fd143cb19"),
                    Id = Guid.Parse("1191531f-6298-4e65-a532-5441064f24c1")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("11d695a1-9893-4f18-a2ab-f61078233585"),
                    SecondDepartmentId = Guid.Parse("1632f86b-846f-4a69-b4a2-e5f6dd7d4742"),
                    Id = Guid.Parse("130a715d-e555-4f08-ab8f-77e71ca7c9f1")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("11d695a1-9893-4f18-a2ab-f61078233585"),
                    SecondDepartmentId = Guid.Parse("82973925-433a-4f55-89c8-f41fc398a0c2"),
                    Id = Guid.Parse("2bee244c-ed72-4ad0-9ff2-560e7275d788")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("11d695a1-9893-4f18-a2ab-f61078233585"),
                    SecondDepartmentId = Guid.Parse("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1"),
                    Id = Guid.Parse("efe043d5-4aa0-4f64-b107-65861380b37e")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("d56fc07c-39f9-42c6-aaf5-640b2b5f6124"),
                    SecondDepartmentId = Guid.Parse("77d7dc5d-545b-4f53-8db2-bf3245f3c131"),
                    Id = Guid.Parse("b82272de-846a-4c01-85a6-f15dce4d188a")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("d56fc07c-39f9-42c6-aaf5-640b2b5f6124"),
                    SecondDepartmentId = Guid.Parse("aec85880-4ac9-43c9-be3f-a47a41d0e88e"),
                    Id = Guid.Parse("421830c5-77dd-4306-933e-e972c2ea4eef")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("d56fc07c-39f9-42c6-aaf5-640b2b5f6124"),
                    SecondDepartmentId = Guid.Parse("e007dcb1-8678-47ab-90dd-441f76873b9e"),
                    Id = Guid.Parse("04effb87-77e2-452a-af46-8703fecd1e09")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("d56fc07c-39f9-42c6-aaf5-640b2b5f6124"),
                    SecondDepartmentId = Guid.Parse("4c3a1f47-f735-4390-ae4d-f979e16c562c"),
                    Id = Guid.Parse("662660de-66f2-45e3-ae3a-dbeb5272ba28")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("d56fc07c-39f9-42c6-aaf5-640b2b5f6124"),
                    SecondDepartmentId = Guid.Parse("7285b039-3ac9-4a21-9dcd-9fc96164e600"),
                    Id = Guid.Parse("763dfe4a-f0c9-4069-8f85-71d48198ae1c")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("d56fc07c-39f9-42c6-aaf5-640b2b5f6124"),
                    SecondDepartmentId = Guid.Parse("2d75fb26-8926-4607-b618-1d727cd31fe8"),
                    Id = Guid.Parse("cc3b4e79-0cce-43bb-b07a-5532ad5d9247")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("e007dcb1-8678-47ab-90dd-441f76873b9e"),
                    SecondDepartmentId = Guid.Parse("d56fc07c-39f9-42c6-aaf5-640b2b5f6124"),
                    Id = Guid.Parse("cb3e7c5a-efd2-40c4-ab75-cb66df34c763")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("e007dcb1-8678-47ab-90dd-441f76873b9e"),
                    SecondDepartmentId = Guid.Parse("d3cb1fd0-444e-4e2a-82a2-7382536b1770"),
                    Id = Guid.Parse("703b816c-361a-48ff-988f-a50eb66f4df3")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("e007dcb1-8678-47ab-90dd-441f76873b9e"),
                    SecondDepartmentId = Guid.Parse("cbf1b899-4d3d-4155-bae7-07915a6b8c09"),
                    Id = Guid.Parse("fc51d3b0-d4dd-415c-8d50-ff27742b8b11")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("e007dcb1-8678-47ab-90dd-441f76873b9e"),
                    SecondDepartmentId = Guid.Parse("895ce97a-633b-4782-b060-f276b4141e90"),
                    Id = Guid.Parse("b38f93bc-6fb4-426f-a744-ddf2e554928b")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("e007dcb1-8678-47ab-90dd-441f76873b9e"),
                    SecondDepartmentId = Guid.Parse("4c3a1f47-f735-4390-ae4d-f979e16c562c"),
                    Id = Guid.Parse("64b4319d-6dfa-48f4-b9b7-da00c22d64d7")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("e007dcb1-8678-47ab-90dd-441f76873b9e"),
                    SecondDepartmentId = Guid.Parse("2d75fb26-8926-4607-b618-1d727cd31fe8"),
                    Id = Guid.Parse("a86b0eb8-584e-4feb-8951-f6f425eb7209")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("e7931a2e-e969-43a2-9c71-542549fc41aa"),
                    SecondDepartmentId = Guid.Parse("8963790c-6864-429c-bd8b-35338c53a170"),
                    Id = Guid.Parse("dd9a0ef1-2d23-465e-8234-afcb081992a3")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("e7931a2e-e969-43a2-9c71-542549fc41aa"),
                    SecondDepartmentId = Guid.Parse("44cc60d3-d233-4bf1-92c1-539961e5be6b"),
                    Id = Guid.Parse("e021ab07-01aa-41b1-a5c2-4557214dc46f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("e7931a2e-e969-43a2-9c71-542549fc41aa"),
                    SecondDepartmentId = Guid.Parse("d3cb1fd0-444e-4e2a-82a2-7382536b1770"),
                    Id = Guid.Parse("b0d07411-b863-4735-9415-5d871a493547")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("e7931a2e-e969-43a2-9c71-542549fc41aa"),
                    SecondDepartmentId = Guid.Parse("cbf1b899-4d3d-4155-bae7-07915a6b8c09"),
                    Id = Guid.Parse("08d560df-57b3-46ac-8e9f-f71106fb6bd9")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("1632f86b-846f-4a69-b4a2-e5f6dd7d4742"),
                    SecondDepartmentId = Guid.Parse("aec85880-4ac9-43c9-be3f-a47a41d0e88e"),
                    Id = Guid.Parse("c7ee3fd9-74d5-47b0-8b51-4bdaef0bf28b")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("1632f86b-846f-4a69-b4a2-e5f6dd7d4742"),
                    SecondDepartmentId = Guid.Parse("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd"),
                    Id = Guid.Parse("e327229a-0f5a-45d0-ab17-8e59407071c2")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("1632f86b-846f-4a69-b4a2-e5f6dd7d4742"),
                    SecondDepartmentId = Guid.Parse("11d695a1-9893-4f18-a2ab-f61078233585"),
                    Id = Guid.Parse("999ecc8a-3b95-4bfa-8806-0ef1ed75fd34")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("1632f86b-846f-4a69-b4a2-e5f6dd7d4742"),
                    SecondDepartmentId = Guid.Parse("7285b039-3ac9-4a21-9dcd-9fc96164e600"),
                    Id = Guid.Parse("2786ccc7-bc75-4698-b060-d94c1336c23d")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("906ac8fa-ce00-4194-8d13-f517242777f4"),
                    SecondDepartmentId = Guid.Parse("f351db6b-828b-462a-a032-1354a73733e8"),
                    Id = Guid.Parse("3a9017cd-2a0d-4798-8a7a-e72eb4e6b59e")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("906ac8fa-ce00-4194-8d13-f517242777f4"),
                    SecondDepartmentId = Guid.Parse("73d7b3b6-1018-4b19-a57b-d189d75c7c81"),
                    Id = Guid.Parse("da317893-b054-41c1-8202-8fbf181be878")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("906ac8fa-ce00-4194-8d13-f517242777f4"),
                    SecondDepartmentId = Guid.Parse("5f5ba403-ae25-440b-9f38-809881781211"),
                    Id = Guid.Parse("78ee4e2c-0fce-431e-a7a6-e3f9103cdf7a")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("906ac8fa-ce00-4194-8d13-f517242777f4"),
                    SecondDepartmentId = Guid.Parse("75020b4c-5dac-447f-941b-470fc5019eac"),
                    Id = Guid.Parse("00793ff5-fee6-4492-962f-9c7218bb8ef3")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("906ac8fa-ce00-4194-8d13-f517242777f4"),
                    SecondDepartmentId = Guid.Parse("f1cfaa9c-44cc-4685-af6f-45ae258efb07"),
                    Id = Guid.Parse("9e41459f-6b02-4d3f-904e-4c1c7790ad3d")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("906ac8fa-ce00-4194-8d13-f517242777f4"),
                    SecondDepartmentId = Guid.Parse("c9220a79-ac83-4e46-a397-0830b052769e"),
                    Id = Guid.Parse("322d30ee-98d6-4dfe-93b6-ca1d23959ee2")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e"),
                    SecondDepartmentId = Guid.Parse("5cc49bd4-a1bf-4f4b-9744-13668eae12f0"),
                    Id = Guid.Parse("38d6249c-8c9a-4dcd-8a55-8ae525a7a5e9")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e"),
                    SecondDepartmentId = Guid.Parse("28cce0f5-1692-4db3-af74-e4efc3aef1e6"),
                    Id = Guid.Parse("41ba73e6-0d41-4ac3-828f-3d0b17d2d03c")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e"),
                    SecondDepartmentId = Guid.Parse("fbcf13f8-24f2-4f89-a9c0-bcada6f4ba62"),
                    Id = Guid.Parse("4843c44f-04df-4300-877f-826522a64691")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e"),
                    SecondDepartmentId = Guid.Parse("b59aa9c6-9441-4b8f-aabf-031eae7ef550"),
                    Id = Guid.Parse("d2311e93-f514-433d-b4d0-08897860d26e")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e"),
                    SecondDepartmentId = Guid.Parse("394ed11a-fe64-4163-b9da-eed89db9d732"),
                    Id = Guid.Parse("0fc0a7f3-ca1b-4062-9584-ffa7f7c0932e")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e"),
                    SecondDepartmentId = Guid.Parse("6af0ad8b-b789-4e9c-a191-e39711617d83"),
                    Id = Guid.Parse("73f1121b-a768-4dd1-b5ff-c856a8281c8f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("fbcf13f8-24f2-4f89-a9c0-bcada6f4ba62"),
                    SecondDepartmentId = Guid.Parse("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e"),
                    Id = Guid.Parse("3de84467-75cc-427b-a0b8-379cc97a3d9f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("fbcf13f8-24f2-4f89-a9c0-bcada6f4ba62"),
                    SecondDepartmentId = Guid.Parse("b59aa9c6-9441-4b8f-aabf-031eae7ef550"),
                    Id = Guid.Parse("32fd6686-e0e0-48c9-9261-f58b1773f87b")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("fbcf13f8-24f2-4f89-a9c0-bcada6f4ba62"),
                    SecondDepartmentId = Guid.Parse("5f5ba403-ae25-440b-9f38-809881781211"),
                    Id = Guid.Parse("74dffb4b-bd39-435a-824e-920c47165fee")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("fbcf13f8-24f2-4f89-a9c0-bcada6f4ba62"),
                    SecondDepartmentId = Guid.Parse("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51"),
                    Id = Guid.Parse("45d76ed9-89a3-456b-b6ba-e806ef84e3ea")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("fbcf13f8-24f2-4f89-a9c0-bcada6f4ba62"),
                    SecondDepartmentId = Guid.Parse("394ed11a-fe64-4163-b9da-eed89db9d732"),
                    Id = Guid.Parse("09119b31-46a2-4af4-aa1f-d5d56bd20e83")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("8ce39bf5-92de-48db-bb8b-30892a4a090f"),
                    SecondDepartmentId = Guid.Parse("1ef7fde0-47b6-4fda-810c-44c33d1fbee8"),
                    Id = Guid.Parse("38c9605b-dac3-46b7-8943-86d9574d0953")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("8ce39bf5-92de-48db-bb8b-30892a4a090f"),
                    SecondDepartmentId = Guid.Parse("85ef4758-c7a8-4cbc-9416-caaea32e4d05"),
                    Id = Guid.Parse("11037b25-e908-4bd4-942d-05d6e4034268")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("8ce39bf5-92de-48db-bb8b-30892a4a090f"),
                    SecondDepartmentId = Guid.Parse("c1aed70b-666e-4f32-bee2-f52722d89b1f"),
                    Id = Guid.Parse("e46604a6-8c6d-472d-be6b-fd38df05474d")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("8ce39bf5-92de-48db-bb8b-30892a4a090f"),
                    SecondDepartmentId = Guid.Parse("6a16c6c6-4b11-4651-b291-739fd143cb19"),
                    Id = Guid.Parse("89152243-b25c-4bd8-87e3-03716d664150")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("8ce39bf5-92de-48db-bb8b-30892a4a090f"),
                    SecondDepartmentId = Guid.Parse("069da2fe-b9c4-49d8-9ae6-77530d8d85ee"),
                    Id = Guid.Parse("07f9fcc2-f128-4f76-b72e-98b297645e31")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("8ce39bf5-92de-48db-bb8b-30892a4a090f"),
                    SecondDepartmentId = Guid.Parse("661ba9ad-e1e9-413c-bdfe-66401edd5596"),
                    Id = Guid.Parse("0d36f9de-3afc-4fdb-881b-0b1ace558652")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("4258f49d-10e3-4428-a398-66ffc5faa23f"),
                    SecondDepartmentId = Guid.Parse("1ef7fde0-47b6-4fda-810c-44c33d1fbee8"),
                    Id = Guid.Parse("25c6f0c3-a69e-4132-947d-b2dc8e97d849")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("4258f49d-10e3-4428-a398-66ffc5faa23f"),
                    SecondDepartmentId = Guid.Parse("dbde4b03-bd9c-4b18-81c3-9b24e0558003"),
                    Id = Guid.Parse("583f0108-be6b-43c5-9b82-85a492bbc18c")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("4258f49d-10e3-4428-a398-66ffc5faa23f"),
                    SecondDepartmentId = Guid.Parse("2acb1828-07a0-45fd-b52e-15b7eb6e02ce"),
                    Id = Guid.Parse("9cc1e057-4f04-45c6-ad61-c069582b7455")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("4258f49d-10e3-4428-a398-66ffc5faa23f"),
                    SecondDepartmentId = Guid.Parse("52ee48da-49f3-4701-93de-f113946380c9"),
                    Id = Guid.Parse("3637aa83-d99f-443b-9ebf-ebcc81380982")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("4258f49d-10e3-4428-a398-66ffc5faa23f"),
                    SecondDepartmentId = Guid.Parse("63a854d0-a738-4684-9853-f83f051a88fc"),
                    Id = Guid.Parse("625f2f55-7cfe-4704-a6ab-31b4860c8bc4")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("d3cb1fd0-444e-4e2a-82a2-7382536b1770"),
                    SecondDepartmentId = Guid.Parse("e007dcb1-8678-47ab-90dd-441f76873b9e"),
                    Id = Guid.Parse("00cc3796-815f-4d68-ad4b-609909684b58")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("d3cb1fd0-444e-4e2a-82a2-7382536b1770"),
                    SecondDepartmentId = Guid.Parse("e7931a2e-e969-43a2-9c71-542549fc41aa"),
                    Id = Guid.Parse("8721aff8-b478-4d6b-8cb5-2952c900d1e9")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("d3cb1fd0-444e-4e2a-82a2-7382536b1770"),
                    SecondDepartmentId = Guid.Parse("cbf1b899-4d3d-4155-bae7-07915a6b8c09"),
                    Id = Guid.Parse("dfa2ef90-cb87-49ce-97b1-a01613488014")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("d3cb1fd0-444e-4e2a-82a2-7382536b1770"),
                    SecondDepartmentId = Guid.Parse("895ce97a-633b-4782-b060-f276b4141e90"),
                    Id = Guid.Parse("4aa0c7d2-3f61-4489-9fbc-585a0818ddcd")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("b59aa9c6-9441-4b8f-aabf-031eae7ef550"),
                    SecondDepartmentId = Guid.Parse("5cc49bd4-a1bf-4f4b-9744-13668eae12f0"),
                    Id = Guid.Parse("ee39859a-2cf1-4b44-8d92-31ae12785833")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("b59aa9c6-9441-4b8f-aabf-031eae7ef550"),
                    SecondDepartmentId = Guid.Parse("c8851fc2-7704-412d-b272-130cbed5f422"),
                    Id = Guid.Parse("64d90025-4ad2-4bd1-80ee-e86a7f6784f9")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("b59aa9c6-9441-4b8f-aabf-031eae7ef550"),
                    SecondDepartmentId = Guid.Parse("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e"),
                    Id = Guid.Parse("7722b570-6b9a-4216-b690-f25b9ad1cef2")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("b59aa9c6-9441-4b8f-aabf-031eae7ef550"),
                    SecondDepartmentId = Guid.Parse("fbcf13f8-24f2-4f89-a9c0-bcada6f4ba62"),
                    Id = Guid.Parse("46919d99-61f2-4fb3-8b88-e3d532b81204")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("b59aa9c6-9441-4b8f-aabf-031eae7ef550"),
                    SecondDepartmentId = Guid.Parse("1c05a510-8e08-4e61-94f1-d5b9661a2b08"),
                    Id = Guid.Parse("231c9de1-cced-4328-b3a8-da02be157721")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("b59aa9c6-9441-4b8f-aabf-031eae7ef550"),
                    SecondDepartmentId = Guid.Parse("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51"),
                    Id = Guid.Parse("d76e1818-dc26-4698-891c-1dd11a0a61ff")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("dd1e3ba1-385c-4941-8d5b-dfbfa1554154"),
                    SecondDepartmentId = Guid.Parse("cc023a01-8a9b-4ed6-b41c-9388c363db49"),
                    Id = Guid.Parse("0603a080-e002-47d4-9d8c-73ca19f3d1d6")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("dd1e3ba1-385c-4941-8d5b-dfbfa1554154"),
                    SecondDepartmentId = Guid.Parse("470669cc-1d05-4d07-838e-3aea8923d7c6"),
                    Id = Guid.Parse("e67deed2-3900-4bb5-9e16-a768b686bab2")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("dd1e3ba1-385c-4941-8d5b-dfbfa1554154"),
                    SecondDepartmentId = Guid.Parse("11560417-8292-4dfd-b345-9e4a207ee6ca"),
                    Id = Guid.Parse("2467bd94-9fd8-4fce-954e-3769cf8fe629")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("dd1e3ba1-385c-4941-8d5b-dfbfa1554154"),
                    SecondDepartmentId = Guid.Parse("069da2fe-b9c4-49d8-9ae6-77530d8d85ee"),
                    Id = Guid.Parse("a628e329-0ec7-4da8-8a4f-386c75c52cce")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("dd1e3ba1-385c-4941-8d5b-dfbfa1554154"),
                    SecondDepartmentId = Guid.Parse("63a854d0-a738-4684-9853-f83f051a88fc"),
                    Id = Guid.Parse("317ce829-6b7f-4ed1-b2cd-f105b7984b06")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("470669cc-1d05-4d07-838e-3aea8923d7c6"),
                    SecondDepartmentId = Guid.Parse("c1aed70b-666e-4f32-bee2-f52722d89b1f"),
                    Id = Guid.Parse("782eb5a7-df78-47b7-b9e6-0a13091935f3")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("470669cc-1d05-4d07-838e-3aea8923d7c6"),
                    SecondDepartmentId = Guid.Parse("95295597-7518-4999-bdd7-52ef36bd24c0"),
                    Id = Guid.Parse("f07b3c3e-e812-4689-872c-eaaa54a7b54c")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("470669cc-1d05-4d07-838e-3aea8923d7c6"),
                    SecondDepartmentId = Guid.Parse("dd1e3ba1-385c-4941-8d5b-dfbfa1554154"),
                    Id = Guid.Parse("aedb2427-f0de-4e00-bc44-1036a637e5bc")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("470669cc-1d05-4d07-838e-3aea8923d7c6"),
                    SecondDepartmentId = Guid.Parse("82973925-433a-4f55-89c8-f41fc398a0c2"),
                    Id = Guid.Parse("61e8cdcd-8be5-484b-af0a-f4789e1407df")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("470669cc-1d05-4d07-838e-3aea8923d7c6"),
                    SecondDepartmentId = Guid.Parse("11560417-8292-4dfd-b345-9e4a207ee6ca"),
                    Id = Guid.Parse("2328be8d-33e4-4e83-ab6b-356134d7635b")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("470669cc-1d05-4d07-838e-3aea8923d7c6"),
                    SecondDepartmentId = Guid.Parse("069da2fe-b9c4-49d8-9ae6-77530d8d85ee"),
                    Id = Guid.Parse("3950ea6e-7642-4324-b30f-a9753bea30b6")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("73d7b3b6-1018-4b19-a57b-d189d75c7c81"),
                    SecondDepartmentId = Guid.Parse("906ac8fa-ce00-4194-8d13-f517242777f4"),
                    Id = Guid.Parse("9b49a9da-0ccc-4f66-8cba-16e89ee4cd0f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("73d7b3b6-1018-4b19-a57b-d189d75c7c81"),
                    SecondDepartmentId = Guid.Parse("5f5ba403-ae25-440b-9f38-809881781211"),
                    Id = Guid.Parse("adb5a3ac-712b-4835-8963-d27f6b6a4fb1")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("73d7b3b6-1018-4b19-a57b-d189d75c7c81"),
                    SecondDepartmentId = Guid.Parse("f1cfaa9c-44cc-4685-af6f-45ae258efb07"),
                    Id = Guid.Parse("8f60689a-c5fc-43df-a8f5-eececa7dd62f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("73d7b3b6-1018-4b19-a57b-d189d75c7c81"),
                    SecondDepartmentId = Guid.Parse("c9220a79-ac83-4e46-a397-0830b052769e"),
                    Id = Guid.Parse("af5d6f4e-77b7-4ec8-a78c-6a4d484dee5a")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("73d7b3b6-1018-4b19-a57b-d189d75c7c81"),
                    SecondDepartmentId = Guid.Parse("f8c9d891-e9c5-43a1-8bfb-62f2cf51ab79"),
                    Id = Guid.Parse("7e0bec02-3e2c-422d-bdd6-4b77fba2c848")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("1c05a510-8e08-4e61-94f1-d5b9661a2b08"),
                    SecondDepartmentId = Guid.Parse("5cc49bd4-a1bf-4f4b-9744-13668eae12f0"),
                    Id = Guid.Parse("bc4bd17b-e660-4324-acf1-93a89ce41381")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("1c05a510-8e08-4e61-94f1-d5b9661a2b08"),
                    SecondDepartmentId = Guid.Parse("c8851fc2-7704-412d-b272-130cbed5f422"),
                    Id = Guid.Parse("c50bac80-f011-4fe8-ad4a-c919c3e15e95")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("1c05a510-8e08-4e61-94f1-d5b9661a2b08"),
                    SecondDepartmentId = Guid.Parse("b59aa9c6-9441-4b8f-aabf-031eae7ef550"),
                    Id = Guid.Parse("85e04383-89db-41a6-b0d1-8196db784b82")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("1c05a510-8e08-4e61-94f1-d5b9661a2b08"),
                    SecondDepartmentId = Guid.Parse("52f1f21c-bea3-498b-bafa-26846d550230"),
                    Id = Guid.Parse("4177d2ec-cbc8-454a-9652-3c92397c44df")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("1c05a510-8e08-4e61-94f1-d5b9661a2b08"),
                    SecondDepartmentId = Guid.Parse("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"),
                    Id = Guid.Parse("aba375e7-b6f7-416a-bfe2-89ca11710ba8")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("1c05a510-8e08-4e61-94f1-d5b9661a2b08"),
                    SecondDepartmentId = Guid.Parse("667fec95-c40d-4289-b5d9-4760525509f3"),
                    Id = Guid.Parse("b95b6343-c6d9-45b0-b457-43d624cbd2e2")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("1c05a510-8e08-4e61-94f1-d5b9661a2b08"),
                    SecondDepartmentId = Guid.Parse("b508db1d-d8dc-4998-bbce-b110e00ac954"),
                    Id = Guid.Parse("e1004aab-8cd7-44c1-9693-0cc82cde43f6")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b"),
                    SecondDepartmentId = Guid.Parse("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd"),
                    Id = Guid.Parse("daf2a88b-2506-4e17-8e13-50b6f30d2e80")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b"),
                    SecondDepartmentId = Guid.Parse("95295597-7518-4999-bdd7-52ef36bd24c0"),
                    Id = Guid.Parse("6dd16790-9f69-4a32-a112-732ba6b31e72")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b"),
                    SecondDepartmentId = Guid.Parse("c1bd362f-88bd-4e6a-8928-ad6d29ee549a"),
                    Id = Guid.Parse("aacc9db7-301c-4d08-87dd-571dcae62db3")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b"),
                    SecondDepartmentId = Guid.Parse("44cc60d3-d233-4bf1-92c1-539961e5be6b"),
                    Id = Guid.Parse("25cc4851-49fa-40ff-8e6d-70c62ba734cb")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b"),
                    SecondDepartmentId = Guid.Parse("cbf1b899-4d3d-4155-bae7-07915a6b8c09"),
                    Id = Guid.Parse("97b5b037-0586-4ff7-a31c-07ba412d8387")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b"),
                    SecondDepartmentId = Guid.Parse("2d75fb26-8926-4607-b618-1d727cd31fe8"),
                    Id = Guid.Parse("aadecebb-51c2-4f26-b7a4-53f2b3bb1fd1")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("cbf1b899-4d3d-4155-bae7-07915a6b8c09"),
                    SecondDepartmentId = Guid.Parse("44cc60d3-d233-4bf1-92c1-539961e5be6b"),
                    Id = Guid.Parse("61612971-503f-4640-8d66-7d1fe05da734")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("cbf1b899-4d3d-4155-bae7-07915a6b8c09"),
                    SecondDepartmentId = Guid.Parse("e007dcb1-8678-47ab-90dd-441f76873b9e"),
                    Id = Guid.Parse("ca81544e-95ab-4b2c-b40a-433514dfad73")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("cbf1b899-4d3d-4155-bae7-07915a6b8c09"),
                    SecondDepartmentId = Guid.Parse("e7931a2e-e969-43a2-9c71-542549fc41aa"),
                    Id = Guid.Parse("2e9065f5-bf95-4053-bd59-366226cd342c")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("cbf1b899-4d3d-4155-bae7-07915a6b8c09"),
                    SecondDepartmentId = Guid.Parse("d3cb1fd0-444e-4e2a-82a2-7382536b1770"),
                    Id = Guid.Parse("41e890e7-b0ea-428c-b245-187b522d0af0")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("cbf1b899-4d3d-4155-bae7-07915a6b8c09"),
                    SecondDepartmentId = Guid.Parse("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b"),
                    Id = Guid.Parse("3e0d08f1-9fd6-4a9c-bcba-13660f6e1257")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("cbf1b899-4d3d-4155-bae7-07915a6b8c09"),
                    SecondDepartmentId = Guid.Parse("2d75fb26-8926-4607-b618-1d727cd31fe8"),
                    Id = Guid.Parse("1fcd7aea-3903-43e3-b43c-ae1ac806d8d1")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("82973925-433a-4f55-89c8-f41fc398a0c2"),
                    SecondDepartmentId = Guid.Parse("c1aed70b-666e-4f32-bee2-f52722d89b1f"),
                    Id = Guid.Parse("64a00cf7-3fd2-488f-af0a-9994bff82910")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("82973925-433a-4f55-89c8-f41fc398a0c2"),
                    SecondDepartmentId = Guid.Parse("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd"),
                    Id = Guid.Parse("574a511e-063d-4f62-9bdd-ce6bf0222a3c")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("82973925-433a-4f55-89c8-f41fc398a0c2"),
                    SecondDepartmentId = Guid.Parse("95295597-7518-4999-bdd7-52ef36bd24c0"),
                    Id = Guid.Parse("11bdfe2c-b9f2-4890-86a1-919d0a4dfbdd")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("82973925-433a-4f55-89c8-f41fc398a0c2"),
                    SecondDepartmentId = Guid.Parse("11d695a1-9893-4f18-a2ab-f61078233585"),
                    Id = Guid.Parse("623c94c1-b7f3-4d44-b85d-dbda9dbcdee2")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("82973925-433a-4f55-89c8-f41fc398a0c2"),
                    SecondDepartmentId = Guid.Parse("470669cc-1d05-4d07-838e-3aea8923d7c6"),
                    Id = Guid.Parse("9274807d-3a47-4579-8284-7f7842d62073")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("5f5ba403-ae25-440b-9f38-809881781211"),
                    SecondDepartmentId = Guid.Parse("fbcf13f8-24f2-4f89-a9c0-bcada6f4ba62"),
                    Id = Guid.Parse("3226f3ef-89db-4af3-9d72-15d0a18e4a8f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("5f5ba403-ae25-440b-9f38-809881781211"),
                    SecondDepartmentId = Guid.Parse("73d7b3b6-1018-4b19-a57b-d189d75c7c81"),
                    Id = Guid.Parse("fe194d6d-b5ba-401b-b232-dcf3a575dbb9")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("5f5ba403-ae25-440b-9f38-809881781211"),
                    SecondDepartmentId = Guid.Parse("f1cfaa9c-44cc-4685-af6f-45ae258efb07"),
                    Id = Guid.Parse("c9fb13de-65c5-4a67-bdc1-6ed5dd77b18e")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("5f5ba403-ae25-440b-9f38-809881781211"),
                    SecondDepartmentId = Guid.Parse("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51"),
                    Id = Guid.Parse("ab521b63-e84e-4393-9488-67a99be13e93")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("5f5ba403-ae25-440b-9f38-809881781211"),
                    SecondDepartmentId = Guid.Parse("479db9d5-9d65-473c-94c9-c84bfe8a9efc"),
                    Id = Guid.Parse("3a98382f-58a5-4d2f-8601-c0cdd884efbd")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("5f5ba403-ae25-440b-9f38-809881781211"),
                    SecondDepartmentId = Guid.Parse("f8c9d891-e9c5-43a1-8bfb-62f2cf51ab79"),
                    Id = Guid.Parse("897db842-32f0-48f4-aff4-d68a653dacb9")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("5f5ba403-ae25-440b-9f38-809881781211"),
                    SecondDepartmentId = Guid.Parse("394ed11a-fe64-4163-b9da-eed89db9d732"),
                    Id = Guid.Parse("a3f96857-541c-471f-8aa4-96649394585e")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("75020b4c-5dac-447f-941b-470fc5019eac"),
                    SecondDepartmentId = Guid.Parse("785e7ff9-229a-426c-b664-479312d4cf8d"),
                    Id = Guid.Parse("9d38470d-37d0-42c4-9474-28ca7c9a56fe")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("75020b4c-5dac-447f-941b-470fc5019eac"),
                    SecondDepartmentId = Guid.Parse("906ac8fa-ce00-4194-8d13-f517242777f4"),
                    Id = Guid.Parse("23ba6106-a12e-4151-b944-46f081441056")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("75020b4c-5dac-447f-941b-470fc5019eac"),
                    SecondDepartmentId = Guid.Parse("f1cfaa9c-44cc-4685-af6f-45ae258efb07"),
                    Id = Guid.Parse("0483bf0d-f593-43a8-8552-3964259a92c2")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("75020b4c-5dac-447f-941b-470fc5019eac"),
                    SecondDepartmentId = Guid.Parse("3489baa7-b17e-4003-a78f-cb156dee058e"),
                    Id = Guid.Parse("ad3c2e1f-1fc7-4c10-a393-2eb566c89743")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("9498c4a1-398d-4c06-8b49-aa84290cf2ca"),
                    SecondDepartmentId = Guid.Parse("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee"),
                    Id = Guid.Parse("822a4cb4-63cf-4d87-adab-b063375f5ef2")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("9498c4a1-398d-4c06-8b49-aa84290cf2ca"),
                    SecondDepartmentId = Guid.Parse("16cd59b4-3971-45ec-bd68-d26ac70d2da0"),
                    Id = Guid.Parse("0324b024-802e-443a-8b54-c8f8e18be841")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("9498c4a1-398d-4c06-8b49-aa84290cf2ca"),
                    SecondDepartmentId = Guid.Parse("30ba0a20-3568-4484-9df1-151de6fd36c2"),
                    Id = Guid.Parse("fb730aa1-c03c-418d-aad7-13fcf7fd1623")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("9498c4a1-398d-4c06-8b49-aa84290cf2ca"),
                    SecondDepartmentId = Guid.Parse("3577171f-2b34-4d53-9aff-17885e7d4679"),
                    Id = Guid.Parse("2b5dc953-6d50-43ff-b0de-358d18c68f99")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("9498c4a1-398d-4c06-8b49-aa84290cf2ca"),
                    SecondDepartmentId = Guid.Parse("310e87ad-0b29-470e-9120-b025a3a46c9f"),
                    Id = Guid.Parse("c2fe02df-3b9a-4e68-a35f-f844ed7a362e")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("9498c4a1-398d-4c06-8b49-aa84290cf2ca"),
                    SecondDepartmentId = Guid.Parse("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"),
                    Id = Guid.Parse("5cbdd9c8-4867-43c1-8014-024ce945d774")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("3577171f-2b34-4d53-9aff-17885e7d4679"),
                    SecondDepartmentId = Guid.Parse("30ba0a20-3568-4484-9df1-151de6fd36c2"),
                    Id = Guid.Parse("8e4998f5-f7bf-40ad-a324-20633fa4b723")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("3577171f-2b34-4d53-9aff-17885e7d4679"),
                    SecondDepartmentId = Guid.Parse("dbde4b03-bd9c-4b18-81c3-9b24e0558003"),
                    Id = Guid.Parse("33c4170a-c527-47dc-af21-03a1d19ea0df")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("3577171f-2b34-4d53-9aff-17885e7d4679"),
                    SecondDepartmentId = Guid.Parse("9498c4a1-398d-4c06-8b49-aa84290cf2ca"),
                    Id = Guid.Parse("21b6ad05-77f4-4c61-8ef7-a4fa388e5440")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("3577171f-2b34-4d53-9aff-17885e7d4679"),
                    SecondDepartmentId = Guid.Parse("310e87ad-0b29-470e-9120-b025a3a46c9f"),
                    Id = Guid.Parse("8c26080c-c2a1-471d-9604-e759d4468a3f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("3577171f-2b34-4d53-9aff-17885e7d4679"),
                    SecondDepartmentId = Guid.Parse("52ee48da-49f3-4701-93de-f113946380c9"),
                    Id = Guid.Parse("bb16b787-957d-477e-923d-99ad7aa73c65")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("3577171f-2b34-4d53-9aff-17885e7d4679"),
                    SecondDepartmentId = Guid.Parse("ff2b1187-63bf-46fa-a70c-4db6b323babb"),
                    Id = Guid.Parse("327375e1-4d80-4b21-8e63-78f059035d69")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("f1cfaa9c-44cc-4685-af6f-45ae258efb07"),
                    SecondDepartmentId = Guid.Parse("906ac8fa-ce00-4194-8d13-f517242777f4"),
                    Id = Guid.Parse("fe3a33d4-e1d3-44b7-8992-a361b57e603f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("f1cfaa9c-44cc-4685-af6f-45ae258efb07"),
                    SecondDepartmentId = Guid.Parse("73d7b3b6-1018-4b19-a57b-d189d75c7c81"),
                    Id = Guid.Parse("b0a70e21-bd2e-4c69-839a-44423da9c27d")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("f1cfaa9c-44cc-4685-af6f-45ae258efb07"),
                    SecondDepartmentId = Guid.Parse("5f5ba403-ae25-440b-9f38-809881781211"),
                    Id = Guid.Parse("7d147d42-db15-4680-a229-5b8a6526f21d")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("f1cfaa9c-44cc-4685-af6f-45ae258efb07"),
                    SecondDepartmentId = Guid.Parse("75020b4c-5dac-447f-941b-470fc5019eac"),
                    Id = Guid.Parse("e2760a2d-9e70-4cbc-b2d0-fa17820c0f26")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("f1cfaa9c-44cc-4685-af6f-45ae258efb07"),
                    SecondDepartmentId = Guid.Parse("3489baa7-b17e-4003-a78f-cb156dee058e"),
                    Id = Guid.Parse("41a52d33-f0ae-4bec-9efc-503851093a17")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("f1cfaa9c-44cc-4685-af6f-45ae258efb07"),
                    SecondDepartmentId = Guid.Parse("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51"),
                    Id = Guid.Parse("91b2c0c8-d905-4326-adca-39eee5dedebd")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("a435415d-d1f2-4af1-8de9-93af2ce43747"),
                    SecondDepartmentId = Guid.Parse("310e87ad-0b29-470e-9120-b025a3a46c9f"),
                    Id = Guid.Parse("afb84516-86d5-4adb-b961-19b559f379c5")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("a435415d-d1f2-4af1-8de9-93af2ce43747"),
                    SecondDepartmentId = Guid.Parse("6b921a7d-143a-4014-b113-862ded825b60"),
                    Id = Guid.Parse("1b7a6348-97ac-4b73-b292-8c0d558e5ec3")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("a435415d-d1f2-4af1-8de9-93af2ce43747"),
                    SecondDepartmentId = Guid.Parse("5614ee02-1939-4ab9-94a7-c64070908c65"),
                    Id = Guid.Parse("224be211-ed91-4651-9aa8-59aca75dad42")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("a435415d-d1f2-4af1-8de9-93af2ce43747"),
                    SecondDepartmentId = Guid.Parse("ff2b1187-63bf-46fa-a70c-4db6b323babb"),
                    Id = Guid.Parse("ea1f75d8-9486-4a32-bf21-0acb90e47914")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("310e87ad-0b29-470e-9120-b025a3a46c9f"),
                    SecondDepartmentId = Guid.Parse("16cd59b4-3971-45ec-bd68-d26ac70d2da0"),
                    Id = Guid.Parse("a96af417-4320-4935-a4ef-247cff00286f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("310e87ad-0b29-470e-9120-b025a3a46c9f"),
                    SecondDepartmentId = Guid.Parse("9498c4a1-398d-4c06-8b49-aa84290cf2ca"),
                    Id = Guid.Parse("c41e06c7-3e53-4ff6-9c44-5d16b59123ca")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("310e87ad-0b29-470e-9120-b025a3a46c9f"),
                    SecondDepartmentId = Guid.Parse("3577171f-2b34-4d53-9aff-17885e7d4679"),
                    Id = Guid.Parse("dc3497d5-4ba4-4605-9454-822c1f6ba515")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("310e87ad-0b29-470e-9120-b025a3a46c9f"),
                    SecondDepartmentId = Guid.Parse("a435415d-d1f2-4af1-8de9-93af2ce43747"),
                    Id = Guid.Parse("018dc9c9-43e1-41bf-b731-4efef4acbeda")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("310e87ad-0b29-470e-9120-b025a3a46c9f"),
                    SecondDepartmentId = Guid.Parse("ff2b1187-63bf-46fa-a70c-4db6b323babb"),
                    Id = Guid.Parse("7509d07b-6d3d-449a-a5eb-3b36c8575e1a")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c9220a79-ac83-4e46-a397-0830b052769e"),
                    SecondDepartmentId = Guid.Parse("f351db6b-828b-462a-a032-1354a73733e8"),
                    Id = Guid.Parse("6053dd86-7b8d-400a-bd59-a2fed35b5608")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c9220a79-ac83-4e46-a397-0830b052769e"),
                    SecondDepartmentId = Guid.Parse("57eb6e76-cfe4-491a-8c5b-2cbbf5d44217"),
                    Id = Guid.Parse("56ff6e61-3e91-4ee6-8c7c-5ffed016ae84")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c9220a79-ac83-4e46-a397-0830b052769e"),
                    SecondDepartmentId = Guid.Parse("906ac8fa-ce00-4194-8d13-f517242777f4"),
                    Id = Guid.Parse("ae7565df-0a08-4156-8b8b-ee762ced170c")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("c9220a79-ac83-4e46-a397-0830b052769e"),
                    SecondDepartmentId = Guid.Parse("73d7b3b6-1018-4b19-a57b-d189d75c7c81"),
                    Id = Guid.Parse("a85609fc-ef32-4363-8f71-7001c1f691ff")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("6b921a7d-143a-4014-b113-862ded825b60"),
                    SecondDepartmentId = Guid.Parse("a435415d-d1f2-4af1-8de9-93af2ce43747"),
                    Id = Guid.Parse("0d495d85-551c-4b26-8952-694fe306e5d4")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("6b921a7d-143a-4014-b113-862ded825b60"),
                    SecondDepartmentId = Guid.Parse("5614ee02-1939-4ab9-94a7-c64070908c65"),
                    Id = Guid.Parse("efbfed22-1049-4e4c-883c-1da8bd878818")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("6b921a7d-143a-4014-b113-862ded825b60"),
                    SecondDepartmentId = Guid.Parse("ff2b1187-63bf-46fa-a70c-4db6b323babb"),
                    Id = Guid.Parse("0e894842-4226-4fe9-be3c-796014cd4175")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("52f1f21c-bea3-498b-bafa-26846d550230"),
                    SecondDepartmentId = Guid.Parse("cc023a01-8a9b-4ed6-b41c-9388c363db49"),
                    Id = Guid.Parse("313c874a-c9dc-4d38-9a29-eb0fe578cf64")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("52f1f21c-bea3-498b-bafa-26846d550230"),
                    SecondDepartmentId = Guid.Parse("5cc49bd4-a1bf-4f4b-9744-13668eae12f0"),
                    Id = Guid.Parse("f6d6f9bb-c447-48f5-8b71-4c5395a69a28")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("52f1f21c-bea3-498b-bafa-26846d550230"),
                    SecondDepartmentId = Guid.Parse("dbde4b03-bd9c-4b18-81c3-9b24e0558003"),
                    Id = Guid.Parse("0e8d5781-4994-43fa-a259-466c0d4d9e09")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("52f1f21c-bea3-498b-bafa-26846d550230"),
                    SecondDepartmentId = Guid.Parse("1c05a510-8e08-4e61-94f1-d5b9661a2b08"),
                    Id = Guid.Parse("98fca573-5601-4ce8-b4ce-f126b3eb1679")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("52f1f21c-bea3-498b-bafa-26846d550230"),
                    SecondDepartmentId = Guid.Parse("63a854d0-a738-4684-9853-f83f051a88fc"),
                    Id = Guid.Parse("56831e06-0fa7-448a-96b1-9e57386e8673")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("52f1f21c-bea3-498b-bafa-26846d550230"),
                    SecondDepartmentId = Guid.Parse("667fec95-c40d-4289-b5d9-4760525509f3"),
                    Id = Guid.Parse("283e8eec-be6a-470f-89d6-86b057f503d4")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("9e8fd57a-abe9-4cd6-958c-53ec0ba6be80"),
                    SecondDepartmentId = Guid.Parse("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee"),
                    Id = Guid.Parse("eec0fb93-8805-4591-bff8-f478283daac8")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("9e8fd57a-abe9-4cd6-958c-53ec0ba6be80"),
                    SecondDepartmentId = Guid.Parse("16cd59b4-3971-45ec-bd68-d26ac70d2da0"),
                    Id = Guid.Parse("d71aaf35-48c4-491c-8df0-ec13c46e243b")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("9e8fd57a-abe9-4cd6-958c-53ec0ba6be80"),
                    SecondDepartmentId = Guid.Parse("7591742b-97d3-4b0a-81a6-20a4247d47ca"),
                    Id = Guid.Parse("9a4e2046-e430-4f87-aff4-b82cc8eee701")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("9e8fd57a-abe9-4cd6-958c-53ec0ba6be80"),
                    SecondDepartmentId = Guid.Parse("343e77cb-a854-416b-aeac-86c9ffad82ce"),
                    Id = Guid.Parse("defd3ab6-05e7-45b3-aad1-053a2ea3b6bf")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("78476d14-2f28-4e95-874e-09f1d4fd0171"),
                    SecondDepartmentId = Guid.Parse("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee"),
                    Id = Guid.Parse("6ce59bbb-302e-4eeb-91fb-729236c22c92")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("78476d14-2f28-4e95-874e-09f1d4fd0171"),
                    SecondDepartmentId = Guid.Parse("a2ba1fd9-47c5-4938-b8b3-ab01bc245859"),
                    Id = Guid.Parse("e9b9d352-5f85-4761-a444-b8bd617422ca")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("78476d14-2f28-4e95-874e-09f1d4fd0171"),
                    SecondDepartmentId = Guid.Parse("b96c0bc3-abbb-49cc-a672-5ec6af45ca63"),
                    Id = Guid.Parse("2f3b0e70-0bb0-41bb-8d2c-cf722ead7159")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("78476d14-2f28-4e95-874e-09f1d4fd0171"),
                    SecondDepartmentId = Guid.Parse("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"),
                    Id = Guid.Parse("9f080c1d-8c9b-4781-8600-7754c0f3392f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("78476d14-2f28-4e95-874e-09f1d4fd0171"),
                    SecondDepartmentId = Guid.Parse("343e77cb-a854-416b-aeac-86c9ffad82ce"),
                    Id = Guid.Parse("fd087bc4-d301-43ec-8e0e-31f9b03636ed")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("78476d14-2f28-4e95-874e-09f1d4fd0171"),
                    SecondDepartmentId = Guid.Parse("24e44487-3f98-42b9-9b44-818e5d8d7bbd"),
                    Id = Guid.Parse("08fa9c60-f101-4a0b-bdc7-3b18f2f2020b")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("3489baa7-b17e-4003-a78f-cb156dee058e"),
                    SecondDepartmentId = Guid.Parse("785e7ff9-229a-426c-b664-479312d4cf8d"),
                    Id = Guid.Parse("3011e2b3-e903-45d4-8471-a0130a885376")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("3489baa7-b17e-4003-a78f-cb156dee058e"),
                    SecondDepartmentId = Guid.Parse("a2ba1fd9-47c5-4938-b8b3-ab01bc245859"),
                    Id = Guid.Parse("a5e290b6-d7ce-4da7-96d9-1e2dc8f62a4e")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("3489baa7-b17e-4003-a78f-cb156dee058e"),
                    SecondDepartmentId = Guid.Parse("c8851fc2-7704-412d-b272-130cbed5f422"),
                    Id = Guid.Parse("98760679-efa4-481c-ac9e-d349f0829162")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("3489baa7-b17e-4003-a78f-cb156dee058e"),
                    SecondDepartmentId = Guid.Parse("75020b4c-5dac-447f-941b-470fc5019eac"),
                    Id = Guid.Parse("2cb8bc3d-1a4f-45e5-8576-914028671133")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("3489baa7-b17e-4003-a78f-cb156dee058e"),
                    SecondDepartmentId = Guid.Parse("f1cfaa9c-44cc-4685-af6f-45ae258efb07"),
                    Id = Guid.Parse("887c90aa-2335-48a9-980c-1381c56ce4e6")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("3489baa7-b17e-4003-a78f-cb156dee058e"),
                    SecondDepartmentId = Guid.Parse("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51"),
                    Id = Guid.Parse("ec843a22-975b-4a86-a273-93a5d190bff0")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("7591742b-97d3-4b0a-81a6-20a4247d47ca"),
                    SecondDepartmentId = Guid.Parse("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee"),
                    Id = Guid.Parse("86c0279e-3ea7-424a-b46b-026be94fc653")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("7591742b-97d3-4b0a-81a6-20a4247d47ca"),
                    SecondDepartmentId = Guid.Parse("9e8fd57a-abe9-4cd6-958c-53ec0ba6be80"),
                    Id = Guid.Parse("a23e8d41-7155-4060-848b-a8366c307b7c")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("7591742b-97d3-4b0a-81a6-20a4247d47ca"),
                    SecondDepartmentId = Guid.Parse("343e77cb-a854-416b-aeac-86c9ffad82ce"),
                    Id = Guid.Parse("abffdbb3-f135-48a6-a636-c6d4b2d379bb")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("11560417-8292-4dfd-b345-9e4a207ee6ca"),
                    SecondDepartmentId = Guid.Parse("cc023a01-8a9b-4ed6-b41c-9388c363db49"),
                    Id = Guid.Parse("c0db2cce-6264-41fd-a042-364ac0988152")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("11560417-8292-4dfd-b345-9e4a207ee6ca"),
                    SecondDepartmentId = Guid.Parse("95295597-7518-4999-bdd7-52ef36bd24c0"),
                    Id = Guid.Parse("a3591601-ce98-4900-9dd0-09db91768b9f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("11560417-8292-4dfd-b345-9e4a207ee6ca"),
                    SecondDepartmentId = Guid.Parse("c1bd362f-88bd-4e6a-8928-ad6d29ee549a"),
                    Id = Guid.Parse("a4d768d1-3787-40b2-a5ab-bdd81d4a23fd")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("11560417-8292-4dfd-b345-9e4a207ee6ca"),
                    SecondDepartmentId = Guid.Parse("28cce0f5-1692-4db3-af74-e4efc3aef1e6"),
                    Id = Guid.Parse("a1d22de4-d568-4926-bf25-1ecdf17ebf46")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("11560417-8292-4dfd-b345-9e4a207ee6ca"),
                    SecondDepartmentId = Guid.Parse("dd1e3ba1-385c-4941-8d5b-dfbfa1554154"),
                    Id = Guid.Parse("4d21e830-f356-491a-92a9-0babfc548dbc")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("11560417-8292-4dfd-b345-9e4a207ee6ca"),
                    SecondDepartmentId = Guid.Parse("470669cc-1d05-4d07-838e-3aea8923d7c6"),
                    Id = Guid.Parse("bc6a10c2-a651-4efc-abc9-fddb5882751e")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("895ce97a-633b-4782-b060-f276b4141e90"),
                    SecondDepartmentId = Guid.Parse("e007dcb1-8678-47ab-90dd-441f76873b9e"),
                    Id = Guid.Parse("9a8b7a2d-ccac-499c-ae29-d42e135d3672")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("895ce97a-633b-4782-b060-f276b4141e90"),
                    SecondDepartmentId = Guid.Parse("d3cb1fd0-444e-4e2a-82a2-7382536b1770"),
                    Id = Guid.Parse("6f773ae3-7f24-47ec-8632-48b9b2945bc1")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("895ce97a-633b-4782-b060-f276b4141e90"),
                    SecondDepartmentId = Guid.Parse("4c3a1f47-f735-4390-ae4d-f979e16c562c"),
                    Id = Guid.Parse("4aa0c76e-257d-4646-9753-cfa30c84e4df")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("4c3a1f47-f735-4390-ae4d-f979e16c562c"),
                    SecondDepartmentId = Guid.Parse("d56fc07c-39f9-42c6-aaf5-640b2b5f6124"),
                    Id = Guid.Parse("67c92055-65ff-4f49-b941-34e939207ade")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("4c3a1f47-f735-4390-ae4d-f979e16c562c"),
                    SecondDepartmentId = Guid.Parse("e007dcb1-8678-47ab-90dd-441f76873b9e"),
                    Id = Guid.Parse("5596172c-969a-4c35-b836-95661a607e9b")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("4c3a1f47-f735-4390-ae4d-f979e16c562c"),
                    SecondDepartmentId = Guid.Parse("895ce97a-633b-4782-b060-f276b4141e90"),
                    Id = Guid.Parse("711fa6a7-c288-4922-91af-592b9ac84d08")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("caa74253-c115-4cb7-8b63-ee23545a62ff"),
                    SecondDepartmentId = Guid.Parse("77d7dc5d-545b-4f53-8db2-bf3245f3c131"),
                    Id = Guid.Parse("7c3d373d-7c7d-47ef-9dd5-ad75773cbf00")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("caa74253-c115-4cb7-8b63-ee23545a62ff"),
                    SecondDepartmentId = Guid.Parse("aec85880-4ac9-43c9-be3f-a47a41d0e88e"),
                    Id = Guid.Parse("3e491213-453a-4063-ac60-39189a9f32ef")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("5614ee02-1939-4ab9-94a7-c64070908c65"),
                    SecondDepartmentId = Guid.Parse("a435415d-d1f2-4af1-8de9-93af2ce43747"),
                    Id = Guid.Parse("47c385d0-7a8e-47e5-9375-cce879ba543e")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("5614ee02-1939-4ab9-94a7-c64070908c65"),
                    SecondDepartmentId = Guid.Parse("6b921a7d-143a-4014-b113-862ded825b60"),
                    Id = Guid.Parse("37e7fcfb-48cf-49ec-b9a5-0fbd54c5b1bc")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("5614ee02-1939-4ab9-94a7-c64070908c65"),
                    SecondDepartmentId = Guid.Parse("d7c383af-e3b6-468c-a4cb-e20f08856972"),
                    Id = Guid.Parse("81889e2e-c2b5-4673-aeef-c243411b79af")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("5614ee02-1939-4ab9-94a7-c64070908c65"),
                    SecondDepartmentId = Guid.Parse("ff2b1187-63bf-46fa-a70c-4db6b323babb"),
                    Id = Guid.Parse("7f9baf91-c2cb-4c16-99c4-1ab9df8cc5ce")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("d7c383af-e3b6-468c-a4cb-e20f08856972"),
                    SecondDepartmentId = Guid.Parse("5614ee02-1939-4ab9-94a7-c64070908c65"),
                    Id = Guid.Parse("7608e18d-fcbd-46d0-bd61-c07f4895b7b7")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("d7c383af-e3b6-468c-a4cb-e20f08856972"),
                    SecondDepartmentId = Guid.Parse("52ee48da-49f3-4701-93de-f113946380c9"),
                    Id = Guid.Parse("5a6c585a-9976-4ae4-97a5-49b94e3d3899")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("d7c383af-e3b6-468c-a4cb-e20f08856972"),
                    SecondDepartmentId = Guid.Parse("ff2b1187-63bf-46fa-a70c-4db6b323babb"),
                    Id = Guid.Parse("1cac38d1-d8ae-4b93-9a98-ebe2781bfbbb")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("d7c383af-e3b6-468c-a4cb-e20f08856972"),
                    SecondDepartmentId = Guid.Parse("0bbca13e-e227-4aaa-a078-265c9133f278"),
                    Id = Guid.Parse("5275cb4e-cb9c-4d08-86f1-511ca8f8d042")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("069da2fe-b9c4-49d8-9ae6-77530d8d85ee"),
                    SecondDepartmentId = Guid.Parse("1ef7fde0-47b6-4fda-810c-44c33d1fbee8"),
                    Id = Guid.Parse("af4dcf9c-92de-46ac-80d1-a036af068ade")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("069da2fe-b9c4-49d8-9ae6-77530d8d85ee"),
                    SecondDepartmentId = Guid.Parse("c1aed70b-666e-4f32-bee2-f52722d89b1f"),
                    Id = Guid.Parse("12033f6e-a2eb-4bb3-b79d-ea386a56fe46")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("069da2fe-b9c4-49d8-9ae6-77530d8d85ee"),
                    SecondDepartmentId = Guid.Parse("6a16c6c6-4b11-4651-b291-739fd143cb19"),
                    Id = Guid.Parse("3bdd2e4c-6f01-4d66-ab4a-bd8494c94a9c")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("069da2fe-b9c4-49d8-9ae6-77530d8d85ee"),
                    SecondDepartmentId = Guid.Parse("8ce39bf5-92de-48db-bb8b-30892a4a090f"),
                    Id = Guid.Parse("24b7db7f-c008-46de-ad93-c8fa2200efd6")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("069da2fe-b9c4-49d8-9ae6-77530d8d85ee"),
                    SecondDepartmentId = Guid.Parse("dd1e3ba1-385c-4941-8d5b-dfbfa1554154"),
                    Id = Guid.Parse("e4eafa51-43be-417c-8800-a6182fc28f83")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("069da2fe-b9c4-49d8-9ae6-77530d8d85ee"),
                    SecondDepartmentId = Guid.Parse("470669cc-1d05-4d07-838e-3aea8923d7c6"),
                    Id = Guid.Parse("eae236e6-cf55-4564-892f-132c0ff215d0")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("069da2fe-b9c4-49d8-9ae6-77530d8d85ee"),
                    SecondDepartmentId = Guid.Parse("63a854d0-a738-4684-9853-f83f051a88fc"),
                    Id = Guid.Parse("77e18b9c-2668-4b09-90c3-dc8a88509bc6")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("52ee48da-49f3-4701-93de-f113946380c9"),
                    SecondDepartmentId = Guid.Parse("dbde4b03-bd9c-4b18-81c3-9b24e0558003"),
                    Id = Guid.Parse("c9e6c97b-fc3e-4413-ae00-a2c4eed72df7")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("52ee48da-49f3-4701-93de-f113946380c9"),
                    SecondDepartmentId = Guid.Parse("2acb1828-07a0-45fd-b52e-15b7eb6e02ce"),
                    Id = Guid.Parse("12ab0405-5362-4c75-b05f-075fb4bee082")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("52ee48da-49f3-4701-93de-f113946380c9"),
                    SecondDepartmentId = Guid.Parse("4258f49d-10e3-4428-a398-66ffc5faa23f"),
                    Id = Guid.Parse("13f425d9-7d60-400f-8678-4533677aad3c")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("52ee48da-49f3-4701-93de-f113946380c9"),
                    SecondDepartmentId = Guid.Parse("3577171f-2b34-4d53-9aff-17885e7d4679"),
                    Id = Guid.Parse("e85675a1-53f7-4f73-865d-df02534db9cd")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("52ee48da-49f3-4701-93de-f113946380c9"),
                    SecondDepartmentId = Guid.Parse("ff2b1187-63bf-46fa-a70c-4db6b323babb"),
                    Id = Guid.Parse("1c2ceb9b-e852-44c9-b5dd-39fae5b42f43")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("52ee48da-49f3-4701-93de-f113946380c9"),
                    SecondDepartmentId = Guid.Parse("0bbca13e-e227-4aaa-a078-265c9133f278"),
                    Id = Guid.Parse("bb404fac-a342-4fa8-873b-2f67d0c5e466")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("63a854d0-a738-4684-9853-f83f051a88fc"),
                    SecondDepartmentId = Guid.Parse("1ef7fde0-47b6-4fda-810c-44c33d1fbee8"),
                    Id = Guid.Parse("ccb62f98-835f-4759-8da4-d5af16705dca")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("63a854d0-a738-4684-9853-f83f051a88fc"),
                    SecondDepartmentId = Guid.Parse("cc023a01-8a9b-4ed6-b41c-9388c363db49"),
                    Id = Guid.Parse("fc351383-032a-43a6-a655-950b131ce5f7")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("63a854d0-a738-4684-9853-f83f051a88fc"),
                    SecondDepartmentId = Guid.Parse("dbde4b03-bd9c-4b18-81c3-9b24e0558003"),
                    Id = Guid.Parse("a32ce416-2df8-468e-b8e3-e21e09bae391")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("63a854d0-a738-4684-9853-f83f051a88fc"),
                    SecondDepartmentId = Guid.Parse("4258f49d-10e3-4428-a398-66ffc5faa23f"),
                    Id = Guid.Parse("024b6614-1197-4741-9baa-21acb8b2e9b8")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("63a854d0-a738-4684-9853-f83f051a88fc"),
                    SecondDepartmentId = Guid.Parse("dd1e3ba1-385c-4941-8d5b-dfbfa1554154"),
                    Id = Guid.Parse("326cb680-ce60-4ff9-b16f-5acfbecf9e13")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("63a854d0-a738-4684-9853-f83f051a88fc"),
                    SecondDepartmentId = Guid.Parse("52f1f21c-bea3-498b-bafa-26846d550230"),
                    Id = Guid.Parse("7a76292f-5e81-47b1-8a6e-a06dcc7e727c")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("63a854d0-a738-4684-9853-f83f051a88fc"),
                    SecondDepartmentId = Guid.Parse("069da2fe-b9c4-49d8-9ae6-77530d8d85ee"),
                    Id = Guid.Parse("7551fd1e-8a98-4716-8a0c-f892aba201a6")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51"),
                    SecondDepartmentId = Guid.Parse("c8851fc2-7704-412d-b272-130cbed5f422"),
                    Id = Guid.Parse("852b1824-c454-4837-86bc-0a25f349f345")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51"),
                    SecondDepartmentId = Guid.Parse("fbcf13f8-24f2-4f89-a9c0-bcada6f4ba62"),
                    Id = Guid.Parse("5785e758-59f9-464d-b142-667ce83c03e1")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51"),
                    SecondDepartmentId = Guid.Parse("b59aa9c6-9441-4b8f-aabf-031eae7ef550"),
                    Id = Guid.Parse("0a88f956-54c5-4ca7-a27f-cd7405a1610c")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51"),
                    SecondDepartmentId = Guid.Parse("5f5ba403-ae25-440b-9f38-809881781211"),
                    Id = Guid.Parse("bc2c9c9c-17be-45d6-a19c-deff1ded4326")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51"),
                    SecondDepartmentId = Guid.Parse("f1cfaa9c-44cc-4685-af6f-45ae258efb07"),
                    Id = Guid.Parse("db58b31b-e2be-4185-8b1c-7da8b3a0aea2")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("fae0fcb0-f6df-4ece-ad3c-f5b7494e5f51"),
                    SecondDepartmentId = Guid.Parse("3489baa7-b17e-4003-a78f-cb156dee058e"),
                    Id = Guid.Parse("69b9774d-5869-48ab-a3cf-46468ba8f26e")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("661ba9ad-e1e9-413c-bdfe-66401edd5596"),
                    SecondDepartmentId = Guid.Parse("1ef7fde0-47b6-4fda-810c-44c33d1fbee8"),
                    Id = Guid.Parse("dd2c3bc3-ff96-4c8d-9dd7-21fb8bcf84a8")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("661ba9ad-e1e9-413c-bdfe-66401edd5596"),
                    SecondDepartmentId = Guid.Parse("85ef4758-c7a8-4cbc-9416-caaea32e4d05"),
                    Id = Guid.Parse("08a1eb75-7d45-47f0-83eb-784503e436f3")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("661ba9ad-e1e9-413c-bdfe-66401edd5596"),
                    SecondDepartmentId = Guid.Parse("8ce39bf5-92de-48db-bb8b-30892a4a090f"),
                    Id = Guid.Parse("13167d18-0093-4b37-950f-10e35f11d892")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("661ba9ad-e1e9-413c-bdfe-66401edd5596"),
                    SecondDepartmentId = Guid.Parse("97a9f4b4-e8d4-4c1a-b6e7-e05426969f58"),
                    Id = Guid.Parse("18f771b9-93cc-46fb-aa5a-79d37be8b349")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("97a9f4b4-e8d4-4c1a-b6e7-e05426969f58"),
                    SecondDepartmentId = Guid.Parse("1ef7fde0-47b6-4fda-810c-44c33d1fbee8"),
                    Id = Guid.Parse("1d5e45b8-6390-416a-b24a-2725089c624d")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("97a9f4b4-e8d4-4c1a-b6e7-e05426969f58"),
                    SecondDepartmentId = Guid.Parse("661ba9ad-e1e9-413c-bdfe-66401edd5596"),
                    Id = Guid.Parse("2ac88622-117b-4048-b2ae-574b00cabac0")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("961e1f7f-fc6f-440e-b11a-426bd93c32f0"),
                    SecondDepartmentId = Guid.Parse("a484a81b-fcf0-42ea-82c2-ef353da33667"),
                    Id = Guid.Parse("ae4a5d51-1ee4-4a00-b8f3-e46a4b509702")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("961e1f7f-fc6f-440e-b11a-426bd93c32f0"),
                    SecondDepartmentId = Guid.Parse("7c7b530a-ff06-4ee3-bcfd-8a79bf094a9b"),
                    Id = Guid.Parse("064ab579-119b-45e9-a1f0-70fb3e35821f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("961e1f7f-fc6f-440e-b11a-426bd93c32f0"),
                    SecondDepartmentId = Guid.Parse("b10b8258-66e2-421a-bad5-cc76e1a3bb77"),
                    Id = Guid.Parse("287edf49-563f-4957-8a6c-a936406dd819")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("b96c0bc3-abbb-49cc-a672-5ec6af45ca63"),
                    SecondDepartmentId = Guid.Parse("a2ba1fd9-47c5-4938-b8b3-ab01bc245859"),
                    Id = Guid.Parse("8413afa8-0686-431d-972c-c4033a58b6c4")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("b96c0bc3-abbb-49cc-a672-5ec6af45ca63"),
                    SecondDepartmentId = Guid.Parse("78476d14-2f28-4e95-874e-09f1d4fd0171"),
                    Id = Guid.Parse("372fb118-77db-4f2b-9713-4012efdec3b9")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("b96c0bc3-abbb-49cc-a672-5ec6af45ca63"),
                    SecondDepartmentId = Guid.Parse("343e77cb-a854-416b-aeac-86c9ffad82ce"),
                    Id = Guid.Parse("de662deb-75e0-4a9f-bf27-d518d566a71d")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"),
                    SecondDepartmentId = Guid.Parse("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee"),
                    Id = Guid.Parse("054851ea-9db7-4c01-a6dd-69b2918dd48e")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"),
                    SecondDepartmentId = Guid.Parse("30ba0a20-3568-4484-9df1-151de6fd36c2"),
                    Id = Guid.Parse("4b9a878e-aa00-4130-9820-8f51741f8094")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"),
                    SecondDepartmentId = Guid.Parse("1c05a510-8e08-4e61-94f1-d5b9661a2b08"),
                    Id = Guid.Parse("0e78dcac-a566-4e1e-b794-8bdbf641f9b6")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"),
                    SecondDepartmentId = Guid.Parse("9498c4a1-398d-4c06-8b49-aa84290cf2ca"),
                    Id = Guid.Parse("7b307636-80bc-4bd3-b927-8693e161b8fe")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"),
                    SecondDepartmentId = Guid.Parse("78476d14-2f28-4e95-874e-09f1d4fd0171"),
                    Id = Guid.Parse("e0fb8a07-04f0-4a80-a62e-51b5bac445ee")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"),
                    SecondDepartmentId = Guid.Parse("667fec95-c40d-4289-b5d9-4760525509f3"),
                    Id = Guid.Parse("3389a8cb-83eb-4da6-9108-ac10e747337f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"),
                    SecondDepartmentId = Guid.Parse("b508db1d-d8dc-4998-bbce-b110e00ac954"),
                    Id = Guid.Parse("747e0743-f48a-4f30-a452-ca90930a49d1")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"),
                    SecondDepartmentId = Guid.Parse("24e44487-3f98-42b9-9b44-818e5d8d7bbd"),
                    Id = Guid.Parse("684c100e-fbd0-484a-a077-49feafe48521")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("55b6f5bd-de1f-435f-a30d-e212e2684eb6"),
                    SecondDepartmentId = Guid.Parse("a2ba1fd9-47c5-4938-b8b3-ab01bc245859"),
                    Id = Guid.Parse("45248194-8c88-42fd-b298-9186148c25c9")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("55b6f5bd-de1f-435f-a30d-e212e2684eb6"),
                    SecondDepartmentId = Guid.Parse("c8851fc2-7704-412d-b272-130cbed5f422"),
                    Id = Guid.Parse("8982e7af-a014-4328-9dcb-7b7572399abd")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("55b6f5bd-de1f-435f-a30d-e212e2684eb6"),
                    SecondDepartmentId = Guid.Parse("b508db1d-d8dc-4998-bbce-b110e00ac954"),
                    Id = Guid.Parse("e8b6928d-1479-49c7-a346-eb6f51df48bc")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("55b6f5bd-de1f-435f-a30d-e212e2684eb6"),
                    SecondDepartmentId = Guid.Parse("a484a81b-fcf0-42ea-82c2-ef353da33667"),
                    Id = Guid.Parse("d86760f9-2c6a-4681-b62f-65de2bd3c6c3")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("55b6f5bd-de1f-435f-a30d-e212e2684eb6"),
                    SecondDepartmentId = Guid.Parse("24e44487-3f98-42b9-9b44-818e5d8d7bbd"),
                    Id = Guid.Parse("6bca2eea-7f60-44a1-bd09-281f39566f47")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("479db9d5-9d65-473c-94c9-c84bfe8a9efc"),
                    SecondDepartmentId = Guid.Parse("cbfb8d4a-5fad-4c9e-8faa-d035cd093928"),
                    Id = Guid.Parse("613cc6bd-0891-4898-b6e8-2e8b91d0db3f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("479db9d5-9d65-473c-94c9-c84bfe8a9efc"),
                    SecondDepartmentId = Guid.Parse("8963790c-6864-429c-bd8b-35338c53a170"),
                    Id = Guid.Parse("6cb3cee5-74d5-494c-8405-7465ff5d33d5")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("479db9d5-9d65-473c-94c9-c84bfe8a9efc"),
                    SecondDepartmentId = Guid.Parse("5f5ba403-ae25-440b-9f38-809881781211"),
                    Id = Guid.Parse("8acdf24e-acc7-432e-b0a4-7fde70ce3f24")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("479db9d5-9d65-473c-94c9-c84bfe8a9efc"),
                    SecondDepartmentId = Guid.Parse("f8c9d891-e9c5-43a1-8bfb-62f2cf51ab79"),
                    Id = Guid.Parse("6139bfa4-0da7-41db-b279-a160ff950f50")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("479db9d5-9d65-473c-94c9-c84bfe8a9efc"),
                    SecondDepartmentId = Guid.Parse("394ed11a-fe64-4163-b9da-eed89db9d732"),
                    Id = Guid.Parse("c694885c-43c0-4ce5-a2c7-b978d5f6e2fe")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("343e77cb-a854-416b-aeac-86c9ffad82ce"),
                    SecondDepartmentId = Guid.Parse("dcd2fb59-088a-4eeb-a24a-f3e8cce22aee"),
                    Id = Guid.Parse("ab0eb70d-4da6-4ec3-a03a-85a3652daceb")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("343e77cb-a854-416b-aeac-86c9ffad82ce"),
                    SecondDepartmentId = Guid.Parse("9e8fd57a-abe9-4cd6-958c-53ec0ba6be80"),
                    Id = Guid.Parse("9d019691-495d-4916-9d66-92cdbc25ae89")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("343e77cb-a854-416b-aeac-86c9ffad82ce"),
                    SecondDepartmentId = Guid.Parse("78476d14-2f28-4e95-874e-09f1d4fd0171"),
                    Id = Guid.Parse("c7d4d8d6-477f-4c7e-9a09-d161a89b7822")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("343e77cb-a854-416b-aeac-86c9ffad82ce"),
                    SecondDepartmentId = Guid.Parse("7591742b-97d3-4b0a-81a6-20a4247d47ca"),
                    Id = Guid.Parse("b4e291f7-a623-4327-893f-c8d0a269d890")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("343e77cb-a854-416b-aeac-86c9ffad82ce"),
                    SecondDepartmentId = Guid.Parse("b96c0bc3-abbb-49cc-a672-5ec6af45ca63"),
                    Id = Guid.Parse("ee40ea3b-70d4-4738-b432-c728c6bd31d0")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("7285b039-3ac9-4a21-9dcd-9fc96164e600"),
                    SecondDepartmentId = Guid.Parse("aec85880-4ac9-43c9-be3f-a47a41d0e88e"),
                    Id = Guid.Parse("71e68d7a-c454-4f64-a0db-61ee196e54f4")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("7285b039-3ac9-4a21-9dcd-9fc96164e600"),
                    SecondDepartmentId = Guid.Parse("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd"),
                    Id = Guid.Parse("72dced46-584f-4a40-ba78-e87572a36cb8")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("7285b039-3ac9-4a21-9dcd-9fc96164e600"),
                    SecondDepartmentId = Guid.Parse("d56fc07c-39f9-42c6-aaf5-640b2b5f6124"),
                    Id = Guid.Parse("58c8cd03-09fe-4b8b-aad6-95f1be471bf6")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("7285b039-3ac9-4a21-9dcd-9fc96164e600"),
                    SecondDepartmentId = Guid.Parse("1632f86b-846f-4a69-b4a2-e5f6dd7d4742"),
                    Id = Guid.Parse("7c9d87d7-a35f-4d36-95ad-44e2fea7be49")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("7285b039-3ac9-4a21-9dcd-9fc96164e600"),
                    SecondDepartmentId = Guid.Parse("2d75fb26-8926-4607-b618-1d727cd31fe8"),
                    Id = Guid.Parse("5242a269-7792-41e0-862f-2016144bf934")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("2d75fb26-8926-4607-b618-1d727cd31fe8"),
                    SecondDepartmentId = Guid.Parse("32847c59-04b7-4a4c-aa67-faaf7d5ff8bd"),
                    Id = Guid.Parse("a9f52ba5-d74a-41b8-9f7a-fe94c735cdbf")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("2d75fb26-8926-4607-b618-1d727cd31fe8"),
                    SecondDepartmentId = Guid.Parse("d56fc07c-39f9-42c6-aaf5-640b2b5f6124"),
                    Id = Guid.Parse("cd6c146b-5340-43ee-8439-b02abc5bd11f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("2d75fb26-8926-4607-b618-1d727cd31fe8"),
                    SecondDepartmentId = Guid.Parse("e007dcb1-8678-47ab-90dd-441f76873b9e"),
                    Id = Guid.Parse("395f153a-e534-4a03-badb-1ec5d53c2bbf")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("2d75fb26-8926-4607-b618-1d727cd31fe8"),
                    SecondDepartmentId = Guid.Parse("d7ad4ed3-ad4d-4f16-aa6b-cb1838aade1b"),
                    Id = Guid.Parse("be24a341-618b-4e03-8a16-6c7c62496827")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("2d75fb26-8926-4607-b618-1d727cd31fe8"),
                    SecondDepartmentId = Guid.Parse("cbf1b899-4d3d-4155-bae7-07915a6b8c09"),
                    Id = Guid.Parse("2ad409de-7036-4771-b2bc-63e345fb4a5c")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("2d75fb26-8926-4607-b618-1d727cd31fe8"),
                    SecondDepartmentId = Guid.Parse("7285b039-3ac9-4a21-9dcd-9fc96164e600"),
                    Id = Guid.Parse("5c6b1813-d575-4b85-a70f-2d740e5b5fe7")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("7fdeabb6-fdd2-49ff-ad5d-b35f56f9db5b"),
                    SecondDepartmentId = Guid.Parse("1bf0a210-c750-4e98-9151-7eaefa8185c7"),
                    Id = Guid.Parse("2bbdf023-321b-430f-862c-43797460ae6c")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("7fdeabb6-fdd2-49ff-ad5d-b35f56f9db5b"),
                    SecondDepartmentId = Guid.Parse("6b787904-7e30-450b-aac4-2867a6f72100"),
                    Id = Guid.Parse("25351a4f-8ee2-4e88-9295-062d5e2689dd")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("7fdeabb6-fdd2-49ff-ad5d-b35f56f9db5b"),
                    SecondDepartmentId = Guid.Parse("95f28447-33e7-449f-8bd7-ecdabaae501f"),
                    Id = Guid.Parse("c4279d96-75fb-442a-8873-40bfad5e318b")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("7fdeabb6-fdd2-49ff-ad5d-b35f56f9db5b"),
                    SecondDepartmentId = Guid.Parse("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1"),
                    Id = Guid.Parse("71aee0c1-97dd-4286-90d8-6ff43cccc917")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1"),
                    SecondDepartmentId = Guid.Parse("1bf0a210-c750-4e98-9151-7eaefa8185c7"),
                    Id = Guid.Parse("6f8dd392-e0ca-4df9-9e07-ff8c6de40d59")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1"),
                    SecondDepartmentId = Guid.Parse("c1aed70b-666e-4f32-bee2-f52722d89b1f"),
                    Id = Guid.Parse("087895e8-b656-4627-96a1-4ac853c86808")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1"),
                    SecondDepartmentId = Guid.Parse("95f28447-33e7-449f-8bd7-ecdabaae501f"),
                    Id = Guid.Parse("dafa8e73-8551-4692-9cd4-7d6d914d18a0")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1"),
                    SecondDepartmentId = Guid.Parse("6a16c6c6-4b11-4651-b291-739fd143cb19"),
                    Id = Guid.Parse("34f412bb-8e22-4500-9c77-af784c94868b")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("5b6220ab-2bdf-4b20-aa2a-4c06c840c0c1"),
                    SecondDepartmentId = Guid.Parse("11d695a1-9893-4f18-a2ab-f61078233585"),
                    Id = Guid.Parse("2426e1cd-e8a9-48ff-aa07-675829d2a485")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("f8c9d891-e9c5-43a1-8bfb-62f2cf51ab79"),
                    SecondDepartmentId = Guid.Parse("8963790c-6864-429c-bd8b-35338c53a170"),
                    Id = Guid.Parse("37dec65c-b521-4151-9a5b-91c90a21dae6")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("f8c9d891-e9c5-43a1-8bfb-62f2cf51ab79"),
                    SecondDepartmentId = Guid.Parse("73d7b3b6-1018-4b19-a57b-d189d75c7c81"),
                    Id = Guid.Parse("a5b25cd3-f9a1-4d5f-83b8-19426199ac09")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("f8c9d891-e9c5-43a1-8bfb-62f2cf51ab79"),
                    SecondDepartmentId = Guid.Parse("5f5ba403-ae25-440b-9f38-809881781211"),
                    Id = Guid.Parse("f9bd3243-9e12-4b39-b878-58d4ca00170f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("f8c9d891-e9c5-43a1-8bfb-62f2cf51ab79"),
                    SecondDepartmentId = Guid.Parse("479db9d5-9d65-473c-94c9-c84bfe8a9efc"),
                    Id = Guid.Parse("5cf3fb55-3005-44c4-9f3a-9a417d77f45d")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("394ed11a-fe64-4163-b9da-eed89db9d732"),
                    SecondDepartmentId = Guid.Parse("cbfb8d4a-5fad-4c9e-8faa-d035cd093928"),
                    Id = Guid.Parse("50ed74d7-8bd7-4943-a535-a836ad339d76")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("394ed11a-fe64-4163-b9da-eed89db9d732"),
                    SecondDepartmentId = Guid.Parse("e4a24c69-a970-4e7e-89b7-ca77e3fc1c3e"),
                    Id = Guid.Parse("c89dd020-1376-44dd-b8a7-6833e5dc6fe8")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("394ed11a-fe64-4163-b9da-eed89db9d732"),
                    SecondDepartmentId = Guid.Parse("fbcf13f8-24f2-4f89-a9c0-bcada6f4ba62"),
                    Id = Guid.Parse("a569cffb-8746-4c7d-ac22-cbe982e0b720")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("394ed11a-fe64-4163-b9da-eed89db9d732"),
                    SecondDepartmentId = Guid.Parse("5f5ba403-ae25-440b-9f38-809881781211"),
                    Id = Guid.Parse("fa8ff58e-0f57-4afa-bfdf-b0a082519b90")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("394ed11a-fe64-4163-b9da-eed89db9d732"),
                    SecondDepartmentId = Guid.Parse("479db9d5-9d65-473c-94c9-c84bfe8a9efc"),
                    Id = Guid.Parse("c418cbec-a129-45c9-b969-c7a1c518484f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("394ed11a-fe64-4163-b9da-eed89db9d732"),
                    SecondDepartmentId = Guid.Parse("6af0ad8b-b789-4e9c-a191-e39711617d83"),
                    Id = Guid.Parse("5884dc07-0f6a-4214-ad4c-1610e157b6c5")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("6af0ad8b-b789-4e9c-a191-e39711617d83"),
                    SecondDepartmentId = Guid.Parse("cbfb8d4a-5fad-4c9e-8faa-d035cd093928"),
                    Id = Guid.Parse("23315763-2c12-4026-8ec1-d764226d1985")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("6af0ad8b-b789-4e9c-a191-e39711617d83"),
                    SecondDepartmentId = Guid.Parse("c1bd362f-88bd-4e6a-8928-ad6d29ee549a"),
                    Id = Guid.Parse("3cb381ed-d98a-4227-a015-bf859219fe7b")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("6af0ad8b-b789-4e9c-a191-e39711617d83"),
                    SecondDepartmentId = Guid.Parse("28cce0f5-1692-4db3-af74-e4efc3aef1e6"),
                    Id = Guid.Parse("f54891ad-fcf7-4e7a-9f1a-25c116dc6248")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("6af0ad8b-b789-4e9c-a191-e39711617d83"),
                    SecondDepartmentId = Guid.Parse("44cc60d3-d233-4bf1-92c1-539961e5be6b"),
                    Id = Guid.Parse("c3520e64-ef8d-4014-ba8d-3d7812ebe5af")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("6af0ad8b-b789-4e9c-a191-e39711617d83"),
                    SecondDepartmentId = Guid.Parse("394ed11a-fe64-4163-b9da-eed89db9d732"),
                    Id = Guid.Parse("eb2366df-92af-4a5e-a979-eb9046ee965d")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("ff2b1187-63bf-46fa-a70c-4db6b323babb"),
                    SecondDepartmentId = Guid.Parse("3577171f-2b34-4d53-9aff-17885e7d4679"),
                    Id = Guid.Parse("1fa0749c-03c3-44a5-a680-a530080a5d41")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("ff2b1187-63bf-46fa-a70c-4db6b323babb"),
                    SecondDepartmentId = Guid.Parse("a435415d-d1f2-4af1-8de9-93af2ce43747"),
                    Id = Guid.Parse("ff0f64ea-a649-4af0-bf36-aedd3414a87e")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("ff2b1187-63bf-46fa-a70c-4db6b323babb"),
                    SecondDepartmentId = Guid.Parse("310e87ad-0b29-470e-9120-b025a3a46c9f"),
                    Id = Guid.Parse("949ac9f0-bfd4-45c7-bf70-707eb32d66ca")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("ff2b1187-63bf-46fa-a70c-4db6b323babb"),
                    SecondDepartmentId = Guid.Parse("6b921a7d-143a-4014-b113-862ded825b60"),
                    Id = Guid.Parse("ebe159e7-3b03-478c-b2f7-ddcdf20e0abd")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("ff2b1187-63bf-46fa-a70c-4db6b323babb"),
                    SecondDepartmentId = Guid.Parse("5614ee02-1939-4ab9-94a7-c64070908c65"),
                    Id = Guid.Parse("d9969192-c237-4b98-ba37-83d9897556ef")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("ff2b1187-63bf-46fa-a70c-4db6b323babb"),
                    SecondDepartmentId = Guid.Parse("d7c383af-e3b6-468c-a4cb-e20f08856972"),
                    Id = Guid.Parse("9a8da0fa-f5b4-4437-8afe-80ce40928e3e")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("ff2b1187-63bf-46fa-a70c-4db6b323babb"),
                    SecondDepartmentId = Guid.Parse("52ee48da-49f3-4701-93de-f113946380c9"),
                    Id = Guid.Parse("fe2a50cf-ce8c-4c4f-b62b-9fad861a97e1")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("ff2b1187-63bf-46fa-a70c-4db6b323babb"),
                    SecondDepartmentId = Guid.Parse("0bbca13e-e227-4aaa-a078-265c9133f278"),
                    Id = Guid.Parse("165c3cdf-ba83-4042-b523-ed60d7b7c7c5")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("667fec95-c40d-4289-b5d9-4760525509f3"),
                    SecondDepartmentId = Guid.Parse("30ba0a20-3568-4484-9df1-151de6fd36c2"),
                    Id = Guid.Parse("6a26b526-77c1-40ef-a2c7-4d730e7d1188")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("667fec95-c40d-4289-b5d9-4760525509f3"),
                    SecondDepartmentId = Guid.Parse("dbde4b03-bd9c-4b18-81c3-9b24e0558003"),
                    Id = Guid.Parse("b25e4814-e9c8-436e-8630-238f2b0b95ef")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("667fec95-c40d-4289-b5d9-4760525509f3"),
                    SecondDepartmentId = Guid.Parse("1c05a510-8e08-4e61-94f1-d5b9661a2b08"),
                    Id = Guid.Parse("e8396360-678b-4a2e-810a-3ba3d3fc3f32")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("667fec95-c40d-4289-b5d9-4760525509f3"),
                    SecondDepartmentId = Guid.Parse("52f1f21c-bea3-498b-bafa-26846d550230"),
                    Id = Guid.Parse("519ec8d3-b565-4795-8110-1504a87b9e44")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("667fec95-c40d-4289-b5d9-4760525509f3"),
                    SecondDepartmentId = Guid.Parse("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"),
                    Id = Guid.Parse("8ef22aab-e7db-46b9-9643-c1424186323b")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("0bbca13e-e227-4aaa-a078-265c9133f278"),
                    SecondDepartmentId = Guid.Parse("2acb1828-07a0-45fd-b52e-15b7eb6e02ce"),
                    Id = Guid.Parse("5eeb35b3-e419-445d-95fb-82ea173e23fd")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("0bbca13e-e227-4aaa-a078-265c9133f278"),
                    SecondDepartmentId = Guid.Parse("d7c383af-e3b6-468c-a4cb-e20f08856972"),
                    Id = Guid.Parse("c2b35904-4f17-4b93-9f4d-4f6f23856a22")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("0bbca13e-e227-4aaa-a078-265c9133f278"),
                    SecondDepartmentId = Guid.Parse("52ee48da-49f3-4701-93de-f113946380c9"),
                    Id = Guid.Parse("9bd09708-fe3f-4252-97fc-7fafcb820782")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("0bbca13e-e227-4aaa-a078-265c9133f278"),
                    SecondDepartmentId = Guid.Parse("ff2b1187-63bf-46fa-a70c-4db6b323babb"),
                    Id = Guid.Parse("c4925045-7235-46c1-9408-23268ac2d7ba")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("b508db1d-d8dc-4998-bbce-b110e00ac954"),
                    SecondDepartmentId = Guid.Parse("c8851fc2-7704-412d-b272-130cbed5f422"),
                    Id = Guid.Parse("9cd868e9-1164-428b-b6f9-499a7a6ec46e")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("b508db1d-d8dc-4998-bbce-b110e00ac954"),
                    SecondDepartmentId = Guid.Parse("1c05a510-8e08-4e61-94f1-d5b9661a2b08"),
                    Id = Guid.Parse("6e422965-aced-42b9-b9cd-2665d32e8149")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("b508db1d-d8dc-4998-bbce-b110e00ac954"),
                    SecondDepartmentId = Guid.Parse("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"),
                    Id = Guid.Parse("35490311-fe1e-4ec4-89b5-0c8a54cf2f62")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("b508db1d-d8dc-4998-bbce-b110e00ac954"),
                    SecondDepartmentId = Guid.Parse("55b6f5bd-de1f-435f-a30d-e212e2684eb6"),
                    Id = Guid.Parse("9d25b3a3-23b4-4b39-8693-b7200c0a3b8f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("b508db1d-d8dc-4998-bbce-b110e00ac954"),
                    SecondDepartmentId = Guid.Parse("a484a81b-fcf0-42ea-82c2-ef353da33667"),
                    Id = Guid.Parse("b9bfeb92-43ab-4ad2-8a91-9234f0e39a9c")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("b508db1d-d8dc-4998-bbce-b110e00ac954"),
                    SecondDepartmentId = Guid.Parse("b10b8258-66e2-421a-bad5-cc76e1a3bb77"),
                    Id = Guid.Parse("4c1078a9-eea0-4ec1-87f4-1ddf3387eaa7")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("a484a81b-fcf0-42ea-82c2-ef353da33667"),
                    SecondDepartmentId = Guid.Parse("961e1f7f-fc6f-440e-b11a-426bd93c32f0"),
                    Id = Guid.Parse("a26f885b-c6a6-48cd-870e-0e937eb62022")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("a484a81b-fcf0-42ea-82c2-ef353da33667"),
                    SecondDepartmentId = Guid.Parse("55b6f5bd-de1f-435f-a30d-e212e2684eb6"),
                    Id = Guid.Parse("fee2d664-f1b7-4bb5-9cbf-ec4f3b3e68ea")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("a484a81b-fcf0-42ea-82c2-ef353da33667"),
                    SecondDepartmentId = Guid.Parse("7c7b530a-ff06-4ee3-bcfd-8a79bf094a9b"),
                    Id = Guid.Parse("9dafd18a-889a-42f7-aebb-446d29c40593")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("a484a81b-fcf0-42ea-82c2-ef353da33667"),
                    SecondDepartmentId = Guid.Parse("24e44487-3f98-42b9-9b44-818e5d8d7bbd"),
                    Id = Guid.Parse("cce89109-d0ca-4045-b7e7-301cbca7bed7")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("7c7b530a-ff06-4ee3-bcfd-8a79bf094a9b"),
                    SecondDepartmentId = Guid.Parse("a484a81b-fcf0-42ea-82c2-ef353da33667"),
                    Id = Guid.Parse("a535fb4c-2a81-49dd-8052-c13c7bc7a131")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("7c7b530a-ff06-4ee3-bcfd-8a79bf094a9b"),
                    SecondDepartmentId = Guid.Parse("b10b8258-66e2-421a-bad5-cc76e1a3bb77"),
                    Id = Guid.Parse("9f73e772-8239-4ee6-887b-e7163e348737")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("7c7b530a-ff06-4ee3-bcfd-8a79bf094a9b"),
                    SecondDepartmentId = Guid.Parse("24e44487-3f98-42b9-9b44-818e5d8d7bbd"),
                    Id = Guid.Parse("91758849-e48e-4ba7-ba3f-1aefd4d87bfb")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("b10b8258-66e2-421a-bad5-cc76e1a3bb77"),
                    SecondDepartmentId = Guid.Parse("961e1f7f-fc6f-440e-b11a-426bd93c32f0"),
                    Id = Guid.Parse("79deab25-433c-4724-9677-5b65a4784119")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("b10b8258-66e2-421a-bad5-cc76e1a3bb77"),
                    SecondDepartmentId = Guid.Parse("11e3ebec-bf5b-4f1b-8488-aa509b066f2e"),
                    Id = Guid.Parse("4981049a-a08d-4bbe-853d-4378267343e4")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("b10b8258-66e2-421a-bad5-cc76e1a3bb77"),
                    SecondDepartmentId = Guid.Parse("b508db1d-d8dc-4998-bbce-b110e00ac954"),
                    Id = Guid.Parse("ab2e8e9e-f24a-43d1-b19a-960963dd4c05")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("b10b8258-66e2-421a-bad5-cc76e1a3bb77"),
                    SecondDepartmentId = Guid.Parse("a484a81b-fcf0-42ea-82c2-ef353da33667"),
                    Id = Guid.Parse("de2a1eae-8797-4eae-938f-db5735394d50")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("b10b8258-66e2-421a-bad5-cc76e1a3bb77"),
                    SecondDepartmentId = Guid.Parse("7c7b530a-ff06-4ee3-bcfd-8a79bf094a9b"),
                    Id = Guid.Parse("20b1e983-c7c1-4b7f-8a51-9e8ba2d48b81")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("24e44487-3f98-42b9-9b44-818e5d8d7bbd"),
                    SecondDepartmentId = Guid.Parse("a2ba1fd9-47c5-4938-b8b3-ab01bc245859"),
                    Id = Guid.Parse("420e7c7a-2027-412b-83bb-f926c36bd14f")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("24e44487-3f98-42b9-9b44-818e5d8d7bbd"),
                    SecondDepartmentId = Guid.Parse("78476d14-2f28-4e95-874e-09f1d4fd0171"),
                    Id = Guid.Parse("1feb5caf-7282-48e3-aa52-ca774df049dc")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("24e44487-3f98-42b9-9b44-818e5d8d7bbd"),
                    SecondDepartmentId = Guid.Parse("55b6f5bd-de1f-435f-a30d-e212e2684eb6"),
                    Id = Guid.Parse("0b1ef2f5-cc6f-4759-b4e7-5448c0408542")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("24e44487-3f98-42b9-9b44-818e5d8d7bbd"),
                    SecondDepartmentId = Guid.Parse("a484a81b-fcf0-42ea-82c2-ef353da33667"),
                    Id = Guid.Parse("6fc9081c-5971-4503-aca0-d04b5555526b")
                },
                new AdjacentDepartments()
                {
                    FirstDepartmentId = Guid.Parse("24e44487-3f98-42b9-9b44-818e5d8d7bbd"),
                    SecondDepartmentId = Guid.Parse("7c7b530a-ff06-4ee3-bcfd-8a79bf094a9b"),
                    Id = Guid.Parse("329846a0-2eef-48ef-a449-a6ee7f4865cc")
                });
        }
    }
}