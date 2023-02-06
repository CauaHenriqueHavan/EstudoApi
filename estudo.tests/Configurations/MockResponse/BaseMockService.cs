using Moq;
using Moq.Protected;
using System.Net;

namespace estudo.tests.Configurations.MockResponse
{
    public abstract class BaseMockService
    {
        protected readonly string UrlBase;

        public HttpClient HttpClient { get; set; }

        public BaseMockService(string urlBase)
        {
            UrlBase= urlBase;
        }

        protected static void SetupMessageHandler(Mock<HttpMessageHandler> messageHandler, string nomeMetodo, Func<HttpRequestMessage, bool> acao, HttpStatusCode statusCode, HttpContent conteudo)
        {
            messageHandler.Protected().Setup<Task<HttpResponseMessage>>(nomeMetodo, new object[2]
            {
                ItExpr.Is((HttpRequestMessage req) => acao(req)),
                ItExpr.IsAny<CancellationToken>()
            }).ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = conteudo
            });
        }
    }
}
