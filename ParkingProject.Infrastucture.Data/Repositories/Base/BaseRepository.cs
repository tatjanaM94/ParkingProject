using Microsoft.EntityFrameworkCore;
using ParkingProject.Domain.Interfaces.Base;
using ParkingProject.Infrastucture.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingProject.Infrastucture.Data.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        
        private readonly LibraryDbContext _dbContext;
        public BaseRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public IReadOnlyList<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
