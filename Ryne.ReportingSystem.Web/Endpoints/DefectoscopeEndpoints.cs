using Ryne.ReportingSystem.Application.Models;
using Ryne.ReportingSystem.Application.Service.Interfaces;
using Ryne.ReportingSystem.Web.Definitions.Base;
using Swashbuckle.AspNetCore.Annotations;

namespace Ryne.ReportingSystem.Web.Endpoints
{
    public class DefectoscopeEndpoints : AppDefinition
    {
        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
        {
            app.MapGet("/api/defectoscopes", GetListDefectoscopes);
            app.MapGet("/api/defectoscopes/{id:guid}", GetOneDefectoscopById);
            app.MapPost("/api/defectoscopes/", CreateDefectoscope);
            app.MapPut("/api/defectoscopes/{id:guid}", UpdateDefectoscope);
            app.MapDelete("/api/defectoscopes/{id:guid}", DeleteDefectoscopeById);
        }


        [SwaggerOperation(
            Summary = "возваращает список дефектосковоп")]
        [SwaggerResponse(StatusCodes.Status200OK, "success", typeof(List<DefectoscopeDTO>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task GetListDefectoscopes(HttpContext http, IDefectoscopeService service)
        {
            var DTO = await service.GetList();
            await http.Response.WriteAsJsonAsync(DTO);
        }

        [SwaggerOperation(
            Summary = "возваращает один дефектосковоп")]
        [SwaggerResponse(StatusCodes.Status200OK, "success", typeof(DefectoscopeDetailDTO))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task GetOneDefectoscopById(HttpContext http, IDefectoscopeService service,
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
            Summary = "создать дефектоскоп")]
        [SwaggerResponse(StatusCodes.Status201Created, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task CreateDefectoscope(HttpContext http, IDefectoscopeService service,
            [SwaggerRequestBody(
                Required = true
            )]
        DefectoscopeCreateDTO DTO)
        {
            await service.CreateOne(DTO);
            http.Response.StatusCode = StatusCodes.Status201Created;
        }

        [SwaggerOperation(
            Summary = "обновляет один дефектоскопа")]
        [SwaggerResponse(StatusCodes.Status201Created, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task UpdateDefectoscope(HttpContext http, IDefectoscopeService service,
            [SwaggerRequestBody(
                Required = true
            )]
        DefectoscopeCreateDTO DTO,
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
            Summary = "удаляеет один дефектосковоп")]
        [SwaggerResponse(StatusCodes.Status200OK, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task DeleteDefectoscopeById(HttpContext http, IDefectoscopeService service,
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
