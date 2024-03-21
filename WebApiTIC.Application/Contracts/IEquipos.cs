

using WebApiTIC.Application.DTOs;
using WebApiTIC.Application.DTOs.Equipos;
using WebApiTIC.Domain.Entities;

namespace WebApiTIC.Application.Contracts
{
    public interface IEquipos
    {
        Task<ServiceReponse> AddAsync(CreateEquiposDto equipos);
        Task<ServiceReponse> UpdateAsync(UpdateEquiposDto equipos, int id);
        Task<ServiceReponse> DeleteAsync(int id);
        Task<List<Equipos>> GetAsync();
        Task<Equipos> GetByIdAsync(int id);
    }
}
