using estudo.api.Auxiliares;
using estudo.domain.DTO_s.InputModels;
using estudo.domain.Entities;
using estudo.domain.Interfaces.Service;
using estudo.service.TokenHandler;
using Microsoft.AspNetCore.Mvc;

namespace estudo.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerApi
    {
        private readonly IUsuarioService _usuarioService;

        public LoginController(IUsuarioService usuarioService)
            => _usuarioService = usuarioService;

        [HttpPost]
        public async Task<ActionResult<dynamic>> GerarToken([FromBody] LoginInputModel model)
        {
            var usuario = _usuarioService.Get(model.Username, model.Password);

            if (usuario == null)
                return BadRequest("Usuario ou Senha invalidos!"); 

            var token = TokenService.GerarToken(usuario);

            usuario.Password = "*******";

            return new
            {
                usuario = usuario,
                token = token
            };
        }
    }
}
