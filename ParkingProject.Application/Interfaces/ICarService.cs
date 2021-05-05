using ParkingProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingProject.Application.Interfaces
{
    public interface ICarService
    {
        IEnumerable<Car> GetCars();
        Car GetCarById(Guid id);

        void InsertCar(Car car);

        // edit car

        void EditCar(Car car);

        // delete car
        void Delete(Guid id);
    }
}
