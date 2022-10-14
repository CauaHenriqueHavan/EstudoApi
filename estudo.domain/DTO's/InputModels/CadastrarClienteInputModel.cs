namespace estudo.domain.DTO_s.InputModels
{
    public class CadastrarClienteInputModel
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
    }
}
