using estudo.domain.DTO_s;
using estudo.domain.DTO_s.InputModels;
using estudo.domain.Interfaces.Repository;
using estudo.domain.Interfaces.Service;

namespace estudo.service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
            => _clienteRepository = clienteRepository;

        public async Task<List<ClienteOutputModel>> BuscarClientesAsync()
            => await _clienteRepository.BuscarClientesAsync();

        public async Task<ClienteOutputModel> BuscarClientesIdAsync(short id)
            => await _clienteRepository.BuscarClientesIdAsync(id);

        public async Task<bool> CriarClienteAsync(CadastrarClienteInputModel model)
            => await _clienteRepository.CriarClienteAsync(model);

        public async Task<bool> AlterarCadastroClienteAsync(AlterarCadastroClienteInputModel model)
            => await _clienteRepository.AlterarCadastroClienteAsync(model);

        public async Task<bool> AlterarSituacaoClienteAsync(short id)
        {
            if (id <= 0)
                return false;

            await _clienteRepository.AlterarSituacaoClientesAsync(id);
     
            return true;
        }
    }
}