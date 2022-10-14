namespace estudo.domain.Entities
{
    public class ClienteEntity
    {

        public short Id { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Cpf { get; private set; }

        public ClienteEntity(short id, string nome, string sobrenome, DateTime dataNascimento, string cpf)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
        }
    }
}
