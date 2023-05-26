using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.api.autores.Persistencia;

namespace TiendaServicio.api.autores.Aplication
{
    public class EliminarAutor
    {
        public class AutorUnico : IRequest
        {
            public int AutorLibroId { get; set; }

        }
        public class Manejador : IRequestHandler<AutorUnico>
        {
            private readonly ContextoAutor contextoAutor;


            public Manejador(ContextoAutor contextoAutor)
            {
                this.contextoAutor = contextoAutor;
            }

            public async Task<Unit> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
               var autor = await contextoAutor.AutorLibros.FindAsync(request.AutorLibroId);
                if (autor == null)
                {
                    throw new Exception("No se encontró el autor");
                }

                contextoAutor.AutorLibros.Remove(autor);
                var result = await contextoAutor.SaveChangesAsync();
                if (result> 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo eliminar el autor");

            }
        }
    }
}
