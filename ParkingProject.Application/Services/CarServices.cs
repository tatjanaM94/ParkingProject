﻿using ParkingProject.Application.Interfaces;
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

        public CarServices(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public Car GetCarById(Guid id)
        {
            var car = _carRepository.GetById(id);
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
            var addCar = _carRepository.GetAll().Where(x => x.Model == car.Model).FirstOrDefault();
            if (addCar!= null)
            {
                throw new Exception("This Car Model already exists");
            }
            car.Id =  Guid.NewGuid();
            _carRepository.Add(car);
            _carRepository.SaveChanges();
        }
    }
}