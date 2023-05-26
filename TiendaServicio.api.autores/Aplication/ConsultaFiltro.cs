using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using TiendaServicio.api.autores.Modelo;
using TiendaServicio.api.autores.Persistencia;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TiendaServicio.api.autores.Aplication
{
    public class ConsultaFiltro
    {
        public class AutorUnico : IRequest<AutorLibroDto>
        {
            public string AutorGuid { get; set; }
        }

        public class Manejador : IRequestHandler<AutorUnico, AutorLibroDto>
        {
            private readonly ContextoAutor _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextoAutor contexto, IMapper mapper)
            {
                this._contexto = contexto;
                this._mapper = mapper;
            }

            public async Task<AutorLibroDto> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var cliente = await _contexto.AutorLibros.
                    Where(p => p.AutorLibroGuid == request.AutorGuid).FirstOrDefaultAsync();
                if (cliente == null)
                {
                    throw new Exception("No se encontro el autor ");
                }
                var ClienteDto = _mapper.Map<AutorLibro, AutorLibroDto>(cliente);
                return ClienteDto;
            }
        }
    }
}
