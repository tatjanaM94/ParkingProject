using AutoMapper;
using ParkingProject.Domain.Models;
using ParkingProject.MVC.Models.Garages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingProject.MVC.Mappers
{
    public class GarageMapper  :  Profile
    {
        public GarageMapper()
        {
            CreateMap<Garage, GarageViewModel>().ReverseMap();
        }
    }
}
