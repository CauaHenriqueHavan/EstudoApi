using estudo.domain.DTO_s;
using estudo.domain.DTO_s.InputModels;
using estudo.domain.Interfaces.Repository;
using estudo.domain.Interfaces.Service;
using estudo.infra.Context;

namespace estudo.service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork<AppDbContext> _uow;

        public ClienteService(IClienteRepository clienteRepository, IUnitOfWork<AppDbContext> uow)
        {
             _clienteRepository = clienteRepository;
            _uow = uow;
        }
            

        public async Task<List<ClienteOutputModel>> BuscarClientesAsync()
            => await _clienteRepository.BuscarClientesAsync();

        public async Task<ClienteOutputModel> BuscarClientesIdAsync(short id)
            => await _clienteRepository.BuscarClientesIdAsync(id);

        public async Task<bool> CriarClienteAsync(CadastrarClienteInputModel model)
        {
            await _clienteRepository.CriarClienteAsync(model);

            await _uow.CommitAsync();

            return true;
        } 
        public async Task<bool> AlterarCadastroClienteAsync(AlterarCadastroClienteInputModel model)
        {
           var cliente =  await _clienteRepository.AlterarCadastroClienteAsync(model);
            if (cliente == false)
                return false;

            await _uow.CommitAsync();

            return true;
        }
             

        public async Task<bool> AlterarSituacaoClienteAsync(short id)
        {
            if (id <= 0)
                return false;

            var cliente = await _clienteRepository.AlterarSituacaoClientesAsync(id);

            if (cliente == null)
                return false;

            await _uow.CommitAsync();

            return true;
        }
    }
}