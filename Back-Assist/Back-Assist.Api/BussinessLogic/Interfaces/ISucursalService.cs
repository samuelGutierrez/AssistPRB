using Back_Assist.Api.BussinessLogic.Dto;

namespace Back_Assist.Api.BussinessLogic.Interfaces
{
    public interface ISucursalService
    {
        Task<bool> Registrar(SucursalCreateDto dto, int usuarioId);
        Task<List<SucursalDto>> Lista();
        Task<bool> Actualizar(SucursalModifyDto dto, int usuarioId, int codigo);
        Task<bool> Eliminar(int codigo);
    }
}
