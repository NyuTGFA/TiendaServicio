using Microsoft.EntityFrameworkCore;
using TiendaServicio.api.autores.Modelo;

namespace TiendaServicio.api.autores.Persistencia
{
    public class ContextoAutor : DbContext
    {
        public ContextoAutor(DbContextOptions<ContextoAutor> options) : base(options)
        {

        }
        public DbSet<AutorLibro> AutorLibros { get; set; }
        public DbSet<GradoAcademico> GradosAcademicos { get; set; }


    }
}
