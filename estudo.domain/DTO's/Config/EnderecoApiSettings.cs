namespace estudo.domain.DTO_s.Config
{
    public class EnderecoApiSettings
    {
        public string EndpointBuscarEndereco { get; set; }

        public EnderecoApiSettings()
        {
        }

        public EnderecoApiSettings(string endpointBuscarEndereco)
        {
            EndpointBuscarEndereco = endpointBuscarEndereco;
        }
    }
}
