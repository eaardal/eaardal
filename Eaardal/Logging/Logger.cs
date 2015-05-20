using System;
using System.Linq;
using Eaardal.Logging.Contracts;
using Eaardal.Logging.LogFactories;

namespace Eaardal.Logging
{
    /// <summary>
    /// A convenience wrapper for logging.
    /// </summary>
    public class Logger : ILogger
    {
        private ILogFactory[] _logFactories;

        /// <summary>
        /// Initializes the log factories to use when logging messages
        /// </summary>
        /// <param name="logFactories">The log factories to use when logging messages</param>
        public void InitializeLogFactories(params ILogFactory[] logFactories)
        {
            _logFactories = logFactories;
        }

        /// <summary>
        /// Logs using the provided action
        /// </summary>
        /// <param name="sourceOfLogMsg">The source object of where the log message originated</param>
        /// <param name="logAction">The log action to perform for each logger registered</param>
        /// <returns></returns>
        public void Msg(object sourceOfLogMsg, Action<ILog> logAction)
        {
            Msg(sourceOfLogMsg.GetType(), logAction);
        }

        /// <summary>
        /// Logs using the provided action
        /// </summary>
        /// <typeparam name="TSourceOfLogMsg">The source object of where the log message originated</typeparam>
        /// <param name="logAction">The log action to perform for each logger registered</param>
        /// <returns></returns>
        public void Msg<TSourceOfLogMsg>(Action<ILog> logAction)
        {
            Msg(typeof(TSourceOfLogMsg), logAction);
        }

        /// <summary>
        /// Logs using the provided action
        /// </summary>
        /// <param name="sourceOfLogMsg">The source object of where the log message originated</param>
        /// <param name="logAction">The log action to perform for each logger registered</param>
        /// <returns></returns>
        public void Msg(Type sourceOfLogMsg, Action<ILog> logAction)
        {
            if (_logFactories == null || !_logFactories.Any())
            {
                throw new Exception("No log factories configured for the logger");
            }

            foreach (var factory in _logFactories)
                logAction(factory.LogFor(sourceOfLogMsg));
        }
    }
}
