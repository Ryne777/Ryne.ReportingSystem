using Ryne.ReportingSystem.Application.Service;
using Ryne.ReportingSystem.Application.Service.Interfaces;
using Ryne.ReportingSystem.Web.Definitions.Base;

namespace Ryne.ReportingSystem.Web.Definitions.AppService
{
    public class AppServiceDefinition :AppDefinition
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IRepairService, RepairService>();
        }
    }
}
