using Microsoft.Extensions.Logging;

namespace Webmotors.Commons.Resilience.Logger
{
    public static class ApplicationLogging
    {
        public static ILoggerFactory LoggerFactory { get; set; }
        internal static ILogger CreateLogger<T>() => LoggerFactory.CreateLogger<T>();
        internal static ILogger CreateLogger(string categoryName) => LoggerFactory.CreateLogger(categoryName);
    }
}
