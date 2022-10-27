using estudo.domain.DTO_s.InputModels;
using estudo.domain.DTO_s.OutPutModelAuxiliar;
using estudo.domain.DTO_s.OutputModels;

namespace estudo.domain.Interfaces.Repository
{
    public interface IProdutoRepository
    {
        Task<PaginadoOutputModel<ProdutosOutputModel>> BuscarProdutosAsync(BuscarProdutosInputModel model);
        Task<bool> CriarProdutoAsync(CriarProdutoInputModel model);
        Task<string> BuscarImagemProdutoAsync(short id);
    }
}
