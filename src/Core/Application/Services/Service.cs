using AutoMapper;
using Application.Contracts;
using Application.Dtos;
using Application.DTOs;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class Service<TEntity, TEntityDTO> : IService<TEntity, TEntityDTO>
        where TEntity : Entity
        where TEntityDTO : DTO
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _iMapper;


        public Service(IMapper iMapper, IRepository<TEntity> repository)
            : base()
        {
            _iMapper = iMapper;
            _repository = repository;
        }


        public async Task<TEntityDTO> GetByIdAsync(string id)
        {
            return _iMapper.Map<TEntityDTO>(await _repository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<TEntityDTO>> GetAllAsync()
        {
            return _iMapper.Map<IEnumerable<TEntityDTO>>(await _repository.GetAllAsync());
        }

        public async Task<IEnumerable<TEntityDTO>> GetAllAsync(GridDTO gridDTO)
        {
            return _iMapper.Map<IEnumerable<TEntityDTO>>(await _repository.GetAllAsync(
                sortBy: gridDTO.sort.sortby,
                sortDirection: gridDTO.sort.direction,
                pageIndex: gridDTO.paginate.pageIndex,
                pageSize: gridDTO.paginate.pageSize
            ));
        }

        public async Task<TEntityDTO> Insert(TEntity T)
        {
            return _iMapper.Map<TEntityDTO>(await _repository.Insert(T));
        }

        public async void Update(TEntity T, string id)
        {
            await Task.Run(() => _repository.Update(T, id));

        }
    }
}
