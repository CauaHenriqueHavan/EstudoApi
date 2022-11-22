using estudo.domain.Auxiliar;
using estudo.domain.DTO_s.InputModels;
using estudo.domain.Interfaces.Repository;
using estudo.domain.Interfaces.Service;
using estudo.infra.Context;

namespace estudo.service
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork<AppDbContext> _uow;

        public ProdutoService(IProdutoRepository produtoRepository, IUnitOfWork<AppDbContext> uow)
        {
            _produtoRepository = produtoRepository;
            _uow = uow;
        }

        public async Task<ResultViewBaseModel> BuscarProdutosAsync(BuscarProdutosInputModel model)
        {
            var produtos = await _produtoRepository.BuscarProdutosAsync(model);

            if (!produtos.Itens.Any())
                return AddErros(ResourceService.ProdutoNaoEncontrado);

            return AddResult(produtos);
        }

        public async Task<ResultViewBaseModel> CriarProdutoAsync(CriarProdutoInputModel model)
        { 
           var result = await _produtoRepository.CriarProdutoAsync(model);

            await _uow.CommitAsync();

            return AddResult(result);
        }

        public async Task<ResultViewBaseModel> BuscarImagemProdutoAsync(short id)
        {
            if (id <= 0)
                return AddErros("Id inválido!");

            return AddResult(await _produtoRepository.BuscarImagemProdutoAsync(id));
        }
    }
}
