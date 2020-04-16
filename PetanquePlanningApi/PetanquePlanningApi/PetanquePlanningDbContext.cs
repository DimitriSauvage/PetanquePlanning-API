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
using Tools.Infrastructure.EntityFramework.Abstractions;

namespace PetanquePlanningApi
{
    public class PetanquePlanningDbContext : AppIdentityDbContext<ApplicationUser, ApplicationRole, long,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public PetanquePlanningDbContext()
        {
        }

        public PetanquePlanningDbContext(DbContextOptions<PetanquePlanningDbContext> options) : base(options)
        {
        }

    }
}