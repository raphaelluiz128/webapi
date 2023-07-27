using Refit;
using webapi.Integration.Response;

namespace webapi.Integration.Refit
{
    public interface IViaCepIntegrationRefit
    {
        //viacep.com
        //{cep} é parametro cep , no caso na url
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> ObterDadosViaCep(string cep);
    }
}
