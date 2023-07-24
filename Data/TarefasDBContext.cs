using Microsoft.EntityFrameworkCore;
using webapi.Data.Map;
using webapi.Models;

namespace webapi.Data
{
    public class TarefasDBContext : DbContext
    {
        public TarefasDBContext(DbContextOptions<TarefasDBContext> options) 
            : base(options) 
        { 
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
