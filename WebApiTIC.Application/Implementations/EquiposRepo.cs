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
                EmpleadosId = equiposDto.EmpleadosId
            };

            if(nuevoEquipo.EmpleadosId == 0)
            {
                nuevoEquipo.EmpleadosId = null;
            }


            if (nuevoEquipo.EmpleadosId != null)
            {
                nuevoEquipo.FechaAsignacion = DateTime.Now;
            }

            _context.Equipos.Add(nuevoEquipo);
            await _context.SaveChangesAsync();
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
            await _context.SaveChangesAsync();
            return new ServiceReponse(true, "Borrado exitosamente");
        }

        public async Task<List<Equipos>> GetAsync() =>
            await _context.Equipos.AsNoTracking().ToListAsync();

        public async Task<Equipos> GetByIdAsync(int id) =>
            await _context.Equipos.FindAsync(id);

        public async Task<ServiceReponse> UpdateAsync(UpdateEquiposDto equiposDto)
        {
            var equipoExistente = await _context.Equipos.FindAsync(equiposDto.Id);

            if (equipoExistente == null)
            {
                return new ServiceReponse(false, "Equipo no encontrado. No se puede actualizar.");
            }

            equipoExistente.Almacenamiento = equiposDto.Almacenamiento;
            equipoExistente.Memoria_Ram = equiposDto.Memoria_Ram;
            equipoExistente.SO = equiposDto.SO;
            equipoExistente.Nombre_Equipo = equiposDto.Nombre_Equipo;
            equipoExistente.Observaciones = equiposDto.Observaciones;

            if (equipoExistente.EmpleadosId != equiposDto.EmpleadosId)
            {
                equipoExistente.FechaAsignacion = DateTime.Now;
            }

            equipoExistente.EmpleadosId = equiposDto.EmpleadosId;

            if (equiposDto.EmpleadosId == 0)
            {
                equipoExistente.EmpleadosId = null;
                equipoExistente.FechaAsignacion = null;
            }
            if(equipoExistente.EmpleadosId == equiposDto.EmpleadosId && equipoExistente.FechaAsignacion == null)
            {
                equipoExistente.FechaAsignacion = DateTime.Now;
            }

            

            await _context.SaveChangesAsync();

            return new ServiceReponse(true, "Actualizado Correctamente");
        }



    }
}
