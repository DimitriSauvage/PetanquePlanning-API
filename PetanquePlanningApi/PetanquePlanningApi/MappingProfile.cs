using AutoMapper;
using PetanquePlanning.Business.Location.Application.Abstractions.DTO;
using PetanquePlanning.Business.Location.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using PetanquePlanning.Business.Core.Application.Abstractions.DTO;
using PetanquePlanning.Business.Core.Domain.Entities;
using PetanquePlanning.Business.Core.Domain.Enumerations;
using PetanquePlanning.Business.Identity.Application.Abstractions.DTO.Roles;
using PetanquePlanning.Business.Identity.Application.Abstractions.DTO.Users;
using PetanquePlanning.Business.Identity.Domain.Entities;
using PetanquePlanning.Business.Identity.Domain.Enumerations;
using Tools.Application.DTOs;
using Tools.Mapper;

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

            this.CreateMap<Club, ClubDTO>().ReverseMap();
            this.CreateMap<Competition, CompetitionDTO>().ReverseMap();
            this.CreateMapsForEnum<CompetitionGenderEnum>();
            this.CreateMapsForEnum<CompetitionLevelEnum>();
            this.CreateMapsForEnum<CompetitionSportEnum>();
            this.CreateMapsForEnum<CompetitionTypeEnum>();

            #endregion

            #region Identity

            this.CreateMap<ApplicationUser, ApplicationUserDTO>().ReverseMap();
            this.CreateMap<ApplicationRole, ApplicationRoleDTO>().ReverseMap();
            this.CreateMapsForEnum<GenderEnum>();

            #endregion
        }

        #region Private methods

        /// <summary>
        /// Create the maps for an enum
        /// </summary>
        /// <typeparam name="TEnum">Enum type for which create the maps</typeparam>
        private void CreateMapsForEnum<TEnum>() where TEnum : struct, IConvertible
        {
            //Enum to DTO
            this.CreateMap<TEnum, EnumDTO<TEnum>>()
                .ConvertUsing<EnumToDtoConverter<TEnum>>();
            this.CreateMap<EnumDTO<TEnum>, TEnum>()
                .ConvertUsing<DtoToEnumConverter<TEnum>>();
        }

        #endregion
    }
}