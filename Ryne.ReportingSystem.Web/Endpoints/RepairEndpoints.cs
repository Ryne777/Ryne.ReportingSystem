using AutoMapper;
using Ryne.ReportingSystem.Application;
using Ryne.ReportingSystem.Web.Definitions.Base;
using Ryne.ReportingSystem.Web.Models;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using Ryne.ReportingSystem.Entity;

namespace Ryne.ReportingSystem.Web.Endpoints
{
    public class RepairEndpoints : AppDefinition
    {
        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
        {
            app.MapGet("/api/repairs/", GetListRepairs);
            app.MapPost("/api/repairs/",CreateRepair);
            app.MapPut("/api/repairs/{id:guid}", UpdateRepair);
            app.MapDelete("/api/repairs/{id:guid}", DeletRepairById);
        }

        
        
        
        
        [SwaggerOperation(
            Summary = "выводит список ремонтов",
            Tags = new[] { "RepairEndpoints" })]
        [SwaggerResponse(StatusCodes.Status200OK, "success", typeof(List<RepairDetailDTO>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]        
        private async Task GetListRepairs(ApplicationDbContext db, HttpContext http, IMapper mapper)
        {
            var data = await db.Repairs.ToArrayAsync();
            var DTO = mapper.Map<List<RepairDetailDTO>>(data);
            await http.Response.WriteAsJsonAsync(DTO);
        }

        [SwaggerOperation(
            Summary = "создать ремонт")]
        [SwaggerResponse(StatusCodes.Status201Created, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task CreateRepair(ApplicationDbContext db, HttpContext http, IMapper mapper,
            [SwaggerRequestBody(
                Required = true
            )]
        RepairCreateDTO DTO)
        {
            var data = mapper.Map<Repair>(DTO);
            await db.Repairs.AddAsync(data);
            await db.SaveChangesAsync();
            http.Response.StatusCode = StatusCodes.Status201Created;
        }

        [SwaggerOperation(
            Summary = "обновляет ремонт дефектоскопа")]
        [SwaggerResponse(StatusCodes.Status201Created, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task UpdateRepair(ApplicationDbContext db, HttpContext http, IMapper mapper,
            [SwaggerRequestBody(
                Required = true
            )]
        RepairCreateDTO DTO,
            [SwaggerParameter("Id:Guid", Required = true)]
            Guid id)
        {
            var dataFromDb = await db.Repairs.FirstOrDefaultAsync(x => x.Id == id);
            if (dataFromDb == null)
            {
                http.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }
            mapper.Map<RepairCreateDTO,Repair>(DTO, dataFromDb);
            db.Repairs.Update(dataFromDb);
            await db.SaveChangesAsync();
            http.Response.StatusCode = StatusCodes.Status201Created;
        }

        [SwaggerOperation(
            Summary = "удаляеет один ремонт")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task DeletRepairById(ApplicationDbContext db, HttpContext http,
            [SwaggerParameter("Id:Guid", Required = true)]
            Guid id)
        {
            var data = await db.Repairs.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                http.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }
            db.Repairs.Remove(data!);
            await db.SaveChangesAsync();
            http.Response.StatusCode = StatusCodes.Status204NoContent;
        }
    }
}
