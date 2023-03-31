using Application.Dtos;
using Application.DTOs.Distribuitor;
using Domain.Entities;

namespace Application.Contracts
{
    public interface IDistribuitorService : IService<Distribuitor, DistribuitorDTO>
    {
        Task UpdateStatus(DistribuitorUpdateStatusDTO distribuitorUpdateStatusDTO);
        Task<Distribuitor> CreateDistribuitor(DistribuitorCreateDTO distribuitorCreateDTO);
        Task UpdateDistribuitor(DistribuitorUpdateDTO distribuitorUpdateDTO);
        Task<IEnumerable<DistribuitorDTO>> GetAllAsync(GridDTO gridDTO, DistribuitorFilterDTO distribuitorFilterDTO);
    }
}
