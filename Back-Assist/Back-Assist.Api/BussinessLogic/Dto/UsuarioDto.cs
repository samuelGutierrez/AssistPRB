namespace Back_Assist.Api.BussinessLogic.Dto
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UsuarioLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UsuarioCreateDto
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UsuarioModifyDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
