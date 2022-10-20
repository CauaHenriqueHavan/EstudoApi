using estudo.api.Auxiliares;
using estudo.domain.Auxiliar;
using estudo.domain.DTO_s;
using estudo.domain.DTO_s.InputModels;
using estudo.domain.DTO_s.OutPutModelAuxiliar;
using estudo.domain.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace estudo.api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]

    public class ClienteController : ControllerApi
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService, IEnderecoService enderecoService)
            => _clienteService = clienteService;

        [HttpPost]
        [Authorize(Roles = "gerente")]
        [ProducesResponseType(typeof(ResultViewModel<bool>), (short)HttpStatusCode.OK)]
        public async Task<IActionResult> CriarCliente([FromBody] CadastrarClienteInputModel model)
            => Response(await _clienteService.CriarClienteAsync(model));

        [HttpGet]
        [Authorize(Roles = "gerente,atendente")]
        [ProducesResponseType(typeof(ResultViewModel<PaginadoOutputModel<ClienteOutputModel>>), (short)HttpStatusCode.OK)]
        public async Task<IActionResult> BuscarClientesAsync([FromQuery] BuscarClientesInputModel model)
             => Response(await _clienteService.BuscarClientesAsync(model));

        [HttpGet("{id}")]
        [Authorize(Roles = "gerente,atendente")]
        [ProducesResponseType(typeof(ResultViewModel<bool>), (short)HttpStatusCode.OK)]
        public async Task<IActionResult> BuscarClientesIdAsync(short id)
             => Response(await _clienteService.BuscarClientesIdAsync(id));

        [HttpPut]
        [Authorize(Roles = "gerente")]
        [ProducesResponseType(typeof(ResultViewModel<bool>), (short)HttpStatusCode.OK)]
        public async Task<IActionResult> AlterarCadastroClienteAsync(AlterarCadastroClienteInputModel model)
             => Response(await _clienteService.AlterarCadastroClienteAsync(model));

        [HttpPatch("{id}")]
        [Authorize(Roles = "gerente")]
        [ProducesResponseType(typeof(ResultViewModel<bool>), (short)HttpStatusCode.OK)]
        public async Task<IActionResult> AlterarSituacaoCliente(short id)
             => Response(await _clienteService.AlterarSituacaoClienteAsync(id));
    }
}
