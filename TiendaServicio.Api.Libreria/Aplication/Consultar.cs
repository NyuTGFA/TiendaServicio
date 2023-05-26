using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp;
using Newtonsoft.Json;
using System.Collections.Generic;
using TiendaServicio.Api.Libreria.Modelo;

namespace TiendaServicio.Api.Libreria.Aplication
{
    public class Consultar

    {
        //clase para obtener la lista de registros de la base de datos

        IFirebaseClient cliente;

        //constructor para la conexion a la base de datos
        public Consultar()
        {


            IFirebaseConfig config = new FirebaseConfig
            {
                //credenciales que se obtienen de firebase 
                AuthSecret = "plJUSpuJq5SanSWnD8gUj4GVkTv9xLg5gyLuGsjp",
                BasePath = "https://libreria-4916c-default-rtdb.firebaseio.com"
            };
            cliente = new FirebaseClient(config);
        }



        //parametro de metodo get que obtiene los registros en la base de datos
        public List<LibreriaDto> get()
        {

            Dictionary<string, Librerias> dict = new Dictionary<string, Librerias>();
            FirebaseResponse response = cliente.Get("Libreria");


            //los convierte en un diccionario de objetos Libreria utilizando el método JsonConvert.DeserializeObject
            if (response.StatusCode == System.Net.HttpStatusCode.OK)

                dict = JsonConvert.DeserializeObject<Dictionary<string, Librerias>>(response.Body);



            List<LibreriaDto> librerias = new List<LibreriaDto>();

            //dentro del ciclo foreach, se crea un nuevo objeto libreriadto y se le asignan valores de cada registro obtenido
            foreach (KeyValuePair<string, Librerias> elemento in dict)
            {
                //se le agrega el objeto a libreria Dto 
                librerias.Add(new LibreriaDto()
                {
                    Id = elemento.Key,
                    Nombre = elemento.Value.Nombre,
                    CorrreoContacto = elemento.Value.CorreoContacto,
                    Direccion = elemento.Value.Direccion,
                    Telefono = elemento.Value.Telefono
                });
            }

            return librerias;
        }


    }
}

