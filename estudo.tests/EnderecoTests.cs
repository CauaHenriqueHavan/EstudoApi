using estudo.domain.Common.Requests;
using estudo.domain.Interfaces.Service;
using estudo.tests.Configurations;
using Xunit;

namespace estudo.tests
{
    [Collection(nameof(InMemoryCollection))]
    public class EnderecoTests
    {
        private readonly IEnderecoService _enderecoService;
        public EnderecoTests(InMemoryBaseFixture fixture)
        {
            _enderecoService = fixture.GetService<IEnderecoService>();
        }

        [Trait("TestesIntegrados", "ClienteTeste")]
        [Fact(DisplayName = "BuscarCliente: Sucesso")]
        public async Task BuscarCliente_Retorna_Sucesso()
        {
            var input = new EnderecoCepRequest() { Cep = "88354001"};

            var result = await _enderecoService.BuscarCepAsync(input);

            Assert.True(result.Success);
        }
    }
}
