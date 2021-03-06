﻿using System;
using System.Collections.Generic;
using DimitriSauvageTools.Application.Abstractions;

namespace PetanquePlanning.Business.Location.Application.DTO.DTO
{
    public class DepartmentDTO : BaseDTO
    {
        /// <summary>
        /// Adjacent departments
        /// </summary>
        public IEnumerable<AdjacentDepartmentsDTO> AdjacentDepartments { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Region
        /// </summary>
        public RegionDTO Region { get; set; }

        /// <summary>
        /// Region code
        /// </summary>
        public Guid RegionId { get; set; }
    }
}