using Microsoft.OpenApi.Models;
using Ryne.ReportingSystem.Web.Definitions.Base;
using System.Reflection;

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
                c.UseInlineDefinitionsForEnums();
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                
            });            
        }
        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
