using TiendaServicio.api.usuarios.Modelo;

namespace TiendaServicio.api.usuarios.Interfaces
{
    public interface ITokenService
    {
        string CreateToken (Usuario usuario);
    }
}
