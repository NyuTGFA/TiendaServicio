using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaServicio.api.CarritoCompras.Aplication;

namespace TiendaServicio.api.CarritoCompras.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class CarritoComprasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarritoComprasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<CarritoDto>> GetCarrito()
        {
            return await _mediator.Send(new ConsultarCompras.ConsultaCarro());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarritoDto>> GetCarritoId(int id)
        {
            return await _mediator.Send(new Consulta.Ejecuta { CarritoSesionId = id });
        }
    }
}
