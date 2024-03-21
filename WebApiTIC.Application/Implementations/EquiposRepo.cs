using Microsoft.EntityFrameworkCore;
using WebApiTIC.Application.Contracts;
using WebApiTIC.Application.Data;
using WebApiTIC.Application.DTOs;
using WebApiTIC.Application.DTOs.Equipos;
using WebApiTIC.Domain.Entities;

namespace WebApiTIC.Application.Implementations
{
    public class EquiposRepo : IEquipos
    {
        private readonly IDbContext _context;

        public EquiposRepo(IDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceReponse> AddAsync(CreateEquiposDto equiposDto)
        {
            if (_context.Equipos.Any(e => e.Serial == equiposDto.Serial))
            {
                return new ServiceReponse(false, "Este equipo ya existe.");
            }

            var nuevoEquipo = new Equipos

            {
                Tipo = equiposDto.Tipo,
                Marca = equiposDto.Marca,
                Modelo = equiposDto.Modelo,
                Serial = equiposDto.Serial,
                Almacenamiento = equiposDto.Almacenamiento,
                Memoria_Ram = equiposDto.Memoria_Ram,
                Procesador = equiposDto.Procesador,
                SO = equiposDto.SO,
                Nombre_Equipo = equiposDto.Nombre_Equipo,
                Observaciones = equiposDto.Observaciones,
                Empleados_Cedula = equiposDto.Empleados_Cedula
            };

            if(nuevoEquipo.Empleados_Cedula == "")
            {
                nuevoEquipo.Estado = "Disponible";
                nuevoEquipo.Empleados_Cedula = null;
                nuevoEquipo.FechaAsignacion = null;
            }


            _context.Equipos.Add(nuevoEquipo);
            await _context.SaveChangesAsync();
            return new ServiceReponse(true, "Agregado Correctamente");
        }

        public async Task<ServiceReponse> DeleteAsync(int id)
        {
            var equipos = await _context.Equipos.FindAsync(id);
            if (equipos == null)
            {
                return new ServiceReponse(false, "Equipo no encontrado");
            }

            await DeleteAsignaAsync(equipos.Serial);

            _context.Equipos.Remove(equipos);
            await _context.SaveChangesAsync();
            return new ServiceReponse(true, "Borrado exitosamente");
        }

        public async Task<List<Equipos>> GetAsync() =>
            await _context.Equipos.AsNoTracking().ToListAsync();

        public async Task<Equipos> GetByIdAsync(int id) =>
            await _context.Equipos.FindAsync(id);

        public async Task<ServiceReponse> UpdateAsync(UpdateEquiposDto equiposDto, int id)
        {
            var equipoExistente = await _context.Equipos.FindAsync(id);

            if (equipoExistente == null)
            {
                return new ServiceReponse(false, "Equipo no encontrado. No se puede actualizar.");
            }

            equipoExistente.Almacenamiento = equiposDto.Almacenamiento;
            equipoExistente.Memoria_Ram = equiposDto.Memoria_Ram;
            equipoExistente.SO = equiposDto.SO;
            equipoExistente.Nombre_Equipo = equiposDto.Nombre_Equipo;
            equipoExistente.Observaciones = equiposDto.Observaciones;

            await _context.SaveChangesAsync();

            return new ServiceReponse(true, "Actualizado Correctamente");
        }

        public async Task<ServiceReponse> DeleteAsignaAsync(string serial)
        {
            var asignaciones = await _context.Asignaciones.FirstOrDefaultAsync(e => e.EquipoId == serial);
            if (asignaciones == null)
            {
                return new ServiceReponse(false, "Asignacion no encontrado");
            }

            _context.Asignaciones.Remove(asignaciones);
            await _context.SaveChangesAsync();
            return new ServiceReponse(true, "Borrado exitosamente");
        }

        }
}
