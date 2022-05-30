using AutoMapper;
using Ryne.ReportingSystem.Application;
using Ryne.ReportingSystem.Web.Definitions.Base;
using Ryne.ReportingSystem.Web.Models;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Ryne.ReportingSystem.Web.Endpoints
{
    public class RepairEndpoints : AppDefinition
    {
        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
        {
            app.MapGet("/api/repairs/", GetListRepairs);
        }

        
        
        
        
        [SwaggerOperation(
            Summary = "выводит список ремонтов",
            Tags = new[] { "RepairsEndpoints" }),
            ]
        [SwaggerResponse(201, "success", typeof(List<RepairDetailDTO>))]
        [SwaggerResponse(500, "some failure")]        
        private async Task GetListRepairs(ApplicationDbContext db, HttpContext http, IMapper mapper)
        {
            var data = await db.Repairs.ToArrayAsync();
            var DTO = mapper.Map<List<RepairDetailDTO>>(data);
            await http.Response.WriteAsJsonAsync(DTO);
        }
    }
}
