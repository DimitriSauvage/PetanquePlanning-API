﻿using System;
using DimitriSauvageTools.Application.Abstractions;
using PetanquePlanning.Business.Location.Application.DTO.DTO;

namespace PetanquePlanning.Business.Identity.Application.DTO.DTO.Users
{
    public class ApplicationUserFavoriteDepartmentDTO : BaseDTO
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Associated department
        /// </summary>
        public DepartmentDTO Department { get; set; }

        /// <summary>
        /// Associated department id
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Associated user
        /// </summary>
        public ApplicationUserDTO User { get; set; }

        /// <summary>
        /// Associated user id
        /// </summary>
        public Guid UserId { get; set; }
    }
}