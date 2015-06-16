using System;
using Eaardal.Infrastructure.DI;
using Eaardal.Logging.Contracts;

namespace Eaardal.Startup
{
    public class Config
    {
        public Config(IIoC ioC, ILogger logger)
        {
            if (ioC == null) throw new ArgumentNullException("ioC");
            if (logger == null) throw new ArgumentNullException("logger");
            IoC = ioC;
            Logger = logger;
        }

        public IIoC IoC { get; private set; }
        public ILogger Logger { get; private set; }
    }
}