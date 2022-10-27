using estudo.domain.Auxiliar;
using estudo.domain.DTO_s.InputModels;
using estudo.domain.Enums;
using estudo.domain.Interfaces.Repository;
using estudo.domain.Interfaces.Service;
using estudo.infra.Context;
using estudo.service.Events.Notification;
using MediatR;

namespace estudo.service
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork<AppDbContext> _uow;
        private readonly IMediator _mediator;

        public ClienteService(IClienteRepository clienteRepository, IUnitOfWork<AppDbContext> uow, IMediator mediator)
        {
            _clienteRepository = clienteRepository;
            _uow = uow;
            _mediator = mediator;
        }


        public async Task<ResultViewBaseModel> BuscarClientesAsync(BuscarClientesInputModel model)
            => AddResult(await _clienteRepository.BuscarClientesAsync(model));

        public async Task<ResultViewBaseModel> BuscarClientesIdAsync(short id)
            => AddResult(await _clienteRepository.BuscarClientesIdAsync(id));

        public async Task<ResultViewBaseModel> CriarClienteAsync(CadastrarClienteInputModel model)
        {
           var cliente = await _clienteRepository.CriarClienteAsync(model);

            if (cliente != null)
            {
               await _mediator.Publish(new LogUsuarioNotification(cliente.Id, TipoEventoEnum.UsuarioCriado));

                return AddResult(ResourceService.ClienteCriado);
            }

            return AddErros(ResourceService.ErroCriarCliente);
        }
        

        public async Task<ResultViewBaseModel> AlterarCadastroClienteAsync(AlterarCadastroClienteInputModel model)
        {
            var cliente  = await _clienteRepository.AlterarCadastroClienteAsync(model);
            if(cliente == null)
                return AddErros(ResourceService.ClienteNaoEncontrado);

            await _uow.CommitAsync();

            await _mediator.Publish(new LogUsuarioNotification(cliente.Id, TipoEventoEnum.AlteradoUsuario));

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

            await _mediator.Publish(new LogUsuarioNotification(cliente.Id, TipoEventoEnum.AlteradoUsuario));

            return AddResult(true);
        }
    }
}