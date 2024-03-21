
using WebApiTIC.Application.DTOs;
using WebApiTIC.Application.DTOs.Empleados;
using WebApiTIC.Domain.Entities;

namespace WebApiTIC.Application.Contracts
{
    public interface IEmpleados
    {
        Task<ServiceReponse> AddAsync(CreacionEmpleadosDto empleados);
        Task<ServiceReponse> UpdateAsync(UpdateEmpleadosDto empleados, int id);
        Task<ServiceReponse> DeleteAsync(int id);
        Task<List<Empleados>> GetAsync();
        Task<Empleados> GetByIdAsync(int id);
    }
}
