using System;
using Eaardal.Logging.Contracts;

namespace Eaardal.Logging.LogFactories
{
    /// <summary>
    /// A log implementation that writes to the debug window
    /// </summary>
    public class DebugLogFactory : ILogFactory
    {
        /// <summary>
        /// Returns a <see cref="ILog"/> implementation that holds the specific log functionality for logging to the debug window
        /// </summary>
        /// <param name="sourceOfLogMsg">The source object of where the log message originated</param>
        /// <returns></returns>
        public ILog LogFor(Type sourceOfLogMsg)
        {
            return new DebugLogger();
        }

        /// <summary>
        /// The debug logger
        /// </summary>
        private class DebugLogger : ILog
        {
            /// <summary>
            /// Writes an debug message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Debug(string message)
            {
                System.Diagnostics.Debug.WriteLine(message);
            }

            /// <summary>
            /// Writes an debug message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="args">The arguments for the message string</param>
            public void Debug(string message, params object[] args)
            {
                System.Diagnostics.Debug.WriteLine(message, args);
            }

            /// <summary>
            /// Writes an verbose message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Verbose(string message)
            {
                System.Diagnostics.Debug.WriteLine(message);
            }

            /// <summary>
            /// Writes an verbose message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="args">The arguments for the message string</param>
            public void Verbose(string message, params object[] args)
            {
                System.Diagnostics.Debug.WriteLine(message, args);
            }

            /// <summary>
            /// Writes an info message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Info(string message)
            {
                System.Diagnostics.Debug.WriteLine(message);
            }

            /// <summary>
            /// Writes a warning message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Warning(string message)
            {
                System.Diagnostics.Debug.WriteLine(message);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Error(string message)
            {
                System.Diagnostics.Debug.WriteLine(message);
            }

            /// <summary>
            /// Writes an info message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="args">The arguments for the message string</param>
            public void Info(string message, params object[] args)
            {
                System.Diagnostics.Debug.WriteLine(string.Format(message, args));
            }

            /// <summary>
            /// Writes a warning message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="args">The arguments for the message string</param>
            public void Warning(string message, params object[] args)
            {
                System.Diagnostics.Debug.WriteLine(string.Format(message, args));
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="args">The arguments for the message string</param>
            public void Error(string message, params object[] args)
            {
                System.Diagnostics.Debug.WriteLine(string.Format(message, args));
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="ex">The exception that caused the error</param>
            /// <param name="args">The arguments for the message string</param>
            public void Error(string message, Exception ex, params object[] args)
            {
                System.Diagnostics.Debug.WriteLine(string.Format(message, args) + "\n" + ex);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="ex">The exception that caused the error</param>
            public void Error(string message, Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(message + "\n" + ex);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="ex">The exception that caused the error</param>
            public void Error(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
    }
}
