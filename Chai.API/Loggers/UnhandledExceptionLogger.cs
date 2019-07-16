using System.Diagnostics;
using System.Web.Http.ExceptionHandling;

namespace Chai.API.Loggers
{
    /// <summary>
    /// ExceptionLogger enables logging all unhandled exceptions.
    /// It catches all unhandled exceptions before even exception filters
    /// </summary>
    public class UnhandledExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            // TO DO: Log exception to log4net or to DB
            var log = context.Exception.Message;
            Debug.WriteLine($"EXCEPTION LOGGED: {log}");
        }
    }
}