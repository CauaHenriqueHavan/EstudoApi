using estudo.domain.DTO_s;
using estudo.domain.DTO_s.InputModels;
using estudo.domain.Entities;
using estudo.domain.Paginado;

namespace estudo.domain.Interfaces.Repository
{
    public interface IClienteRepository
    {
        Task<ClienteEntity> CriarClienteAsync(CadastrarClienteInputModel model);
        Task<PaginadoOutput<ClienteOutputModel>> BuscarClientesAsync(BuscarClientesInputModel model);
        Task<ClienteOutputModel> BuscarClientesIdAsync(short id);
        Task<ClienteEntity> AlterarCadastroClienteAsync(AlterarCadastroClienteInputModel model);

        Task<ClienteEntity> AlterarSituacaoClientesAsync(short id);
    }
}
