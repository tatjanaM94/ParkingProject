using AutoMapper;
using ParkingProject.Domain.Models;
using ParkingProject.MVC.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingProject.MVC.Mappers
{
    public class CarMapper:Profile
    {
        public CarMapper()
        {
            CreateMap<Car, CarViewModel>().ReverseMap();

            CreateMap<IReadOnlyList<Garage>, Garage>();
        }

        
    }
}
