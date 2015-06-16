using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Eaardal.Infrastructure.DI;
using Eaardal.Logging;

namespace Eaardal.Startup
{
    public class AutofacConfig
    {
        private ContainerBuilder _builder;

        public AutofacConfig BuildDefault<TTypeInThisAssembly>(string appAssemblyIdentifier = null)
        {
            _builder = new ContainerBuilder();

            var typeName = typeof (TTypeInThisAssembly).FullName;

            var assemblyIdentifier = appAssemblyIdentifier ?? (typeName.Contains('.') ? typeName.Substring(0, typeName.IndexOf('.')) : typeName);

            var mainAssembly = Assembly.GetAssembly(typeof (TTypeInThisAssembly));
            var referencedAssemblies = mainAssembly.GetReferencedAssemblies();
            var appAssemblies = referencedAssemblies
                .Where(x => x.Name.StartsWith(assemblyIdentifier))
                .Concat(new[] {mainAssembly.GetName()})
                .Concat(referencedAssemblies.Where(x => x.Name.StartsWith("Eaardal")))
                .Select(Assembly.Load)
                .ToArray();

            _builder.RegisterAssemblyTypes(appAssemblies)
                .Except<IoC>()
                .AsImplementedInterfaces()
                .AsSelf();

            _builder.RegisterType<IoC>().AsImplementedInterfaces().AsSelf().SingleInstance();

            _builder.RegisterType<Logger>().AsImplementedInterfaces().AsSelf().SingleInstance();

            return this;
        }

        public AutofacConfig Build(Action<ContainerBuilder> buildCustomConfig)
        {
            buildCustomConfig(_builder);
            return this;
        }

        public AutofacConfig UpdateContainer(Action<IContainer> updateAction)
        {
            var container = _builder.Build();
            updateAction(container);
            _builder = new ContainerBuilder();
            return this;
        }

        public IContainer Build()
        {
            return _builder.Build();
        }
    }
}
