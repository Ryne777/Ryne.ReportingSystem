using Ryne.ReportingSystem.Web.Definitions.Base;
using Swashbuckle.AspNetCore.Annotations;
using Ryne.ReportingSystem.Application.Models;
using Ryne.ReportingSystem.Application.Service.Interfaces;

namespace Ryne.ReportingSystem.Web.Endpoints
{
    public class RepairEndpoints : AppDefinition
    {
        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
        {
            app.MapGet("/api/repairs/", GetListRepairs);
            app.MapGet("/api/repairs/{id:guid}", GetOneRepairById);
            app.MapPost("/api/repairs/",CreateRepair);
            app.MapPut("/api/repairs/{id:guid}", UpdateRepair);
            app.MapDelete("/api/repairs/{id:guid}", DeletRepairById);
        }

        
        
        
        
        [SwaggerOperation(
            Summary = "выводит список ремонтов",
            Tags = new[] { "RepairEndpoints" })]
        [SwaggerResponse(StatusCodes.Status200OK, "success", typeof(List<RepairDetailDTO>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]        
        private async Task GetListRepairs(HttpContext http, IRepairService service)
        {
            var DTO = await service.GetList();
            await http.Response.WriteAsJsonAsync(DTO);
        }

        [SwaggerOperation(
            Summary = "выводит оди ремонт",
            Tags = new[] { "RepairEndpoints" })]
        [SwaggerResponse(StatusCodes.Status200OK, "success", typeof(RepairDetailDTO))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task GetOneRepairById(HttpContext http, IRepairService service,
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
            Summary = "создать ремонт")]
        [SwaggerResponse(StatusCodes.Status201Created, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task CreateRepair(HttpContext http, IRepairService service,
            [SwaggerRequestBody(
                Required = true
            )]
        RepairCreateDTO DTO)
        {
            await service.CreateOne(DTO);
            http.Response.StatusCode = StatusCodes.Status201Created;
        }

        [SwaggerOperation(
            Summary = "обновляет ремонт дефектоскопа")]
        [SwaggerResponse(StatusCodes.Status201Created, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task UpdateRepair(HttpContext http, IRepairService service,
            [SwaggerRequestBody(
                Required = true
            )]
        RepairCreateDTO DTO,
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
            Summary = "удаляеет один ремонт")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task DeletRepairById(HttpContext http, IRepairService service,
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
