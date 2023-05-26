using Microsoft.EntityFrameworkCore;
using TiendaServicio.api.CarritoCompras.Modelo;

namespace TiendaServicio.api.CarritoCompras.Persistencia
{
    public class CarritoContexto :DbContext
    {
        public CarritoContexto(DbContextOptions<CarritoContexto>options): base(options)
        {

        }
        
        public DbSet<CarritoSesion> CarritoSesion { get; set; }
        public DbSet<CarritoSesionDetalle> CarritoSesionDetalles { get; set; }
        
    }
}
