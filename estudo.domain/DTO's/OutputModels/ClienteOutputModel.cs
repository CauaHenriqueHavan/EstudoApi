using estudo.domain.Entities;

namespace estudo.domain.DTO_s
{
    public class ClienteOutputModel
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public DateTime DataCriação { get; set; }
    }
}
