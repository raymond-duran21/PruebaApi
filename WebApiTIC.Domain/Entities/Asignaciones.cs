
using System.ComponentModel.DataAnnotations;

namespace WebApiTIC.Domain.Entities
{
    public class Asignaciones
    {
        [Key]
        public int AsignacionId { get; set; }
        public int EmpleadosId { get; set; }
        public int EquiposId { get; set; }
        public ICollection<Equipos> Equipos { get; set;}
        public Empleados Empleados {  get; set; }
        public DateTime FechaAsignacion { get; set;}
    }
}
