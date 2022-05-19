using Ryne.ReportingSystem.Application;
using Ryne.ReportingSystem.Application.Utils;

var def = new DefectoscopeBuilder();
var cd = new CreateDocuments(def.Build());
await cd.CreateActOfRepairWork();

