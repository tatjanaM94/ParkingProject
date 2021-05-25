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
    public class GarageService : IGarageService
    {
        private readonly IGarageRepository _garageRepository;
        private readonly ICarRepository _carRepository;
        private IMemoryCache _memoryCache;
        private string _allGaragesKey = "All_Garage_Cache";
        private IMapper _mapper;
        
        public GarageService(IGarageRepository garageRepository, ICarRepository carRepository,IMemoryCache memoryCache,IMapper mapper)
        {
            _garageRepository = garageRepository;
            _carRepository = carRepository;
            _memoryCache = memoryCache;
            _mapper = mapper;
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
            _memoryCache.Remove(_allGaragesKey);
        }

        public void EditGarage(Garage garage)
        {
            _garageRepository.Update(garage);
            _memoryCache.Remove(_allGaragesKey);
           
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
            List<Garage> garages;
            garages = (List<Garage>)_memoryCache.Get(_allGaragesKey);
      
            if (garages == null)
            {
                var garagesEntity = _garageRepository.GetAll();
                garages = _mapper.Map<List<Garage>>(garagesEntity);
               
                _memoryCache.Set(_allGaragesKey, garages, new MemoryCacheEntryOptions().
                    SetSlidingExpiration(TimeSpan.FromSeconds(40)).
                    SetAbsoluteExpiration(TimeSpan.FromSeconds(120)));               
            }
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

            _memoryCache.Remove(_allGaragesKey);

        }
    }
}
