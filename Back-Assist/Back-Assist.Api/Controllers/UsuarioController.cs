using Back_Assist.Api.BussinessLogic.Dto;
using Back_Assist.Api.BussinessLogic.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Back_Assist.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _iUsuarioService;

        public UsuarioController(IUsuarioService iUsuarioService)
        {
            _iUsuarioService = iUsuarioService;
        }

        [HttpGet("Listar")]
        public async Task<List<UsuarioDto>> ListaMonedas()
        {
            return await _iUsuarioService.Lista();
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarMonedas(UsuarioCreateDto dto)
        {
            if (await _iUsuarioService.Registrar(dto))
                return Ok(new
                {
                    Mensaje = "Usuario creada con exito",
                    dto
                });
            else
            {
                return BadRequest(new
                {
                    Mensaje = "Error al intentar crear el Usuario"
                });

            }
        }

        [HttpPut("Actualizar/{id}")]
        public async Task<IActionResult> Actualizar(UsuarioModifyDto dto, int id)
        {
            if (await _iUsuarioService.Actualizar(dto, id))
                return Ok(new
                {
                    Mensaje = "Usuario actualizado con exito"
                });
            else
            {
                return BadRequest(new
                {
                    Mensaje = "Error al intentar actualizar la sucursal"
                });

            }
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> EliminarMonedas(int id)
        {
            if (await _iUsuarioService.Eliminar(id))
                return Ok(new
                {
                    Mensaje = "Usuario eliminada con exito"

                });
            else
                return BadRequest(new
                {
                    Mensaje = "Error al intentar eliminar la Usuario"
                });

        }
    }
}
