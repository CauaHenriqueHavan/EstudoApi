using estudo.domain.DTO_s.OutputModels;
using estudo.domain.Entities;

namespace estudo.domain.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        UsuarioOutputModel BuscarUsuarioAsync(string nome, string senha);
    }
}
