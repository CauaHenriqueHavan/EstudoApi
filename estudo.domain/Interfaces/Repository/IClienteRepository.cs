using estudo.domain.DTO_s.InputModels;
using estudo.domain.DTO_s;
using estudo.domain.Entities;

namespace estudo.domain.Interfaces.Repository
{
    public interface IClienteRepository
    {
        Task<ClienteEntity> CriarClienteAsync(CadastrarClienteInputModel model);
        Task<List<ClienteOutputModel>> BuscarClientesAsync();
        Task<ClienteOutputModel> BuscarClientesIdAsync(short id);
        Task<bool> AlterarCadastroClienteAsync(AlterarCadastroClienteInputModel model);

        Task<ClienteEntity> AlterarSituacaoClientesAsync(short id);
    }
}
