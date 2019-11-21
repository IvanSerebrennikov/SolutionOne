using Microsoft.Extensions.Logging;

namespace SO.Domain.Logger
{
    public static class LoggerFactories
    {
        public static readonly ILoggerFactory ConsoleLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });
    }
}
