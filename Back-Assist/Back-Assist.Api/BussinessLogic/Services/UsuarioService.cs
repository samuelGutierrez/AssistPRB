using Back_Assist.Api.BussinessLogic.Dto;
using Back_Assist.Api.BussinessLogic.Interfaces;
using Back_Assist.Data.Data;
using Back_Assist.Data.Domain;
using Back_Assist.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_Assist.Api.BussinessLogic.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGeneric<Usuario> _igUsuario;
        private readonly Context _context;

        public UsuarioService(Context context, IGeneric<Usuario> igUsuario)
        {
            _context = context;
            _igUsuario = igUsuario;
        }

        public async Task<UsuarioDto> ObtenerUsuario(UsuarioLoginDto login)
        {
            try
            {
                var usuario = await (from u in _context.Usuarios
                                     where u.Username == login.Username && u.Password == login.Password
                                     select new UsuarioDto
                                     {
                                         Id = u.Id,
                                         Apellidos = u.Apellidos,
                                         Identificacion = u.Identificacion,
                                         Nombre = u.Nombre,
                                         Username = u.Username
                                     }).FirstOrDefaultAsync();
                return usuario;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<List<UsuarioDto>> Lista()
        {
            var lista = await (from a in _context.Usuarios
                               select new UsuarioDto
                               {
                                   Id = a.Id,
                                   Apellidos = a.Apellidos,
                                   Identificacion = a.Identificacion,
                                   Nombre = a.Nombre,
                                   Username = a.Username
                               }).ToListAsync();
            return lista;
        }

        public async Task<bool> Registrar(UsuarioCreateDto dto)
        {
            try
            {
                var saveData = new Usuario()
                {
                    Username = dto.Username,
                    Apellidos = dto.Apellidos,
                    Identificacion = dto.Identificacion,
                    Nombre = dto.Nombre,
                    Password = dto.Password,
                };

                var exitoso = await _igUsuario.CreateAsync(saveData);

                if (exitoso != null)
                    return true;

                return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> Actualizar(UsuarioModifyDto dto, int usuarioId)
        {
            try
            {
                var currentSucursal = _igUsuario.Search(x => x.Id == usuarioId);

                currentSucursal.Username = dto.Username;
                currentSucursal.Password = dto.Password;

                var exitoso = await _igUsuario.ModifyAsync(currentSucursal);

                if (exitoso != null)
                    return true;

                return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var currentMoneda = _igUsuario.Search(x => x.Id == id);

                await _igUsuario.RemoveAsync(currentMoneda);
                return true;

            }
            catch (Exception ex) { throw ex; }
        }
    }
}
