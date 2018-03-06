using Microsoft.Extensions.Logging;

namespace TimberClient.Extensions
{
    public static class LogLevelExtension
    {
        public static string Name(this LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Critical: return "critical";
                case LogLevel.Debug: return "debug";
                case LogLevel.Error: return "error";
                case LogLevel.Information: return "info";
                case LogLevel.None: return "alert";
                case LogLevel.Trace: return "debug";
                case LogLevel.Warning: return "warn";
            }

            return "alert";
        }
    }
}