using System.ComponentModel.DataAnnotations;
using System;

namespace TiendaServicio.Api.Libro.Modelo
{
    public class Libreria
    {
        [Key]
        public Guid? LibreriaMateriaId { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public Guid? AutorLibro { get; set; }

        public double Precio { get; set; }
    }
}
