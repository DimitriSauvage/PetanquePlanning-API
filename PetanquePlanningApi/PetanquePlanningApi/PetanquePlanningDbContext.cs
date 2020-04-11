using Microsoft.EntityFrameworkCore;
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

            #region I18n
            #endregion

            #region Core
            #endregion
        }
    }
}
