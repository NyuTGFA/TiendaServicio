using MongoDB.Driver;
using TiendaServiciosMongo.Entities;

namespace TiendaServiciosMongo.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
