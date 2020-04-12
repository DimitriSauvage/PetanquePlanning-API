using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetanquePlanning.Business.Core.Domain.Entities;

namespace PetanquePlanning.Business.Core.Infrastructure.Abstractions.Abstractions
{
    public interface ICompetitionRepository
    {

        /// <summary>
        /// Get all competitions in specifies departments
        /// </summary>
        /// <param name="departmentCodes">Codes of the departments</param>
        /// <returns>Competitions in the departments</returns>
        Task<List<Competition>> GetAsync(List<string> departmentCodes = null);

        /// <summary>
        /// Get all competitions in specifies departments
        /// </summary>
        /// <param name="startDate">Start date for the competition</param>
        /// <param name="endDate"></param>
        /// <param name="departmentCodes">Codes of the departments</param>
        /// <returns>Competitions in the departments</returns>
        Task<List<Competition>> GetAsync(DateTimeOffset startDate,
            DateTimeOffset endDate, List<string> departmentCodes = null );
    }
}