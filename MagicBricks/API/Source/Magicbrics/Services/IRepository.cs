using Magicbrics.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magicbrics.Services
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity, int userId);
        void AddRange(IEnumerable<TEntity> entities);

    }

    public class Repository<T> : IRepository<T> where T : class
    {
        public magicbrics2392jeetContext DbContext { get; set; }
        public Repository(magicbrics2392jeetContext Context)
        {
            DbContext = Context;
        }
        public IEnumerable<T> GetAll()
        {
            return DbContext.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return DbContext.Set<T>().Find(id);
        }
        public T Remove(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            DbContext.SaveChanges();
            return entity;
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            DbContext.Set<T>().RemoveRange(entities);
        }

        public T Update(T entity, int userId)
        {
            
            var obj = GetById(userId);
            if (obj != null)
            {
                DbContext.Set<T>().Update(obj);
                DbContext.SaveChanges();
                return obj;
            }
            else return entity;
        }
        public void Add(T entity)
        {
            DbContext.Set<T>().Add(entity);
            DbContext.SaveChanges();
        }
        public void AddRange(IEnumerable<T> entities)
        {
            DbContext.Set<T>().AddRange(entities);
        }
    }
}
