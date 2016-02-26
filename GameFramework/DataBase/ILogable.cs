using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework.DataBase
{
    /// <summary>
    /// A delegate used for log.
    /// </summary>
    /// <param name="logMsg">The msg to write to log.</param>
    public delegate void LogHandler(string log);

    /// <summary>
    /// A delegate used for exception.
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="log"></param>
    public delegate void ExceptionLogHandler(Exception exception, string log);

    /// <summary>
    /// Mark a implementing class as loggable.
    /// </summary>
    interface ILogable
    {
        /// <summary>
        /// OnLog event.
        /// </summary>
        event LogHandler OnLog;

        /// <summary>
        /// OnDbException event;
        /// </summary>
        event ExceptionLogHandler OnExceptionLog;
    }
}
