using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParkingProject.Application.Interfaces;
using ParkingProject.MVC.Models.Garages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingProject.MVC.Controllers
{
    public class GaragesController : Controller
    {
        private readonly IGarageService _garageService;
        private readonly IMapper _mapper;

        public GaragesController(IGarageService garageService, IMapper mapper)
        {
            _garageService = garageService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var allGarages = _garageService.GetGarages();
            return View(_mapper.Map<List<GarageViewModel>>(allGarages));

        }

        public IActionResult Details(Guid id)
        {
            var garage = _garageService.GetGarageById(id);
            return View(_mapper.Map<GarageViewModel>(garage));
        }

        public IActionResult Add()
        {
            var garageCreation = new GarageViewModel();

            return View(garageCreation);
        }
    }
}
