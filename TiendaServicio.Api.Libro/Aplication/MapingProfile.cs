using AutoMapper;
using TiendaServicio.Api.Libro.Modelo;

namespace TiendaServicio.Api.Libro.Aplication
{
    public class MapingProfile : Profile
    {
        public MapingProfile()
        {
            CreateMap<Libreria, LibreriaDto>();

        }
    }
}
