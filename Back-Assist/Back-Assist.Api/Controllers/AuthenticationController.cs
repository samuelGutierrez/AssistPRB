using Back_Assist.Api.BussinessLogic.Dto;
using Back_Assist.Api.BussinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Back_Assist.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly string _secretKey;
        private readonly IUsuarioService _iUsuarioServices;

        public AuthenticationController(IConfiguration config, IUsuarioService iUsuarioServices)
        {
            _secretKey = config.GetSection("settings").GetSection("secretKey").ToString();
            _iUsuarioServices = iUsuarioServices;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDto login)
        {
            var oLogin = await _iUsuarioServices.ObtenerUsuario(login);

            if (oLogin != null)
            {
                var keyBytes = Encoding.ASCII.GetBytes(_secretKey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, oLogin.Id.ToString()));
                claims.AddClaim(new Claim(ClaimTypes.Email, oLogin.Username));
                claims.AddClaim(new Claim(ClaimTypes.Name, oLogin.Nombre));
                claims.AddClaim(new Claim(ClaimTypes.Surname, oLogin.Apellidos));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string tokencreado = tokenHandler.WriteToken(tokenConfig);

                return Ok(new { token = tokencreado });
            }
            else
                return Unauthorized(new { token = "" });
        }
    }
}
