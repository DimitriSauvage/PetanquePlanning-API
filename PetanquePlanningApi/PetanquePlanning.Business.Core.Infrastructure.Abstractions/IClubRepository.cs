using PetanquePlanning.Business.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace PetanquePlanning.Business.Core.Infrastructure.Abstractions
{
    public interface IClubRepository
    {
        /// <summary>
        /// Get all competitions
        /// </summary>
        /// <returns>Competitions</returns>
        Task<List<Club>> GetAsync();

    }
}
