using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiTIC.Application.DTOs.Autenticacion;
using Microsoft.Extensions.Configuration;
using WebApiTIC.Application.Contracts;
using System.Security.Cryptography;

namespace WebApiTIC.Infrastructure.Authentication
{
    public class JwtToken : IJwtGenerator
    {

        private readonly IConfiguration _configuration;

        public JwtToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string GenerateJwtToken(AutenticationResultDto authenticationResult)
        {
            var key = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:Secret").Value)), SecurityAlgorithms.HmacSha256); 

            var claims = new List<Claim>
        {
        new Claim(ClaimTypes.Email, authenticationResult.Email),
        new Claim(ClaimTypes.Role, authenticationResult.Rol)
        };


            var token = new JwtSecurityToken(
            issuer: _configuration.GetSection("JwtSettings:Issuer").Value,
            audience: _configuration.GetSection("JwtSettings:Audience").Value,
            expires: DateTime.UtcNow.AddMinutes(5),
            claims: claims,
            signingCredentials: key
            );

            authenticationResult.Token = token.ToString();


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}