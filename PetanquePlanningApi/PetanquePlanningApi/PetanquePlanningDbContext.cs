using Microsoft.EntityFrameworkCore;
using PetanquePlanning.Business.Location.Infrastructure.EntityFramework.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetanquePlanningApi
{
    public class PetanquePlanningDbContext : DbContext
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
            #endregion
        }
    }
}
