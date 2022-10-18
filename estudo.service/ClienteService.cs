using estudo.domain.Auxiliar;
using estudo.domain.DTO_s.InputModels;
using estudo.domain.Interfaces.Repository;
using estudo.domain.Interfaces.Service;
using estudo.infra.Context;

namespace estudo.service
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork<AppDbContext> _uow;

        public ClienteService(IClienteRepository clienteRepository, IUnitOfWork<AppDbContext> uow)
        {
             _clienteRepository = clienteRepository;
            _uow = uow;
        }
            

        public async Task<ResultViewBaseModel> BuscarClientesAsync(BuscarClientesInputModel model)
            => AddResult(await _clienteRepository.BuscarClientesAsync(model));

        public async Task<ResultViewBaseModel> BuscarClientesIdAsync(short id)
            => AddResult(await _clienteRepository.BuscarClientesIdAsync(id));

        public async Task<ResultViewBaseModel> CriarClienteAsync(CadastrarClienteInputModel model)
            => AddResult(await _clienteRepository.CriarClienteAsync(model));

        public async Task<ResultViewBaseModel> AlterarCadastroClienteAsync(AlterarCadastroClienteInputModel model)
        {
            var cliente  = await _clienteRepository.AlterarCadastroClienteAsync(model);
            if(cliente == false)
                return AddErros(ResourceService.ClienteNaoEncontrado);

            await _uow.CommitAsync();

            return AddResult(true);
        }
           

        public async Task<ResultViewBaseModel> AlterarSituacaoClienteAsync(short id)
        {
            if (id <= 0)
                return AddErros(ResourceService.IdInvalido);

            var cliente = await _clienteRepository.AlterarSituacaoClientesAsync(id);

            if (cliente == null)
                return AddErros(ResourceService.ClienteNaoEncontrado);

            await _uow.CommitAsync();

            return AddResult(true);
        }
    }
}