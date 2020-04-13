﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetanquePlanning.Business.Core.Domain.Entities;
using PetanquePlanning.Business.Core.Infrastructure.Abstractions.Abstractions;
using Tools.Infrastructure.EntityFramework.Abstractions;

namespace PetanquePlanning.Business.Core.Infrastructure.EntityFramework.Repositories
{
    public class ClubRepository : PetanquePlanningRepository<Club>, IClubRepository
    {
        #region Constructor

        public ClubRepository(DbContext dbContext) : base(dbContext)
        {
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<IEnumerable<Club>> GetAsync()
        {
            return await this.Query().ToListAsync();
        }

        #endregion
    }
}