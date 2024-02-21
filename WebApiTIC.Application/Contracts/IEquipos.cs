

using WebApiTIC.Application.DTOs;
using WebApiTIC.Domain.Entities;

namespace WebApiTIC.Application.Contracts
{
    public interface IEquipos
    {
        Task<ServiceReponse> AddAsync(Equipos equipos);
        Task<ServiceReponse> UpdateAsync(Equipos equipos);
        Task<ServiceReponse> DeleteAsync(int id);
        Task<List<Equipos>> GetAsync();
        Task<Equipos> GetByIdAsync(int id);
    }
}
