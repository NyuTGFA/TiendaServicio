using System;
using System.Collections.Generic;

namespace TiendaServicio.api.CarritoCompras.Aplication
{
    public class CarritoDto
    {
        public int CarritoId { get; set; }

       
        public DateTime? FechaCreacionSesion { get; set; }
        public List<CarritoDetalleDto> ListaDeProductos{ get;set; }
    }
}
