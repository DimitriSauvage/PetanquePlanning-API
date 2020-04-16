﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetanquePlanning.Business.Core.Application.DTO.DTO;
using PetanquePlanning.Business.Core.Domain.Entities;
using PetanquePlanning.Business.Core.Infrastructure.Abstractions.Abstractions;
using Tools.Application.Abstractions;

namespace PetanquePlanning.Business.Core.Application.Services
{
    public class ClubService : BaseService<Club, IClubRepository>
    {
        #region Fields

        #endregion

        #region Constructor

        #endregion

        #region Methods

        /// <summary>
        /// Get all competitions
        /// </summary>
        /// <returns>Competitions</returns>
        public async Task<IEnumerable<ClubDTO>> GetAsync()
        {
            var clubs = await this.Repository.GetAsync();
            return clubs.Select(x => this.Mapper.Map<ClubDTO>(x));
        }

        #endregion
    }
}