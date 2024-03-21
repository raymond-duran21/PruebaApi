using Microsoft.EntityFrameworkCore;
using WebApiTIC.Application.Contracts;
using WebApiTIC.Application.Data;
using WebApiTIC.Application.DTOs;
using WebApiTIC.Application.DTOs.Empleados;
using WebApiTIC.Domain.Entities;

namespace WebApiTIC.Application.Implementations
{
    public class EmpleadosRepo : IEmpleados
    {
        private readonly IDbContext _context;

        public EmpleadosRepo(IDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceReponse> AddAsync(CreacionEmpleadosDto empleadoDto)
        {
            if(_context.Empleados.Any(e => e.Cedula_Pasaporte == empleadoDto.Cedula_Pasaporte))
            {
                return new ServiceReponse(false, "La cedula ya existe. No se puede agregar el empleado");
            }

            var nuevoEmpleado = new Empleados

            {
                Nombre = empleadoDto.Nombre,
                Cedula_Pasaporte = empleadoDto.Cedula_Pasaporte,
                Puesto = empleadoDto.Puesto,
                Departamento = empleadoDto.Departamento,
            };

            _context.Empleados.Add(nuevoEmpleado);
             await _context.SaveChangesAsync();
            return new ServiceReponse(true, "Agregado Correctamente");
        }

        public async Task<ServiceReponse> DeleteAsync(int id)
        {
            var empleados = await _context.Empleados.FindAsync(id);
            if (empleados == null)
            {
                return new ServiceReponse(false, "Empleado no encontrado");
            }
            _context.Empleados.Remove(empleados);
            await _context.SaveChangesAsync();
            return new ServiceReponse(true, "Borrado exitosamente");
        }

        public async Task<List<Empleados>> GetAsync() => 
            await _context.Empleados.AsNoTracking().ToListAsync();


        public async Task<Empleados> GetByIdAsync(int id) =>
            await _context.Empleados.FindAsync(id);
        

        public async Task<ServiceReponse> UpdateAsync(UpdateEmpleadosDto empleadosDto, int id)
        {
            
            var empleadoExistente = await _context.Empleados.FindAsync(id);

            if (empleadoExistente == null)
            {
                return new ServiceReponse(false, "Empleado no encontrado. No se puede actualizar.");
            }
            empleadoExistente.Puesto = empleadosDto.Puesto;
            empleadoExistente.Departamento = empleadosDto.Departamento;


            await _context.SaveChangesAsync();

            return new ServiceReponse(true, "Actualizado Correctamente");
        }

        
    }  
}
