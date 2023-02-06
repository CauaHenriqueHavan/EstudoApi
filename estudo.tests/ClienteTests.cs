using estudo.domain.DTO_s.InputModels;
using estudo.domain.Interfaces.Service;
using estudo.tests.Configurations;
using Xunit;

namespace estudo.tests
{
    [Collection(nameof(InMemoryCollection))]
    public class ClienteTest
    {
        public readonly IClienteService _fixture;

        public ClienteTest(InMemoryBaseFixture fixture)
        {
            _fixture = fixture.GetService<IClienteService>();
        }

        [Trait("TestesIntegrados", "ClienteTeste")]
        [Fact(DisplayName = "BuscarCliente: Sucesso")]
        public async Task BuscarCliente_Retorna_Sucesso()
        {
            var input = new BuscarClientesInputModel();

            var result = await _fixture.BuscarClientesAsync(input);

            Assert.True(result.Success);
        }

        [Trait("TestesIntegrados", "ClienteTeste")]
        [Fact(DisplayName = "CadastrarCliente: Sucesso")]
        public async Task CadastrarCliente_Retorna_Sucesso()
        {
            var input = new CadastrarClienteInputModel() { Cpf = "13211224945", DataNascimento = DateTime.Now.AddYears(-20), Nome = "Teste", Sobrenome = "Cadastro"};

            var result = await _fixture.CriarClienteAsync(input);

            Assert.True(result.Success);
        }

        [Trait("TestesIntegrados", "ClienteTeste")]
        [Fact(DisplayName = "CadastrarCliente: Falha")]
        public async Task CadastrarCliente_Retorna_Falha()
        {
            var input = new CadastrarClienteInputModel() { Cpf = "13111224945", DataNascimento = DateTime.Now.AddYears(-20), Nome = "Teste", Sobrenome = "Cadastro" };

            var result = await _fixture.CriarClienteAsync(input);

            Assert.False(result.Success);
        }

        [Trait("TestesIntegrados", "ClienteTeste")]
        [Fact(DisplayName = "AlterarCadastroCliente: Sucesso")]
        public async Task AlterarCadastroCliente_Retorna_Sucesso()
        {
            var input = new AlterarCadastroClienteInputModel() { Cpf = "13111224945", Nome = "Teste", Sobrenome = "Alterado" };

            var result = await _fixture.AlterarCadastroClienteAsync(input);

            Assert.True(result.Success);
        }

        [Trait("TestesIntegrados", "ClienteTeste")]
        [Fact(DisplayName = "AlterarCadastroCliente: Falha")]
        public async Task AlterarCadastroCliente_Retorna_Falha()
        {
            var input = new AlterarCadastroClienteInputModel() { Cpf = "13112224945", Nome = "Teste", Sobrenome = "Alterado" };

            var result = await _fixture.AlterarCadastroClienteAsync(input);

            Assert.False(result.Success);
        }

        [Trait("TestesIntegrados", "ClienteTeste")]
        [Fact(DisplayName = "AlterarSituacaoCliente: Sucesso")]
        public async Task AlterarSituacaoCliente_Retorna_Sucesso()
        {
            var result = await _fixture.AlterarSituacaoClienteAsync(1);

            Assert.True(result.Success);
        }

        [Trait("TestesIntegrados", "ClienteTeste")]
        [Fact(DisplayName = "AlterarSituacaoCliente: Falha")]
        public async Task AlterarSituacaoCliente_Retorna_Falha()
        {
            var result = await _fixture.AlterarSituacaoClienteAsync(5);

            Assert.False(result.Success);
        }
    }
}