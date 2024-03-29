﻿using Microsoft.AspNetCore.Http.Json;
using Ryne.ReportingSystem.Web.Definitions.Base;
using System.Net;
using System.Text.Json.Serialization;

namespace Ryne.ReportingSystem.Web.Definitions.Common
{
    public class CommonDefinition : AppDefinition
    {

        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddRazorPages()
                .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            //TODO:избавиться от этой опции
            services.Configure<JsonOptions>(options =>
            {
                options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;                
            });
            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
                options.HttpsPort = 5001;
            });
            services.AddCors();
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
                
            });

        }
        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                

            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors(builder => {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();                
            });

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();         
            

        }
    }
}
