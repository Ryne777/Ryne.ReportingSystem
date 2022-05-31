using Ryne.ReportingSystem.Web.Definitions.Base;
using Swashbuckle.AspNetCore.Annotations;

namespace Ryne.ReportingSystem.Web.Endpoints
{
    public class ReportEndpoints : AppDefinition
    {
        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
        {
            app.MapGet("/api/report/", DownLoadFile);
        }



        [SwaggerOperation(
           Summary = "скачать файл отчета",
           Tags = new[] { "ReportEndpoints" })]
        [SwaggerResponse(StatusCodes.Status200OK, "success")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "some failure")]
        private async Task DownLoadFile(HttpContext http)
        {
            var path = @"F:\project\Ryne.ReportingSystem\Ryne.ReportingSystem.ConsoleClient\акты рем. работ 2022.xlsx";
            var contentType = @"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //var downloadName = "2022.xlsx";
            http.Response.ContentType = contentType;            
            await http.Response.SendFileAsync(path);
        }
    }
}
