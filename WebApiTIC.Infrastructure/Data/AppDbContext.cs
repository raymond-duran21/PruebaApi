using Microsoft.EntityFrameworkCore;
using WebApiTIC.Application.Data;
using WebApiTIC.Domain.Entities;

namespace WebApiTIC.Infrastructure.Data
{
    public class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Empleados> Empleados { get; set;}
        public DbSet<Equipos> Equipos { get; set;}
        public DbSet<Auditoria> auditorias { get; set;}

    }
}
