using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetanquePlanning.Business.Location.Domain.Entities;

namespace PetanquePlanning.Business.Location.Infrastructure.Abstractions
{
    public interface IRegionRepository
    {
        /// <summary>
        /// Get all regions
        /// </summary>
        /// <returns>Regions</returns>
        Task<IEnumerable<Region>> GetAsync(bool includeDepartments = false);
    }
}
