using ParkingProject.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingProject.Domain.Models
{
     public  class Car:AuditableBaseEntity
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Kilometrage { get; set; }
        public string Engine { get; set; }
        public int Price { get; set; }
        public string ImgUrl { get; set; }


        public Guid GarageId { get; set; }

        public virtual Garage Garage { get; set; }

    }
}
