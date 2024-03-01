using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTIC.Application.DTOs.Autenticacion;
using WebApiTIC.Application.Implementations;
using WebApiTIC.Application.Contracts;
using Microsoft.Identity.Client;

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
                var token = _jwtGenerator.GenerateJwtToken(result);

                // Puedes devolver el token junto con otros datos que desees
                return Ok(new { Token = token, Email = result.Email, Rol = result.Rol });
                return Ok();
            }
            else
            {
                return Unauthorized("Credenciales no válidas");
            }
        }
    }
}
