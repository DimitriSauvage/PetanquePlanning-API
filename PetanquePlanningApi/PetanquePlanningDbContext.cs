using System;
using System.Linq;
using System.Reflection;
using DimitriSauvageTools.Infrastructure.EntityFramework.Abstractions;
using DimitriSauvageTools.Infrastructure.EntityFramework.Helpers;
using Microsoft.EntityFrameworkCore;
using PetanquePlanning.Business.Identity.Domain.Entities;

namespace PetanquePlanningApi
{
    public class PetanquePlanningDbContext : AppIdentityDbContext<ApplicationUser, ApplicationRole, Guid,
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