using estudo.infraCrossCuting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace estudo.tests.Configurations
{
    public class InMemoryBaseFixture : IDisposable
    {
        protected IServiceProvider ServiceProvider { get; set; }
        protected IServiceCollection Service { get; }
        protected IConfiguration Configuration { get; }

        public InMemoryBaseFixture()
        {
            DadosFixture.MockBanco();

            Service.SetupDepencencyInjection().AddSingleton(Configuration);
        }

        public T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }

        public void Dispose()
        {
            DadosFixture.MockBanco();
        }
    }
}
