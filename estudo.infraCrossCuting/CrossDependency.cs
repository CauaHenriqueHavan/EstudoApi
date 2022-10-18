using estudo.domain.Interfaces.Repository;
using estudo.domain.Interfaces.Service;
using estudo.infra.Auxiliares;
using estudo.infra.Repository;
using estudo.service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace estudo.infraCrossCuting
{
    public static class CrossDependency
    {
        public static IServiceCollection SetupDepencencyInjection(this IServiceCollection services, IConfiguration configuration)
            {
            services.ConfigureServices()
                    .ConfiguringRepositories();
            services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            return services;
            }
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
            {
                services.AddTransient<IClienteService, ClienteService>();

                return services;
            }

        public static IServiceCollection ConfiguringRepositories(this IServiceCollection services)
            {
                services.AddTransient<IClienteRepository, ClienteRepository>();

                return services;
            }
    }
}