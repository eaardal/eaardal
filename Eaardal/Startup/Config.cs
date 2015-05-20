using Eaardal.Infrastructure.DI;
using Eaardal.Logging.Contracts;

namespace Eaardal.Startup
{
    public class Config
    {
        public IIoC IoC { get; set; }
        public ILogger Logger { get; set; }
    }
}