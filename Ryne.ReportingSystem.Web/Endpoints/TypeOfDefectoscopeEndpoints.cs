using Ryne.ReportingSystem.Application.Models;
using Ryne.ReportingSystem.Application.Service.Interfaces;
using Ryne.ReportingSystem.Web.Definitions.Base;
using Swashbuckle.AspNetCore.Annotations;

namespace Ryne.ReportingSystem.Web.Endpoints
{
    public class TypeOfDefectoscopeEndpoints :AppDefinition
    {
        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
        {
            app.MapGet("/api/TypeOfDefectoscope/", GetListTypeOfDefectoscope);
            app.MapGet("/api/TypeOfDefectoscope/{id:guid}", GetOneTypeOfDefectoscopeById);
            app.MapPost("/api/TypeOfDefectoscope/", CreateTypeOfDefectoscope);
            app.MapPut("/api/TypeOfDefectoscope/{id:guid}", UpdateTypeOfDefectoscope);
            app.MapDelete("/api/TypeOfDefectoscope/{id:guid}", DeletTypeOfDefectoscopeById);
        }


        [SwaggerOperation(
            Summary = "выводит список типов дефектоскопов",
            Tags = new[] { "TypeOfDefectoscopeEndpoints" }),
            ]
        [SwaggerResponse(StatusCodes.Status200OK, "success", typeof(List<TypeOfDefectoscopeDTO>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task GetListTypeOfDefectoscope(HttpContext http, ITypeOfDefectoscopeService service)
        {
            var DTO = await service.GetList();
            await http.Response.WriteAsJsonAsync(DTO);
        }

        [SwaggerOperation(
           Summary = "возваращает один тип дефектоскопов")]
        [SwaggerResponse(StatusCodes.Status200OK, "success", typeof(TypeOfDefectoscopeDetailDTO))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task GetOneTypeOfDefectoscopeById(HttpContext http, ITypeOfDefectoscopeService service,
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
            Summary = "создает тип дефектоскопов")]
        [SwaggerResponse(StatusCodes.Status201Created, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task CreateTypeOfDefectoscope(HttpContext http, ITypeOfDefectoscopeService service,
            [SwaggerRequestBody(
                Required = true
            )]
        TypeOfDefectoscopeCreateDTO DTO)
        {
            await service.CreateOne(DTO);
            http.Response.StatusCode = StatusCodes.Status201Created;
        }

        [SwaggerOperation(
            Summary = "обновляет тип дефектоскопа")]
        [SwaggerResponse(StatusCodes.Status201Created, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task  UpdateTypeOfDefectoscope(HttpContext http, ITypeOfDefectoscopeService service,
            [SwaggerRequestBody(
                Required = true
            )]
        TypeOfDefectoscopeCreateDTO DTO,
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
            Summary = "удаляеет один тип дефектоскопа")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task DeletTypeOfDefectoscopeById(HttpContext http, ITypeOfDefectoscopeService service,
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
