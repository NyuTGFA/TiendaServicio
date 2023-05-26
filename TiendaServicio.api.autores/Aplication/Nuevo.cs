using FluentValidation;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using TiendaServicio.api.autores.Modelo;
using TiendaServicio.api.autores.Persistencia;

namespace TiendaServicio.api.autores.Aplication
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {

            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }
        }


        public class EjcutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjcutaValidacion()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Apellido).NotEmpty();


            }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ContextoAutor _context;
            public Manejador(ContextoAutor contexto)
            {
                _context = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                //Se crea la instancia del cliente ligado al contexto
                var autorLibro = new AutorLibro
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    FechaNacimiento = request.FechaNacimiento,
                    AutorLibroGuid = Convert.ToString(Guid.NewGuid())
                };
                //Agregar el objeto
                _context.AutorLibros.Add(autorLibro);
                //Insertamos el valor de insercion 
                var respuesta = await _context.SaveChangesAsync();
                if (respuesta > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("NO SE PUDO INSERTAR EL CLIENTE");
            }
        }
    }
}
