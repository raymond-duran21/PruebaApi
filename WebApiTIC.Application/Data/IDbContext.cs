using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTIC.Domain.Entities;

namespace WebApiTIC.Application.Data
{
    public interface IDbContext
    {
          DbSet<Asignaciones> Asignaciones { get; set; }
          DbSet<Empleados> Empleados { get; set; }
          DbSet<Equipos> Equipos { get; set; }
          DbSet<Auditoria> Auditorias { get; set; }
          DbSet<RefreshToken> RefreshTokens { get; set; }
          Task<int>SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
