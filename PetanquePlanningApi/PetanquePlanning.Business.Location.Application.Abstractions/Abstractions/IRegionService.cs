using PetanquePlanning.Business.Location.Application.Abstractions.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetanquePlanning.Business.Location.Application.Abstractions.Abstractions
{
    public interface IRegionService
    {
        /// <summary>
        /// Get all regions
        /// </summary>
        /// <returns>Regions</returns>
        Task<IEnumerable<RegionDTO>> GetAsync(bool includeDepartments = false);
    }
}
