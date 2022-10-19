using estudo.domain.Auxiliar;
using estudo.domain.Common.Requests;
using estudo.domain.Common.Responses;

namespace estudo.domain.Interfaces.Service
{
    public interface IEnderecoService
    {
        Task<ResultViewModel<EnderecoCepResponse>> BuscarCepAsync(EnderecoCepRequest model);
    }
}