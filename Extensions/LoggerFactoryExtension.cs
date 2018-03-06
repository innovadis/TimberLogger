using Microsoft.Extensions.Logging;
using TimberClient.Configuration;
using TimberClient.Provider;

namespace TimberClient.Extensions
{
    public static class LoggerFactoryExtension
    {
        public static void AddTimberLogging(this ILoggerFactory loggerFactory,
            TimberLoggerConfiguration configuration)
        {
            loggerFactory.AddProvider(new TimberLoggerProvider(configuration));
        }
    }
}