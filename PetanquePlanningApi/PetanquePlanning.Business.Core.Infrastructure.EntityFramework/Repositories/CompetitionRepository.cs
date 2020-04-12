using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetanquePlanning.Business.Core.Domain.Entities;
using PetanquePlanning.Business.Core.Infrastructure.Abstractions.Abstractions;
using Tools.Infrastructure.EntityFramework.Abstractions;

namespace PetanquePlanning.Business.Core.Infrastructure.EntityFramework.Repositories
{
    public class CompetitionRepository : PetanquePlanningRepository<Competition>, ICompetitionRepository
    {
        #region Constructor
        public CompetitionRepository(DbContext dbContext) : base(dbContext)
        {
        }
        #endregion

        
        #region Methods

        #endregion
    }
}