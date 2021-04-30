using ParkingProject.Domain.Interfaces;
using ParkingProject.Domain.Models;
using ParkingProject.Infrastucture.Data.Context;
using ParkingProject.Infrastucture.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingProject.Infrastucture.Data.Repositories
{
    public class GarageRepository:BaseRepository<Garage>,IGarageRepository
    {
        public GarageRepository(LibraryDbContext libraryDbContext ):base(libraryDbContext)
        {

        }
    }
}
