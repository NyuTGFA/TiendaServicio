using System;

namespace TiendaServicio.api.CarritoCompras.Aplication
{
    public class CarritoDetalleDto
    {
        public Guid? LibroId { get; set; }

        public string TituloLibro { get; set; }
        public Guid? AutorLibro { get; set; }
        public double   Precio { get; set; }
        public DateTime? FechaPublicacion { get; set; }

       
    }
}
