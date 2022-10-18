using estudo.domain.Auxiliar;
using estudo.domain.DTO_s;
using estudo.domain.DTO_s.InputModels;

namespace estudo.domain.Interfaces.Service
{
    public interface IClienteService
    {
        Task<ResultViewBaseModel> CriarClienteAsync(CadastrarClienteInputModel model);
        Task<ResultViewBaseModel> BuscarClientesAsync();
        Task<ResultViewBaseModel> BuscarClientesIdAsync(short id);
        Task<ResultViewBaseModel> AlterarCadastroClienteAsync(AlterarCadastroClienteInputModel model);
        Task<ResultViewBaseModel> AlterarSituacaoClienteAsync(short id);
    }
}

