using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.Api.Libro.Modelo;
using TiendaServicio.Api.Libro.Persistencia;

namespace TiendaServicio.Api.Libro.Aplication
{
    public class ConsultarFiltro
    {
        public class LibreriaUnico : IRequest<LibreriaDto>
        {
            public Guid? LibroId
            { get; set; }
        }

        public class Manejador : IRequestHandler<LibreriaUnico, LibreriaDto>
        {
            private readonly ContextoLibreria _contextoLibreria;
            private readonly IMapper _mapper;

            public Manejador(ContextoLibreria contextoLibreria, IMapper mapper)
            {
                _contextoLibreria = contextoLibreria;
                _mapper = mapper;
            }

            public async Task<LibreriaDto> Handle(LibreriaUnico request, CancellationToken cancellationToken)
            {
                var Libreria = await _contextoLibreria.Librerias.Where(p => p.LibreriaMateriaId == request.LibroId).FirstOrDefaultAsync();
                if (Libreria == null)
                {
                    throw new Exception("No se encontro el libro");
                }
                var LibreriaDto= _mapper.Map<Libreria, LibreriaDto>(Libreria);
                return LibreriaDto;
            }
        }
    }
}
