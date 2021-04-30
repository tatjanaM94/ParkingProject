using Microsoft.EntityFrameworkCore;
using ParkingProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingProject.Infrastucture.Data.Context
{
   public  class LibraryDbContext:DbContext
    {
        public LibraryDbContext()
        {

        }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> dbContextOptions) : base (dbContextOptions)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Garage> Garages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasOne(x => x.Garage).WithMany(x => x.Cars).HasForeignKey(x => x.GarageId);
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
