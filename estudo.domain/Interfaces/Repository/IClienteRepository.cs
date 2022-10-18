using estudo.domain.DTO_s.InputModels;
using estudo.domain.DTO_s;
using estudo.domain.Entities;
using estudo.domain.DTO_s.OutPutModelAuxiliar;

namespace estudo.domain.Interfaces.Repository
{
    public interface IClienteRepository
    {
        Task<bool> CriarClienteAsync(CadastrarClienteInputModel model);
        Task<PaginadoOutputModel<ClienteOutputModel>> BuscarClientesAsync(BuscarClientesInputModel model);
        Task<ClienteOutputModel> BuscarClientesIdAsync(short id);
        Task<bool> AlterarCadastroClienteAsync(AlterarCadastroClienteInputModel model);

        Task<ClienteEntity> AlterarSituacaoClientesAsync(short id);
    }
}
