using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using TiendaServicio.Api.Libro.Persistencia;
using Microsoft.EntityFrameworkCore;
using TiendaServicio.Api.Libro.Modelo;

namespace TiendaServicio.Api.Libro.Aplication
{
    public class Consulta
    {
        public class ListaLibreria : IRequest<List<LibreriaDto>>


        {

        }

        public class Manejador : IRequestHandler<ListaLibreria, List<LibreriaDto>>
        {
            private readonly ContextoLibreria   _context;
            private readonly IMapper _mapper;
            public Manejador(ContextoLibreria context, IMapper mapper)
            {
                this._context = context;
                this._mapper = mapper;
            }

            public async Task<List<LibreriaDto>> Handle(ListaLibreria request, CancellationToken cancellationToken)
            {
                var libreria = await _context.Librerias.ToListAsync();
                var LibreriaDto= _mapper.Map<List<Libreria>, List<LibreriaDto>>(libreria);
                return LibreriaDto;
            }
        }
    }

}
