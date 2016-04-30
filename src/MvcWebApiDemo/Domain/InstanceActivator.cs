using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.IDomain;
using WebApplication1.IRepository;
using Autofac;

namespace WebApplication1.Domain
{
    public class InstanceActivator : IDomain.IInstanceActivator
    {
        private IContainer _container;
        private  WebApplication1.IRepository.IInstanceActivator  _repositoryInstanceActivator;

        public InstanceActivator(Repository.InstanceActivator repositoryInstanceActivator)
        {
            _repositoryInstanceActivator = repositoryInstanceActivator;
            BuildContainer();
        }

        void BuildContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();
            _container = builder.Build();
        }

        public T GetInstance<T, R>(R repository, Models.Identity currentUserIdentity)
            where R : IRepository.IRepository
            where T : IDomain.OperationSet
        {
            var parameters = new NamedParameter[2];
            parameters[0] = new NamedParameter("repository", repository);
            parameters[1] = new NamedParameter("currentUserIdentity", currentUserIdentity);
            T t = _container.Resolve<T>(parameters);
            t.InstanceActivator = this;
            t.RepositoryInstanceActivator = _repositoryInstanceActivator;
            t.CurrentUserIdentity = currentUserIdentity;
            return t;
        }

        public T GetInstance<T>(Models.Identity currentUserIdentity)
            where T : IDomain.OperationSet
        {
            var parameters = new NamedParameter[1];
            parameters[0] = new NamedParameter("currentUserIdentity", currentUserIdentity);
            return _container.Resolve<T>(parameters);
        }

    }
}
