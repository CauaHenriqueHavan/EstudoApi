using estudo.api.Auxiliares;
using estudo.domain.Auxiliar;
using estudo.domain.DTO_s.InputModels;
using estudo.domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace estudo.api.Controllers
{
    [ApiController]
    [Route("api/")]

    public class ClienteController : ControllerApi
    {
        private readonly IClienteService _clienteService;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(IClienteService clienteService, ILogger<ClienteController> logger)
        {
            _clienteService = clienteService;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResultViewModel<bool>), (short)HttpStatusCode.OK)]
        public async Task<IActionResult> CriarCliente([FromBody] CadastrarClienteInputModel model)
            => Response(await _clienteService.CriarClienteAsync(model));

        [HttpGet]
        [ProducesResponseType(typeof(ResultViewModel<bool>), (short)HttpStatusCode.OK)]
        public async Task<IActionResult> BuscarClientesAsync()
            => Response(await _clienteService.BuscarClientesAsync());

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResultViewModel<bool>), (short)HttpStatusCode.OK)]
        public async Task<IActionResult> BuscarClientesIdAsync(short id)
            => Response(await _clienteService.BuscarClientesIdAsync(id));

        [HttpPut]
        [ProducesResponseType(typeof(ResultViewModel<bool>), (short)HttpStatusCode.OK)]
        public async Task<IActionResult> AlterarCadastroClienteAsync(AlterarCadastroClienteInputModel model)
            => Response(await _clienteService.AlterarCadastroClienteAsync(model));

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(ResultViewModel<bool>), (short)HttpStatusCode.OK)]
        public async Task<IActionResult> AlterarSituacaoCliente(short id)
             => Response(await _clienteService.AlterarSituacaoClienteAsync(id));
    }
}
