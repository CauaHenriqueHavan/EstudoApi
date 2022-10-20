namespace estudo.domain.Entities
{
    public class UsuarioEntity
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
    }
}
