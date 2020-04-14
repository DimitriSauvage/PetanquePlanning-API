using Microsoft.EntityFrameworkCore;
using PetanquePlanning.Business.Location.Infrastructure.EntityFramework.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PetanquePlanning.Business.Core.Infrastructure.EntityFramework.Maps;
using PetanquePlanning.Business.Identity.Domain.Entities;

namespace PetanquePlanningApi
{
    public class PetanquePlanningDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public PetanquePlanningDbContext() : base() { }
        public PetanquePlanningDbContext(DbContextOptions<PetanquePlanningDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Identity
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
