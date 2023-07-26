using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapi.Models;

namespace webapi.Data.Map
{
    public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
    {
        public void Configure(EntityTypeBuilder<TarefaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.UsuarioId);

            builder.HasOne(x => x.Usuario);
        }
    }
}
