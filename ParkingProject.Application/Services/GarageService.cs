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
        public GarageService(IGarageRepository garageRepository)
        {
            _garageRepository = garageRepository;
        }

        public void DeleteGarage(Guid id)
        {
            var garage = _garageRepository.GetById(id);
            _garageRepository.Delete(garage);
            _garageRepository.SaveChanges();
        }

        public void EditGarage(Garage garage)
        {
            _garageRepository.Update(garage);
            _garageRepository.SaveChanges();
        }

        public Garage GetGarageById(Guid id)
        {
            var garage = _garageRepository.GetById(id);
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
            _garageRepository.SaveChanges();
        }
    }
}
