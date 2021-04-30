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
        public Garage GetGarageById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Garage> GetGarages()
        {
            var garages = new List<Garage>();
            garages = _garageRepository.GetAll().ToList();
            return garages;
        }
    }
}
