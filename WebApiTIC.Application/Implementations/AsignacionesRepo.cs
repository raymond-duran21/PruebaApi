using Microsoft.EntityFrameworkCore;
using WebApiTIC.Application.Contracts;
using WebApiTIC.Application.Data;
using WebApiTIC.Application.DTOs;
using WebApiTIC.Application.DTOs.Asignaciones;
using WebApiTIC.Domain.Entities;

namespace WebApiTIC.Application.Implementations
{
    public class AsignacionesRepo : IAsignaciones
    {
        private readonly IDbContext _context;

        public AsignacionesRepo(IDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceReponse> AddASync(CreateAsignacionDto AsignacionDto)
        {
            if (_context.Asignaciones.Any(e => e.EquipoId == AsignacionDto.EquipoId))
            {
                return new ServiceReponse(false, "El equipo ya se encuentra asignado.");
            }

            var nuevaAsignacion = new Asignaciones
            {
                EmpleadoId = AsignacionDto.EmpleadoId,
                NombreEmpleado = AsignacionDto.NombreEmpleado,
                Departamento = AsignacionDto.Departamento,
                EquipoId = AsignacionDto.EquipoId,
                Nombre_Equipo = AsignacionDto.Nombre_Equipo,
                Estado = "Asignado",
                Fecha_Asignacion = DateTime.Now
            };

            _context.Asignaciones.Add(nuevaAsignacion);
            await _context.SaveChangesAsync();
            await UpdateAsingAsync(nuevaAsignacion.EmpleadoId, nuevaAsignacion.EquipoId);
            return new ServiceReponse(true, "Asignado Correctamente");
        }

        public async Task<List<Asignaciones>> GetASync() =>
            await _context.Asignaciones.AsNoTracking().ToListAsync();

        public async Task<Asignaciones> GetByIdAsync(int id) =>
                    await _context.Asignaciones.FindAsync(id);

        public async Task<IEnumerable<Asignaciones>> GetByCedulaAsync(string cedula)
        {
            var asignaciones = await _context.Asignaciones
                .Where(e => e.EmpleadoId == cedula)
                .ToListAsync();

            return asignaciones;
        }

        public async Task<ServiceReponse> UpdateAsingAsync(string EmpleadoId, string EquipoId)
        {
            var empleadoExistente = await _context.Equipos.FirstOrDefaultAsync(e => e.Serial == EquipoId);

            if (empleadoExistente.Empleados_Cedula != null)
            {
                return new ServiceReponse(false, "El equipo esta asignado.");
            }

            empleadoExistente.Estado = "Asignado";
            empleadoExistente.Empleados_Cedula = EmpleadoId;
            empleadoExistente.FechaAsignacion = DateTime.Now;

            await _context.SaveChangesAsync();

            return new ServiceReponse(true, "Asignado Correctamente");
        }

        public async Task<ServiceReponse> UpdateDeleteAsingAsync(string EmpleadoId, string EquipoId)
        {
            var empleadoExistente = await _context.Equipos.FirstOrDefaultAsync(e => e.Serial == EquipoId);

            if (empleadoExistente.Empleados_Cedula == null)
            {
                return new ServiceReponse(false, "El equipo no esta asignado.");
            }
            empleadoExistente.Estado = "Disponible";
            empleadoExistente.Empleados_Cedula = null;
            empleadoExistente.FechaAsignacion = null;
            await _context.SaveChangesAsync();

            return new ServiceReponse(true, "Asignado Correctamente");
        }

        public async Task<ServiceReponse> DeleteAsync(int id)
        {
            var asignaciones = await _context.Asignaciones.FindAsync(id);
            if (asignaciones == null)
            {
                return new ServiceReponse(false, "Asignacion no encontrado");
            }
            await UpdateDeleteAsingAsync(asignaciones.EmpleadoId, asignaciones.EquipoId);

            _context.Asignaciones.Remove(asignaciones);
            await _context.SaveChangesAsync();
            return new ServiceReponse(true, "Borrado exitosamente");
        }
    }
}
