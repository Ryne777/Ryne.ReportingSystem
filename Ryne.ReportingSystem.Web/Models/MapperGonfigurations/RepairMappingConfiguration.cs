using AutoMapper;
using Ryne.ReportingSystem.Entity;

namespace Ryne.ReportingSystem.Web.Models.MapperGonfigurations
{
    public class RepairMappingConfiguration: Profile
    {
        public RepairMappingConfiguration()
        {
            CreateMap<Repair, RepairDTO>();
            CreateMap<Repair, RepairDetailDTO>();
            CreateMap<RepairCreateDTO, Repair>();
            
        }
    }
}
