using System;

namespace TiendaServicio.Api.Libro.Aplication
{
    public class LibreriaDto
    {
        public Guid? LibreriaMateriaId { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public Guid? AutorLibro { get; set; }

        public double precio { get; set; }
    }
}
