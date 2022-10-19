using estudo.domain.Auxiliar;
using estudo.domain.Common.Requests;
using estudo.domain.Common.Responses;
using estudo.domain.Interfaces.Service;
using Newtonsoft.Json;

namespace estudo.service
{
    public class EnderecoService : IEnderecoService
    {
        public async Task<ResultViewModel<EnderecoCepResponse>> BuscarCepAsync(EnderecoCepRequest model)
        {
            var retorno = new ResultViewModel<EnderecoCepResponse>();
            
            using var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://viacep.com.br/");
            var response = await httpClient.GetAsync($"ws/{model.Cep}/json/");

            if (!response.IsSuccessStatusCode)
                return retorno.AddErros("Erro ao buscar CEP!");

            var result = JsonConvert.DeserializeObject<EnderecoCepResponse>(await response.Content.ReadAsStringAsync());

            return retorno.AddResult(result);
        }
    }
}
