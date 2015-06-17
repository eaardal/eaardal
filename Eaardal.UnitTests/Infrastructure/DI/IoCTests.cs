using Autofac;
using Eaardal.Infrastructure.DI;
using NUnit.Framework;

namespace Eaardal.UnitTests.Infrastructure.DI
{
    [TestFixture]
    public class IoCTests
    {
        [Test]
        public void InheritsInterfaces()
        {
            var ioc = new IoC();
            Assert.IsInstanceOf<IAutofacContainer>(ioc);
            Assert.IsInstanceOf<IIoC>(ioc);
        }

        [Test]
        public void RegisterContainer_SetsContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Service>();

            var container = builder.Build();

            var ioc = new IoC();
            ioc.RegisterContainer(container);

            var service = ioc.Resolve<Service>();

            Assert.NotNull(service);
            Assert.IsInstanceOf<Service>(service);
        }

        [Test]
        public void Resolve_WhenServiceIsRegistered_ReturnsInstanceOfService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Service>();

            var container = builder.Build();

            var ioc = new IoC();
            ioc.RegisterContainer(container);

            var service = ioc.Resolve<Service>();

            Assert.NotNull(service);
            Assert.IsInstanceOf<Service>(service);
        }

        [Test]
        public void Resolve_WhenServiceIsRegisteredWithInterface_AndInterfaceIsRequested_ReturnsInstanceOfService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Service>().As<IService>();

            var container = builder.Build();

            var ioc = new IoC();
            ioc.RegisterContainer(container);

            var service = ioc.Resolve<IService>();

            Assert.NotNull(service);
            Assert.IsInstanceOf<Service>(service);
        }
        
        interface IService
        {
            
        }

        class Service : IService
        {

        }
    }
}
