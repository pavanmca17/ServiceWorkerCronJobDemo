using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceWorkerCronJobDemo.Services;
using ServiceWorkerCronJobDemo.Services.Interface;

namespace ServiceWorkerCronJobDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IProcessService, ProcessService>();

            services.AddCronJob<CreateJobService>(c =>
            {
                // Runs every one mintue
                c.TimeZoneInfo = TimeZoneInfo.Local;
                c.CronExpression = @"*/1 * * * *";
            });
            // MyCronJob2 calls the scoped service MyScopedService
            services.AddCronJob<ProcessJobService>(c =>
            {
                // Runs every two mintue
                c.TimeZoneInfo = TimeZoneInfo.Local;
                c.CronExpression = @"*/2 * * * *";
            });

            services.AddCronJob<RandomJobServie>(c =>
            {
                // Runs every thirty mintues
                c.TimeZoneInfo = TimeZoneInfo.Local;
                c.CronExpression = @"*/3 * * * *";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
