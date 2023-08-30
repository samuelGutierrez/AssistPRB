using Back_Assist.Api.BussinessLogic.Dto;

namespace Back_Assist.Api.BussinessLogic.Interfaces
{
    public interface IMonedaService
    {
        Task<List<MonedaDto>> ListaMonedas();
        Task<bool> RegistrarMonedas(MonedaCreateDto dto);
        Task<bool> EliminarMonedas(int id);
    }
}
