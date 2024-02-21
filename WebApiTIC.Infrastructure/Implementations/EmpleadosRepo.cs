

using Microsoft.EntityFrameworkCore;
using WebApiTIC.Application.Contracts;
using WebApiTIC.Application.DTOs;
using WebApiTIC.Domain.Entities;
using WebApiTIC.Infrastructure.Data;

namespace WebApiTIC.Infrastructure.Implementations
{
    public class EmpleadosRepo : IEmpleados
    {
        private readonly AppDbContext _context;
        public EmpleadosRepo(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<ServiceReponse> AddAsync(Empleados empleados)
        {
            _context.Empleados.Add(empleados);
             await SaveChangeAsync();
            return new ServiceReponse(true, "Agregado Correctamente");
        }

        public async Task<ServiceReponse> DeleteAsync(int id)
        {
            var empleados = await _context.Empleados.FindAsync(id);
            if (empleados != null)
            {
                return new ServiceReponse(false, "Empleado no encontrado");
            }

            _context.Empleados.Remove(empleados);
            await SaveChangeAsync();
            return new ServiceReponse(true, "Borrado exitosamente");
        }

        public async Task<List<Empleados>> GetAsync() => 
            await _context.Empleados.AsNoTracking().ToListAsync();


        public async Task<Empleados> GetByIdAsync(int id) =>
            await _context.Empleados.FindAsync(id);
        

        public async Task<ServiceReponse> UpdateAsync(Empleados empleados)
        {
            _context.Update(empleados);
            await SaveChangeAsync();
            return new ServiceReponse(true, "Actualizado correctamente");
        }

        private async Task SaveChangeAsync() => await _context.SaveChangesAsync();
    }
}
