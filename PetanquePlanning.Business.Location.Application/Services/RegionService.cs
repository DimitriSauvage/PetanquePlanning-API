using System.Collections.Generic;
using System.Threading.Tasks;
using DimitriSauvageTools.Application.Abstractions;
using PetanquePlanning.Business.Location.Application.DTO.DTO;
using PetanquePlanning.Business.Location.Domain.Entities;
using PetanquePlanning.Business.Location.Infrastructure.Abstractions.Abstractions;

namespace PetanquePlanning.Business.Location.Application.Services
{
    public class RegionService : BaseService<Region, IRegionRepository>
    {
        #region Fields

        #endregion

        #region Constructor

        #endregion

        #region Methods

        /// <summary>
        /// Get all regions
        /// </summary>
        /// <returns>Regions</returns>
        public async Task<IEnumerable<RegionDTO>> GetAsync(bool includeDepartments = false)
        {
            List<RegionDTO> regionDto = new List<RegionDTO>();

            //Get departments
            var regions = await this.Repository.GetAsync(includeDepartments);

            //Map to the DTO
            foreach (var region in regions)
            {
                regionDto.Add(this.Mapper.Map<RegionDTO>(region));
            }

            return regionDto;
        }

        #endregion
    }
}