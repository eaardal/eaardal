using System;
using Eaardal.Logging.Contracts;
using Serilog;
using Serilog.Events;
using ILogger = Serilog.ILogger;

namespace Eaardal.Logging.LogFactories
{
    /// <summary>
    /// A very basic Serilog log factory. This does not use "proper" Serilog features such as 
    /// Message Template syntax or any log level other than Information, Warning and Error.
    /// The default log output is colored console only.
    /// To use more advanced Serilog features, either provide an implementation of ILogger through the 
    /// Serilogger property or implement a new LogFactory for your application.
    /// </summary>
    public class SerilogLogFactory : ILogFactory
    {
        /// <summary>
        /// Provide a customized <see cref="ILogger"/> implementation for better Serilog logging.
        /// If no implementation is provided a default will be used.
        /// </summary>
        public ILogger Serilogger { get; set; }
        
        /// <summary>
        /// Returns a <see cref="ILog"/> implementation that holds the specific log functionality for logging to serilog
        /// </summary>
        /// <param name="sourceOfLogMsg">The source object of where the log message originated</param>
        /// <returns></returns>
        public ILog LogFor(Type sourceOfLogMsg)
        {
            return new SerilogLogger(sourceOfLogMsg, Serilogger);
        }

        /// <summary>
        /// The serilog logger
        /// </summary>
        private class SerilogLogger : ILog
        {
            private readonly Type _type;
            private readonly ILogger _logger;

            /// <summary>
            /// Constructor. Uses default serilog config if not provided.
            /// </summary>
            /// <param name="type">The source object of where the log message originated</param>
            /// <param name="serilogger">The <see cref="ILogger"/> implementation to use. Will fall back to default if not provided (can be null)</param>
            public SerilogLogger(Type type, ILogger serilogger)
            {
                _type = type;
                _logger = serilogger ?? CreateDefaultSerilogger();
            }

            /// <summary>
            /// Creates a default serilogger that logs to colored console only.
            /// </summary>
            /// <returns>The Serilog.ILogger implementation to use</returns>
            private ILogger CreateDefaultSerilogger()
            {
                var config = new LoggerConfiguration();
                config.MinimumLevel.Is(LogEventLevel.Verbose);
                config.WriteTo.ColoredConsole();

                return config.CreateLogger();
            }
            
            /// <summary>
            /// Writes an debug message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Debug(string message)
            {
                _logger.ForContext(_type).Debug(message);
            }

            /// <summary>
            /// Writes an debug message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// /// <param name="args">The arguments for the message string</param>
            public void Debug(string message, params object[] args)
            {
                _logger.ForContext(_type).Debug(message, args);
            }

            /// <summary>
            /// Writes an verbose message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Verbose(string message)
            {
                _logger.ForContext(_type).Verbose(message);
            }

            /// <summary>
            /// Writes an verbose message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="args">The arguments for the message string</param>
            public void Verbose(string message, params object[] args)
            {
                _logger.ForContext(_type).Verbose(message, args);
            }

            /// <summary>
            /// Writes an info message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Info(string message)
            {
                _logger.ForContext(_type).Information(message);
            }

            /// <summary>
            /// Writes a warning message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Warning(string message)
            {
                _logger.ForContext(_type).Warning(message);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Error(string message)
            {
                _logger.ForContext(_type).Warning(message);
            }

            /// <summary>
            /// Writes an info message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="args">The arguments for the message string</param>
            public void Info(string message, params object[] args)
            {
                _logger.ForContext(_type).Information(message, args);
            }

            /// <summary>
            /// Writes a warning message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="args">The arguments for the message string</param>
            public void Warning(string message, params object[] args)
            {
                _logger.ForContext(_type).Warning(message, args);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="args">The arguments for the message string</param>
            public void Error(string message, params object[] args)
            {
                _logger.ForContext(_type).Error(message, args);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="ex">The exception that caused the error</param>
            /// <param name="args">The arguments for the message string</param>
            public void Error(string message, Exception ex, params object[] args)
            {
                _logger.ForContext(_type).Error(ex, message, args);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="ex">The exception that caused the error</param>
            public void Error(string message, Exception ex)
            {
                _logger.ForContext(_type).Error(ex, message);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="ex">The exception that caused the error</param>
            public void Error(Exception ex)
            {
                _logger.ForContext(_type).Error(ex, String.Empty);
            }
        }
    }
}
