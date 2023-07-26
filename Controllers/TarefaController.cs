using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Repositories.Interfaces;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRep _tarefaRep;

        public TarefaController(ITarefaRep tarefaRep)
        {
            _tarefaRep = tarefaRep;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> Get()
        {
            List<TarefaModel> tarefas = await _tarefaRep.Get();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> Get(int id)
        {
            TarefaModel tarefa = await _tarefaRep.Get(id);
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Post([FromBody] TarefaModel tarefaModel)
        {
            TarefaModel tarefa = await _tarefaRep.Post(tarefaModel);
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> Put([FromBody] TarefaModel tarefaModel, int id)
        {
            tarefaModel.Id = id;
            TarefaModel tarefa = await _tarefaRep.Put(tarefaModel, id);
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Delete(int id)
        {
            bool apagado = await _tarefaRep.Delete(id);
            return Ok(apagado);
        }
    }
}
