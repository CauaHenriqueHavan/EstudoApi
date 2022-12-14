using estudo.domain.Common;
using estudo.domain.Common.Interfaces;
using estudo.domain.Interfaces.Repository;
using estudo.domain.Interfaces.Service;
using estudo.infra.Auxiliares;
using estudo.infra.Context;
using estudo.infra.Mapper;
using estudo.infra.Repository;
using estudo.service;
using estudo.service.Events.Notification;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace estudo.infraCrossCuting
{
    public static class CrossDependency
    {
        public static IServiceCollection SetupDepencencyInjection(this IServiceCollection services)
        {
            services.ConfigureServices()
                    .ConfiguringRepositories()
                    .AddMediatR(typeof(LogUsuarioNotification))
                    .AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>))
                    .AddAutoMapper(typeof(AutoMapperConfig));

            return services;
        }
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
                services.AddTransient<IClienteService, ClienteService>();
                services.AddScoped<ILogService, LogService>();
                services.AddTransient<IEnderecoService, EnderecoService>();
                services.AddTransient<IProdutoService, ProdutoService>();

                services.AddDbContext<AppDbContext>();

                return services;
        }

        public static IServiceCollection ConfiguringRepositories(this IServiceCollection services)
            {
                services.AddTransient<IClienteRepository, ClienteRepository>();
                services.AddTransient<IProdutoRepository, ProdutoRepository>();

                return services;
            }
    }
}