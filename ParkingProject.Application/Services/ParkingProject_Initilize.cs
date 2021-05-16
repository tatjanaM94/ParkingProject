using ParkingProject.Application.Interfaces;
using ParkingProject.Domain.Interfaces;
using ParkingProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingProject.Application.Services
{
    public class ParkingProject_Initilize : IParkingProject_Inicialize
    {

        private readonly ICarRepository _carRepository;
        private readonly IGarageRepository _garageRepository;

        public ParkingProject_Initilize(ICarRepository carRepository, IGarageRepository garageRepository)
        {
            _carRepository = carRepository;
            _garageRepository = garageRepository;
        }
        public void InicializeCars()
        {
            var cars = _carRepository.GetAll();

            if (cars.Count == 0)
            {
                var car1 = new Car()
                {
                    //Id = Guid.NewGuid(),
                    Id = Guid.NewGuid(),
                    GarageId = Guid.Parse("8b3c08d1-37fb-4879-9fb1-f456e366a030"),
                    Brand = "Opel",
                    Model = "Corsa",
                    Engine = "V8",
                    Kilometrage = 44,
                    Price = 1400,                  
                    Created = DateTime.UtcNow,
                    CreatedBy = "Tatjana",

                };
                _carRepository.Add(car1);


                var car2 = new Car()
                {
                    Id = Guid.NewGuid(),
                    GarageId = Guid.Parse("e1a4cfd6-14b2-4aec-aa93-8822f0b84a46"),
                    Brand = "Citroen",
                    Model = "C4",
                    Engine = "V8",
                    Kilometrage = 44,
                    Price = 1400,                  
                    Created = DateTime.UtcNow,
                    CreatedBy = "Tatjana",
                };
              
                _carRepository.Add(car2);
            }
        }

        public void InitializeGarage()
        {
            var garage = _garageRepository.GetAll();
            if (garage.Count == 0)
            {

                var garage1 = new Garage()
                {
                    Id = Guid.Parse("8b3c08d1-37fb-4879-9fb1-f456e366a030"), 
                    Name = "ГАРАЖА",
                    Address = "Street-OT",
                    Email = "garage@email.com",
                    PhoneNumber = "464846466",
                    MaxCarsInStock = 50,
                    CreatedBy = "Tatjana",
                    Created = DateTime.UtcNow
                };

                _garageRepository.Add(garage1);

                var garage2 = new Garage()
                {
                    Id = Guid.Parse("e1a4cfd6-14b2-4aec-aa93-8822f0b84a46"),
                    Name = "НЕ ПАРКИРАЈ",
                    Address = "Car-OT",
                    Email = "some@email.com",
                    PhoneNumber = "5465464",
                    MaxCarsInStock = 51,                 
                    CreatedBy = "Tatjana",
                    Created = DateTime.UtcNow
                };

                _garageRepository.Add(garage2);
            }
        }
    }
}
