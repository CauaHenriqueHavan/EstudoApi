using estudo.domain.Auxiliar;
using estudo.domain.Common.Requests;
using estudo.domain.Common.Responses;
using estudo.domain.DTO_s.Config;
using estudo.domain.Interfaces.Service;
using static estudo.service.RequestGeneric;

namespace estudo.service
{
    public class EnderecoService : IEnderecoService
    {
        private readonly HttpClient _httpClient;
        private readonly EnderecoApiSettings _enderecoApiSettings;

        public EnderecoService(HttpClient httpClient, EnderecoApiSettings enderecoApiSettings)
        {
            _httpClient = httpClient;
            _enderecoApiSettings = enderecoApiSettings;
        }

        public async Task<ResultViewModel<EnderecoCepResponse>> BuscarCepAsync(EnderecoCepRequest model)
        {
            var response = await RequisicaoHttp<EnderecoCepRequest, EnderecoCepResponse>(string.Format(_enderecoApiSettings.EndpointBuscarEndereco, model.Cep), HttpMethod.Get, null);

            var retorno = new ResultViewModel<EnderecoCepResponse>();

            return response.Result?.Cep is null
                 ? retorno.AddErros("Cep inválido ou não encontrado")
                 : response;
        }
    }
}