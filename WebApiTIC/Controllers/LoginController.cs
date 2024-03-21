using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTIC.Application.DTOs.Autenticacion;
using WebApiTIC.Application.Implementations;
using WebApiTIC.Application.Contracts;
using Microsoft.Identity.Client;
using System.IdentityModel.Tokens.Jwt;
using WebApiTIC.Application.DTOs;

namespace WebApiTIC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _loginService;
        private readonly IJwtGenerator _jwtGenerator;
        public LoginController(ILogin loginService, IJwtGenerator jwtGenerator)
        {
            _loginService = loginService;
            _jwtGenerator = jwtGenerator;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AutenticacionDto autenticacionDto)
        {
            var result = await _loginService.Login(autenticacionDto);

            if (result != null)
            {
                var token = await _jwtGenerator.DevolverToken(result);
                return Ok(token);
            }
            else
            {
                return Unauthorized("Credenciales no válidas");
            }
        }

        /*[HttpPost("/ObtenerRefreshToken")]
        public async Task<IActionResult> ObtenerRefreshToken([FromBody] RefreshTokenRequest request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validacionTokenExpirado = tokenHandler.ReadJwtToken(request.RefreshToken);

            if (validacionTokenExpirado.ValidTo > DateTime.UtcNow)
                return BadRequest(new AutorizacionResponse { Resultado = false, Msg="Token no expirado"});


            var autorizacion = new AutenticacionResultDto();
            autorizacion.Email = validacionTokenExpirado.Claims.First(x => x.Type == JwtRegisteredClaimNames.NameId).Value.ToString();
            

            var autorizacionResponse = await _jwtGenerator.DevolverRefreshToken(request, autorizacion);

            if (autorizacionResponse.Resultado)
                return Ok(autorizacionResponse);
            else
                return BadRequest(autorizacionResponse);
        }*/
    }
}
