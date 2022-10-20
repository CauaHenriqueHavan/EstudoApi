using estudo.domain.DTO_s.OutputModels;
using estudo.domain.Entities;
using estudo.domain.Interfaces.Repository;
using estudo.domain.Interfaces.Service;

namespace estudo.service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
            => _usuarioRepository = usuarioRepository;

        public UsuarioOutputModel Get(string username, string password)
            => _usuarioRepository.BuscarUsuarioAsync(username, password);
    }
}
