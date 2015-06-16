using System;
using System.Diagnostics;
using System.Reflection;
using Eaardal.Logging.Contracts;

namespace Eaardal.Logging.LogFactories
{
    /// <summary>
    /// A log implementation that writes to the console window
    /// </summary>
    public class WindowsEventLogLogFactory : ILogFactory
    {
        public string AppIdentifier { get; set; }

        public WindowsEventLogLogFactory()
        {
            AppIdentifier = Assembly.GetExecutingAssembly().FullName;
        }

        /// <summary>
        /// Returns a <see cref="ILog"/> implementation that holds the specific log functionality for logging to the console
        /// </summary>
        /// <param name="sourceOfLogMsg">The source object of where the log message originated</param>
        /// <returns></returns>
        public ILog LogFor(Type sourceOfLogMsg)
        {
            return new WindowsEventLogLogger(AppIdentifier);
        }

        /// <summary>
        /// The windows event log logger
        /// </summary>
        private class WindowsEventLogLogger : ILog
        {
            private readonly string _appIdentifier;

            public WindowsEventLogLogger(string appIdentifier)
            {
                if (appIdentifier == null) throw new ArgumentNullException("appIdentifier");
                _appIdentifier = appIdentifier;

                if (!EventLog.SourceExists(appIdentifier))
                {
                    EventLog.CreateEventSource(appIdentifier, "Application");
                }
            }

            /// <summary>
            /// Writes an debug message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Debug(string message)
            {
                EventLog.WriteEntry(_appIdentifier, message, EventLogEntryType.Information);
            }

            /// <summary>
            /// Writes an debug message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="args">The arguments for the message string</param>
            public void Debug(string message, params object[] args)
            {
                EventLog.WriteEntry(_appIdentifier, string.Format(message, args), EventLogEntryType.Information);
            }

            /// <summary>
            /// Writes an verbose message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Verbose(string message)
            {
                EventLog.WriteEntry(_appIdentifier, message, EventLogEntryType.Information);
            }

            /// <summary>
            /// Writes an verbose message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="args">The arguments for the message string</param>
            public void Verbose(string message, params object[] args)
            {
                EventLog.WriteEntry(_appIdentifier, string.Format(message, args), EventLogEntryType.Information);
            }

            /// <summary>
            /// Writes an info message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Info(string message)
            {
                EventLog.WriteEntry(_appIdentifier, message, EventLogEntryType.Information);
            }

            /// <summary>
            /// Writes a warning message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Warning(string message)
            {
                EventLog.WriteEntry(_appIdentifier, message, EventLogEntryType.Warning);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            public void Error(string message)
            {
                EventLog.WriteEntry(_appIdentifier, message, EventLogEntryType.Error);
            }

            /// <summary>
            /// Writes an info message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="args">The arguments for the message string</param>
            public void Info(string message, params object[] args)
            {
                EventLog.WriteEntry(_appIdentifier, string.Format(message, args), EventLogEntryType.Information);
            }

            /// <summary>
            /// Writes a warning message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="args">The arguments for the message string</param>
            public void Warning(string message, params object[] args)
            {
                EventLog.WriteEntry(_appIdentifier, string.Format(message, args), EventLogEntryType.Warning);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="args">The arguments for the message string</param>
            public void Error(string message, params object[] args)
            {
                EventLog.WriteEntry(_appIdentifier, string.Format(message, args), EventLogEntryType.Error);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="ex">The exception that caused the error</param>
            /// <param name="args">The arguments for the message string</param>
            public void Error(string message, Exception ex, params object[] args)
            {
                EventLog.WriteEntry(_appIdentifier, string.Format(message, args) + "\n" + ex, EventLogEntryType.Error);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="message">The message to log</param>
            /// <param name="ex">The exception that caused the error</param>
            public void Error(string message, Exception ex)
            {
                EventLog.WriteEntry(_appIdentifier, string.Format("{0}\n{1}\n{2}",message, ex.Message, ex.StackTrace), EventLogEntryType.Error);
            }

            /// <summary>
            /// Writes an error message to the log
            /// </summary>
            /// <param name="ex">The exception that caused the error</param>
            public void Error(Exception ex)
            {
                EventLog.WriteEntry(_appIdentifier, string.Format("{0}\n{1}\n{2}", ex.Message, ex.StackTrace, ex.ToString()), EventLogEntryType.Error);
            }
        }
    }
}
