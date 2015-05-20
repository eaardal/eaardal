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

        public virtual BootstrapBuilder Wire()
        {
            return new BootstrapBuilder();
        }

        public virtual BootstrapBuilder WithDefaultAutofacConfig<TTypeInThisAssembly>(string appAssemblyIdentifier = null)
        {
            _autofacConfig.ConfigureDefault<TTypeInThisAssembly>(appAssemblyIdentifier);
            return this;
        }

        public virtual BootstrapBuilder WithCustomizedAutofacConfig(Action<ContainerBuilder> customAutofacConfig)
        {
            _autofacConfig.ConfigureCustom(customAutofacConfig);
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

            var ioc = container.Resolve<IAutofacContainer>();
            ioc.RegisterContainer(container);

            return new Config
            {
                Logger = _logger,
                IoC = (IIoC)ioc
            };
        }
    }
}
