using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using TimberClient.Configuration;

namespace TimberClient.Provider
{
    public class TimberLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, TimberLogger> _loggers = new ConcurrentDictionary<string, TimberLogger>();
        private readonly TimberLoggerConfiguration _config;

        public TimberLoggerProvider(TimberLoggerConfiguration config)
        {
            _config = config;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new TimberLogger(name, _config));
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}