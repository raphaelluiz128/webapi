using webapi.Models;

namespace webapi.Repositories.Interfaces
{
    public interface IUsuarioRep
    {
        Task<List<UsuarioModel>> Get();
        Task<UsuarioModel> Get(int id);
        Task<UsuarioModel> Post(UsuarioModel usuario);
        Task<UsuarioModel> Put(UsuarioModel usuario, int id);
        Task<bool> Delete(int id);
    }
}
