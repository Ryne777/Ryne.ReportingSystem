using Microsoft.AspNetCore.Server.Kestrel.Core;
using Ryne.ReportingSystem.Web.Definitions.Base;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefinitions(builder, typeof(Program));

var app = builder.Build();
app.UseDefinitions();

app.Logger.LogInformation("The app started");
app.Run();