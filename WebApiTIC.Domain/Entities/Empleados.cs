﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiTIC.Domain.Entities;

    public class Empleados
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula_Pasaporte { get; set; }
        public string Puesto { get; set; }
        public string Departamento { get; set; }
    }
