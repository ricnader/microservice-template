using MongoDB.Bson;
using MongoDB.Driver;
using Domain.Entities;
using Domain.Enums;

namespace Domain.Contracts
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        FilterDefinition<TEntity> MyFilterDefinition { get; set; }
        Task<IEnumerable<TEntity>> GetAllAsync(string sortBy, ESortDirection sortDirection, int pageIndex, int pageSize);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(string id);
        Task<TEntity> Insert(TEntity T);
        void Update(TEntity T, string id);
    }
}
