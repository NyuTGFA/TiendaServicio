using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using TiendaServicio.api.autores.Modelo;
using TiendaServicio.api.autores.Persistencia;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace TiendaServicio.api.autores.Aplication
{
    public class EditarAutor
    {


        public class AutorUnico : IRequest
        {
            public int AutorLibroId { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }
            public string AutorLibroGuid { get; set; }
        }

        public class EjcutaValidacion : AbstractValidator<AutorUnico>
        {
            public EjcutaValidacion()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Apellido).NotEmpty();
                RuleFor(x => x.FechaNacimiento).NotEmpty();


            }
        }


        public class Manejador : IRequestHandler<AutorUnico>
        {
            private readonly ContextoAutor _contexto;


            public Manejador(ContextoAutor contexto)
            {
                _contexto = contexto;

            }


            

            public async Task<Unit> Handle(AutorUnico request, CancellationToken cancellationToken)
            {

                var cliente = await _contexto.AutorLibros.FindAsync(request.AutorLibroId);
                if (cliente == null)
                {
                    throw new Exception("No se encontro el autor ");
                }

                cliente.AutorLibroId = request.AutorLibroId;
                cliente.Nombre = request.Nombre ?? cliente.Nombre;
                cliente.Apellido = request.Apellido ?? cliente.Apellido;

                cliente.FechaNacimiento = request.FechaNacimiento != default ? request.FechaNacimiento : cliente.FechaNacimiento;

               
                
                var result = await _contexto.SaveChangesAsync();

                if (result > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo actualizar el autor");
            }
        }
    }
}

      
  
       
   
