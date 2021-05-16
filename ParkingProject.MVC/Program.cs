using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ParkingProject.Infrastucture.Data.Context;
using Serilog;
using Serilog.Formatting.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingProject.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var confiq = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(confiq)
                .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp} {Message}{NewLine:1}{Exception:1}")
                .WriteTo.File(new JsonFormatter(), "Logs/log.json", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                Log.Information("Application Started!!!");

                CreateHostBuilder(args).Build().Run();
                
            }
            catch (Exception ex)
            {
                Log.Error(ex, "The Application failed to start!");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        //private static void SeedDatabase(IHost host)
        //{
        //    using (var scope = host.Services.CreateScope())
        //    {
        //        var services = scope.ServiceProvider;
        //        var loggerFactory = services.GetRequiredService<ILoggerFactory>();

        //        try
        //        {
        //            var libraryDbContext = services.GetRequiredService<LibraryDbContext>();
        //            LibraryDbContextSeed.SeedAsync(libraryDbContext, loggerFactory).Wait();
        //        }
        //        catch (Exception exception)
        //        {
        //            var logger = loggerFactory.CreateLogger<Program>();
        //            logger.LogError(exception, "An error occurred seeding the DB.");
        //        }
        //    }
        //}
    }
}
