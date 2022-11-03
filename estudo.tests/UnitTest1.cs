using estudo.domain.Interfaces.Service;
using estudo.tests.Configurations;

namespace estudo.tests
{
    [TestClass]
    public class ClienteTest
    {
        public readonly IClienteService _clienteService;

        public ClienteTest(InMemoryBaseFixture fixture)
        {
            _clienteService = fixture.GetService<IClienteService>();
        }

        [TestMethod]
        public async Task TestMethod1()
        {
            DadosFixture.MockBanco();
        }
    }
}