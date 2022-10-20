using estudo.domain.DTO_s.OutputModels;
using estudo.domain.Entities;
using estudo.domain.Interfaces.Repository;
using estudo.infra.Context;

namespace estudo.infra.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
            => _context = context;

        public  UsuarioOutputModel BuscarUsuarioAsync(string nome, string senha)
            => _context.Usuario.Where(x => x.Username.ToLower() == nome.ToLower() &&
                                                   x.Password.ToLower() == senha.ToLower())
                                                   .Select(x => new UsuarioOutputModel
                                                   {
                                                       Id = x.Id,
                                                       Password = x.Password,
                                                       Role = x.Role,
                                                       Username = x.Username
                                                   }).FirstOrDefault();

    }
}
