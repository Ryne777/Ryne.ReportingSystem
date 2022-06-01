using AutoMapper;
using Ryne.ReportingSystem.Entity;

namespace Ryne.ReportingSystem.Application.Models.MapperGonfigurations
{
    public class EngineerMapperConfiguration : Profile
    {
        public EngineerMapperConfiguration()
        {
            CreateMap<Engineer, EngineerDTO>();
            CreateMap<EngineerCreateDTO, Engineer>();
        }
    }
}
