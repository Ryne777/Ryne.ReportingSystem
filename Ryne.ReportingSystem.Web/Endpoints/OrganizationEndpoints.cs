using Ryne.ReportingSystem.Application.Models;
using Ryne.ReportingSystem.Application.Service.Interfaces;
using Ryne.ReportingSystem.Web.Definitions.Base;
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
        private async Task GetListOrganization(HttpContext http, IOrganizationService service)
        {
            var DTO = await service.GetList();
            await http.Response.WriteAsJsonAsync(DTO);
        }

        [SwaggerOperation(
           Summary = "возваращает одину организацию")]
        [SwaggerResponse(StatusCodes.Status200OK, "success", typeof(OrganizationDetailDTO))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task GetOneOrganizationById(HttpContext http, IOrganizationService service,
           [SwaggerParameter("Id:Guid", Required = true)]
            Guid id)
        {
            var DTO = await service.GetById(id);
            if (DTO == null)
            {
                http.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }
            await http.Response.WriteAsJsonAsync(DTO);
        }
        [SwaggerOperation(
            Summary = "создает организацию")]
        [SwaggerResponse(StatusCodes.Status201Created, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task CreateOrganization(HttpContext http, IOrganizationService service,
            [SwaggerRequestBody(
                Required = true
            )]
        OrganizationCreateDTO DTO)
        {
            await service.CreateOne(DTO);
            http.Response.StatusCode = StatusCodes.Status201Created;
        }

        [SwaggerOperation(
            Summary = "обновляет Организацию")]
        [SwaggerResponse(StatusCodes.Status201Created, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task UpdateOrganization(HttpContext http, IOrganizationService service,
            [SwaggerRequestBody(
                Required = true
            )]
        OrganizationCreateDTO DTO,
            [SwaggerParameter("Id:Guid", Required = true)]
            Guid id)
        {
            if (!await service.UpdateOne(DTO, id))
            {
                http.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }
            http.Response.StatusCode = StatusCodes.Status201Created;
        }

        [SwaggerOperation(
            Summary = "удаляеет одину организацию")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task DeletOranizationById(HttpContext http, IOrganizationService service,
            [SwaggerParameter("Id:Guid", Required = true)]
            Guid id)
        {
            if (!await service.DeleteOne(id))
            {
                http.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }
            http.Response.StatusCode = StatusCodes.Status204NoContent;
        }
    }
}
