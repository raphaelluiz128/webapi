﻿using webapi.Integration.Interfaces;
using webapi.Integration.Refit;
using webapi.Integration.Response;
using System;

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

            if (responseData != null && responseData.IsSuccessStatusCode)
            {
                return responseData.Content;
            }


            return null;
        }

    }
}
