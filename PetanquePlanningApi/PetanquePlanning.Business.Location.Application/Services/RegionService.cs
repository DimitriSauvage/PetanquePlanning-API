using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PetanquePlanning.Business.Location.Application.Abstractions.Abstractions;
using PetanquePlanning.Business.Location.Application.Abstractions.DTO;
using PetanquePlanning.Business.Location.Infrastructure.Abstractions;

namespace PetanquePlanning.Business.Location.Application.Services
{
    public class RegionService : IRegionService
    {
        #region Fields

        /// <summary>
        /// Department storage manager
        /// </summary>
        private IRegionRepository RegionRepository { get; }

        /// <summary>
        /// Mapper manager
        /// </summary>
        private IMapper Mapper { get; }

        #endregion

        #region Constructor

        public RegionService(IRegionRepository regionRepository, IMapper mapper)
        {
            this.RegionRepository = regionRepository;
            this.Mapper = mapper;
        }

        #endregion

        #region Methods

        ///<inheritdoc/>
        public async Task<IEnumerable<RegionDTO>> GetAsync(bool includeDepartments = false)
        {
            List<RegionDTO> regionDTOs = new List<RegionDTO>();

            //Get departments
            var regions = await this.RegionRepository.GetAsync(includeDepartments);

            //Map to the DTO
            foreach (var region in regions)
            {
                regionDTOs.Add(this.Mapper.Map<RegionDTO>(region));
            }

            return regionDTOs;
        }

        #endregion
    }
}