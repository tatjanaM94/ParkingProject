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


        public Guid GarageId { get; set; }

       // public virtual Garage Garage { get; set; }
    }
}
