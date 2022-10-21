using estudo.api.Auxiliares;
using estudo.domain.Auxiliar;
using estudo.domain.DTO_s.InputModels;
using estudo.domain.DTO_s.OutputModels;
using estudo.domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace estudo.api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProdutoController : ControllerApi
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
            => _produtoService = produtoService;


        [HttpGet]
        [ProducesResponseType(typeof(ResultViewModel<List<ProdutosOutputModel>>), (short)HttpStatusCode.OK)]
        public async Task<IActionResult> BuscarProduto([FromQuery] BuscarProdutosInputModel model)
        {
            return Response(await _produtoService.BuscarProdutosAsync(model));
        }
    }
}
