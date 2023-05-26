using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using TiendaServicio.api.autores.Modelo;
using TiendaServicio.api.autores.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace TiendaServicio.api.autores.Aplication
{
    public class Consulta
    {
        public class ListaCliente : IRequest<List<AutorLibroDto>>


        {

        }

        public class Manejador : IRequestHandler<ListaCliente, List<AutorLibroDto>>
        {
            private readonly ContextoAutor _context;
            private readonly IMapper _mapper;
            public Manejador(ContextoAutor context, IMapper mapper)
            {
                this._context = context;
                this._mapper = mapper;
            }

            public async Task<List<AutorLibroDto>> Handle(ListaCliente request, CancellationToken cancellationToken)
            {
                var clientes = await _context.AutorLibros.ToListAsync();
                var clienteDto = _mapper.Map<List<AutorLibro>, List<AutorLibroDto>>(clientes);
                return clienteDto;
            }
        }
    }
}

