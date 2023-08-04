using Refit;
using webapi.Integration.Response;

namespace webapi.Integration.Interfaces
{
    public interface IViaCepIntegration
    {
        Task<ApiResponse<ViaCepResponse>> ObterDadosViaCep(string cep);

    }
}
