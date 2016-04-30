using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using WebApplication1.Models;
using WebApplication1.IRepository;

namespace WebApplication1.Repository
{
    public class Repository<T1> : IRepositoryBase<T1, Guid> where T1 : Models.ModelWithTracking
    {
        private bool disposed = false;
        private DbContext _dbContext;

        protected List<string> _fieldsIgnoredForSaveExisting = new List<string>();
        protected List<string> _fieldsIgnoredForSaveNew = new List<string>();

        protected virtual bool IsCompositeRepository
        {
            get
            {
                return false;
            }
        }

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
            _fieldsIgnoredForSaveExisting.AddRange(new string[] { "AddedDate" });
        }

        //saving entity
        public virtual T1 Add(T1 entity)
        {
            if (entity != null)
            {
                entity.AddedDate = DateTime.Now;
                BeforeSaveNew(new T1[] { entity });
                _dbContext.Set<T1>().Add(entity);
                _dbContext.SaveChanges();
                AfterSaveNew(new T1[] { entity });
                return entity;
            }
            else
            {
                throw new ArgumentNullException("items can't be null");
            }
        }

        public virtual T1[] Add(T1[] entities)
        {
            foreach (var entity in entities)
            {
                if (!IsCompositeRepository)
                {
                    entity.ID = Guid.NewGuid();
                }
                entity.AddedDate = DateTime.Now;
                _dbContext.Set<T1>().Add(entity);
                IgnoreFieldsForSaveNew(entity);
            }
            _dbContext.SaveChanges();
            AfterSaveNew(entities);
            return entities;
        }

        public virtual T1 Update(T1 entity)
        {
            if (entity != null)
            {
                entity.ModifiedDate = DateTime.Now;
                _dbContext.Set<T1>().Update(entity);

                IgnoreFieldsForSaveExisting(entity);
                this.BeforeSaveExisting(entity);
                _dbContext.SaveChanges();
                AfterSaveExisting(entity);
                return entity;
            }else
            {
                throw new ArgumentNullException("Entity can't be null");
            }
        }

        //finding entity
        public virtual T1 FindById(Guid id)
        {
            return _dbContext.Set<T1>().FirstOrDefault(m => m.ID == id);
        }
        public virtual T1[] FindById(Guid[] ids)
        {
            return _dbContext.Set<T1>().Where(e => ids.Contains(e.ID)).ToArray();
        }

        //list entity
        public virtual IEnumerable<T1> GetAll()
        {
            return _dbContext.Set<T1>();
        }

        //save context changes
        public virtual void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        //delete entity
        public virtual void Remove(T1 entity)
        {
            if (entity != null)
            {
                _dbContext.Set<T1>().Remove(entity);
                _dbContext.SaveChanges();
            }
        }
        public virtual void Remove(T1[] entities)
        {
            foreach (var entity in entities)
            {
                Remove(entity);
            }
            _dbContext.SaveChanges();
        }
        public virtual void Remove(Guid id)
        {
            T1 entity = FindById(id);
            Remove(entity);
        }
        public virtual void Remove(Guid[] ids)
        {
            T1[] entities = FindById(ids);
            Remove(entities);
        }

        //disponse context
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //hooks
        protected virtual void BeforeSaveExisting(T1 entity)
        {
        }

        protected virtual void BeforeSaveExisting(T1[] entity)
        {
        }
        protected virtual void BeforeSaveNew(T1[] entity)
        {
        }
        protected virtual void AfterSaveNew(T1[] entity)
        {

        }
        protected virtual void AfterSaveExisting(T1 entity)
        {
        }

        protected void IgnoreFieldsForSaveExisting(T1 entity)
        {
            foreach (string field in this._fieldsIgnoredForSaveExisting)
            {
                _dbContext.Entry(entity).Property(field).IsModified = false;
            }
        }
        protected void IgnoreFieldsForSaveNew(T1 entity)
        {
            foreach (string field in this._fieldsIgnoredForSaveNew)
            {
                _dbContext.Entry(entity).Property(field).IsModified = false;
            }
        }
    }
}
