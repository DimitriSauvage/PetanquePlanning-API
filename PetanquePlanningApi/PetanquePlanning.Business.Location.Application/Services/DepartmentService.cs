using AutoMapper;
using PetanquePlanning.Business.Location.Application.Abstractions.Abstractions;
using PetanquePlanning.Business.Location.Application.Abstractions.DTO;
using PetanquePlanning.Business.Location.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetanquePlanning.Business.Location.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        #region Fields
        /// <summary>
        /// Department storage manager
        /// </summary>
        public IDepartmentRepository DepartmentRepository { get; }
        /// <summary>
        /// Mapper manager
        /// </summary>
        public IMapper Mapper { get; }
        #endregion

        #region Constructor
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            this.DepartmentRepository = departmentRepository;
            this.Mapper = mapper;
        }
        #endregion

        #region Methods
        ///<inheritdoc/>
        public async Task<IEnumerable<DepartmentDTO>> GetAsync(bool withAdjacentDepartments = false, bool withRegion = false)
        {
            List<DepartmentDTO> departmentDTOs = new List<DepartmentDTO>();
            //Get departments
            var departments = await this.DepartmentRepository.GetAsync(withAdjacentDepartments, withRegion);

            //Map to the DTO
            foreach (var department in departments)
            {
                departmentDTOs.Add(this.Mapper.Map<DepartmentDTO>(department));
            }

            return departmentDTOs;
        }
        #endregion
    }
}
