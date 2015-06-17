using System.Collections.Generic;
using Autofac;

namespace Eaardal.Infrastructure.DI
{
    public class IoC : IIoC, IAutofacContainer
    {
        private IContainer _container;

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return _container.Resolve<IEnumerable<T>>();
        }

        public T Resolve<T>(string name)
        {
            return _container.ResolveNamed<T>(name);
        }

        public void RegisterContainer(IContainer container)
        {
            _container = container;
        }
    }
}
