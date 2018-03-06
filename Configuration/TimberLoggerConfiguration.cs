using Microsoft.Extensions.Logging;

namespace TimberClient.Configuration
{
    public class TimberLoggerConfiguration
    {
        public string TimberUrl { get; set; } = "https://logs.timber.io";

        public string ApiKey { get; set; }
        
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;

        public int EventId { get; set; } = 0;

        public string Format { get; set; } = "[{0}] {1}";
    }
}