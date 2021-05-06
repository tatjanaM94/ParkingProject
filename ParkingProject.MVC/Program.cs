using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
    }
}
