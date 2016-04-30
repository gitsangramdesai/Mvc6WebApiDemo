using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.IRepository;

namespace WebApplication1.Repository
{
    public class InstanceActivator: IRepository.IInstanceActivator
    {
        string _connectionString;
        IContainer _container;

        public InstanceActivator(string connectionString)
        {
            _connectionString = connectionString;
            BuildContainer();
        }

        protected void BuildContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();
            _container = builder.Build();
        }

        public TModel GetInstance<TModel>() where TModel : IRepository.IRepository
        {
            var parameters = new NamedParameter[1];
            parameters[0] = new NamedParameter("connectionString", _connectionString);
            return _container.Resolve<TModel>(parameters);
        }
    }
}
