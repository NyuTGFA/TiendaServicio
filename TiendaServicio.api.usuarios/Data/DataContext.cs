using Microsoft.EntityFrameworkCore;
using TiendaServicio.api.usuarios.Modelo;

namespace TiendaServicio.api.usuarios.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 
        
        }

        public DbSet<Usuario>?  users  { get; set; }
    }
}
