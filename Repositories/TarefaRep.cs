using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;
using webapi.Repositories.Interfaces;

namespace webapi.Repositories
{
    public class TarefaRep : ITarefaRep
    {
        private readonly TarefasDBContext _dbContext;
        public TarefaRep(TarefasDBContext tarefasDBContex)
        {
            _dbContext = tarefasDBContex;
        }

        public async Task<TarefaModel> Get(int id)
        {
            return await _dbContext.Tarefas
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefaModel>> Get()
        {
            return await _dbContext.Tarefas
                .Include(x => x.Usuario)
                .ToListAsync();
        }

        public async Task<TarefaModel> Post(TarefaModel tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();

            return tarefa;
        }

        public async Task<TarefaModel> Put(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await Get(id);

            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrado no banco de dados.");
            }

            tarefaPorId.Description = tarefa.Description;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioId = tarefa.UsuarioId;

            _dbContext.Tarefas.Update(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return tarefaPorId;
        }

        public async Task<bool> Delete(int id)
        {
            TarefaModel tarefaPorId = await Get(id);

            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Tarefas.Remove(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
