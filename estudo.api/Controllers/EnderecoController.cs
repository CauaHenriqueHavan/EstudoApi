using estudo.api.Auxiliares;
using estudo.domain.Auxiliar;
using estudo.domain.Common.Requests;
using estudo.domain.Common.Responses;
using estudo.domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace estudo.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerApi
    {
        private readonly IEnderecoService _enderecoService;
        public EnderecoController(IEnderecoService enderecoService)
            => _enderecoService = enderecoService;

        [HttpPost]
        [ProducesResponseType(typeof(ResultViewModel<EnderecoCepResponse>), (short)HttpStatusCode.OK)]
        public async Task<IActionResult> BuscarCep([FromBody] EnderecoCepRequest model)
            => Response(await _enderecoService.BuscarCepAsync(model));
    }
}
