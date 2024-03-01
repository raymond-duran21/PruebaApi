using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTIC.Domain.Entities
{
    public class Auditoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ValorAnterior { get; set; }
        public string ValorNuevo { get; set;}
        public string? Accion {  get; set; }
        public string? usuario { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
