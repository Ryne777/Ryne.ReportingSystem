using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ryne.ReportingSystem.Application;
using Ryne.ReportingSystem.Application.Models;
using Ryne.ReportingSystem.Entity;
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
        private async Task GetListEngineers(ApplicationDbContext db, HttpContext http, IMapper mapper)
        {
            var data = await db.Engineers.ToArrayAsync();
            var DTO = mapper.Map<List<EngineerDTO>>(data);
            await http.Response.WriteAsJsonAsync(DTO);
        }

        [SwaggerOperation(
           Summary = "возваращает одиного электроника")]
        [SwaggerResponse(StatusCodes.Status200OK, "success", typeof(EngineerDTO))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task GetOneEngineerById(ApplicationDbContext db, HttpContext http, IMapper mapper,
           [SwaggerParameter("Id:Guid", Required = true)]
            Guid id)
        {
            var data = await db.Organizations.FirstOrDefaultAsync(x => x.Id == id);
            var DTO = mapper.Map<EngineerDTO>(data);
            await http.Response.WriteAsJsonAsync(DTO);
        }
        [SwaggerOperation(
            Summary = "создает электроника")]
        [SwaggerResponse(StatusCodes.Status201Created, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task CreateEngineer(ApplicationDbContext db, HttpContext http, IMapper mapper,
            [SwaggerRequestBody(
                Required = true
            )]
        EngineerCreateDTO DTO)
        {
            var data = mapper.Map<Engineer>(DTO);
            await db.Engineers.AddAsync(data);
            await db.SaveChangesAsync();
            http.Response.StatusCode = StatusCodes.Status201Created;
        }

        [SwaggerOperation(
            Summary = "обновить электроника")]
        [SwaggerResponse(StatusCodes.Status201Created, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task UpdateEngineer(ApplicationDbContext db, HttpContext http,
            [SwaggerRequestBody(
                Required = true
            )]
        EngineerCreateDTO DTO,
            [SwaggerParameter("Id:Guid", Required = true)]
            Guid id)
        {
            var dataFromDb = await db.Engineers.FirstOrDefaultAsync(x => x.Id == id);
            if (dataFromDb == null)
            {
                http.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }
            dataFromDb.Name = DTO.Name;
            db.Engineers.Update(dataFromDb);
            await db.SaveChangesAsync();
            http.Response.StatusCode = StatusCodes.Status201Created;
        }

        [SwaggerOperation(
            Summary = "удаляеет одиного электроника")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task DeletEngineerById(ApplicationDbContext db, HttpContext http,
            [SwaggerParameter("Id:Guid", Required = true)]
            Guid id)
        {
            var data = await db.Engineers.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                http.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }
            db.Engineers.Remove(data!);
            await db.SaveChangesAsync();
            http.Response.StatusCode = StatusCodes.Status204NoContent;
        }
    }
    
}
