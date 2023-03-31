using MongoDB.Bson;
using Application.Dtos;
using Application.DTOs;
using Domain.Entities;

namespace Application.Contracts
{
    public interface IService<TEntity, TEntityDTO>
    where TEntity : Entity
    where TEntityDTO : DTO
    {
        Task<IEnumerable<TEntityDTO>> GetAllAsync(GridDTO PaginateDTO);
        Task<IEnumerable<TEntityDTO>> GetAllAsync();
        Task<TEntityDTO> GetByIdAsync(string id);
        Task<TEntityDTO> Insert(TEntity T);
        void Update(TEntity T, string id);
    }
}
