﻿using AutoMapper;
using Ryne.ReportingSystem.Entity;

namespace Ryne.ReportingSystem.Application.Models.MapperGonfigurations
{
    public class TypeOfDefectoscopeMapperConfiguration: Profile
    {
        public TypeOfDefectoscopeMapperConfiguration()
        {
            CreateMap<TypeOfDefectoscope, TypeOfDefectoscopeDTO>();
            CreateMap<TypeOfDefectoscope, TypeOfDefectoscopeDetailDTO>();
            CreateMap<TypeOfDefectoscopeCreateDTO, TypeOfDefectoscope>();            
        }
    }
}
