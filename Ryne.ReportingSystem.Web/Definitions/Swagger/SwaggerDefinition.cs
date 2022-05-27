using Microsoft.OpenApi.Models;
using Ryne.ReportingSystem.Web.Definitions.Base;

namespace Ryne.ReportingSystem.Web.Definitions.Swagger
{
    public class SwaggerDefinition: AppDefinition
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c => {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Reporting Sytem For Defectoscope API",
                    Description = "Система для хранения и создания отчетов, ремонта дефктоскопов",
                    
                });
            });
        }
        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
