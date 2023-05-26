using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.api.CarritoCompras.Modelo;
using TiendaServicio.api.CarritoCompras.Persistencia;

namespace TiendaServicio.api.CarritoCompras.Aplication
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public DateTime FechaCreacionSesion { get; set; }
            public List<string> ProductoLista { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CarritoContexto _contexto;
           
            public Manejador(CarritoContexto contexto)
            {
                _contexto = contexto;
            }

            public async  Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSesion = new CarritoSesion
                {
                    FechaCreacion = request.FechaCreacionSesion
                };

                _contexto.CarritoSesion.Add(carritoSesion);
                var result = await _contexto.SaveChangesAsync();
                if (result == 0)
                {
                    throw new Exception("no se pudo insertar nada imbecil");
                }
                int id = carritoSesion.CarritoSesionId;
                foreach (var p in request.ProductoLista)
                {
                    var detalleSesion = new CarritoSesionDetalle
                    {
                        FechaCreacion = DateTime.Now,
                        CarritoSesionId = id,
                        ProductoSeleccionado = p
                    };
                    _contexto.CarritoSesionDetalles.Add(detalleSesion);
                }
               var value = await _contexto.SaveChangesAsync();
               if (value > 0)
               {
                        return Unit.Value;
               }
              throw new Exception("no se pudo insertar el detalle del carrito jajaa ");
                
            }
        }
    }
}
