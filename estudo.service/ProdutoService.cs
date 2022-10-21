using estudo.domain.Auxiliar;
using estudo.domain.DTO_s.InputModels;
using estudo.domain.Interfaces.Repository;
using estudo.domain.Interfaces.Service;

namespace estudo.service
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
            => _produtoRepository = produtoRepository;


        public async Task<ResultViewBaseModel> BuscarProdutosAsync(BuscarProdutosInputModel model)
        {
            var produtos = await _produtoRepository.BuscarProdutosAsync(model);

            if (!produtos.Itens.Any())
                return AddErros(ResourceService.ProdutoNaoEncontrado);

            return AddResult(produtos);
        }
    }
}
