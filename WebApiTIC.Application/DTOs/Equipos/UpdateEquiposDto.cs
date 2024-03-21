using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTIC.Application.DTOs.Equipos
{
    public record UpdateEquiposDto(int Id, string Almacenamiento, string Memoria_Ram, string SO, string Nombre_Equipo, string Observaciones);
}
