using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTIC.Application.DTOs;
using WebApiTIC.Application.DTOs.Asignaciones;
using WebApiTIC.Domain.Entities;

namespace WebApiTIC.Application.Contracts
{
    public interface IAsignaciones
    {
        Task<ServiceReponse> AddASync(CreateAsignacionDto createAsignacionDto);
        Task<List<Asignaciones>> GetASync();
        Task<Asignaciones> GetByIdAsync(int id);
        Task<IEnumerable<Asignaciones>> GetByCedulaAsync(string cedula);
        Task<ServiceReponse> UpdateAsingAsync(string EmpleadoId, string EquipoId);
        Task<ServiceReponse> UpdateDeleteAsingAsync(string EmpleadoId, string EquipoId);
        Task<ServiceReponse> DeleteAsync(int id);
    }
}
