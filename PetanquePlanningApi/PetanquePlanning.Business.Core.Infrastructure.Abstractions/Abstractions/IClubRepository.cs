using System.Collections.Generic;
using System.Threading.Tasks;
using PetanquePlanning.Business.Core.Domain.Entities;
using Tools.Infrastructure.Abstraction;

namespace PetanquePlanning.Business.Core.Infrastructure.Abstractions.Abstractions
{
    public interface IClubRepository : IRepository<Club>
    {
        /// <summary>
        /// Get all competitions
        /// </summary>
        /// <returns>Competitions</returns>
        Task<IEnumerable<Club>> GetAsync();
    }
}