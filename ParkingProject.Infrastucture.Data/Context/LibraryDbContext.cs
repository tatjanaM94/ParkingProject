using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ParkingProject.Domain.Models;
using ParkingProject.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingProject.Infrastucture.Data.Context
{
   
    public  class LibraryDbContext:DbContext
    {
        private IHttpContextAccessor _httpContextAccessor;
        public LibraryDbContext()
        {

        }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> dbContextOptions,IHttpContextAccessor httpContextAccessor) : base (dbContextOptions)
        {
            _httpContextAccessor = httpContextAccessor;
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

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableBaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditableBaseEntity)entityEntry.Entity).Created = DateTime.UtcNow;
                    ((AuditableBaseEntity)entityEntry.Entity).CreatedBy = this._httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "MyApp";
                }
                else
                {
                    Entry((AuditableBaseEntity)entityEntry.Entity).Property(p => p.Created).IsModified = false;
                    Entry((AuditableBaseEntity)entityEntry.Entity).Property(p => p.CreatedBy).IsModified = false;
                }

                ((AuditableBaseEntity)entityEntry.Entity).LastModified = DateTime.UtcNow;
                ((AuditableBaseEntity)entityEntry.Entity).LastModifiedBy = this._httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "MyApp";
            }
            return base.SaveChanges();
        }
    }
}
