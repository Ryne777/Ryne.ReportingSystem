using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ryne.ReportingSystem.Application;
using Ryne.ReportingSystem.Application.Models;
using Ryne.ReportingSystem.Entity;
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
        private async Task GetListTypeOfDefectoscope(ApplicationDbContext db, HttpContext http, IMapper mapper)
        {
            var data = await db.TypeOfDefectoscopes.ToArrayAsync();
            var DTO = mapper.Map<List<TypeOfDefectoscopeDTO>>(data);
            await http.Response.WriteAsJsonAsync(DTO);
        }

        [SwaggerOperation(
           Summary = "возваращает один тип дефектоскопов")]
        [SwaggerResponse(StatusCodes.Status200OK, "success", typeof(TypeOfDefectoscopeDetailDTO))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task GetOneTypeOfDefectoscopeById(ApplicationDbContext db, HttpContext http, IMapper mapper,
           [SwaggerParameter("Id:Guid", Required = true)]
            Guid id)
        {
            var data = await db.TypeOfDefectoscopes.FirstOrDefaultAsync(x => x.Id == id);
            var DTO = mapper.Map<TypeOfDefectoscopeDetailDTO>(data);
            await http.Response.WriteAsJsonAsync(DTO);
        }

        [SwaggerOperation(
            Summary = "создает тип дефектоскопов")]
        [SwaggerResponse(StatusCodes.Status201Created, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task CreateTypeOfDefectoscope(ApplicationDbContext db, HttpContext http, IMapper mapper, 
            [SwaggerRequestBody(
                Required = true
            )]
        TypeOfDefectoscopeCreateDTO DTO)
        {            
            var data = mapper.Map<TypeOfDefectoscope>(DTO);            
            await db.TypeOfDefectoscopes.AddAsync(data);
            await db.SaveChangesAsync();
            http.Response.StatusCode = StatusCodes.Status201Created;
        }

        [SwaggerOperation(
            Summary = "обновляет тип дефектоскопа")]
        [SwaggerResponse(StatusCodes.Status201Created, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task  UpdateTypeOfDefectoscope(ApplicationDbContext db, HttpContext http, IMapper mapper,
            [SwaggerRequestBody(
                Required = true
            )]
        TypeOfDefectoscopeUpdateDTO DTO,
            [SwaggerParameter("Id:Guid", Required = true)]
            Guid id)
        {
            var dataFromDb = await db.TypeOfDefectoscopes.FirstOrDefaultAsync(x => x.Id == id);
            if (dataFromDb == null)
            {
                http.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }            
            dataFromDb.Name = DTO.Name;
            db.TypeOfDefectoscopes.Update(dataFromDb);
            await db.SaveChangesAsync();
            http.Response.StatusCode = StatusCodes.Status201Created;
        }

        [SwaggerOperation(
            Summary = "удаляеет один тип дефектоскопа")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task DeletTypeOfDefectoscopeById(ApplicationDbContext db, HttpContext http,
            [SwaggerParameter("Id:Guid", Required = true)]
            Guid id)
        {
            var data = await db.TypeOfDefectoscopes.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                http.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }
            db.TypeOfDefectoscopes.Remove(data!);
            await db.SaveChangesAsync();
            http.Response.StatusCode = StatusCodes.Status204NoContent;
        }
    }
}
