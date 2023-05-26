using System;
using System.Threading.Tasks;
using TiendaServicio.api.CarritoCompras.RemoteModel;

namespace TiendaServicio.api.CarritoCompras.RemoteInterface
{
    public interface ILibroService
    {
        Task<(bool resultado, LibroRemote libro, string ErrorMessage)> GetLibro(Guid? libroId);
    }
}
