using System.Collections.Generic;
using System.Threading.Tasks;
using DimitriSauvageTools.Infrastructure.Abstraction;
using PetanquePlanning.Business.Location.Domain.Entities;

namespace PetanquePlanning.Business.Location.Infrastructure.Abstractions.Abstractions
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        /// <summary>
        /// Get all departments
        /// </summary>
        /// <param name="withAdjacentDepartments">Include adjacent departments</param>
        /// <param name="withRegion">Include region</param>
        /// <returns>Departments</returns>
        Task<IEnumerable<Department>> GetAsync(bool withAdjacentDepartments = false, bool withRegion = false);
    }
}