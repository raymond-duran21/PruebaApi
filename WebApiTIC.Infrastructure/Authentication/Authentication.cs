using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiTIC.Application.DTOs.Autenticacion;
using Microsoft.Extensions.Configuration;
using WebApiTIC.Application.Contracts;
using System.Security.Cryptography;
using WebApiTIC.Application.DTOs;
using WebApiTIC.Domain.Entities;
using WebApiTIC.Application.Data;
using System.Net;

namespace WebApiTIC.Infrastructure.Authentication
{
    public class JwtToken : IJwtGenerator
    {

        private readonly IConfiguration _configuration;
        private readonly IDbContext _context;


        public JwtToken(IConfiguration configuration, IDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }


        public string GenerateJwtToken(AutenticacionResultDto autorizacion)
        {
            var key = _configuration.GetValue<string>("JwtSettings:Secret");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.Email, autorizacion.Email));
            claims.AddClaim(new Claim(ClaimTypes.Role, autorizacion.Rol));

            var credencialesToken = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature);


            var token = new SecurityTokenDescriptor {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(7),
                SigningCredentials = credencialesToken,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(token);

            string tokenCreado = tokenHandler.WriteToken(tokenConfig);

            return tokenCreado;

        }
        
        private string GenerarRefreshToken() 
        {
            var byteArray = new byte[64];
            var refreshToken = "";

            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(byteArray);
                refreshToken = Convert.ToBase64String(byteArray);
            }
            return refreshToken;
        }

        private async Task<AutorizacionResponse> DevolverRefreshTokenInter(string UserId, string token, string refreshToken)
        {
            var GuardarrefreshToken = new RefreshToken
            {
                UserId = UserId,
                Token = token,
                RefreshTokenV = refreshToken,
                AddedDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddMinutes(7),
            };

            await _context.RefreshTokens.AddAsync(GuardarrefreshToken);
            await _context.SaveChangesAsync();

            return new AutorizacionResponse() {Token = token, RefreshToken = refreshToken, Resultado = true, Msg = "Ok" };

        }

        public async Task<AutorizacionResponse> DevolverToken(AutenticacionResultDto autorizacion)
        {
            string tokencreado = GenerateJwtToken(autorizacion);

            string refreshTokenCreado = GenerarRefreshToken();

            //return new AutorizacionResponse(){Token = tokencreado, Resultado = true, Msg = "Ok"};

            return await DevolverRefreshTokenInter(autorizacion.Email.ToString(), tokencreado, refreshTokenCreado);
        }

        public async Task<AutorizacionResponse> DevolverRefreshToken(RefreshTokenRequest refreshTokenRequest, AutenticacionResultDto autorizacion)
        {
            var refreshTokenEncontrado = _context.RefreshTokens.FirstOrDefault(x => 
            x.Token == refreshTokenRequest.TokenExpirado && 
            x.Token == refreshTokenRequest.RefreshToken && 
            x.UserId == autorizacion.Email);

            if(refreshTokenEncontrado == null)
            {
                return new AutorizacionResponse{ Resultado = false, Msg = "No existe RefreshToken"};
            }
            var refreshTokenCreado = GenerarRefreshToken();
            var tokenCreado = GenerateJwtToken(autorizacion);

            return await DevolverRefreshTokenInter(autorizacion.Email, tokenCreado, refreshTokenCreado);
        }
        
    }
}