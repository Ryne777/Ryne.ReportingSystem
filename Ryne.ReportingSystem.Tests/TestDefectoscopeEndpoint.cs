using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Ryne.ReportingSystem.Application.Models;
using Ryne.ReportingSystem.Application.Service.Interfaces;
using Ryne.ReportingSystem.Web.Endpoints;
using System.Net;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Ryne.ReportingSystem.Tests.Infrastructure;
using System.Text;

namespace Ryne.ReportingSystem.Tests
{
    public class TestDefectoscopeEndpoint
    {
        [Fact]
        public async Task TestDefectoscopeGetListEndpointAsync()
        {
            await using var application = new TestDefectoscopeApplication();
            using var client = application.CreateClient();

            var response = await client.GetAsync("/api/defectoscopes");
            var returnedJson = await response.Content.ReadAsStringAsync();
            var returnedDefectoscopes = JsonSerializer.Deserialize<List<DefectoscopeDTO>>(returnedJson);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(returnedDefectoscopes);
        }


        [Fact]
        public async Task TestDefectoscopeGetOneEndpointAsync()
        {
            await using var application = new TestDefectoscopeApplication();
            using var client = application.CreateClient();
            var response = await client.GetAsync("/api/defectoscopes/936DA01F-9ABD-4d9d-80C7-02AF85C822A8");
            var returnedJson = await response.Content.ReadAsStringAsync();
            var returnedDefectoscopes = JsonSerializer.Deserialize<DefectoscopeDetailDTO>(returnedJson);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(returnedDefectoscopes);
        }

        [Fact]
        public async Task TestDefectoscopeCreateEndpointAsync()
        {
            await using var application = new TestDefectoscopeApplication();
            using var client = application.CreateClient();
            var response = await client.PostAsync("/api/defectoscopes/", 
                new StringContent(
                    JsonSerializer.Serialize(TestDefectoscopeApplication.OneDefCreateTest()), 
                    Encoding.UTF32, 
                    "application/json"));                       

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            
        }
    }
    }