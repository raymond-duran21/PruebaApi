using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTIC.Application.Contracts;
using WebApiTIC.Application.DTOs;
using WebApiTIC.Domain.Entities;
using WebApiTIC.Infrastructure.Data;

namespace WebApiTIC.Infrastructure.Implementations
{
    public class AsignacionesRepo : IAsignaciones
    {
        private readonly AppDbContext _context;
        public AsignacionesRepo(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<ServiceReponse> AddAsync(Asignaciones asignaciones)
        {
            asignaciones.FechaAsignacion = DateTime.Now;
            _context.Asignaciones.Add(asignaciones);
            await SaveChangeAsync();
            return new ServiceReponse(true, "Agregado Correctamente");
        }

        public async Task<List<Asignaciones>> GetAsync() =>
            await _context.Asignaciones.AsNoTracking().ToListAsync();

        public async Task<Asignaciones> GetByIdAsync(int id) =>
            await _context.Asignaciones.FindAsync(id);

        private async Task SaveChangeAsync() => await _context.SaveChangesAsync();

    }
}
