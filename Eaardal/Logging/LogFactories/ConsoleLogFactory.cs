using System;
using Eaardal.Logging.Contracts;

namespace Eaardal.Logging.LogFactories
{
    /// <summary>
    /// A log implementation that writes to the console window
    /// </summary>
    public class ConsoleLogFactory : ILogFactory
    {
        /// <summary>
        /// Returns a <see cref="ILog"/> implementation that holds the specific log functionality for logging to the console
        /// </summary>
        /// <param name="sourceOfLogMsg">The source object of where the log message originated</param>
        /// <returns></returns>
        public ILog LogFor(Type sourceOfLogMsg)
        {
            return new ConsoleLogger();
        }

        /// <summary>
        /// The console logger
        /// </summary>
        private class ConsoleLogger : ILog
        {
            /// <summary>
            /// Writes an debug message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Debug(string message)
            {
                Console.WriteLine(message);
            }

            /// <summary>
            /// Writes an debug message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="args">The arguments for the message string</param>
            public void Debug(string message, params object[] args)
            {
                Console.WriteLine(message, args);
            }

            /// <summary>
            /// Writes an verbose message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Verbose(string message)
            {
                Console.WriteLine(message);
            }

            /// <summary>
            /// Writes an verbose message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="args">The arguments for the message string</param>
            public void Verbose(string message, params object[] args)
            {
                Console.WriteLine(message, args);
            }

            /// <summary>
            /// Writes an info message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Info(string message)
            {
                Console.WriteLine(message);
            }

            /// <summary>
            /// Writes a warning message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Warning(string message)
            {
                Console.WriteLine(message);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Error(string message)
            {
                Console.WriteLine(message);
            }

            /// <summary>
            /// Writes an info message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="args">The arguments for the message string</param>
            public void Info(string message, params object[] args)
            {
                Console.WriteLine(string.Format(message, args));
            }

            /// <summary>
            /// Writes a warning message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="args">The arguments for the message string</param>
            public void Warning(string message, params object[] args)
            {
                Console.WriteLine(string.Format(message, args));
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="args">The arguments for the message string</param>
            public void Error(string message, params object[] args)
            {
                Console.WriteLine(string.Format(message, args));
            }
            
            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="ex">The exception that caused the error</param>
            /// <param name="args">The arguments for the message string</param>
            public void Error(string message, Exception ex, params object[] args)
            {
                Console.WriteLine(string.Format(message, args) + "\n" + ex);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="ex">The exception that caused the error</param>
            public void Error(string message, Exception ex)
            {
                Console.WriteLine(message + "\n" + ex);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="ex">The exception that caused the error</param>
            public void Error(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
