using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
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
        private IMemoryCache _memoryCache;
        private string _allCarsKey = "All_Cars_Cache";
        private IMapper _mapper;
        public CarServices(ICarRepository carRepository,IGarageRepository garageRepository,IMemoryCache memoryCache, IMapper mapper)
        {
            _carRepository = carRepository;
            _garageRepository = garageRepository;
            _memoryCache = memoryCache;
            _mapper = mapper;
        }

        public void Delete(Guid id)
        {
            var car = _carRepository.GetById(id);
            _carRepository.Delete(car);
            _memoryCache.Remove(_allCarsKey);
    
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
            List<Car> cars;
            cars = (List<Car>)_memoryCache.Get(_allCarsKey);

            if (cars == null)
            {
                var carEntity = _carRepository.GetAll();
                cars = _mapper.Map<List<Car>>(carEntity);

                _memoryCache.Set(_allCarsKey, cars, new MemoryCacheEntryOptions().
                    SetSlidingExpiration(TimeSpan.FromSeconds(40)).
                    SetAbsoluteExpiration(TimeSpan.FromSeconds(120)));
            }
            return cars;
        }

        public void InsertCar(Car car)
        {

            car.RegistrationPlate =
                $"{car.Brand.Substring(0, 1).ToUpper()}{car.Model.Substring(0, 1).ToUpper()}-{DateTime.Now.Millisecond}";
            var addCar = _carRepository.GetAll().Where(x => x.RegistrationPlate == car.RegistrationPlate).FirstOrDefault();
            if (addCar!= null)
            {
                throw new Exception("This Car Registration Plate already exists");
            }
            car.Id =  Guid.NewGuid();
            _carRepository.Add(car);
            _memoryCache.Remove(_allCarsKey);
          
        }
    }
}
