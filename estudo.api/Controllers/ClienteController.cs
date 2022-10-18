using estudo.domain.DTO_s;
using estudo.domain.DTO_s.InputModels;
using estudo.domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace estudo.api.Controllers
{
    [ApiController]
    [Route("api/")]

    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(IClienteService clienteService, ILogger<ClienteController> logger)
        {
            _clienteService = clienteService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CriarCliente([FromBody] CadastrarClienteInputModel model)
        {
            var result = await _clienteService.CriarClienteAsync(model);

            if (!result)
                return BadRequest("Não foi possivel criar cadastro!");

            return Ok();
        }

        [HttpGet]
        public async Task<List<ClienteOutputModel>> BuscarClientesAsync()
            => await _clienteService.BuscarClientesAsync();

        [HttpGet("{id}")]
        public async Task<ClienteOutputModel> BuscarClientesIdAsync(short id)
            => await _clienteService.BuscarClientesIdAsync(id);

        [HttpPut]
        public async Task<IActionResult> AlterarCadastroClienteAsync(AlterarCadastroClienteInputModel model)
        {
            var result = await _clienteService.AlterarCadastroClienteAsync(model);

            if (!result)
                return BadRequest("Não foi possivel alterar cadastro!");

            return Ok("Alterado com sucesso!");
        }
    }
}
