using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTIC.Application.DTOs.Asignaciones
{
    public record  CreateAsignacionDto (string EmpleadoId, string NombreEmpleado, string Departamento, string EquipoId,string Nombre_Equipo);
}
