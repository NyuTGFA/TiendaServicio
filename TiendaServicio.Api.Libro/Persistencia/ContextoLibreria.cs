using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TiendaServicio.Api.Libro.Modelo;

namespace TiendaServicio.Api.Libro.Persistencia
{
    public class ContextoLibreria: DbContext
    {
         public ContextoLibreria(DbContextOptions<ContextoLibreria> options) : base(options)
    {

    }

    public DbSet<Libreria> Librerias { get; set; }
}
}
