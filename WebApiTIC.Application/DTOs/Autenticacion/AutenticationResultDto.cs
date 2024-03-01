using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTIC.Application.DTOs.Autenticacion
{
    public record class AutenticationResultDto
    { 
        public string Email { get; set; }
        public string Token { get; set; }
        public string Rol {  get; set; }
    }
    
}
