using estudo.domain.Common.Interfaces;
using estudo.domain.DTO_s.Config;
using estudo.domain.Interfaces.Service;
using estudo.infra.Context;
using estudo.infraCrossCuting;
using estudo.service;
using estudo.tests.Configurations.MockResponse;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Moq;
using static estudo.tests.Configurations.ContextoFactory;
using static estudo.tests.Configurations.DadosFixture;

namespace estudo.tests.Configurations
{
    public class InMemoryBaseFixture : BaseFixture, IDisposable
    {
        private AppDbContext _context;

        public InMemoryBaseFixture() : base(Path.Combine(@"C:\Users\116890\source\repos\API DE ESTUDO\estudo.tests\Configurations\appsettings.json"))
        {
            Service.SetupDepencencyInjection(Configuration)
                   .AddSingleton(Configuration);

            IniciarContexto();

            PopulaDatabase();

            MockLog();

            ConfigurarEnderecoApiService();

            BuildEscopo();
        }

        public T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }

        private void ConfigurarEnderecoApiService()
        {
            var enderecoApiSettings = Configuration.GetSection("EnderecoApiSettings");
            var enderecoApiMock = new EnderecoApiMock(enderecoApiSettings["UrlBase"]);
            var configuracaoEndereco = Options.Create(new EnderecoApiSettings(enderecoApiSettings["EndpointBuscarEndereco"]));

            Service.AddSingleton<IEnderecoService>(new EnderecoService(enderecoApiMock.HttpClient, configuracaoEndereco.Value));
        }

        private void MockLog()
        {
            var mockLogService = new Mock<ILogService>();
            Service.AddSingleton(mockLogService.Object);

            var mediator = new Mock<IMediator>();
            Service.AddSingleton(mediator.Object);
        }

        private void IniciarContexto()
        {
            _context = CriarContexto<AppDbContext>();
            Service.AddSingleton(_context);
        }

        private void PopulaDatabase()
        {
            _context.AddRange(GerarClienteEntity());
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Scope?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}