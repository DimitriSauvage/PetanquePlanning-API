using PetanquePlanning.Business.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace PetanquePlanning.Business.Core.Infrastructure.Abstractions
{
    public interface ICompetitionRepository
    {
        /// <summary>
        /// Get all competitions
        /// </summary>
        /// <returns>Competitions</returns>
        Task<List<Competition>> GetAsync();

        /// <summary>
        /// Get all competitions in specifies departments
        /// </summary>
        /// <param name="departmentCodes">Codes of the departments</param>
        /// <returns>Competitions in the departments</returns>
        Task<List<Competition>> GetAsync(List<string> departmentCodes);

        /// <summary>
        /// Get all competitions in specifies departments
        /// </summary>
        /// <param name="departmentCodes">Codes of the departments</param>
        /// <returns>Competitions in the departments</returns>
        Task<List<Competition>> GetAsync(List<string> departmentCodes, DateTimeOffset startDate, DateTimeOffset endDate);
    }
}
