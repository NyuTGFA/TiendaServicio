using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaServicio.api.autores.Aplication;
using TiendaServicio.api.autores.Modelo;

namespace TiendaServicio.api.autores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : Controller
    {
        private readonly IMediator _mediator;

        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorLibroDto>>> GetClientes()
        {
            return await _mediator.Send(new Consulta.ListaCliente());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutorLibroDto>> GetClienteId(string id)
        {
            return await _mediator.Send(new ConsultaFiltro.AutorUnico { AutorGuid = id });
        }

        [HttpPut]
        public async Task<ActionResult<Unit>> Editar( EditarAutor.AutorUnico data)
        {
            return await _mediator.Send(data);
        }
        [HttpDelete]
        public async Task<ActionResult<Unit>> Eliminar(EliminarAutor.AutorUnico data)
        {
         return await _mediator.Send(data);
        }

    }
}
