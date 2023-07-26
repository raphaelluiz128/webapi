using webapi.Attributes;

namespace webapi.Models
{
    public class UsuarioModel
    {
        [SwaggerIgnore]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
