using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTIC.Domain.Entities
{
        public class RefreshToken
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public string? Token { get; set; }
            public DateTime AddedDate { get; set; }
            public DateTime ExpiryDate { get; set; }
            public bool IsRevoked { get; set; }
            public string? UserId { get; set; }
        }
}
