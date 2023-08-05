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

                switch (responseData.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        return Ok(responseData.Content);
                    case System.Net.HttpStatusCode.Unauthorized:
                        return Unauthorized();
                    case System.Net.HttpStatusCode.NotFound:
                        return NotFound("Não encontrado.");
                    default:
                        return BadRequest();
                }

            }

            catch (Exception e)
            
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }

        }
    }
}
