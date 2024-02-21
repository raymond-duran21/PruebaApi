
using WebApiTIC.Application.DTOs;
using WebApiTIC.Domain.Entities;

namespace WebApiTIC.Application.Contracts
{
    public interface IEmpleados
    {
        Task<ServiceReponse> AddAsync(Empleados empleados);
        Task<ServiceReponse> UpdateAsync(Empleados empleados);
        Task<ServiceReponse> DeleteAsync(int id);
        Task<List<Empleados>> GetAsync();
        Task<Empleados> GetByIdAsync(int id);
    }
}
