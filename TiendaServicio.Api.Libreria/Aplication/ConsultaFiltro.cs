using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp;
using TiendaServicio.Api.Libreria.Modelo;

namespace TiendaServicio.Api.Libreria.Aplication
{
    public class ConsultaFiltro
    {

        //creamos  una instancia del cliente de Firebase y lo asigna a la variable cliente 
        private readonly IFirebaseClient cliente;

        //constructor consultar filtro crea la conexion a la base de datos
        public ConsultaFiltro()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                //credenciales que se obtienen del proyecto creado en firebase
                AuthSecret = "plJUSpuJq5SanSWnD8gUj4GVkTv9xLg5gyLuGsjp",
                BasePath = "https://libreria-4916c-default-rtdb.firebaseio.com"
            };
            cliente = new FirebaseClient(config);
        }

        //recibimos el parametro id registrado en la base de datos 
        public LibreriaDto get(string id)
        {
            //obtiene los datos del registro con el id 


            FirebaseResponse response = cliente.Get("Libreria/" + id);
            var libreria = response.ResultAs<Librerias>();
            //convierte a una clase de la libreria Dto y lo devuelve
            LibreriaDto data = new LibreriaDto
            {
                Id = libreria.Id,
                Nombre = libreria.Nombre,
                CorrreoContacto = libreria.CorreoContacto,
                Direccion = libreria.Direccion,
                Telefono = libreria.Telefono

            };

            return data;
        }



    
}
}
