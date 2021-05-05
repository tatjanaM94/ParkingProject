using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParkingProject.Application.Interfaces;
using ParkingProject.MVC.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingProject.MVC.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CarsController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var allCars = _carService.GetCars();
            return View(_mapper.Map<List<CarViewModel>>(allCars));
           
        }
    }
}
