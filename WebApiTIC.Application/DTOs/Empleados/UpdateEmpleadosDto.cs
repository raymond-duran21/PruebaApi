using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTIC.Application.DTOs.Empleados
{
    public record UpdateEmpleadosDto(int Id, string Entidad, string Direccion, string Departamento);

}
