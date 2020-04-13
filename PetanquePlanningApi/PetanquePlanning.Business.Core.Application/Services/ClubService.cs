using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PetanquePlanning.Business.Core.Application.Abstractions.Abstractions;
using PetanquePlanning.Business.Core.Domain.Entities;
using PetanquePlanning.Business.Core.Infrastructure.Abstractions.Abstractions;

namespace PetanquePlanning.Business.Core.Application.Services
{
    public class ClubService : IClubService
    {
        #region Fields

        /// <summary>
        /// Club manager
        /// </summary>
        private IClubRepository ClubRepository { get; }

        /// <summary>
        /// Mapping manager
        /// </summary>
        private IMapper Mapper { get; }

        #endregion

        #region Constructor

        public ClubService(IClubRepository clubRepository)
        {
            this.ClubRepository = clubRepository;
        }

        #endregion


        #region Methods

        /// <inheritdoc />
        public async Task<IEnumerable<ClubDTO>> GetAsync()
        {
            var clubs = await this.ClubRepository.GetAsync();
            return clubs.Select(x => this.Mapper.Map<ClubDTO>(x));
        }

        #endregion
    }
}