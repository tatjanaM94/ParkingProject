using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingProject.MVC.Models.Garages
{
    public class GarageViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int MaxCarsInStock { get; set; }
       // public virtual ICollection<Car> Cars { get; set; }
        public string ImgUrl { get; set; }
    }
}
