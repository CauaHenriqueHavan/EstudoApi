using estudo.domain.Common;
using estudo.domain.Common.Interfaces;
using estudo.domain.Interfaces.Repository;
using estudo.domain.Interfaces.Service;
using estudo.infra.Repository;
using estudo.service;
using estudo.service.Events.Notification;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace estudo.infraCrossCuting
{
    public static class CrossDependency
    {
        public static IServiceCollection SetupDepencencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureServices()
                    .ConfiguringRepositories()
                    .AddMediatR(typeof(LogUsuarioNotification));

            return services;
        }
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
                services.AddTransient<IClienteService, ClienteService>();
                services.AddScoped<ILogService, LogService>();

                return services;
        }

        public static IServiceCollection ConfiguringRepositories(this IServiceCollection services)
            {
                services.AddTransient<IClienteRepository, ClienteRepository>();

                return services;
            }
    }
}