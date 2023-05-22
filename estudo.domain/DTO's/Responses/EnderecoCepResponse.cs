namespace estudo.domain.Common.Responses
{
    public class EnderecoCepResponse
    {
        public string Cep { get; init; }
        public string Logradouro { get; init; }
        public string Complemento { get; init; }
        public string Bairro { get; init; }
        public string Localidade { get; init; }
        public string Uf { get; init; }
    }
}
