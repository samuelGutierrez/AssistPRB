using Back_Assist.Api.BussinessLogic.Dto;

namespace Back_Assist.Api.BussinessLogic.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> ObtenerUsuario(UsuarioLoginDto login);
        Task<List<UsuarioDto>> Lista();
        Task<bool> Registrar(UsuarioCreateDto dto);
        Task<bool> Actualizar(UsuarioModifyDto dto, int usuarioId);
        Task<bool> Eliminar(int id);
    }
}
