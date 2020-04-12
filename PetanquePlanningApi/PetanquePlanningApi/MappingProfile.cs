using AutoMapper;
using PetanquePlanning.Business.Location.Application.Abstractions.DTO;
using PetanquePlanning.Business.Location.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetanquePlanningApi
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Location
            this.CreateMap<Department, DepartmentDTO>().ReverseMap();
            this.CreateMap<Region, RegionDTO>().ReverseMap();
            #endregion

            #region Core

            #endregion
        }
    }
}
