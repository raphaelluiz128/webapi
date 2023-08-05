using webapi.Integration.Interfaces;
using webapi.Integration.Refit;
using webapi.Integration.Response;
using System;
using System.Net;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using Azure;
using Microsoft.AspNetCore.ResponseCompression;
using Refit;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace webapi.Integration
{
    public class ViaCepIntegration : IViaCepIntegration
    {
        private readonly IViaCepIntegrationRefit _viaCepIntegrationRefit;
        public ViaCepIntegration(IViaCepIntegrationRefit viaCepIntegrationRefit)
        {
            _viaCepIntegrationRefit = viaCepIntegrationRefit;
        }

        public async Task<ApiResponse<ViaCepResponse>> ObterDadosViaCep(string cep)
        {
            var responseData = await _viaCepIntegrationRefit.ObterDadosViaCep(cep); 
                return responseData;          
        }

    }
}
