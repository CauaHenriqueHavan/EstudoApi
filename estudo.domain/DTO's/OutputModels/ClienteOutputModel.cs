using estudo.domain.Entities;
using estudo.domain.Enums;

namespace estudo.domain.DTO_s
{
    public class ClienteOutputModel
    {
        public short Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public SituacaoEnum Situacao { get; set; }

        public static implicit operator ClienteOutputModel(ClienteEntity entidade)
            => new()
            {
                Cpf = entidade.Cpf,
                DataNascimento = entidade.DataNascimento,
                Id = entidade.Id,
                Nome = entidade.Nome,
                Situacao = entidade.Situacao,
                Sobrenome = entidade.Sobrenome
            };
    }
}
