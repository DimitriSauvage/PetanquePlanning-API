using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetanquePlanning.Business.Core.Application.DTO.DTO;
using PetanquePlanning.Business.Core.Domain.Entities;
using PetanquePlanning.Business.Core.Infrastructure.Abstractions.Abstractions;
using Tools.Application.Abstractions;
using Tools.Infrastructure.Exceptions;

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
        /// Get all clubs
        /// </summary>
        /// <returns>Competitions</returns>
        public async Task<IEnumerable<ClubDTO>> GetAllAsync()
        {
            var clubs = await this.Repository.ListAsync();
            return clubs.Select(x => this.Mapper.Map<ClubDTO>(x));
        }

        /// <summary>
        /// Get a club by his id
        /// </summary>
        /// <param name="id">Club id</param>
        /// <returns></returns>
        public async Task<ClubDTO> GetByIdAsync(Guid id)
        {
            var club = await this.Repository.GetByIdAsync(id);
            if (club == null) throw new EntityNotFoundException<Club>();
            return this.Mapper.Map<ClubDTO>(club);
        }

        /// <summary>
        /// Create a new club
        /// </summary>
        /// <param name="clubDto">Club to crate</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="EntityAlreadyExistsException{TEntity}"<Club>"></exception>
        public async Task<ClubDTO> CreateAsync(ClubDTO clubDto)
        {
            if (clubDto == null) throw new ArgumentNullException(nameof(clubDto));

            return await this.Repository.TransactionalExecutionAsync(
                action: async (club, transaction) =>
                {
                    //Check if the club does not already exist
                    var searchedClub = await this.Repository.GetByUniqueKeyAsync(club);
                    if (searchedClub != null) throw new EntityAlreadyExistsException<Club>(club);

                    //Add the club
                    await this.Repository.AddAsync(club);
                    await this.Repository.SaveChangesAsync();
                },
                obj: this.Mapper.Map<Club>(clubDto),
                onSuccessFunc: (createdClub => this.Mapper.Map<ClubDTO>(createdClub)));
        }

        /// <summary>
        /// Update a club
        /// </summary>
        /// <param name="clubDto">Club to update</param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException<Club>"></exception>
        public async Task UpdateAsync(ClubDTO clubDto)
        {
            await this.Repository.TransactionalExecutionAsync(
                action: async (club, transaction) =>
                {
                    //Check if the club already exists
                    var toUpdateClub = await this.Repository.GetByIdAsync(club.Id);
                    if (toUpdateClub == null) throw new EntityNotFoundException<Club>();

                    toUpdateClub.CopyFrom(club);

                    //Save the club
                    await this.Repository.SaveChangesAsync();
                },
                obj: this.Mapper.Map<Club>(clubDto));
        }

        #endregion
    }
}