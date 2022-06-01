namespace Ryne.ReportingSystem.Application.Models.MapperGonfigurations
{
    public class AutoMapperConfig
    {
        public static Type[] RegisterMappings()
        {
            return new Type[]
            {
                typeof(RepairMappingConfiguration),
                typeof(DefectoscopeMapperCongiguration),
                typeof(TypeOfDefectoscopeMapperConfiguration),
                typeof(OrganizationMapperConfiguration),
                typeof(EngineerMapperConfiguration)
            };
        }
    }
}
