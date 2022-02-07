using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Webmotors.ApplicationCore.UseCases;
using Webmotors.ApplicationCore.UseCases.Interfaces;

namespace Webmotors.ApplicationCore.Configuration
{
    public static class CoreConfiguration
    {
        public static void ConfigureCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDependencies(configuration);
        }

        public static void ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGetAd, GetAd>();
            services.AddScoped<IGetMake, GetMake>();
            services.AddScoped<IGetModel, GetModel>();
            services.AddScoped<IGetVersion, GetVersion>();
            services.AddScoped<ICreateAd, CreateAd>();
            services.AddScoped<IChangeAd, ChangeAd>();
            services.AddScoped<IDeleteAd, DeleteAd>();
        }
    }
}
