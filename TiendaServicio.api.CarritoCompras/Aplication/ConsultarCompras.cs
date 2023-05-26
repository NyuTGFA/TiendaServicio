using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.api.CarritoCompras.Modelo;
using TiendaServicio.api.CarritoCompras.Persistencia;
using TiendaServicio.api.CarritoCompras.RemoteInterface;
using TiendaServicio.api.CarritoCompras.RemoteService;

namespace TiendaServicio.api.CarritoCompras.Aplication
{
    public class ConsultarCompras
    {
        public class ConsultaCarro : IRequest<CarritoDto>
        {
           
        }

        public class Manejador : IRequestHandler<ConsultaCarro, CarritoDto>
        {
            private readonly CarritoContexto carritoContexto;
            private readonly ILibroService libroService;

            public Manejador(CarritoContexto _carritoContexto, ILibroService _libroService)
            {
                carritoContexto = _carritoContexto;
                libroService = _libroService;
            }

            public async Task<CarritoDto> Handle(ConsultaCarro request, CancellationToken cancellationToken)
            {
                var carritoSesion = await carritoContexto.CarritoSesion.FirstOrDefaultAsync();
                var carritoSesionDetalle = await carritoContexto.CarritoSesionDetalles.ToListAsync();
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
