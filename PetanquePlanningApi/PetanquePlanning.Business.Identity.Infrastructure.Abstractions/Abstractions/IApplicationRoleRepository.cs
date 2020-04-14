﻿using System.Collections.Generic;
using System.Threading.Tasks;
using PetanquePlanning.Business.Identity.Domain.Entities;
using Tools.Infrastructure.Abstraction;

namespace PetanquePlanning.Business.Identity.Infrastructure.Abstractions.Abstractions
{
    public interface IApplicationRoleRepository : IRepository<ApplicationRole>
    {
        /// <summary>
        /// Get a role by his name
        /// </summary>
        /// <param name="role">Role name</param>
        /// <returns>Role</returns>
        Task<ApplicationRole> GetByName(string role);
    }
}