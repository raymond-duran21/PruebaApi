

using Microsoft.EntityFrameworkCore;
using WebApiTIC.Application.Contracts;
using WebApiTIC.Application.DTOs;
using WebApiTIC.Domain.Entities;
using WebApiTIC.Infrastructure.Data;

namespace WebApiTIC.Infrastructure.Implementations
{
    public class EquiposRepo : IEquipos
    {
        private readonly AppDbContext _context;
        public EquiposRepo(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<ServiceReponse> AddAsync(Equipos equipos)
        {
            _context.Equipos.Add(equipos);
            await SaveChangeAsync();
            return new ServiceReponse(true, "Agregado Correctamente");
        }

        public async Task<ServiceReponse> DeleteAsync(int id)
        {
            var equipos = await _context.Equipos.FindAsync(id);
            if (equipos != null)
            {
                return new ServiceReponse(false, "Empleado no encontrado");
            }

            _context.Equipos.Remove(equipos);
            await SaveChangeAsync();
            return new ServiceReponse(true, "Borrado exitosamente");
        }

        public async Task<List<Equipos>> GetAsync() =>
            await _context.Equipos.AsNoTracking().ToListAsync();

        public async Task<Equipos> GetByIdAsync(int id) =>
            await _context.Equipos.FindAsync(id);

        public async Task<ServiceReponse> UpdateAsync(Equipos equipos)
        {
            _context.Update(equipos);
            await SaveChangeAsync();
            return new ServiceReponse(true, "Actualizado correctamente");
        }

        private async Task SaveChangeAsync() => await _context.SaveChangesAsync();

    }
}
