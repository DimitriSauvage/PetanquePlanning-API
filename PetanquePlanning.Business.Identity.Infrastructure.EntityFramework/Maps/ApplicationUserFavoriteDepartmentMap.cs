using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetanquePlanning.Business.Identity.Domain.Entities;
using Tools.Infrastructure.EntityFramework.Abstractions;

namespace PetanquePlanning.Business.Identity.Infrastructure.EntityFramework.Maps
{
    public class ApplicationUserFavoriteDepartmentMap : EntityWithIdMap<ApplicationUserFavoriteDepartment>
    {
        public override void Configure(EntityTypeBuilder<ApplicationUserFavoriteDepartment> builder)
        {
            base.Configure(builder);

            //User
            builder
                .HasOne(x => x.User)
                .WithMany(x => x.FavoriteDepartments)
                .HasForeignKey(x => x.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ApplicationUserFavoriteDepartment_ApplicationUser");

            //Department
            builder
                .HasOne(x => x.Department)
                .WithMany()
                .HasForeignKey(x => x.DepartmentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ApplicationUserFavoriteDepartment_Depatment");

            //Index
            builder
                .HasIndex(x => new {x.DepartmentId, x.UserId})
                .IsUnique()
                .HasName("UK_PrimaryKey");
        }
    }
}