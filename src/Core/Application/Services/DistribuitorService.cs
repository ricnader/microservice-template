using AutoMapper;
using MongoDB.Bson;
using Serilog;
using Application.Contracts;
using Application.Dtos;
using Application.DTOs.Distribuitor;
using Domain.Contracts;
using Domain.Entities;
using Infrastructure.RepositoriesFiltersDefinition;
//using Infrastructure.RepositoriesFiltersDefinition;
using Shared.Helpers;

namespace Application.Services
{

    public class DistribuitorService : Service<Distribuitor, DistribuitorDTO>, IDistribuitorService
    {
        public DistribuitorService(IMapper iMapper, IDistribuitorRepository repository)
            : base(iMapper, repository)
        {
        }

        public async Task<Distribuitor> CreateDistribuitor(DistribuitorCreateDTO distribuitorCreateDTO)
        {
            Log.Logger.Information($"Inserindo novo distribuidor. Dados a serem inseridos:" +
                $"Nome:{distribuitorCreateDTO.State}" +
                $"Estado:{distribuitorCreateDTO.Name}" +
                $"Cidade:{distribuitorCreateDTO.City}" +
                $"Bairro:{distribuitorCreateDTO.Neighborhood}" +
                $"Endereço:{distribuitorCreateDTO.Address}" +
                $"Número:{distribuitorCreateDTO.Number}" +
                $"Tipo:{distribuitorCreateDTO.Type.GetDescription}.");

            var distribuitorMap = _iMapper.Map<Distribuitor>(distribuitorCreateDTO);
            var newDistribuitor = await _repository.Insert(distribuitorMap);

            Log.Logger.Information($"O distribuidor (ID: {newDistribuitor.Id}) foi criado com sucesso.");

            return newDistribuitor;
        }

        public async Task UpdateDistribuitor(DistribuitorUpdateDTO distribuitorUpdateDTO)
        {
            Log.Logger.Information($"Leitura de distribuidor (ID: {distribuitorUpdateDTO.Id}) para atualização de status.");

            var id = new ObjectId(distribuitorUpdateDTO.Id);

            var distribuitor = await _repository.GetByIdAsync(distribuitorUpdateDTO.Id);

            Log.Logger.Information($"Atualizando dados do distribuidor(ID: {distribuitorUpdateDTO.Id}). Dados a serem atualizados:" +
                $"Nome:{distribuitorUpdateDTO.State}" +
                $"Estado:{distribuitorUpdateDTO.Name}" +
                $"Cidade:{distribuitorUpdateDTO.City}" +
                $"Bairro:{distribuitorUpdateDTO.Neighborhood}" +
                $"Endereço:{distribuitorUpdateDTO.Address}" +
                $"Número:{distribuitorUpdateDTO.Number}" +
                $"Tipo:{distribuitorUpdateDTO.Type.GetDescription}.");

            _repository.Update(_iMapper.Map<Distribuitor>(distribuitorUpdateDTO), distribuitorUpdateDTO.Id);

            Log.Logger.Information($"O distribuidor (ID: {distribuitorUpdateDTO.Id}) foi atualizado com sucesso.");
        }

        public async Task UpdateStatus(DistribuitorUpdateStatusDTO distribuitorUpdateStatusDTO)
        {
            Log.Information($"Leitura de distribuidor (ID: {distribuitorUpdateStatusDTO.Id}) para atualização de status.");

            var distribuitor = await _repository.GetByIdAsync(distribuitorUpdateStatusDTO.Id);

            if (distribuitor == null) throw new KeyNotFoundException($"Não foi possível encontrar o distribuidor.");

            Log.Information($"Setando o status do distribuidor (ID: {distribuitorUpdateStatusDTO.Id}) para '{distribuitorUpdateStatusDTO.Status.GetDescription()}'.");
            distribuitor.AlterStatus(distribuitorUpdateStatusDTO.Status);

            Log.Information($"Atualizando o status do distribuidor (ID: {distribuitorUpdateStatusDTO.Id}) para '{distribuitorUpdateStatusDTO.Status.GetDescription()}'.");
            Update(distribuitor, distribuitorUpdateStatusDTO.Id);

            Log.Information($"O distribuidor (ID: {distribuitorUpdateStatusDTO.Id}) teve o status atualizado com sucesso para '{distribuitorUpdateStatusDTO.Status.GetDescription()}'.");
        }

        public async Task<IEnumerable<DistribuitorDTO>> GetAllAsync(GridDTO gridDTO, DistribuitorFilterDTO filter)
        {
            var sorts = gridDTO.sort;
            var paginates = gridDTO.paginate;

            Log.Logger.Information($"Nova consulta sendo gerada. Parametros enviados:" +
              $"sortBy:{sorts.sortby}" +
              $"direction:{sorts.direction}" +
              $"pageIndex:{paginates.pageIndex}" +
              $"pageSize:{paginates.pageSize}");

            _repository.MyFilterDefinition = DistribuitorFiltersDefinition.CreateFilters(
                filter.name,
                filter.type,
                filter.city,
                filter.state,
                filter.status,
                filter.createdAtBeginDate,
                filter.createdAtEndDate,
                filter.inactivatedDateBeginDate,
                filter.inactivatedDateEndDate);

            var distribuitors = await _repository.GetAllAsync(
                sorts.sortby,
                sorts.direction,
                paginates.pageIndex,
                paginates.pageSize
            );

            return _iMapper.Map<IEnumerable<DistribuitorDTO>>(distribuitors);
        }
    }
}
