using System;
using System.Diagnostics;
using Eaardal.Logging.Contracts;

namespace Eaardal.Logging.LogFactories
{
    /// <summary>
    /// A log implementation that writes to the trace log
    /// </summary>
    public  class TraceLogFactory : ILogFactory
    {
        /// <summary>
        /// Returns a <see cref="ILog"/> implementation that holds the specific log functionality for logging to the trace log
        /// </summary>
        /// <param name="sourceOfLogMsg">The source object of where the log message originated</param>
        /// <returns></returns>
        public ILog LogFor(Type sourceOfLogMsg)
        {
            return new TraceLogger();
        }

        /// <summary>
        /// The trace logger
        /// </summary>
        private class TraceLogger : ILog
        {
            /// <summary>
            /// Writes an debug message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Debug(string message)
            {
                Trace.TraceInformation(message);
            }

            /// <summary>
            /// Writes an debug message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// /// <param name="args">The arguments for the message string</param>
            public void Debug(string message, params object[] args)
            {
                Trace.TraceInformation(message, args);
            }

            /// <summary>
            /// Writes an verbose message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Verbose(string message)
            {
                Trace.TraceInformation(message);
            }

            /// <summary>
            /// Writes an verbose message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// /// <param name="args">The arguments for the message string</param>
            public void Verbose(string message, params object[] args)
            {
                Trace.TraceInformation(message, args);
            }

            /// <summary>
            /// Writes an info message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Info(string message)
            {
                Trace.TraceInformation(message);
            }

            /// <summary>
            /// Writes a warning message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Warning(string message)
            {
                Trace.TraceWarning(message);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Error(string message)
            {
                Trace.TraceError(message);
            }

            /// <summary>
            /// Writes an info message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="args">The arguments for the message string</param>
            public void Info(string message, params object[] args)
            {
                Trace.TraceInformation(message, args);
            }

            /// <summary>
            /// Writes a warning message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="args">The arguments for the message string</param>
            public void Warning(string message, params object[] args)
            {
                Trace.TraceWarning(message, args);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="args">The arguments for the message string</param>
            public void Error(string message, params object[] args)
            {
                Trace.TraceError(message, args);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="ex">The exception that caused the error</param>
            /// <param name="args">The arguments for the message string</param>
            public void Error(string message, Exception ex, params object[] args)
            {
                Trace.TraceError(message + "\n\n" + ex.Message + "\n\n" + ex.StackTrace, args);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="ex">The exception that caused the error</param>
            public void Error(string message, Exception ex)
            {
                Trace.TraceError(message + "\n\n" + ex.Message + "\n\n" + ex.StackTrace);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="ex">The exception that caused the error</param>
            public void Error(Exception ex)
            {
                Trace.TraceError(ex.Message + "\n\n" + ex.StackTrace);
            }
        }
    }
}
