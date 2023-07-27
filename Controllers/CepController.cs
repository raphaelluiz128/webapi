using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webapi.Integration.Interfaces;
using webapi.Integration.Response;
using System;
namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegration _viaCepIntegration;
        
        public CepController(IViaCepIntegration viaCepIntegration)
        {
            _viaCepIntegration = viaCepIntegration;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCepResponse>> ListarDadosEndereco(string cep)
        {
            try
            {
                var responseData = await _viaCepIntegration.ObterDadosViaCep(cep);

                if (responseData == null)
                {
                    return BadRequest("CEP não encontrado.");
                }
                return Ok(responseData);

            }

            catch (Exception e)
            
            {
                Console.WriteLine(e);
                return BadRequest("Erro."+e);
            }

        }
    }
}
