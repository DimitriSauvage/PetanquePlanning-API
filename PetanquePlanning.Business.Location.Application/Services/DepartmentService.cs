using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetanquePlanning.Business.Location.Application.DTO.DTO;
using PetanquePlanning.Business.Location.Domain.Entities;
using PetanquePlanning.Business.Location.Infrastructure.Abstractions.Abstractions;
using Tools.Application.Abstractions;

namespace PetanquePlanning.Business.Location.Application.Services
{
    public class DepartmentService : BaseService<Department, IDepartmentRepository>
    {
        #region Fields

        #endregion

        #region Constructor

        #endregion

        #region Methods

        /// <summary>
        /// Get all departments
        /// </summary>
        /// <param name="withAdjacentDepartments">Include adjacent departments</param>
        /// <param name="withRegion">Include region</param>
        /// <returns>Departments</returns>
        public async Task<IEnumerable<DepartmentDTO>> GetAsync(bool withAdjacentDepartments = false,
            bool withRegion = false)
        {
            //Get departments
            var departments = await this.Repository.GetAsync(withAdjacentDepartments, withRegion);

            //Map to the DTO
            return departments.Select(department => this.Mapper.Map<DepartmentDTO>(department)).ToList();
        }

        #endregion
    }
}