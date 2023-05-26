﻿using MongoDB.Bson.Serialization.Attributes;

namespace TiendaServiciosMongo.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Nombre")]

        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Resumen { get; set; }
        
        public string Descripcion { get; set; }
        public string ImagenArchivo { get; set; }
        public string Precio { get; set; }


    }
}
