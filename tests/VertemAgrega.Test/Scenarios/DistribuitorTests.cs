using AutoMapper;
using Application.Dtos;
using Application.DTOs.Distribuitor;
using Application.Map;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.RepositoriesFiltersDefinition;
using Vertem.Agrega.Test.Repository;

namespace Vertem.Agrega.Test.Tests
{
    public class DistribuitorTests 
    {

        private readonly DistribuitorFakeRepository _distribuitorFakeRepository;

        public DistribuitorTests()
        {
            _distribuitorFakeRepository = new DistribuitorFakeRepository();
        }

        public async Task<IEnumerable<ParticipantDTO>> GetAllAsync(GridDTO gridDTO, DistribuitorFilterDTO filter)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapConfig());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            _distribuitorFakeRepository.MyFilterDefinition = DistribuitorFiltersDefinition.CreateFilters(
                filter.name,
                filter.type,
                filter.city,
                filter.state,
                filter.status,
                filter.createdAtBeginDate,
                filter.createdAtEndDate,
                filter.inactivatedDateBeginDate,
                filter.inactivatedDateEndDate);

            return mapper.Map<IEnumerable<ParticipantDTO>>(await _distribuitorFakeRepository.GetAllAsync(
                gridDTO.sort.sortby,
                gridDTO.sort.direction,
                gridDTO.paginate.pageIndex,
                gridDTO.paginate.pageSize
            ));
        }



        [Fact]
        public async Task GivenFilledObject_WhenInsertingDistribuitor_ReturnsDistribuitor()
        {
          
            Distribuitor distribuitor = _distribuitorFakeRepository._distribuitor;

            var result  =  await _distribuitorFakeRepository.Insert(distribuitor);
            Assert.IsType<ParticipantDTO>(result);
        }

        [Fact]
        public async Task GiveNullObject_WhenInsertingDistribuitor_ReturnsException()
        {
            Distribuitor distribuitor = null;

            #region Assert
            await Assert.ThrowsAsync<NullReferenceException>(() =>  _distribuitorFakeRepository.Insert(distribuitor));
            ; 
            #endregion
        }

        [Fact]
        public async Task GiveFilledObject_WhenUpdatigDistribuitor_ReturnsTrue()
        {
            Distribuitor distribuitor = _distribuitorFakeRepository._distribuitor;

            var result = await _distribuitorFakeRepository.Update(distribuitor, distribuitor.Id);
            Assert.IsType<bool>(result);
            Assert.True(result);
        }


        [Fact]
        public async Task GiveFilledObject_WhenUpdatigDistribuitor_ReturnsException()
        {
            Distribuitor distribuitor = null;
            await Assert.ThrowsAsync<NullReferenceException>(() => _distribuitorFakeRepository.Update(distribuitor, distribuitor.Id));
        }


        [Fact]
        public async void GivenIInformAnyParameter_WhenIListAllDistribuitors_ReturnACollectionOfDistribuitors()
        {
            #region Arrange
            var gridDTO = new GridDTO();

            var distribuitorFilter = new DistribuitorFilterDTO();
            #endregion

            #region Act
            var distribuitors = await GetAllAsync(gridDTO, distribuitorFilter);
            #endregion

            #region Assert
            Assert.True(distribuitors?.Count() > 0);
            #endregion
        }

        [Fact]
        public async Task GivenInactive_WhenStatusDistribuitor_ReturnTrue()
        {
            Distribuitor distribuitor = _distribuitorFakeRepository._distribuitor;

            var result = await _distribuitorFakeRepository.GetStatusAsync(distribuitor, EDistribuitorStatus.I);
            Assert.IsType<bool>(result);
            Assert.True(result);
        }

        [Fact]
        public async Task GivenActive_WhenStatusDistribuitor_ReturnTrue()
        {
            Distribuitor distribuitor = _distribuitorFakeRepository._distribuitor;

            var result = await _distribuitorFakeRepository.GetStatusAsync(distribuitor, EDistribuitorStatus.A);
            Assert.IsType<bool>(result);
            Assert.True(result);
        }

    }
}
