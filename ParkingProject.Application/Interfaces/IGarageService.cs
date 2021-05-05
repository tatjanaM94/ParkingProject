using ParkingProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingProject.Application.Interfaces
{
    public interface IGarageService
    {
        IEnumerable<Garage> GetGarages();
        Garage GetGarageById(Guid id);

        void InsertGarage(Garage garage);

        //edit method
        void EditGarage(Garage garage);

        // delete method

        void DeleteGarage(Guid id);

    }
}
