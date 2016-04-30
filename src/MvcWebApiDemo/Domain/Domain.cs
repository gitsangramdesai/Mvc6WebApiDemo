using System;
using WebApplication1.IDomain;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.IRepository;

namespace WebApplication1.Domain
{
    public abstract class ProcessBase
    {
        public IRepository.IInstanceActivator RepositoryInstanceActivator { get; set; }
        public IDomain.IInstanceActivator InstanceActivator { get; set; }
        public Models.Identity CurrentUserIdentity { get; set; }
    }

    public abstract class ProcessBase<T>: ProcessBase, IDomain.OperationSet where T : IRepository.IRepository
    {
        protected T _repository;
        protected IDomain.IInstanceActivator _instanceActivator;

        protected ProcessBase(T repository)
        {
            _repository = repository;
        }
    }

    public abstract class ProcessBaseWithStorageOperations<TRepository, TModel> : 
        ProcessBase<TRepository>,OperationSetWithStorageOperations<TModel> 
        where TRepository : IRepositoryBase<TModel,Guid>  where TModel : WebApplication1.Models.ModelWithTracking
    {
        protected ProcessBaseWithStorageOperations(TRepository repository) : base(repository)
        {
        }

        public TModel Get(Guid id)
        {
            return _repository.FindById(id);
        }

        public TModel[] Get(Guid[] ids)
        {
            return _repository.FindById(ids);
        }

        protected virtual void BeforeSaveNew(TModel entity)
        {
        }

        protected virtual void BeforeSaveExisting(TModel entity)
        {
        }

        public virtual TModel Save(TModel entity)
        {
            if (entity.ID == Guid.Empty)
            {
                this.BeforeSaveNew(entity);
                _repository.Add(entity);
            }
            else
            {
                this.BeforeSaveExisting(entity);
                return _repository.Update(entity);
            }
            return entity;
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
        }

        public void Remove(Guid[] ids)
        {
            _repository.Remove(ids);
        }
    }
}
