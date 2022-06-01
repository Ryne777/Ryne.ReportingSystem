using AutoMapper;
using Ryne.ReportingSystem.Entity;

namespace Ryne.ReportingSystem.Application.Models.MapperGonfigurations
{
    public class RepairMappingConfiguration: Profile
    {
        public RepairMappingConfiguration()
        {
            CreateMap<Repair, RepairDTO>();
            CreateMap<Repair, RepairDetailDTO>();
            CreateMap<RepairCreateDTO, Repair>();
            CreateMap<Repair, RepairAndDefectoscopeDTO>()
                .ForMember(dest => dest.TypeOfDefectoscope, 
                opt => opt.MapFrom(srs => srs.Defectoscope!.TypeOfDefectoscope!.Name));
            
        }
    }
}
