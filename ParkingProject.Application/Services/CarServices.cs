using ParkingProject.Application.Interfaces;
using ParkingProject.Domain.Interfaces;
using ParkingProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingProject.Application.Services
{
    public class CarServices : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IGarageRepository _garageRepository;

        public CarServices(ICarRepository carRepository,IGarageRepository garageRepository)
        {
            _carRepository = carRepository;
            _garageRepository = garageRepository;
        }

        public void Delete(Guid id)
        {
            var car = _carRepository.GetById(id);
            _carRepository.Delete(car);
    
        }

        public void EditCar(Car car)
        {
            _carRepository.Update(car);
       
        }

        public Car GetCarById(Guid id)
        {
            var car = _carRepository.GetById(id);
            var garage = _garageRepository.GetAll().Where(x => x.Id == car.GarageId).FirstOrDefault();
            if (garage != null)
            {
                car.Garage = garage;
            }
            return car;
        }

        public IEnumerable<Car> GetCars()
        {
            var cars = new List<Car>();
            cars = _carRepository.GetAll().ToList();
            return cars;
        }

        public void InsertCar(Car car)
        {

            //car.RegistrationPlates = 
            //    $"{car.Brand.Substring(0, 1).ToUpper()}{car.Model.Substring(0, 1).ToUpper()}-{DateTime.Now.Millisecond}";
            var addCar = _carRepository.GetAll().Where(x => x.Model == car.Model).FirstOrDefault();
            if (addCar!= null)
            {
                throw new Exception("This Car Registration Plate already exists");
            }
            car.Id =  Guid.NewGuid();
            _carRepository.Add(car);
          
        }
    }
}
