using System.ComponentModel.DataAnnotations;

namespace TiendaServicio.Api.Libreria.Modelo
{
    public class Librerias
    {
        [Key]
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string CorreoContacto { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
       
    }
}
