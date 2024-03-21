using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTIC.Application.DTOs.Empleados
{
    public record CreacionEmpleadosDto(string Nombre, string Cedula_Pasaporte, string Puesto, string Departamento);
    
}
