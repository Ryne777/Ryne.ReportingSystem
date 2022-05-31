using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ryne.ReportingSystem.Application;
using Ryne.ReportingSystem.Entity;
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
            app.MapPost("/api/organizations/", CreateOrganization);
            app.MapPut("/api/organizations/{id:guid}", UpdateOrganization);
            app.MapDelete("/api/organizations/{id:guid}", DeletOranizationById);
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
        [SwaggerOperation(
            Summary = "создает организацию")]
        [SwaggerResponse(StatusCodes.Status201Created, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task CreateOrganization(ApplicationDbContext db, HttpContext http, IMapper mapper,
            [SwaggerRequestBody(
                Required = true
            )]
        OrganizationCreateDTO DTO)
        {
            var data = mapper.Map<Organization>(DTO);
            await db.Organizations.AddAsync(data);
            await db.SaveChangesAsync();
            http.Response.StatusCode = StatusCodes.Status201Created;
        }

        [SwaggerOperation(
            Summary = "обновляет Организацию")]
        [SwaggerResponse(StatusCodes.Status201Created, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task UpdateOrganization(ApplicationDbContext db, HttpContext http,
            [SwaggerRequestBody(
                Required = true
            )]
        OrganizationCreateDTO DTO,
            [SwaggerParameter("Id:Guid", Required = true)]
            Guid id)
        {
            var dataFromDb = await db.Organizations.FirstOrDefaultAsync(x => x.Id == id);
            if (dataFromDb == null)
            {
                http.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }
            dataFromDb.Name = DTO.Name;
            db.Organizations.Update(dataFromDb);
            await db.SaveChangesAsync();
            http.Response.StatusCode = StatusCodes.Status201Created;
        }

        [SwaggerOperation(
            Summary = "удаляеет одину организацию")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task DeletOranizationById(ApplicationDbContext db, HttpContext http,
            [SwaggerParameter("Id:Guid", Required = true)]
            Guid id)
        {
            var data = await db.Organizations.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                http.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }
            db.Organizations.Remove(data!);
            await db.SaveChangesAsync();
            http.Response.StatusCode = StatusCodes.Status204NoContent;
        }
    }
}
