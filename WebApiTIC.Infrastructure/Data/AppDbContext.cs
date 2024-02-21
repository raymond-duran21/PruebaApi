using Microsoft.EntityFrameworkCore;
using WebApiTIC.Domain.Entities;

namespace WebApiTIC.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<Empleados> Empleados { get; set;}
        public DbSet<Equipos> Equipos { get; set;}
        public DbSet<Asignaciones> Asignaciones { get; set;}

    }
}
