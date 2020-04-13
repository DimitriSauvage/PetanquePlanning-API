﻿using System.Collections.Generic;
using System.Threading.Tasks;
using PetanquePlanning.Business.Core.Domain.Entities;

namespace PetanquePlanning.Business.Core.Application.Abstractions.Abstractions
{
    public interface IClubService
    {
        /// <summary>
        /// Get all competitions
        /// </summary>
        /// <returns>Competitions</returns>
        Task<IEnumerable<ClubDTO>> GetAsync();
    }
}