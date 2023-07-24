using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;
using webapi.Repositories.Interfaces;

namespace webapi.Repositories
{
    public class UsuarioRep : IUsuarioRep

    {
        private readonly TarefasDBContext _dbContext;

        public UsuarioRep(TarefasDBContext tarefasDBContext) {
            _dbContext = tarefasDBContext;
        }
        public async Task<List<UsuarioModel>> Get()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Get(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<bool> Delete(int id)
        {
            UsuarioModel usuarioPorId = await Get(id);
            if (usuarioPorId == null)
            {
                throw new Exception("Usuário não encontrado no banco");
            }
            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        
        }


        public async Task<UsuarioModel> Post(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

       public  async Task<UsuarioModel> Put(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await Get(id);
            if(usuarioPorId == null)
            {
                throw new Exception("Usuário não encontrado no banco");
            }

            usuarioPorId.Name = usuario.Name;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

    }
}
