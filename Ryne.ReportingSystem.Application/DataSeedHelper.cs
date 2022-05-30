using Microsoft.Extensions.DependencyInjection;
using Ryne.ReportingSystem.Application;

namespace Ryne.ReportingSystem.Web.Helpers
{
    public class DataSeedHelper
    {
        public static async void Seed(IServiceProvider serviceProvider)
        {

            // create a scope
            using var scope = serviceProvider.CreateScope();
            // then resolve the services and execute it
            await using var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            if (!context!.Defectoscopes.Any())
            {
                var _defectoscopeBuilder = new DefectoscopeBuilder();
                var _repairBuilder = new RepairBuilder();
                var org = new Entity.Organization() { Id = Guid.NewGuid(), Name = "pch12" };
                var type = new Entity.TypeOfDefectoscope() { Id = Guid.NewGuid(), Name = "RDM12" };
                var en = new Entity.Engineer() { Id = Guid.NewGuid(), Name = "dff" };
                var rep = _repairBuilder
                .AddEngineer(en)
                .AddTypeOfRepair(Ryne.ReportingSystem.Entity.TypeOfRepair.TR1)
                .AddDateReceipt(DateTime.Now)
                .AddDateOfLastRepair(DateTime.Now)
                .AddDateRelease(DateTime.Now)
                .AddDateOfCalibration(DateTime.Now)
                .Bulid();
                _defectoscopeBuilder
                .AddSerialNumber("21200")
                .AddOrganization(org)
                .AddTypeOfDefectoscope(type)
                .AddProductionYear(2010)
                .AddRepair(rep
                );
                var def = _defectoscopeBuilder.Build();                
                await context.Defectoscopes.AddAsync(def);
                await context.SaveChangesAsync();
            }
        }


    }
}
