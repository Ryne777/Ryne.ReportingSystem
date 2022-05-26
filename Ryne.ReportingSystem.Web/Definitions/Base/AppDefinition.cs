namespace Ryne.ReportingSystem.Web.Definitions.Base
{
    public abstract class AppDefinition : IAppDefinition
    {
        public virtual void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
        {
            
        }

        public virtual void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
           
        }
    }
}
