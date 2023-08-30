using Back_Assist.Api.BussinessLogic.Dto;
using Back_Assist.Api.BussinessLogic.Interfaces;
using Back_Assist.Data.Domain;
using Back_Assist.Data.Interfaces;

namespace Back_Assist.Api.BussinessLogic.Services
{
    public class LogSucursalService : ILogSucursalService
    {
        private readonly IGeneric<LogSucursal> _igLogSucursal;

        public LogSucursalService(IGeneric<LogSucursal> igLogSucursal)
        {
            _igLogSucursal = igLogSucursal;
        }

        public async void Registrar(LogSucursalCreateDto dto )
        {
            try
            {
                var saveData = new LogSucursal()
                {
                    CodigoSucursal = dto.CodigoSucursal,
                    FechaCreacion = DateTime.Now,
                    IdUsuario = dto.UsuarioId,
                    TipoOperacion = dto.TipoOperacion
                };

                await _igLogSucursal.CreateAsync(saveData);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
