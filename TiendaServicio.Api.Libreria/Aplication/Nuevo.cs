using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp;
using FluentValidation;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using TiendaServicio.Api.Libreria.Modelo;

namespace TiendaServicio.Api.Libreria.Aplication
{
    public class Nuevo : IRequest
    {
        public class Ejecuta : IRequest
        {

            public string Nombre { get; set; }
            public string CorrreoContacto { get; set; }
            public string Direccion { get; set; }
            public string Telefono { get; set; }

        }
        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.CorrreoContacto).NotEmpty();
                RuleFor(x => x.Direccion).NotEmpty();
                RuleFor(x => x.Telefono).NotEmpty();

            }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            public Manejador()
            {

            }


            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                IFirebaseConfig config = new FirebaseConfig()
                {
                    AuthSecret = "plJUSpuJq5SanSWnD8gUj4GVkTv9xLg5gyLuGsjp",
                    BasePath = "https://libreria-4916c-default-rtdb.firebaseio.com"
                };
                FirebaseClient _client = new FireSharp.FirebaseClient(config);
                var libreria = new Librerias
                {
                    Nombre = request.Nombre,
                    CorreoContacto = request.CorrreoContacto,
                    Direccion = request.Direccion,
                    Telefono = request.Telefono,

                };

                try
                {
                    var data = libreria;
                    PushResponse response = _client.Push("Libreria/", data);
                    data.Id = response.Result.name;
                    SetResponse setResponse = _client.Set("Libreria/" + data.Id, data);
                    if (setResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return Unit.Value;
                    }
                    else
                    {
                        throw new Exception("no se pudo insertar la libreria");
                    }
                }
                catch (Exception)
                {
                    throw new Exception("no se pudo insertar la libreria");
                }
            }

        }

    }
}
