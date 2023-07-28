using webapi.Integration.Interfaces;
using webapi.Integration.Refit;
using webapi.Integration.Response;
using System;
using System.Net;

namespace webapi.Integration
{
    public class ViaCepIntegration : IViaCepIntegration
    {
        private readonly IViaCepIntegrationRefit _viaCepIntegrationRefit;

        public ViaCepIntegration(IViaCepIntegrationRefit viaCepIntegrationRefit)
        {
            _viaCepIntegrationRefit = viaCepIntegrationRefit;
        }

        public async Task<ViaCepResponse> ObterDadosViaCep(string cep)
        {
            var responseData = await _viaCepIntegrationRefit.ObterDadosViaCep(cep);
            Console.WriteLine("resp");
            Console.WriteLine(responseData.StatusCode);

            if (responseData != null && responseData.IsSuccessStatusCode)
            {
                return responseData.Content;
            }

            if(responseData.StatusCode == HttpStatusCode.BadRequest) {
                Console.WriteLine("é bad");
            };

            return null;
        }

    }
}
