using webapi.Integration.Response;

namespace webapi.Integration.Interfaces
{
    public interface IViaCepIntegration
    {
        Task<ViaCepResponse> ObterDadosViaCep(string cep);
    }
}
