using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTIC.Domain.Entities
{
    public class Asignaciones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id {  get; set; }
        public string EmpleadoId { get; set; }
        public string NombreEmpleado { get; set; }
        public string Departamento { get; set; }
        public string EquipoId { get; set; }
        public string Nombre_Equipo {  get; set; }
        public string Estado { get; set; }
        public DateTime Fecha_Asignacion { get; set; }

    }
}
