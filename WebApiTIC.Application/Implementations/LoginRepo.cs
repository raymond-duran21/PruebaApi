using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using WebApiTIC.Application.DTOs.Autenticacion;
using System.DirectoryServices.AccountManagement;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WebApiTIC.Application.DTOs;
using System.ComponentModel.DataAnnotations;
using WebApiTIC.Application.Contracts;

namespace WebApiTIC.Application.Implementations
{
    public interface ILogin
    {
        Task<AutenticacionResultDto> Login(AutenticacionDto autenticacionDto);
    }

    public class LoginRepo : ILogin
    {
        private IConfiguration _config;

        public LoginRepo(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<AutenticacionResultDto> Login(AutenticacionDto autenticacionDto)
        {
            var domainName = _config.GetSection("ADConfig:Domain").Value;
            var formattedEmail = autenticacionDto.email.Trim();
            var formattedPass = autenticacionDto.password.Trim();
            var adContext = new PrincipalContext(ContextType.Domain, domainName);
            var result = adContext.ValidateCredentials(formattedEmail, formattedPass);
            
            if (!result)
            {
                Console.WriteLine("ERROR EN VALIDACION DE ROL");
                return null;
            }
            else
            {
                var accessRole = new string[] { "App_Tic_Admin", "App_Tic_Usuario" };

                var user = UserPrincipal.FindByIdentity(adContext, IdentityType.UserPrincipalName, formattedEmail);

                if (user != null)
                {
                    string userEmail = user.UserPrincipalName;

                    var userRoles = user.GetGroups()
                        .Where(group => accessRole.Contains(group.Name))
                        .Select(group => group.Name)
                        .FirstOrDefault();

                    if (!string.IsNullOrEmpty(userRoles) && accessRole.Contains(userRoles))
                    {
                        return new AutenticacionResultDto
                        {
                            Email = userEmail,
                            Rol = userRoles
                        };
                    }
                }


                return null;
            }
        }




    }
}
   

        
