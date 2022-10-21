using estudo.domain.Auxiliar;
using estudo.domain.DTO_s.InputModels;

namespace estudo.domain.Interfaces.Service
{
    public interface IProdutoService
    {
        Task<ResultViewBaseModel> BuscarProdutosAsync(BuscarProdutosInputModel model);
    }
}
