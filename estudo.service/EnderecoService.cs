using estudo.domain.Auxiliar;
using estudo.domain.Common.Requests;
using estudo.domain.Common.Responses;
using estudo.domain.DTO_s.Config;
using estudo.domain.Interfaces.Service;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace estudo.service
{
    public class EnderecoService : IEnderecoService
    {
        private readonly HttpClient _httpClient;
        private readonly EnderecoApiSettings _enderecoApiSettings;

        public EnderecoService(HttpClient httpClient, IOptions<EnderecoApiSettings> enderecoApiSettings)
        {
            _httpClient = httpClient;
            _enderecoApiSettings = enderecoApiSettings.Value;
        }

        public async Task<ResultViewModel<EnderecoCepResponse>> BuscarCepAsync(EnderecoCepRequest model)
        {
            var retorno = new ResultViewModel<EnderecoCepResponse>();
            
            var response = await _httpClient.GetAsync(string.Format(_enderecoApiSettings.EndpointBuscarEndereco, model.Cep));

            if (!response.IsSuccessStatusCode)
                return retorno.AddErros("Erro ao buscar CEP!");

            var result = JsonConvert.DeserializeObject<EnderecoCepResponse>(await response.Content.ReadAsStringAsync());

            return result.Cep is null
                ? retorno.AddErros("Cep inválido ou não encontrado")
                : retorno.AddResult(result);
        }
    }
}