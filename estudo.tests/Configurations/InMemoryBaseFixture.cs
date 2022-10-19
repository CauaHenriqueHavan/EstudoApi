using estudo.infra.Context;

namespace estudo.tests.Configurations
{
    public class InMemoryBaseFixture : InMemoryBaseFixture, IDisposable
    {
        private readonly AppDbContext
        public InMemoryBaseFixture() : base(Path.Combine("estudo.api", "appsettings.json"))
        {
            
        }

        private void IniciarContexto()
        {

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
