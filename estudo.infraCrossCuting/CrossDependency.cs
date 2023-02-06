using estudo.domain.Common;
using estudo.domain.Common.Interfaces;
using estudo.domain.DTO_s.Config;
using estudo.domain.Interfaces.Repository;
using estudo.domain.Interfaces.Service;
using estudo.infra.Auxiliares;
using estudo.infra.Context;
using estudo.infra.Mapper;
using estudo.infra.Repository;
using estudo.service;
using estudo.service.Events.Notification;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
                    .AddMediatR(typeof(LogUsuarioNotification))
                    .AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>))
                    .AddAutoMapper(typeof(AutoMapperConfig))
                    .ConfiguringServicesOptions(configuration);

            return services;
        }
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
                services.AddScoped<ILogService, LogService>();
                services.AddTransient<IClienteService, ClienteService>();
                services.AddTransient<IEnderecoService, EnderecoService>();
                services.AddTransient<IProdutoService, ProdutoService>();

                services.AddDbContext<AppDbContext>(x => x.UseSqlite("Data source=local.db"));

            return services;
        }

        public static IServiceCollection ConfiguringRepositories(this IServiceCollection services)
        {
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();

            return services;
        }

        private static void ConfiguringServicesOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddHttpClient<IEnderecoService, EnderecoService>(client 
                    => client.BaseAddress = new Uri(configuration.GetSection("EnderecoApiSettings")["UrlBase"]));

            services.Configure<EnderecoApiSettings>(configuration.GetSection("EnderecoApiSettings"));
        }
    }
}