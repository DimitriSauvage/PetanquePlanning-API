using Microsoft.EntityFrameworkCore;
using PetanquePlanning.Business.Core.Infrastructure.EntityFramework.Maps;
using PetanquePlanning.Business.Identity.Domain.Entities;
using PetanquePlanning.Business.Identity.Infrastructure.EntityFramework.Maps;
using PetanquePlanning.Business.Location.Infrastructure.EntityFramework.Maps;
using Tools.Infrastructure.EntityFramework.Abstractions;

namespace PetanquePlanningApi
{
    public class PetanquePlanningDbContext : AppIdentityDbContext<ApplicationUser, ApplicationRole, long,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public PetanquePlanningDbContext()
        {
        }

        public PetanquePlanningDbContext(DbContextOptions options) : base(options)
        {
        }

        #region Overrides of AppIdentityDbContext<ApplicationUser,ApplicationRole,long,ApplicationUserClaim,ApplicationUserRole,ApplicationUserLogin,ApplicationRoleClaim,ApplicationUserToken>

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Core

            modelBuilder.ApplyConfiguration(new ClubMap());
            modelBuilder.ApplyConfiguration(new CompetitionMap());

            #endregion

            #region Identity

            modelBuilder.ApplyConfiguration(new ApplicationRoleClaimMap());
            modelBuilder.ApplyConfiguration(new ApplicationRoleMap());
            modelBuilder.ApplyConfiguration(new ApplicationUserClaimMap());
            modelBuilder.ApplyConfiguration(new ApplicationUserLoginMap());
            modelBuilder.ApplyConfiguration(new ApplicationUserMap());
            modelBuilder.ApplyConfiguration(new ApplicationUserRoleMap());
            modelBuilder.ApplyConfiguration(new ApplicationUserTokenMap());
            modelBuilder.ApplyConfiguration(new ApplicationUserFavoriteDepartmentMap());

            #endregion

            #region Location

            modelBuilder.ApplyConfiguration(new DepartmentMap());
            modelBuilder.ApplyConfiguration(new RegionMap());
            modelBuilder.ApplyConfiguration(new AdjacentDepartmentMap());

            #endregion
        }

        #endregion
    }
}