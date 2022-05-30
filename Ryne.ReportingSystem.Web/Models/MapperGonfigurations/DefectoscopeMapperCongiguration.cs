﻿using AutoMapper;
using Ryne.ReportingSystem.Entity;

namespace Ryne.ReportingSystem.Web.Models.MapperGonfigurations
{
    public class DefectoscopeMapperCongiguration: Profile
    {
        public DefectoscopeMapperCongiguration()
        {
            CreateMap<Defectoscope, DefectoscopeDTO>();
            CreateMap<Defectoscope, DefectoscopeDetailDTO>();
        }
    }
}
