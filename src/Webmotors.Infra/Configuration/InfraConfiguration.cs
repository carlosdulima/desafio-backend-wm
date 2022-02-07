using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Webmotors.ApplicationCore.Gateways;
using Webmotors.Commons.Resilience.Builder;
using Webmotors.Commons.Resilience.Interfaces;
using Webmotors.Infra.Gateway.External;
using Webmotors.Infra.Gateways;
using Webmotors.Infra.Repositories;
using Webmotors.Infra.Repositories.Context;
using Webmotors.Infra.Repositories.Interfaces;

namespace Webmotors.Infra.Configuration
{
    public static class InfraConfiguration
    {
        public static void ConfigureInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDependencies(configuration);
        }

        public static void ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdContext>(opt =>
                 opt.UseSqlServer(configuration.GetConnectionString("AdConnection"))
                    .UseLazyLoadingProxies());

            services.AddScoped<IAdGateway, AdGateway>();
            services.AddScoped<IMakeGateway, MakeGateway>();
            services.AddScoped<IModelGateway, ModelGateway>();
            services.AddScoped<IVersionGateway, VersionGateway>();

            services.AddScoped<AdContext>();
            services.AddScoped<IAdRepository, AdRepository>();

            services.ConfigurePollyAndRefit<IDesafioOnlineWebmotorsGateway>(configuration, ApiCatalog.DESAFIO_ONLINE_WEBMOTORS);
        }

        public static void ConfigurePollyAndRefit<T>(
            this IServiceCollection services, IConfiguration configuration, string serviceName)
            where T : class
        {
            var proxies = new List<ApiSettings>();
            configuration.GetSection(nameof(ApiSettings)).Bind(proxies);

            var proxie = proxies.FirstOrDefault(f => f.Name == serviceName);

            AddRefit<T>(services, configuration, proxie);

            services.AddSingleton(new PolicyBuilder()
                .UseExecutorAsync()
                .WithRetry(proxie.PoliciesSettings.Retry)
                .WithWaitRetry(proxie.PoliciesSettings.Retry, i => TimeSpan.FromSeconds(i)).Build());
        }

        private static void AddRefit<T>(IServiceCollection services, IConfiguration configuration, ApiSettings proxie)
            where T : class
        {
            services.TryAddScoped<IHttpPolicyAsyncBuilder, HttpPolicyAsyncBuilder>();

            var serializerSettings = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var settings = new RefitSettings(new SystemTextJsonContentSerializer(serializerSettings));

            services.AddRefitClient<T>(settings)
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(proxie.Url));
        }
    }
}
