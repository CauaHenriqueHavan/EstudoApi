using estudo.domain.DTO_s;
using estudo.domain.Enums;

namespace estudo.domain.Entities
{
    public class ClienteEntity
    {

        public short Id { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Cpf { get; private set; }
        public SituacaoEnum Situacao { get; private set; }

        public ClienteEntity(short id, string nome, string sobrenome, DateTime dataNascimento, string cpf, SituacaoEnum situacao)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Situacao = situacao;
        }

        public ClienteEntity AlterarCadastro(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;

            return this;
        }
    }
}
