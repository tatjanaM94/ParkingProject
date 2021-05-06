using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkingProject.Application.Interfaces;
using ParkingProject.Domain.Models;
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
        private readonly IGarageService _garageService;

        public CarsController(ICarService carService, IMapper mapper, IGarageService garageService)
        {
            _carService = carService;
            _mapper = mapper;
            _garageService = garageService;
        }
        public IActionResult Index()
        {
            var allCars = _carService.GetCars();
            return View(_mapper.Map<List<CarViewModel>>(allCars));
           

        }

        public IActionResult Details(Guid id)
        {
            var car = _carService.GetCarById(id);
            
            return View(_mapper.Map<CarViewModel>(car));
        }

        public IActionResult Add()
        {
            var carCreation = new CarViewModel();
            var garages = _garageService.GetGarages();

            carCreation.GaragesList = _mapper.Map<List<SelectListItem>>(garages);

            return View(carCreation);
        }

        [HttpPost]
        public IActionResult Add(CarViewModel carViewModel)
        {
            var carEntityForCreation = _mapper.Map<Car>(carViewModel);
            _carService.InsertCar(carEntityForCreation);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            _carService.Delete(id);
            return RedirectToAction("Index");
            
        }

        public IActionResult Edit(Guid id)
        {
            var car = _carService.GetCarById(id);
            var garages = _garageService.GetGarages();
            var carViewModel = _mapper.Map<CarViewModel>(car);
            carViewModel.GaragesList = _mapper.Map<List<SelectListItem>>(garages);

            return View(carViewModel);

        }

        [HttpPost]
        public IActionResult Edit(CarViewModel carModel)
        {
            var carForEdit = _mapper.Map<Car>(carModel);
            _carService.EditCar(carForEdit);

            return RedirectToAction("Index");
        }
    }
}
