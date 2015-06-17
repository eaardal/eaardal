using System.Collections.Generic;

namespace Eaardal.Infrastructure.DI
{
    public interface IIoC
    {
        T Resolve<T>();
        IEnumerable<T> ResolveAll<T>();
        T Resolve<T>(string name);
    }
}