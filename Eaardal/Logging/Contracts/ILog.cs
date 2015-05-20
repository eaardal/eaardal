using System;

namespace Eaardal.Logging.Contracts
{
    /// <summary>
    /// Interface for the log implementation
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Writes an debug message to the log
        /// </summary>
        /// <param name="message">The message to log</param>
        void Debug(string message);

        /// <summary>
        /// Writes an debug message to the log
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="args">The arguments for the message string</param>
        void Debug(string message, params object[] args);

        /// <summary>
        /// Writes an verbose message to the log
        /// </summary>
        /// <param name="message">The message to log</param>
        void Verbose(string message);

        /// <summary>
        /// Writes an verbose message to the log
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="args">The arguments for the message string</param>
        void Verbose(string message, params object[] args);

        /// <summary>
        /// Writes an info message to the log
        /// </summary>
        /// <param name="message">The message to log</param>
        void Info(string message);

        /// <summary>
        /// Writes an info message to the log
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="args">The arguments for the message string</param>
        void Info(string message, params object[] args);

        /// <summary>
        /// Writes a warning message to the log
        /// </summary>
        /// <param name="message">The message to log</param>
        void Warning(string message);
        
        /// <summary>
        /// Writes a warning message to the log
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="args">The arguments for the message string</param>
        void Warning(string message, params object[] args);

        /// <summary>
        /// Writes an error message to the log
        /// </summary>
        /// <param name="message">The message to log</param>
        void Error(string message);

        /// <summary>
        /// Writes an error message to the log
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="args">The arguments for the message string</param>
        void Error(string message, params object[] args);

        /// <summary>
        /// Writes an error message to the log
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="ex">The exception that caused the error</param>
        /// <param name="args">The arguments for the message string</param>
        void Error(string message, Exception ex, params object[] args);

        /// <summary>
        /// Writes an error message to the log
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="ex">The exception that caused the error</param>
        void Error(string message, Exception ex);

        /// <summary>
        /// Writes an error message to the log
        /// </summary>
        /// <param name="ex">The exception that caused the error</param>
        void Error(Exception ex);
    }
}
