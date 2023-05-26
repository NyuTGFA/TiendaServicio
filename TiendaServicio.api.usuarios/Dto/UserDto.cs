namespace TiendaServicio.api.usuarios.Dto
{
    //clase que se encarga de transportar los datos del usuario
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
