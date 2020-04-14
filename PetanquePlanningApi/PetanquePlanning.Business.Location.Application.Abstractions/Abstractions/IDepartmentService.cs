using System.Collections.Generic;
using System.Threading.Tasks;
using PetanquePlanning.Business.Location.Application.Abstractions.DTO;

namespace PetanquePlanning.Business.Location.Application.Abstractions.Abstractions
{
    public interface IDepartmentService
    {
        /// <summary>
        /// Get all departments
        /// </summary>
        /// <param name="withAdjacentDepartments">Include adjacent departments</param>
        /// <param name="withRegion">Include region</param>
        /// <returns>Departments</returns>
        Task<IEnumerable<DepartmentDTO>> GetAsync(bool withAdjacentDepartments = false, bool withRegion = false);
    }
}