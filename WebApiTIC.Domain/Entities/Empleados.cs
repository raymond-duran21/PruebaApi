
using System.ComponentModel.DataAnnotations;

namespace WebApiTIC.Domain.Entities;

    public class Empleados
    {
        [Key]
        public int EmpleadosId { get; set; }
        public string Nombre { get; set; }
        public string Cedula_Pasaporte { get; set; }
        public string Entidad { get; set; }
        public string Direccion { get; set; }
        public string Departamento { get; set; }
        public int EquipoId { get; set; }
        public  ICollection<Equipos> Equipos { get; set; }
    }
