using System.Collections.Generic;
using System.Threading.Tasks;
using PetanquePlanning.Business.Location.Application.Abstractions.DTO;

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