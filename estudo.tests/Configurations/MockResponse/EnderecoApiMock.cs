using estudo.domain.Common.Responses;
using Moq;
using Newtonsoft.Json;
using System.Net;

namespace estudo.tests.Configurations.MockResponse
{
    public class EnderecoApiMock : BaseMockService
    {
        private readonly string _urlBase;
        public EnderecoApiMock(string urlBase) : base(urlBase)
        {
            _urlBase= urlBase;
            BuildarHttpClient();
        }

        private void BuildarHttpClient()
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            var objRetorno = new EnderecoCepResponse() { Bairro = "Centro", Cep = "883500001", Complemento = "Lado A", Localidade = "Brusque", Logradouro = "Av Consul Carlos Renaux", Uf = "SC" };

            SetupMessageHandler
                (
                    mockHttpMessageHandler,
                    "SendAsync",
                    (r) => true,
                    HttpStatusCode.OK,
                    new StringContent(JsonConvert.SerializeObject(objRetorno))

                );

            HttpClient = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri(_urlBase)
            };
        }
    }
}
