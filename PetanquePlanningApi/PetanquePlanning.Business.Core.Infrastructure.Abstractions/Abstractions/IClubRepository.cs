using System.Collections.Generic;
using System.Threading.Tasks;
using PetanquePlanning.Business.Core.Domain.Entities;

namespace PetanquePlanning.Business.Core.Infrastructure.Abstractions.Abstractions
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