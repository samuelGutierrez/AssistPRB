namespace Back_Assist.Api.BussinessLogic.Dto
{
    public class LogSucursalDto
    {
        public int Id { get; set; }
        public int CodigoSucursal { get; set; }
        public int IdUsuario { get; set; }
        public string TipoOperacion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public class LogSucursalCreateDto
    {
        public int CodigoSucursal { get; set; }
        public string TipoOperacion { get; set; }
        public int UsuarioId { get; set; }
    }
}
