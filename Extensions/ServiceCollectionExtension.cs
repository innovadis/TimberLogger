using Microsoft.Extensions.DependencyInjection;

namespace TimberClient.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddTimberLogging(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}