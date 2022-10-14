using estudo.domain.Interfaces.Repository;
using estudo.domain.Interfaces.Service;
using estudo.infra.Repository;
using Havan.DadosMestre.Domain.DTOs.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace estudo.infraCrossCuting
{
    public static class CrossDependency
    {
            public static IServiceCollection ConfiguringDependencyInjection(this IServiceCollection services, IConfiguration configuration)
            {
                services.ConfiguringRepositories();
                services.ConfiguringServices();
            }

            private static void ConfiguringRepositories(this IServiceCollection services)
            {
                services.AddScoped<IClienteRepository, ClienteRepository>();
            }

            private static void ConfiguringServices(this IServiceCollection services)
            {
                services.AddTransient<IClienteService, IClienteService>();
            }
    }
}