using ParkingProject.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingProject.Domain.Models
{
    public class Garage:AuditableBaseEntity
    {

        public string Name { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int MaxCarsInStock { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public string ImgUrl { get; set; }



    }
}
