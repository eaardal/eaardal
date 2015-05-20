using System;

namespace Eaardal.Logging.Contracts
{
    /// <summary>
    /// The common log factory that log implementations must use
    /// </summary>
    public interface ILogFactory
    {
        /// <summary>
        /// Returns a <see cref="ILog"/> implementation that holds the specific log functionality
        /// </summary>
        /// <param name="sourceOfLogMsg">The source object of where the log message originated</param>
        /// <returns></returns>
        ILog LogFor(Type sourceOfLogMsg);
    }
}
