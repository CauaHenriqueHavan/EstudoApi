using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace estudo.tests.Configurations
{
    public class BaseFixture
    {
        protected IServiceScope Scope;

        protected IServiceProvider ServiceProvider { get; set; }

        protected IServiceCollection Service { get; }

        protected IConfiguration Configuration { get; }

        public BaseFixture(string appSettingsPath)
        {
            Service = new ServiceCollection();
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(appSettingsPath, optional: false, reloadOnChange: true);
            Configuration = configurationBuilder.Build();
        }
        public void BuildEscopo()
        {
            ServiceProvider provider = Service.BuildServiceProvider();
            Scope = provider.CreateScope();
            ServiceProvider = Scope.ServiceProvider;
        }

        public T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }

    }
}
