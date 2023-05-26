using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Net.Http.Headers;
using TiendaServiciosMongo.Entities;

namespace TiendaServiciosMongo.Data
{
    public class CatalogContext: ICatalogContext
    {
        public CatalogContext(IConfiguration configuration) {
        var client= new 
                MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database= 
                client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

                Products = database.
                GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            //CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }

    }
}
