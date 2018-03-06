using System;
using Microsoft.Extensions.Logging;
using TimberClient.Configuration;
using TimberClient.Contract;
using TimberClient.Http;

namespace TimberClient
{
    public class TimberLogger : ILogger
    {
        private readonly string _category;
        private readonly TimberLoggerConfiguration _config;
        private readonly ITimberClient _timberClient;

        public TimberLogger(string category, TimberLoggerConfiguration config)
        {
            _category = category;
            _config = config;
            _timberClient = new TimberHttpClient(_config.TimberUrl, _config.ApiKey, config.Format);
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            
            _timberClient.Send(logLevel, _category, formatter(state, exception));
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}