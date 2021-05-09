using ParkingProject.Application.Interfaces;
using ParkingProject.Domain.Interfaces;
using ParkingProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingProject.Application.Services
{
    public class GarageService : IGarageService
    {
        private readonly IGarageRepository _garageRepository;
        private readonly ICarRepository _carRepository;
        public GarageService(IGarageRepository garageRepository, ICarRepository carRepository)
        {
            _garageRepository = garageRepository;
            _carRepository = carRepository;
        }

        public void DeleteGarage(Guid id)
        {
            var garage = _garageRepository.GetById(id);
            var cars = _carRepository.GetAll().Where(x => x.GarageId == id).ToList();

            foreach (var car in cars)
            {
                car.GarageId = Guid.Empty;
            }

            _garageRepository.Delete(garage);           
        }

        public void EditGarage(Garage garage)
        {
            _garageRepository.Update(garage);
           
        }

        public Garage GetGarageById(Guid id)
        {
            var garage = _garageRepository.GetById(id);
            var cars = _carRepository.GetAll().Where(x => x.GarageId == id).ToList();

            if (cars.Count != 0)
            {
                garage.Cars = cars;
            }

            return garage;
        }

        public IEnumerable<Garage> GetGarages()
        {
            var garages = new List<Garage>();
            garages = _garageRepository.GetAll().ToList();
            return garages;
        }

        public void InsertGarage(Garage garage)
        {
            var addGarage = _garageRepository.GetAll().Where(x => x.Name == garage.Name).FirstOrDefault();
           
            if (addGarage!= null)
            {
                throw new Exception("The Garage With That Name Already Exists");
            }
            garage.Id = Guid.NewGuid();
            _garageRepository.Add(garage);
           
        }
    }
}
