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

        public Task<List<ClienteOutputModel>> BuscarClientesAsync()
            => _clienteRepository.BuscarClientesAsync();

        public Task<ClienteOutputModel> BuscarClientesIdAsync(short id)
            => _clienteRepository.BuscarClientesIdAsync(id);

        public Task<bool> CriarClienteAsync(CadastrarClienteInputModel model)
            => _clienteRepository.CriarClienteAsync(model);
    }
}