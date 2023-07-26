using webapi.Models;

namespace webapi.Repositories.Interfaces
{
    public interface ITarefaRep
    {
        Task<List<TarefaModel>> Get();
        Task<TarefaModel> Get(int id);
        Task<TarefaModel> Post(TarefaModel usuario);
        Task<TarefaModel> Put(TarefaModel usuario, int id);
        Task<bool> Delete(int id);
    }
}
