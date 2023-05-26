using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaServicio.Api.Libro.Aplication;

namespace TiendaServicio.Api.Libro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : Controller
    {
        private readonly IMediator _mediator;

        public LibrosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }
        [HttpGet]
        public async Task<ActionResult<List<LibreriaDto>>> Getlibros()
        {
            return await _mediator.Send(new Consulta.ListaLibreria());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<LibreriaDto>> GetlibrosId(Guid?  id)
        {
            return await _mediator.Send(new ConsultarFiltro.LibreriaUnico { LibroId =  id});
        }
    
    }
}
