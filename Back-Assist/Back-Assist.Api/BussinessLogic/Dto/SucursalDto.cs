using System.ComponentModel.DataAnnotations;

namespace Back_Assist.Api.BussinessLogic.Dto
{
    public class SucursalDto
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Identificacion { get; set; }
        public int MonedaId { get; set; }
        public string Moneda { get; set; }
    }

    public class SucursalCreateDto
    {
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Identificacion { get; set; }
        public int MonedaId { get; set; }
    }

    public class SucursalModifyDto
    {
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public int MonedaId { get; set; }
    }
}
