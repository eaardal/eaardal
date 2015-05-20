using Autofac;
using Eaardal.Startup;

namespace Eaardal.ConsoleClient
{
    public class Bootstrapper
    {
        public static Config Wire()
        {
            var config =
               new BootstrapBuilder().Wire()
                   .WithDefaultAutofacConfig<Config>()
                   .WithCustomizedAutofacConfig(ConfigureIoC)
                   .WithDefaultLogConfig()
                   .Build();

            return config;
        }

        private static void ConfigureIoC(ContainerBuilder builder)
        {

        }
    }
}
