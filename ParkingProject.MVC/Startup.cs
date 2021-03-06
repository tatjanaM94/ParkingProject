using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParkingProject.Application.Interfaces;
using ParkingProject.Infrastructure.IoC;
using ParkingProject.Infrastucture.Data.Context;
using ParkingProject.MVC.Mappers;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingProject.MVC
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

            services.AddResponseCaching();

            services.AddMemoryCache();

            services.AddControllersWithViews();


            services.AddDbContext<LibraryDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MyConnectionString")));

            services.AddIoCService();

            services.AddAutoMapper(typeof(GarageMapper));
            services.AddAutoMapper(typeof(CarMapper));

            services.AddHttpContextAccessor();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IServiceProvider serviceProvider)
        {
            var parkingProject = serviceProvider.GetService<IParkingProject_Inicialize>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseResponseCaching();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSerilogRequestLogging();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
          
            
            parkingProject.InitializeGarage();
           
            parkingProject.InicializeCars();
        }
    }
}
