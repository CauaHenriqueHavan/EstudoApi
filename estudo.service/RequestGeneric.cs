using estudo.domain.Auxiliar;
using Newtonsoft.Json;
using System.Text;

namespace estudo.service
{
    public class RequestGeneric
    {
        public static async Task<ResultViewModel<TResponse>> RequisicaoHttp<TRequest, TResponse>(string url, HttpMethod httpMethod, TRequest requestBody = default)
        {
            var resultado = new ResultViewModel<TResponse>();

            using var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = new Uri(url)
            };

            if (requestBody != null)
            {
                var jsonContent = JsonConvert.SerializeObject(requestBody);
                request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            }

            var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            if (!response.IsSuccessStatusCode)
                return resultado.AddErros("ErroRealizarRequisicao");

            var responseObj = JsonConvert.DeserializeObject<TResponse>(await response.Content?.ReadAsStringAsync());

            return resultado.AddResult(responseObj);
        }
    }
}
