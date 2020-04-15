using Microsoft.EntityFrameworkCore;
using PetanquePlanning.Business.Location.Infrastructure.EntityFramework.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PetanquePlanning.Business.Core.Infrastructure.EntityFramework.Maps;
using PetanquePlanning.Business.Identity.Domain.Entities;
using PetanquePlanning.Business.Identity.Infrastructure.EntityFramework.Maps;
using PetanquePlanning.Business.Identity.Infrastructure.EntityFramework.Maps;
using PetanquePlanning.Business.Identity.Infrastructure.EntityFramework.Maps;

namespace PetanquePlanningApi
{
    public class PetanquePlanningDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public PetanquePlanningDbContext() : base()
        {
        }

        public PetanquePlanningDbContext(DbContextOptions<PetanquePlanningDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Identity

            modelBuilder.ApplyConfiguration(new ApplicationRoleClaimMap());
            modelBuilder.ApplyConfiguration(new ApplicationRoleMap());
            modelBuilder.ApplyConfiguration(new ApplicationUserClaimMap());
            modelBuilder.ApplyConfiguration(new ApplicationUserLoginMap());
            modelBuilder.ApplyConfiguration(new ApplicationUserMap());
            modelBuilder.ApplyConfiguration(new ApplicationUserRoleMap());
            modelBuilder.ApplyConfiguration(new ApplicationUserTokenMap());

            #endregion

            #region Location

            modelBuilder.ApplyConfiguration(new DepartmentMap());
            modelBuilder.ApplyConfiguration(new RegionMap());

            #endregion

            #region Core

            modelBuilder.ApplyConfiguration(new ClubMap());
            modelBuilder.ApplyConfiguration(new CompetitionMap());

            #endregion
        }
    }
}