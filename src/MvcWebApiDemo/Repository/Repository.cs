using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class Repository<T1> : IRepository<T1, Guid> where T1 : ModelBase
    {
        private DbContext _dbContext;

        public DbSet<T1> DbSet
        {
            get
            {
                return _dbContext.Set<T1>();
            }
        }

        public DbContext DbContext
        {
            set
            {
                _dbContext = value;
            }
            get
            {
                return _dbContext;
            }
        }

        public Repository()
        {
        }

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual void Add(T1 entity)
        {
            if (entity != null)
            {
                entity.AddedDate = DateTime.Now;
                _dbContext.Set<T1>().Add(entity);
                _dbContext.SaveChanges();
            }
        }

        public virtual T1 FindById(Guid id)
        {
            return _dbContext.Set<T1>().Where(m => m.ID == id).SingleOrDefault();
        }

        public virtual IEnumerable<T1> GetAll()
        {
            return _dbContext.Set<T1>();
        }

        public virtual void Remove(T1 entity)
        {
            if (entity != null)
            {
                _dbContext.Set<T1>().Remove(entity);
                _dbContext.SaveChanges();
            }
        }

        public virtual void Update(T1 entity)
        {
            if (entity != null)
            {
                entity.ModifiedDate = DateTime.Now;
                _dbContext.Set<T1>().Update(entity);
                _dbContext.SaveChanges();
            }
        }

        public virtual void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
