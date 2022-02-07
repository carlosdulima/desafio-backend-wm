using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Webmotors.UI.Configuration
{
    public static class WebConfiguration
    {
        public static void ConfigureWeb(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDependencies(configuration);
        }

        public static void ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(WebMapperProfile));
        }
    }
}
