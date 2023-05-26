using System.ComponentModel.DataAnnotations;

namespace TiendaServicio.api.usuarios.Modelo
{
    public class Usuario
    {


        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
