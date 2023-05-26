using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaServicio.Api.Libreria.Aplication;

namespace TiendaServicio.Api.Libreria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibreriasController : Controller
    {
        private readonly IMediator _mediator;
        private readonly Consultar cs = new Consultar();
        private readonly ConsultaFiltro cf = new ConsultaFiltro();

        public LibreriasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public ActionResult<List<LibreriaDto>> GetLibros()
        {
            return cs.get();
        }

        [HttpGet("{id}")]
        public ActionResult<LibreriaDto> GetAutorLibro(string id)
        {
            return cf.get(id);
        }

    }
}
