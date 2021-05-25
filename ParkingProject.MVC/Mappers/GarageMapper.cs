using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            CreateMap<Garage, SelectListItem>()
                    .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id.ToString()))
                    .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name.ToString()))
                    .ReverseMap();

            CreateMap<IReadOnlyList<Garage>, Garage>();
        }
    }
}
