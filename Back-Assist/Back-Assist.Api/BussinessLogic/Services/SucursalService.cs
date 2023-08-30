using Back_Assist.Api.BussinessLogic.Dto;
using Back_Assist.Api.BussinessLogic.Interfaces;
using Back_Assist.Data.Data;
using Back_Assist.Data.Domain;
using Back_Assist.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_Assist.Api.BussinessLogic.Services
{
    public class SucursalService : ISucursalService
    {
        private readonly IGeneric<Sucursales> _igSucursales;
        private readonly ILogSucursalService _iLogSucursalService;
        private readonly Context _context;

        public SucursalService(IGeneric<Sucursales> igSucursales, ILogSucursalService iLogSucursalService, Context context)
        {
            _igSucursales = igSucursales;
            _iLogSucursalService = iLogSucursalService;
            _context = context;
        }

        public async Task<List<SucursalDto>> Lista()
        {
            var lista = await (from a in _context.Sucursales
                               join m in _context.Monedas on a.MonedaId equals m.Id
                                        select new SucursalDto
                                        {
                                           Codigo = a.Codigo,
                                           Descripcion = a.Descripcion,
                                           Direccion = a.Direccion,
                                           Identificacion = a.Identificacion,
                                           MonedaId = m.Id,
                                           Moneda = m.Descripcion
                                        }).ToListAsync();
            return lista;
        }

        public async Task<bool> Registrar(SucursalCreateDto dto, int usuarioId)
        {
            try
            {
                var saveData = new Sucursales()
                {
                    Descripcion = dto.Descripcion,
                    Direccion = dto.Direccion,
                    FechaCreacion = DateTime.Now,
                    Identificacion = dto.Identificacion,
                    MonedaId = dto.MonedaId
                };

                var exitoso = await _igSucursales.CreateAsync(saveData);

                if (exitoso != null)
                {
                    var log = new LogSucursalCreateDto()
                    {
                        CodigoSucursal = exitoso.Codigo,
                        TipoOperacion = "POST",
                        UsuarioId = usuarioId
                    };
                    //_iLogSucursalService.Registrar(log);

                    return true;
                }

                return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> Actualizar(SucursalModifyDto dto, int usuarioId, int codigo)
        {
            try
            {
                var currentSucursal = _igSucursales.Search(x => x.Codigo == codigo);

                currentSucursal.Descripcion = dto.Descripcion;
                currentSucursal.Direccion = dto.Direccion;
                currentSucursal.FechaCreacion = DateTime.Now;
                currentSucursal.MonedaId = dto.MonedaId;

                var exitoso = await _igSucursales.ModifyAsync(currentSucursal);

                if (exitoso != null)
                {
                    var log = new LogSucursalCreateDto()
                    {
                        CodigoSucursal = currentSucursal.Codigo,
                        TipoOperacion = "PUT",
                        UsuarioId = usuarioId
                    };
                    //_iLogSucursalService.Registrar(log);

                    return true;
                }

                return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> Eliminar(int codigo)
        {
            try
            {
                var currentMoneda = _igSucursales.Search(x => x.Codigo == codigo);

                await _igSucursales.RemoveAsync(currentMoneda);
                return true;

            }
            catch (Exception ex) { throw ex; }
        }
    }
}
