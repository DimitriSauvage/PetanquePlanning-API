using Microsoft.EntityFrameworkCore;
using PetanquePlanning.Business.Identity.Domain.Entities;
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
    }
}