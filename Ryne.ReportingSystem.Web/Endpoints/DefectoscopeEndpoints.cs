using Microsoft.EntityFrameworkCore;
using Ryne.ReportingSystem.Application;
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
            app.MapDelete("/api/defectoscopes/{id:guid}", DeleteDefectoscopeById);
        }

        [SwaggerOperation(
            Summary = "удаляеет один дефектосковоп")]
        [SwaggerResponse(201, "success")]
        [SwaggerResponse(500, "some failure")]
        private async Task DeleteDefectoscopeById(ApplicationDbContext db, HttpContext context,
            [SwaggerParameter("Id:Guid", Required = true)]
            Guid id)
        {
            db.Defectoscopes.Remove(db.Defectoscopes.FindAsync(id).Result);
            await db.SaveChangesAsync();
        }

        [SwaggerOperation(
            Summary = "возваращает список дефектосковоп")]
        [SwaggerResponse(200, "success")]
        [SwaggerResponse(500, "some failure")]
        private async Task GetListDefectoscopes(ApplicationDbContext db, HttpContext http)
        {
            await http.Response.WriteAsJsonAsync(db.Defectoscopes.Select(x => new
            {
                x.Id,
                type_of_defectoscope = x.TypeOfDefectoscope.Name,
                x.SerialNumber,
                x.ProductionYear,
                organizition_name = x.Organization.Name,
                repairs = x.Repairs.Select(r => new
                {
                    engineer_name = r.Engineer.Name,
                    r.DateOfCalibration,
                    r.DateOfReceipt,
                    r.DateOfRelease,
                    type_of_repair = r.TypeOfRepair.ToString()
                }).ToArray()
            }).ToArrayAsync().Result);
        }

        [SwaggerOperation(
            Summary = "возваращает один дефектосковоп")]
        [SwaggerResponse(200, "success")]
        [SwaggerResponse(500, "some failure")]
        private async Task GetOneDefectoscopById(ApplicationDbContext db, HttpContext http,
            [SwaggerParameter("Id:Guid", Required = true)]
            Guid id)
        {
            await http.Response.WriteAsJsonAsync(db.Defectoscopes.Where(x => x.Id == id).Select(x => new
            {
                x.Id,
                type_of_defectoscope = x.TypeOfDefectoscope.Name,
                x.SerialNumber,
                x.ProductionYear,
                organizition_name = x.Organization.Name,
                repairs = x.Repairs.Select(r => new
                {
                    engineer_name = r.Engineer.Name,
                    r.DateOfCalibration,
                    r.DateOfReceipt,
                    r.DateOfRelease,
                    type_of_repair = r.TypeOfRepair.ToString()
                }).ToArray()
            }).FirstAsync().Result);
        }

    }
}
