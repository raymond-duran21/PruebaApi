using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTIC.Application.DTOs.Equipos
{
    public record UpdateAsigEquipoDto(string Empleado_Cedula,string Estado, DateTime Fecha_Asignacion);
}
