using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using TiendaServicio.api.CarritoCompras.Persistencia;
using TiendaServicio.api.CarritoCompras.RemoteInterface;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TiendaServicio.api.CarritoCompras.Aplication
{
    public class Consulta
    {
        public class Ejecuta : IRequest<CarritoDto>
        {
            public int CarritoSesionId { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, CarritoDto>
        {
            private readonly CarritoContexto carritoContexto;
            private readonly ILibroService libroService;

            public Manejador(CarritoContexto _carritoContexto, ILibroService _libroService)
            {
                carritoContexto = _carritoContexto;
                libroService = _libroService;
            }

            public async Task<CarritoDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSesion = await carritoContexto.CarritoSesion.FirstOrDefaultAsync(x => x.CarritoSesionId == request.CarritoSesionId);
                var carritoSesionDetalle = await carritoContexto.CarritoSesionDetalles.Where(x => x.CarritoSesionId == carritoSesion.CarritoSesionId).ToListAsync();
                var listaCarritoDto = new List<CarritoDetalleDto>();

                foreach (var libro in carritoSesionDetalle)
                {
                    var response = await libroService.GetLibro(new System.Guid(libro.ProductoSeleccionado));
                    if (response.resultado)
                    {
                        var objetoLibro = response.libro;
                        var carritoDetalle = new CarritoDetalleDto
                        {
                            TituloLibro = objetoLibro.Titulo,
                            Precio = objetoLibro.Precio,
                            FechaPublicacion = objetoLibro.FechaPublicacion,
                            LibroId = objetoLibro.LibreriaMateriaId,
                            AutorLibro = objetoLibro.AutorLibro
                        };
                        listaCarritoDto.Add(carritoDetalle);
                    }
                }

                var carritoSesionDto = new CarritoDto
                {
                    CarritoId = carritoSesion.CarritoSesionId,
                 
                    FechaCreacionSesion = carritoSesion.FechaCreacion,
                    ListaDeProductos = listaCarritoDto
                };

                return carritoSesionDto;
            }

        }
    }
}
