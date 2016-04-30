using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Repository;
using WebApplication1.IRepository;

namespace WebApplication1.IDomain
{
    public interface IInstanceActivator
    {
        T GetInstance<T, R>(R repository, Models.Identity currentUserIdentity) where R : IRepository.IRepository
            where T : IDomain.OperationSet;

        T GetInstance<T>(Models.Identity currentUserIdentity)
            where T : IDomain.OperationSet;
    }
}
