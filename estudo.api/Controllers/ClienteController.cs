using estudo.domain.DTO_s;
using estudo.domain.DTO_s.InputModels;
using estudo.domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace estudo.api.Controllers
{
    [ApiController]
    [Route("api/")]

    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
            => _clienteService = clienteService;

        [HttpPost]
        public async Task<IActionResult> CriarCliente([FromBody]CadastrarClienteInputModel model)
        {
            await _clienteService.CriarClienteAsync(model);

            return Ok();
        }

        [HttpGet]
        public async Task<List<ClienteOutputModel>> BuscarClientesAsync()
            => await _clienteService.BuscarClientesAsync();

        [HttpGet("{id}")]
        public async Task<ClienteOutputModel> BuscarClientesIdAsync(short id)
            => await _clienteService.BuscarClientesIdAsync(id);
    }
}
