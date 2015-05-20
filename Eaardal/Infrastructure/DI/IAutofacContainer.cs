using Autofac;

namespace Eaardal.Infrastructure.DI
{
    public interface IAutofacContainer
    {
        void RegisterContainer(IContainer container);
    }
}