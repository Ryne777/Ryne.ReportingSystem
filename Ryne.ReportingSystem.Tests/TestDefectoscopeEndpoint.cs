using Microsoft.AspNetCore.Mvc.Testing;
using Ryne.ReportingSystem.Application.Models;
using Ryne.ReportingSystem.Web.Endpoints;
using System.Net;
using System.Text.Json;


namespace Ryne.ReportingSystem.Tests
{
    public class TestDefectoscopeEndpoint
    {
        [Fact]
        public async Task TestDefectoscopeGetListEndpointAsync()
        {
            await using var application = new WebApplicationFactory<DefectoscopeEndpoints>();
            using var client = application.CreateClient();

            var response = await client.GetAsync("/api/defectoscopes");
            var returnedJson = await response.Content.ReadAsStringAsync();
            var returnedDefectoscopes = JsonSerializer.Deserialize<List<DefectoscopeDTO>>(returnedJson);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(returnedDefectoscopes);
        }
        public async Task TestDefectoscopeGetOneEndpointAsync()
        {
            await using var application = new WebApplicationFactory<DefectoscopeEndpoints>();
            using var client = application.CreateClient();
            //TODO: tests
            var response = await client.GetAsync("/api/defectoscopes/");
            var returnedJson = await response.Content.ReadAsStringAsync();
            var returnedDefectoscopes = JsonSerializer.Deserialize<List<DefectoscopeDetailDTO>>(returnedJson);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(returnedDefectoscopes);
        }
    }
}