using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SAPexSchedulerService.Data;
using SAPexSchedulerService.Repositories;
using SAPexSchedulerService.Services;

namespace SAPexSchedulerService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<AppDbContext>();
            services.AddHangfire(x => x.UseSqlServerStorage(Environment.GetEnvironmentVariable("MSSQL_HANGFIRE_CONNECTION_STRING")));
            services.AddHangfireServer();
            services.AddScoped<ISandboxRepository, SandboxRepository>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IStatusService statusService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var options = new DashboardOptions
            {
                Authorization = new[] {
                    new DashboardAuthorization(new[]
                    {
                        new HangfireUserCredentials
                        {
                            Username = "admin@gmail.com",
                            Password = "admin123456"
                        }
                    })
                }
            };
            app.UseHangfireDashboard("/hangfire", options);
            RecurringJob.AddOrUpdate(() => statusService.StatusJob(), Cron.Minutely);
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
