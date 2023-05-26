using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TiendaServicio.api.CarritoCompras.RemoteInterface;
using TiendaServicio.api.CarritoCompras.RemoteModel;

namespace TiendaServicio.api.CarritoCompras.RemoteService
{
    public class LibroService : ILibroService
    {

        private readonly IHttpClientFactory httpClient;
        private readonly ILogger<LibroService> logger;

        public LibroService(IHttpClientFactory _httpClient, ILogger<LibroService> _logger)
        {
            httpClient = _httpClient;
            logger = _logger;
        }

     
        public async  Task<(bool resultado, LibroRemote libro, string ErrorMessage)> GetLibro(Guid? libroId)
        {
            try
            {
                var cliente = httpClient.CreateClient("Libros");
                var response = await cliente.GetAsync($"api/libros/{libroId}");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<LibroRemote>(contenido, options);
                    return (true, resultado, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)

            {
                logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        
    }
}
