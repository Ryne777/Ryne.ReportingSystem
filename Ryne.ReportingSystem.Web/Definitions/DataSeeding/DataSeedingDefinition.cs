using Ryne.ReportingSystem.Web.Definitions.Base;
using Ryne.ReportingSystem.Web.Helpers;

namespace Ryne.ReportingSystem.Web.Definitions.DataSeeding
{
    public class DataSeedingDefinition: AppDefinition
    {
        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
        {
            DataSeedHelper.Seed(app.Services);
        }
    }
}
