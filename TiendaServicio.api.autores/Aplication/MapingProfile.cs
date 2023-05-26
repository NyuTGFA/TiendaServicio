using AutoMapper;
using TiendaServicio.api.autores.Modelo;

namespace TiendaServicio.api.autores.Aplication
{
    public class MapingProfile :Profile
    {
        public MapingProfile()
        {
            CreateMap<AutorLibro, AutorLibroDto>();

        }
    }
}
