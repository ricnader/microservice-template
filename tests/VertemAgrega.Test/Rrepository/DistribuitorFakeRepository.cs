using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using Application.DTOs.Distribuitor;
using Application.Map;
using Domain.Entities;
using Domain.Enums;

namespace Vertem.Agrega.Test.Repository
{
    public class DistribuitorFakeRepository 
    {
        private readonly IEnumerable<ParticipantDTO> _all;
        internal readonly Distribuitor _distribuitor;
        public FilterDefinition<Distribuitor> MyFilterDefinition { get; set; }

        public DistribuitorFakeRepository()
        {
            _all = new List<ParticipantDTO>()
            {
                new ParticipantDTO() { Id = new ObjectId().ToString(), Name = "Distribuitor 1", Address ="Address 1", Neighborhood = "Neighborhood 1", Number = "Number 1", City = "City 1", State = "State 1", CreatedAt = new DateTime() , Status = EDistribuitorStatus.A },
                new ParticipantDTO() { Id = new ObjectId().ToString(), Name = "Distribuitor 2", Address ="Address 2", Neighborhood = "Neighborhood 2", Number = "Number 2", City = "City 2", State = "State 2", CreatedAt = new DateTime() , Status = EDistribuitorStatus.A },
                new ParticipantDTO() { Id = new ObjectId().ToString(), Name = "Distribuitor 3", Address ="Address 3", Neighborhood = "Neighborhood 3", Number = "Number 3", City = "City 3", State = "State 3", CreatedAt = new DateTime() , Status = EDistribuitorStatus.A },
                new ParticipantDTO() { Id = new ObjectId().ToString(), Name = "Distribuitor 4", Address ="Address 4", Neighborhood = "Neighborhood 4", Number = "Number 4", City = "City 4", State = "State 4", CreatedAt = new DateTime() , Status = EDistribuitorStatus.A },
                new ParticipantDTO() { Id = new ObjectId().ToString(), Name = "Distribuitor 5", Address ="Address 1", Neighborhood = "Neighborhood 5", Number = "Number 5", City = "City 5", State = "State 5", CreatedAt = new DateTime() , Status = EDistribuitorStatus.A },
            };

            _distribuitor = new Domain.Entities.Distribuitor()
            {
                Name = "João da Silva",
                Address = "Rua 25 de março",
                City = "São Paulo",
                State = "SP",
                Number = "333",
                CreatedAt = DateTime.Now,
                Neighborhood = "Lapa",
                Status = EDistribuitorStatus.A
            };
        }

        public Task<ParticipantDTO> GetByIdAsync(string id)
        {
            return Task.Delay(10000)
                .ContinueWith(t => _all.Where(x => x.Id == id.ToString()).FirstOrDefault());
        }

        public Task<IEnumerable<ParticipantDTO>> GetAllAsync(string sortBy, ESortDirection sortDirection, int pageIndex, int pageSize)
        {
            return Task.Delay(10000)
                .ContinueWith(t => _all.Skip(pageIndex * pageSize).Take(pageSize));
        }

        public Task<ParticipantDTO> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ParticipantDTO> Insert(Domain.Entities.Distribuitor distribuitor)
        {
            try
            {
                if (distribuitor != null)
                {
                    var mapperConfig = new MapperConfiguration(mc =>
                    {
                        mc.AddProfile(new MapConfig());
                    });

                    IMapper mapper = mapperConfig.CreateMapper();

                    return await Task.FromResult(mapper.Map<ParticipantDTO>(distribuitor));
                }
                else
                    throw new NullReferenceException();

            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<bool> Update(Domain.Entities.Distribuitor distribuitor, Object id)
        {
            try
            {
                if (distribuitor != null)
                    return await Task.FromResult(distribuitor != null);
                else
                    throw new Exception();
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<bool> GetStatusAsync(Domain.Entities.Distribuitor distribuitor, EDistribuitorStatus status)
        {
            try
            {
                if (distribuitor != null)
                    return await Task.FromResult(distribuitor != null);
                else
                    throw new Exception();
            }
            catch
            {
                throw;
            }
        }

    }
}