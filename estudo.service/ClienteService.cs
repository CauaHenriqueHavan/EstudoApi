using estudo.domain.DTO_s;
using estudo.domain.DTO_s.InputModels;
using estudo.domain.Enums;
using estudo.domain.Interfaces.Repository;
using estudo.domain.Interfaces.Service;
using estudo.service.Events.Notification;
using MediatR;

namespace estudo.service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMediator _mediator;

        public ClienteService(IClienteRepository clienteRepository, IMediator mediator)
        {
            _clienteRepository = clienteRepository;
            _mediator = mediator;
        } 

        public async Task<List<ClienteOutputModel>> BuscarClientesAsync()
            => await _clienteRepository.BuscarClientesAsync();

        public async Task<ClienteOutputModel> BuscarClientesIdAsync(short id)
            => await _clienteRepository.BuscarClientesIdAsync(id);

        public async Task<bool> CriarClienteAsync(CadastrarClienteInputModel model)
        {
            var cliente = await _clienteRepository.CriarClienteAsync(model);

            if (cliente != null)
            {
               await _mediator.Publish(new LogUsuarioNotification(cliente.Id, TipoEventoEnum.UsuarioCriado));
                return true;
            }

            return false;
        }
        public async Task<bool> AlterarCadastroClienteAsync(AlterarCadastroClienteInputModel model)
            => await _clienteRepository.AlterarCadastroClienteAsync(model);

    }
}