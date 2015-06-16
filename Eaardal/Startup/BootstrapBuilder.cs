using System;
using Autofac;
using Eaardal.Infrastructure.DI;
using Eaardal.Logging;
using Eaardal.Logging.Contracts;

namespace Eaardal.Startup
{
    public class BootstrapBuilder
    {
        private readonly AutofacConfig  _autofacConfig;
        private readonly ILogger _logger;

        public BootstrapBuilder()
        {
            _autofacConfig = new AutofacConfig();
            _logger = new Logger();
        }

        public virtual BootstrapBuilder WithDefaultAutofacConfig<TTypeInThisAssembly>(string appAssemblyIdentifier = null)
        {
            _autofacConfig.BuildDefault<TTypeInThisAssembly>(appAssemblyIdentifier);
            return this;
        }

        public virtual BootstrapBuilder WithCustomizedAutofacConfig(Action<ContainerBuilder> customAutofacConfig)
        {
            _autofacConfig.Build(customAutofacConfig);
            return this;
        }

        public virtual BootstrapBuilder WithCustomizedAutofacConfig(Action<IContainer> customAutofacConfig)
        {
            _autofacConfig.UpdateContainer(customAutofacConfig);
            return this;
        }

        public virtual BootstrapBuilder WithDefaultLogConfig(params ILogFactory[] logFactories)
        {
            _logger.InitializeLogFactories(logFactories);
            _logger.Msg(typeof(BootstrapBuilder), log => log.Verbose("Log framework initialized"));

            Log.Initialize(_logger);

            return this;
        }

        public virtual Config Build()
        {
            var container = _autofacConfig.Build();

            var iocContainer = container.Resolve<IAutofacContainer>();
            iocContainer.RegisterContainer(container);

            var ioc = (IIoC) iocContainer;

            return new Config(ioc, _logger);
        }
    }
}
