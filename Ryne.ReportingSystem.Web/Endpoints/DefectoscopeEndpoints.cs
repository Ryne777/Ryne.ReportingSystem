using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ryne.ReportingSystem.Application;
using Ryne.ReportingSystem.Web.Definitions.Base;
using Ryne.ReportingSystem.Web.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ryne.ReportingSystem.Web.Endpoints
{
    public class DefectoscopeEndpoints : AppDefinition
    {
        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
        {
            app.MapGet("/api/defectoscopes", GetListDefectoscopes);
            app.MapGet("/api/defectoscopes/{id:guid}", GetOneDefectoscopById);
            app.MapDelete("/api/defectoscopes/{id:guid}", DeleteDefectoscopeById);
        }

        [SwaggerOperation(
            Summary = "удаляеет один дефектосковоп")]
        [SwaggerResponse(StatusCodes.Status200OK, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]        
        private async Task DeleteDefectoscopeById(ApplicationDbContext db, HttpContext context,
            [SwaggerParameter("Id:Guid", Required = true)]
            Guid id)
        {
            var data = await db.Defectoscopes.FirstOrDefaultAsync(x => x.Id == id);
            db.Defectoscopes.Remove(data!);
            await db.SaveChangesAsync();
        }

        [SwaggerOperation(
            Summary = "возваращает список дефектосковоп")]
        [SwaggerResponse(StatusCodes.Status200OK, "success", typeof(List<DefectoscopeDTO>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task GetListDefectoscopes(ApplicationDbContext db, HttpContext http, IMapper mapper)
        {
            var data = await db.Defectoscopes.ToArrayAsync();
            var DTO = mapper.Map<List<DefectoscopeDTO>>(data);
            await http.Response.WriteAsJsonAsync(DTO);
        }

        [SwaggerOperation(
            Summary = "возваращает один дефектосковоп")]
        [SwaggerResponse(StatusCodes.Status200OK, "success", typeof(DefectoscopeDetailDTO))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task GetOneDefectoscopById(ApplicationDbContext db, HttpContext http, IMapper mapper,
            [SwaggerParameter("Id:Guid", Required = true)]
            Guid id)
        {
            var data = await db.Defectoscopes.FirstOrDefaultAsync(x => x.Id == id);
            var DTO = mapper.Map<DefectoscopeDetailDTO>(data);
            await http.Response.WriteAsJsonAsync(DTO);
        }

    }
}
