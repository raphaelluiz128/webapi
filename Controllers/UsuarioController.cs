using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Repositories.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRep? _usuarioRep;
        
        public UsuarioController(IUsuarioRep usuarioRep)
        {
            _usuarioRep = usuarioRep;
        }

        // GET: api/<UsuariosController>
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> Get()
        {
            List<UsuarioModel> usuarios = await _usuarioRep.Get();
            return Ok(usuarios);
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel usuario = await _usuarioRep.Get(id);
            return Ok(usuario);
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRep.Post(usuarioModel);
            return Ok(usuario);
        }


        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _usuarioRep.Put(usuarioModel, id);
            return Ok(usuario);
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            bool apagado = await _usuarioRep.Delete(id);
            return Ok(apagado);
        }
    }
}
