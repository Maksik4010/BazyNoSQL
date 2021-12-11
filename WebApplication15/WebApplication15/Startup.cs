using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApplication15.Models;
using WebApplication15.Services;

namespace WebApplication15
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
            services.Configure<DatabaseSettings>(
                Configuration.GetSection(nameof(DatabaseSettings)));

            services.AddSingleton<IDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

            services.AddSingleton<PrisonerService>();
            services.AddSingleton<SensorService>();
            services.AddSingleton<ApplicationService>();
            services.AddSingleton<ApplicationTypeService>();
            services.AddSingleton<GuardService>();
            services.AddSingleton<GuiltService>();
            services.AddSingleton<JobService>();
            services.AddSingleton<LocationService>();
            services.AddSingleton<PrisonerJobService>();
            services.AddSingleton<PrisonLocationService>();
            services.AddSingleton<PrisonRankService>();
            services.AddSingleton<PrisonPositionService>();
            services.AddSingleton<ScheduleService>();
            services.AddSingleton<SensorLogService>();
            services.AddSingleton<SensorTypeService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
