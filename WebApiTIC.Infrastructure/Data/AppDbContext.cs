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
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Asignaciones> Asignaciones { get; set; }
        public DbSet<Empleados> Empleados { get; set;}
        public DbSet<Equipos> Equipos { get; set;}
        public DbSet<Auditoria> Auditorias { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.Property(e => e.IsRevoked)
                    .HasComputedColumnSql("iif(ExpiryDate < getdate(), convert(bit,0), convert(bit,1))");
            });
        }

    }
}
