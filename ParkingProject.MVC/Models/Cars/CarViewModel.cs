using Microsoft.AspNetCore.Mvc.Rendering;
using ParkingProject.MVC.Models.Garages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingProject.MVC.Models.Cars
{
    public class CarViewModel
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Kilometrage { get; set; }
        public string Engine { get; set; }
        public int Price { get; set; }
        public string ImgUrl { get; set; }

        public string RegistrationPlate { get; set; }


        public Guid GarageId { get; set; }

        public GarageViewModel Garage { get; set; }

        public List<SelectListItem> GaragesList { get; set; }

       
    }
}
