using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ryne.ReportingSystem.Application;
using Ryne.ReportingSystem.Web.Definitions.Base;
using Ryne.ReportingSystem.Web.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ryne.ReportingSystem.Web.Endpoints
{
    public class OrganizationEndpoints: AppDefinition
    {
        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
        {
            app.MapGet("/api/organizations/", GetListOrganization);
            app.MapGet("/api/organizations/{id:guid}", GetOneOrganizationById);
        }





        [SwaggerOperation(
            Summary = "выводит список организаций",
            Tags = new[] { "OrganizationEndpoints" }),
            ]
        [SwaggerResponse(StatusCodes.Status200OK, "success", typeof(List<OrganizationDTO>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task GetListOrganization(ApplicationDbContext db, HttpContext http, IMapper mapper)
        {
            var data = await db.Organizations.ToArrayAsync();
            var DTO = mapper.Map<List<OrganizationDTO>>(data);
            await http.Response.WriteAsJsonAsync(DTO);
        }

        [SwaggerOperation(
           Summary = "возваращает одину организацию")]
        [SwaggerResponse(StatusCodes.Status200OK, "success", typeof(OrganizationDetailDTO))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task GetOneOrganizationById(ApplicationDbContext db, HttpContext http, IMapper mapper,
           [SwaggerParameter("Id:Guid", Required = true)]
            Guid id)
        {
            var data = await db.Organizations.FirstOrDefaultAsync(x => x.Id == id);
            var DTO = mapper.Map<OrganizationDetailDTO>(data);
            await http.Response.WriteAsJsonAsync(DTO);
        }
    }
}
