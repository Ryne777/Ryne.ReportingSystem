﻿using AutoMapper;
using Ryne.ReportingSystem.Entity;

namespace Ryne.ReportingSystem.Application.Models.MapperGonfigurations
{
    public class OrganizationMapperConfiguration:Profile
    {
        public OrganizationMapperConfiguration()
        {
            CreateMap<Organization, OrganizationDTO>();
            CreateMap<Organization, OrganizationDetailDTO>();
            CreateMap<OrganizationCreateDTO, Organization>();

        }
    }
}
