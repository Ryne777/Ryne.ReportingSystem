using Ryne.ReportingSystem.Application.Models;
using Ryne.ReportingSystem.Application.Service.Interfaces;
using Ryne.ReportingSystem.Web.Definitions.Base;
using Swashbuckle.AspNetCore.Annotations;

namespace Ryne.ReportingSystem.Web.Endpoints
{
    public class EngineerEndpoints : AppDefinition
    {
        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
        {
            app.MapGet("/api/engineers/", GetListEngineers);
            app.MapGet("/api/engineers/{id:guid}", GetOneEngineerById);
            app.MapPost("/api/engineers/", CreateEngineer);
            app.MapPut("/api/engineers/{id:guid}", UpdateEngineer);
            app.MapDelete("/api/engineers/{id:guid}", DeletEngineerById);
        }

        [SwaggerOperation(
            Summary = "выводит список электроников",
            Tags = new[] { "EngineerEndpoints" }),
            ]
        [SwaggerResponse(StatusCodes.Status200OK, "success", typeof(List<EngineerDTO>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task GetListEngineers(HttpContext http, IEngineerService service)
        {
            var DTO = await service.GetList();
            await http.Response.WriteAsJsonAsync(DTO);
        }

        [SwaggerOperation(
           Summary = "возваращает одиного электроника")]
        [SwaggerResponse(StatusCodes.Status200OK, "success", typeof(EngineerDTO))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task GetOneEngineerById(HttpContext http, IEngineerService service,
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
            Summary = "создает электроника")]
        [SwaggerResponse(StatusCodes.Status201Created, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task CreateEngineer(HttpContext http, IEngineerService service,
            [SwaggerRequestBody(
                Required = true
            )]
        EngineerCreateDTO DTO)
        {
            await service.CreateOne(DTO);
            http.Response.StatusCode = StatusCodes.Status201Created;            
        }

        [SwaggerOperation(
            Summary = "обновить электроника")]
        [SwaggerResponse(StatusCodes.Status201Created, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task UpdateEngineer(HttpContext http, IEngineerService service,
            [SwaggerRequestBody(
                Required = true
            )]
        EngineerCreateDTO DTO,
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
            Summary = "удаляеет одиного электроника")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task DeletEngineerById(HttpContext http, IEngineerService service,
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
