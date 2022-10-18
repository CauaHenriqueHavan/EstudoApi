using estudo.domain.DTO_s.InputModels;
using estudo.domain.DTO_s;

namespace estudo.domain.Interfaces.Repository
{
    public interface IClienteRepository
    {
        Task<bool> CriarClienteAsync(CadastrarClienteInputModel model);
        Task<List<ClienteOutputModel>> BuscarClientesAsync();
        Task<ClienteOutputModel> BuscarClientesIdAsync(short id);
        Task<bool> AlterarCadastroClienteAsync(AlterarCadastroClienteInputModel model);
    }
}
