using estudo.api.Auxiliares;
using estudo.domain.Auxiliar;
using estudo.domain.DTO_s.InputModels;
using estudo.domain.DTO_s.OutputModels;
using estudo.domain.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "gerente,atendente")]
        [HttpGet]
        [ProducesResponseType(typeof(ResultViewModel<List<ProdutosOutputModel>>), (short)HttpStatusCode.OK)]
        public async Task<IActionResult> BuscarProduto([FromQuery] BuscarProdutosInputModel model)
            => Response(await _produtoService.BuscarProdutosAsync(model));
        [Authorize(Roles = "gerente")]
        [HttpPost]
        [ProducesResponseType(typeof(ResultViewModel<bool>), (short)HttpStatusCode.OK)]
        public async Task<IActionResult> CriarProduto([FromForm] CriarProdutoInputModel model)
            => Response(await _produtoService.CriarProdutoAsync(model));

        [Authorize(Roles = "gerente,atendente")]
        [Route("/BuscarImagemProduto")]
        [HttpGet]
        [ProducesResponseType(typeof(ResultViewModel<string>), (short)HttpStatusCode.OK)]
        public async Task<IActionResult> BuscarImagemProduto([FromQuery] short id)
            => Response(await _produtoService.BuscarImagemProdutoAsync(id));
    }
}
