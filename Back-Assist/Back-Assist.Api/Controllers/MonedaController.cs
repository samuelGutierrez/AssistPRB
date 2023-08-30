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
    public class MonedaController : ControllerBase
    {
        private readonly IMonedaService _iMonedaService;

        public MonedaController(IMonedaService iMonedaService)
        {
            _iMonedaService = iMonedaService;
        }

        [HttpGet("Listar")]
        public async Task<List<MonedaDto>> ListaMonedas()
        {
            return await _iMonedaService.ListaMonedas();
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarMonedas(MonedaCreateDto dto)
        {
            if (await _iMonedaService.RegistrarMonedas(dto))
                return Ok(new
                {
                    Mensaje = "Moneda creada con exito",
                    dto
                });
            else
            {
                return BadRequest(new
                {
                    Mensaje = "Error al intentar crear la moneda"
                });
            }
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> EliminarMonedas(int id)
        {
            if (await _iMonedaService.EliminarMonedas(id))
                return Ok(new
                {
                    Mensaje = "Moneda eliminada con exito"

                });
            else
                return BadRequest(new
                {
                    Mensaje = "Error al intentar eliminar la moneda"
                });

        }
    }
}
