﻿using Ryne.ReportingSystem.Web.Definitions.Base;

namespace Ryne.ReportingSystem.Web.Definitions.Mapping
{
    public class AutoMapperDefinition: AppDefinition
    {
        /// <summary>
        /// Configure services for current microservice
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
            => services.AddAutoMapper(typeof(Program));

        /// <summary>
        /// Configure application for current microservice
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment env)
        {
            var mapper = app.Services.GetRequiredService<AutoMapper.IConfigurationProvider>();
            if (env.IsDevelopment())
            {
                // validate Mapper Configuration
                //mapper.AssertConfigurationIsValid();
            }
            else
            {
                mapper.CompileMappings();
            }
        }
    }
}
