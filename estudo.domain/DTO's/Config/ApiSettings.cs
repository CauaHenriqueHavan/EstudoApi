namespace Havan.DadosMestre.Domain.DTOs.Config
{
    public class ApiSettings
    {
        public string ApiKey { get; set; }

        public ApiSettings() { }
        public ApiSettings(string apiKey)
            => ApiKey = apiKey;
    }
}
