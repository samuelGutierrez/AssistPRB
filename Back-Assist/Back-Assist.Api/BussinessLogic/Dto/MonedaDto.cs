namespace Back_Assist.Api.BussinessLogic.Dto
{
    public class MonedaDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }

    public class MonedaCreateDto
    {
        public string Descripcion { get; set; }
    }
}

