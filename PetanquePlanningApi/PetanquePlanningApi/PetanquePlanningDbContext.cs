using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PetanquePlanning.Business.Core.Infrastructure.EntityFramework.Maps;
using PetanquePlanning.Business.Identity.Domain.Entities;
using PetanquePlanning.Business.Identity.Infrastructure.EntityFramework.Maps;
using PetanquePlanning.Business.Location.Infrastructure.EntityFramework.Maps;
using Tools.Infrastructure.EntityFramework.Abstractions;
using Tools.Infrastructure.EntityFramework.Helpers;

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

            //Apply all maps
            MapHelper.ApplyMapsConfiguration(
                Assembly.GetExecutingAssembly()
                    .GetReferencedAssemblies()
                    .Select(Assembly.Load)
                    .ToList(),
                modelBuilder);

        }

        #endregion
    }
}