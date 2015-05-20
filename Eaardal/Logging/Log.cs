using System;
using Eaardal.Logging.Contracts;

namespace Eaardal.Logging
{
    /// <summary>
    /// A convenience wrapper for logging.
    /// </summary>
    public static class Log
    {
        private static ILogger _logger;

        static Log()
        {
            if (_logger == null)
            {
                _logger = new Logger();
            }
        }
        
        /// <summary>
        /// Initializes the log factories to use when logging messages and sets a custom <see cref="ILogger"/> implementation
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> implementation to use for logging. This is not required to set by default.</param>
        public static void Initialize(ILogger logger)
        {
            if (logger == null) throw new ArgumentNullException("logger");
            _logger = logger;
        }

        /// <summary>
        /// Logs using the provided action
        /// </summary>
        /// <param name="sourceOfLogMsg">The source object of where the log message originated</param>
        /// <param name="logAction">The log action to perform for each logger registered</param>
        /// <returns></returns>
        public static void Msg(object sourceOfLogMsg, Action<ILog> logAction)
        {
            _logger.Msg(sourceOfLogMsg, logAction);
        }

        /// <summary>
        /// Logs using the provided action
        /// </summary>
        /// <param name="sourceOfLogMsg">The source object of where the log message originated</param>
        /// <param name="logAction">The log action to perform for each logger registered</param>
        /// <returns></returns>
        public static void Msg(Type sourceOfLogMsg, Action<ILog> logAction)
        {
            _logger.Msg(sourceOfLogMsg, logAction);
        }

        /// <summary>
        /// Logs using the provided action
        /// </summary>
        /// <typeparam name="TSourceOfLogMsg">The source object of where the log message originated</typeparam>
        /// <param name="logAction">The log action to perform for each logger registered</param>
        /// <returns></returns>
        public static void Msg<TSourceOfLogMsg>(Action<ILog> logAction)
        {
            _logger.Msg(typeof(TSourceOfLogMsg), logAction);
        }
    }
}
