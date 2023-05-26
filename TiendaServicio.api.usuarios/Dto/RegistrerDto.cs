using System.ComponentModel.DataAnnotations;

namespace TiendaServicio.api.usuarios.Dto
{
    public class RegistrerDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
