using estudo.domain.DTO_s.OutputModels;

namespace estudo.domain.Interfaces.Service
{
    public interface IUsuarioService
    {
         UsuarioOutputModel Get(string username, string password);
    }
}
