using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.Api.Libro.Modelo;
using TiendaServicio.Api.Libro.Persistencia;

namespace TiendaServicio.Api.Libro.Aplication
{
    public class Nuevo
    {

        public class Ejecuta : IRequest
        {
        
            public string Titulo { get; set; }
            public DateTime FechaPublicacion { get; set; }
            public double Precio { get; set; }
            public Guid? AutorLibro { get; set; }
            

        }


        public class EjcutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjcutaValidacion()
            {
                
                RuleFor(x => x.Titulo).NotEmpty();
                RuleFor(x => x.FechaPublicacion).NotEmpty();
                RuleFor(x => x.AutorLibro).NotEmpty();
                RuleFor(x => x.Precio).NotEmpty();


            }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ContextoLibreria _context;
            public Manejador(ContextoLibreria contexto)
            {
                _context = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
           
                

                var Libreria = new Libreria
                {
                  
                    Titulo = request.Titulo,
                    FechaPublicacion = request.FechaPublicacion,
                    Precio= request.Precio,
                    AutorLibro =request.AutorLibro,
                   

                    

                };
                //agregamos el objeto
                _context.Librerias.Add(Libreria);
                //insertamos el valor de la insercion
                var respuesta = await _context.SaveChangesAsync();
                if(respuesta > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("jajaj no se pudo insertar el libro papu");
            }
        }
    }
}