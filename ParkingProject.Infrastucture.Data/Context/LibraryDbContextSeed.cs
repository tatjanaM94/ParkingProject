using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ParkingProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.Infrastucture.Data.Context
{
    public class LibraryDbContextSeed
    {
        public static async Task SeedAsync(LibraryDbContext libraryDbContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                // NOTE : Only run this if using a real database
                libraryDbContext.Database.Migrate();
                libraryDbContext.Database.EnsureCreated();

                // seed Soaps
                await SeedCarsAsync(libraryDbContext);

            }
            catch (Exception exception)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<LibraryDbContextSeed>();
                    log.LogError(exception.Message);
                    await SeedAsync(libraryDbContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }
        private static async Task SeedCarsAsync(LibraryDbContext libraryDbContext)
        {
            if (libraryDbContext.Cars.Any())
                return;

            var cars = new List<Car>()
            {
                new Car()
                {
                    Id = Guid.NewGuid(),
                    Brand = "Opel",
                    Model = "Corsa",
                    Engine = "V8",
                    Kilometrage = 44,
                    Price = 1400,
                    //RegistrationPlates = "OC-345",
                    Created = DateTime.UtcNow,
                    CreatedBy = "Viktor",
                },
                new Car()
                {
                    Id = Guid.Parse("c475e20a-4a20-4e1a-9b84-149623d68f4f"),
                    Brand = "Citroen",
                    Model = "C4",
                    Engine = "V8",
                    Kilometrage = 44,
                    Price = 1400,
                    //RegistrationPlates = "CC-234",
                    Created = DateTime.UtcNow,
                    CreatedBy = "Viktor",
                }
            };

            libraryDbContext.Cars.AddRange(cars);
            await libraryDbContext.SaveChangesAsync();

        }
    }

}
