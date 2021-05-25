using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParkingProject.Application.Interfaces;
using ParkingProject.Domain.Models;
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

        [ResponseCache(Duration = 15, VaryByQueryKeys = new string[] { "id"})]
        public IActionResult Details(Guid id)
        {
            var garage = _garageService.GetGarageById(id);
            return View(_mapper.Map<GarageViewModel>(garage));
        }

        public IActionResult Add()
        {
            var garageViewModelForCreation = new GarageViewModel();
            return View(garageViewModelForCreation);
        }

        [HttpPost]
        public IActionResult Add(GarageViewModel model)
        {
            var garageEntityForCreation = _mapper.Map<Garage>(model);
            _garageService.InsertGarage(garageEntityForCreation);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            _garageService.DeleteGarage(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            var garage = _garageService.GetGarageById(id);
            return View(_mapper.Map<GarageViewModel>(garage));
        }

        [HttpPost]
        public IActionResult Edit(GarageViewModel model)
        {
            var garageForEdit = _mapper.Map<Garage>(model);
            _garageService.EditGarage(garageForEdit);

            return RedirectToAction("Index");

        }

        
    }
}
