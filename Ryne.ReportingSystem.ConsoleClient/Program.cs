using Ryne.ReportingSystem.Application;

var def = new DefectoscopeBuilder();
var rep = new RepairBuilder();
def.AddTypeOfDefectoscope(new Ryne.ReportingSystem.Entity.TypeOfDefectoscope() { Name = "1234"})
    .AddSerialNumber("21200")
    .AddOrganization(new Ryne.ReportingSystem.Entity.Organization() { Name = "pch12"})
    .AddTypeOfDefectoscope(new Ryne.ReportingSystem.Entity.TypeOfDefectoscope() { Name = "RDM12"})
    .AddRepair(rep
    .AddEngineer(new Ryne.ReportingSystem.Entity.Engineer() { Name = "dff"})
    .AddTypeOfRepair(Ryne.ReportingSystem.Entity.TypeOfRepair.TR1)
    .AddDateReceipt(DateTime.Now)
    .AddDateOfLastRepair(DateTime.Now)
    .AddDateRelease(DateTime.Now)
    .AddDateOfCalibration(DateTime.Now)
    .Bulid()
    );
var defec = def.Build();
////using var context = new ApplicationDbContext(options =>
////{
////    options.Database.EnsureCreated();
////});
//await context.Defectoscopes.AddAsync(defec);
//await context.SaveChangesAsync();
Console.WriteLine(defec);

