using System.Collections.Generic;
using System.Threading.Tasks;
using PetanquePlanning.Business.Location.Domain.Entities;
using Tools.Infrastructure.Abstraction;

namespace PetanquePlanning.Business.Location.Infrastructure.Abstractions.Abstractions
{
    public interface IRegionRepository : IRepository<Region>
    {
        /// <summary>
        /// Get all regions
        /// </summary>
        /// <returns>Regions</returns>
        Task<IEnumerable<Region>> GetAsync(bool includeDepartments = false);
    }
}