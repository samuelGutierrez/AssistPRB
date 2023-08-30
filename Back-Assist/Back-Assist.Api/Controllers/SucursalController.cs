using Back_Assist.Api.BussinessLogic.Dto;
using Back_Assist.Api.BussinessLogic.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Back_Assist.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SucursalController : ControllerBase
    {
        private readonly ISucursalService _iSucursalService;

        public SucursalController(ISucursalService iSucursalService)
        {
            _iSucursalService = iSucursalService;
        }

        [HttpGet("Listar")]
        public async Task<List<SucursalDto>> ListaMonedas()
        {
            return await _iSucursalService.Lista();
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarMonedas(SucursalCreateDto dto)
        {
            // Recuperar el token JWT del encabezado de autorización
            string jwtToken = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (jwtToken == null)
                return Unauthorized("");

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.ReadJwtToken(jwtToken);

            var claims = jwtSecurityToken.Claims.Select(claim => new { Type = claim.Type, Value = claim.Value });

            var usuarioId = Convert.ToInt32(claims.Where(x => x.Type == "nameid").FirstOrDefault().Value);

            if (await _iSucursalService.Registrar(dto, usuarioId))
                return Ok(new
                {
                    Mensaje = "Sucursal creada con exito",
                    dto
                });
            else
            {
                return BadRequest(new
                {
                    Mensaje = "Error al intentar crear la sucursal"
                });

            }
        }

        [HttpPut("Actualizar/{codigo}")]
        public async Task<IActionResult> Actualizar(SucursalModifyDto dto, int codigo)
        {
            // Recuperar el token JWT del encabezado de autorización
            string jwtToken = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (jwtToken == null)
                return Unauthorized("");


            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.ReadJwtToken(jwtToken);

            var claims = jwtSecurityToken.Claims.Select(claim => new { Type = claim.Type, Value = claim.Value });

            var usuarioId = Convert.ToInt32(claims.Where(x => x.Type == "nameid").FirstOrDefault().Value);

            if (await _iSucursalService.Actualizar(dto, usuarioId, codigo))
                return Ok(new
                {
                    Mensaje = "Sucursal actualizada con exito"
                });
            else
            {
                return BadRequest(new
                {
                    Mensaje = "Error al intentar actualizar la sucursal"
                });

            }
        }

        [HttpDelete("Eliminar/{codigo}")]
        public async Task<IActionResult> EliminarMonedas(int codigo)
        {
            if (await _iSucursalService.Eliminar(codigo))
                return Ok(new
                {
                    Mensaje = "Sucursal eliminada con exito"

                });
            else
                return BadRequest(new
                {
                    Mensaje = "Error al intentar eliminar la sucursal"
                });

        }
    }
}
