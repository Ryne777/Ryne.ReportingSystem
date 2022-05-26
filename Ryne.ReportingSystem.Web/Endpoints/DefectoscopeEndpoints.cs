using Microsoft.EntityFrameworkCore;
using Ryne.ReportingSystem.Application;
using Ryne.ReportingSystem.Web.Definitions.Base;

namespace Ryne.ReportingSystem.Web.Endpoints
{
    public class DefectoscopeEndpoints:AppDefinition
    {
        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
        {

            app.MapGet("/api", async (ApplicationDbContext db, HttpContext http) =>
            {
                await http.Response.WriteAsJsonAsync( db.Defectoscopes);                
            });
        }
    }
}
