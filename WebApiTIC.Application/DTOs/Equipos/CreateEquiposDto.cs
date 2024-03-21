using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTIC.Application.DTOs.Equipos
{
    public record CreateEquiposDto(string Tipo, string Marca, string Modelo, string Serial, string Almacenamiento, string Memoria_Ram, string Procesador, string SO, string Nombre_Equipo, string Empleados_Cedula, string Observaciones, string Estado);

}
