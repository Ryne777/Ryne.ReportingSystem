using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Moq;
using Ryne.ReportingSystem.Application.Models;
using Ryne.ReportingSystem.Application.Service.Interfaces;
using Ryne.ReportingSystem.Web.Endpoints;


namespace Ryne.ReportingSystem.Tests.Infrastructure
{
    public class TestDefectoscopeApplication: WebApplicationFactory<DefectoscopeEndpoints>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var mock = new Mock<IDefectoscopeService>();
            mock.Setup(ser => ser.GetList()).Returns(Task.FromResult(TestDefList()));
            mock.Setup(ser => ser.GetById(Guid.Parse("936DA01F-9ABD-4d9d-80C7-02AF85C822A8"))).Returns(Task.FromResult(OneDefTest()));
            mock.Setup(ser => ser.CreateOne(OneDefCreateTest())).Returns(Task.FromResult(true));
            var serviceDescriptor = new ServiceDescriptor(typeof(IDefectoscopeService), mock.Object);
            builder.ConfigureServices(services =>
            {
                services.Replace(serviceDescriptor); ;
            });

            return base.CreateHost(builder);
        }

        public static DefectoscopeCreateDTO OneDefCreateTest()
        {
            return new DefectoscopeCreateDTO
            {
                OrganizationId = Guid.NewGuid(),
                ProductionYear = 233,
                SerialNumber = "dff",
                TypeOfDefectoscopeId = Guid.NewGuid()

            };
        }

        public static DefectoscopeDetailDTO OneDefTest()
        {
            return new DefectoscopeDetailDTO
            {
                Id =  Guid.Parse("936DA01F-9ABD-4d9d-80C7-02AF85C822A8"),
                OrganizationId = Guid.NewGuid(),
                OrganizationName = "dff",
                ProductionYear = 23,
                Repairs = new List<RepairDTO>(),
                SerialNumber = "df",
                TypeOfDefectoscopeId = Guid.NewGuid(),
                TypeOfDefectoscopeName = "er"
            };
        }

        public static List<DefectoscopeDTO> TestDefList()
        {
            var def = new DefectoscopeDTO
            {
                Id = Guid.Parse("936DA01F-9ABD-4d9d-80C7-02AF85C822A8"),
                OrganizationName = "dfff",
                ProductionYear = 2022,
                SerialNumber = "2333",
                TypeOfDefectoscopeName = "sdff"
            };
            return new List<DefectoscopeDTO> {
                def
            };
        }
    }
}
