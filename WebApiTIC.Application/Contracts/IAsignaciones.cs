using WebApiTIC.Application.DTOs;
using WebApiTIC.Domain.Entities;

namespace WebApiTIC.Application.Contracts
{
    public interface IAsignaciones
    {
        Task<ServiceReponse> AddAsync(Asignaciones asignaciones);
        Task<List<Asignaciones>> GetAsync();
        Task<Asignaciones> GetByIdAsync(int id);
    }
}
