using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DimitriSauvageTools.Infrastructure.Abstraction;
using PetanquePlanning.Business.Identity.Domain.Entities;

namespace PetanquePlanning.Business.Identity.Infrastructure.Abstractions.Abstractions
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        /// <summary>
        /// Get all users with this role
        /// </summary>
        /// <param name="roleId">Role identifier</param>
        /// <returns></returns>
        Task<IEnumerable<ApplicationUser>> GetByRoleAsync(Guid roleId);
    }
}