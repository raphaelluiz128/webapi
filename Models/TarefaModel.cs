using webapi.Enums;

namespace webapi.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public StatusTarefaEnum? Status { get; set; }
    }
}
