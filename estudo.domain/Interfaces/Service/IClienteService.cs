using estudo.domain.DTO_s;
using estudo.domain.DTO_s.InputModels;

namespace estudo.domain.Interfaces.Service
{
    public interface IClienteService
    {
        Task<bool> CriarClienteAsync(CadastrarClienteInputModel model);
        Task<List<ClienteOutputModel>> BuscarClientesAsync();
        Task<ClienteOutputModel> BuscarClientesIdAsync(short id);
        Task<bool> AlterarCadastroClienteAsync(AlterarCadastroClienteInputModel model);
    }
}
