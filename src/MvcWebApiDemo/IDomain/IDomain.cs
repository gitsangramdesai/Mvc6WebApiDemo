using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repository;


namespace WebApplication1.IDomain
{
    public interface OperationSet
    {
        IRepository.IInstanceActivator RepositoryInstanceActivator { get; set; }

        IDomain.IInstanceActivator InstanceActivator { get; set; }

        WebApplication1.Models.Identity CurrentUserIdentity { get; set; }
    }

    public interface OperationSetWithStorageOperations<T> where T : WebApplication1.Models.ModelBase
    {
        T Get(Guid id);

        T[] Get(Guid[] ids);

        T Save(T entity);

        void Remove(Guid id);

        void Remove(Guid[] ids);
    }
}
