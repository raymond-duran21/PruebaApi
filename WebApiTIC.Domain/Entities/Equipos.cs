
using System.ComponentModel.DataAnnotations;

namespace WebApiTIC.Domain.Entities;
    public class Equipos
    {
        [Key]
        public int EquiposId { get; set; }
        public string Tipo {  get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Serial { get; set; }
        public string? Almacenamiento { get; set; }
        public string? Memoria_Ram {  get; set; }
        public string? Procesador {  get; set; }
        public string? SO { get; set; }
        public string? Nombre_Equipo { get; set; }
        public int EmpleadosId { get; set; }
        public virtual Empleados Empleados { get; set; }
        public string? Observaciones { get; set; }
    }
