
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiTIC.Domain.Entities;
    public class Equipos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Tipo {  get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Serial { get; set; }
        public string? Almacenamiento { get; set; }
        public string? Memoria_Ram {  get; set; }
        public string? Procesador {  get; set; }
        public string? SO { get; set; }
        public string Nombre_Equipo { get; set; }
        public string? Empleados_Cedula { get; set; }
        public string? Observaciones { get; set; }
        public string? Estado {  get; set; }
        public DateTime? FechaAsignacion {  get; set; }
    }
