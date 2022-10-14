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
            => id == null ? null : await _clienteRepository.BuscarClientesIdAsync(id);

        public Task<bool> CriarClienteAsync(CadastrarClienteInputModel model)
            => _clienteRepository.CriarClienteAsync(model);
    }
}