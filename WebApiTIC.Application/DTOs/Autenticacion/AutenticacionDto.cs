using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTIC.Application.DTOs.Autenticacion
{
    public record class AutenticacionDto(string email, string password);
    
}
