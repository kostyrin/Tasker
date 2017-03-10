using System;
using System.Collections.Generic;
using Autofac;
using RepositoryT.Infrastructure;

namespace TaskerWindowsService.Topshelf
{
    public class AutofacServiceLocator : IServiceLocator
    {
        private readonly ILifetimeScope _scope;

        public AutofacServiceLocator(ILifetimeScope scope)
        {
            _scope = scope;

        }

        public object GetService(Type serviceType)
        {
            return _scope.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var enumerableServiceType = typeof(IEnumerable<>).MakeGenericType(serviceType);
            var instance = _scope.Resolve(enumerableServiceType);

            return (IEnumerable<object>)instance;
        }
    }
}
