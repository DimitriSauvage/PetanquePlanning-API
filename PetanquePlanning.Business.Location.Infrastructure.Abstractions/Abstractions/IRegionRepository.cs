using System.Collections.Generic;
using System.Threading.Tasks;
using DimitriSauvageTools.Infrastructure.Abstraction;
using PetanquePlanning.Business.Location.Domain.Entities;

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