using Domain.Enums;
using Infrastructure.RepositoriesFiltersDefinition;
using Vertem.Agrega.Test;
using Shared.Helpers;

namespace VertemAgrega.Test.FilterDefinition
{
    public class DistribuitorFilterDefinitionTests
    {
        [Fact]
        public void GivenIInformNameParameter_WhenIListAllDistribuitors_ReturnACollectionOfDistribuitorsWichContainsNameInformed()
        {
            var filter = DistribuitorFiltersDefinition.CreateFilters(name: "Distribuitor Name");
            var fields = FilterDefinitionTester.GetFilters(filter);

            Assert.True(fields.Count() > 0);
            Assert.Equal("Name=/Distribuitor Name/", fields.Where(x => x.Key == "Name")?.FirstOrDefault().Value);
        }

        [Fact]
        public void GivenIInformTypeParameter_WhenIListAllDistribuitors_ReturnACollectionOfDistribuitorsWichContainsTypeInformed()
        {
            var filter = DistribuitorFiltersDefinition.CreateFilters(type: EDistribuitorType.M);
            var fields = FilterDefinitionTester.GetFilters(filter);
            
            Assert.True(fields.Count() > 0);
            Assert.Equal("Type=1", fields.Where(x => x.Key == "Type")?.FirstOrDefault().Value);
        }

        [Fact]
        public void GivenIInformCityParameter_WhenIListAllDistribuitors_ReturnACollectionOfDistribuitorsWichContainsCityInformed()
        {
            var filter = DistribuitorFiltersDefinition.CreateFilters(city: "City of Distribuitor");
            var fields = FilterDefinitionTester.GetFilters(filter);

            Assert.True(fields.Count() > 0);
            Assert.Equal("City=/City of Distribuitor/", fields.Where(x => x.Key == "City")?.FirstOrDefault().Value);
        }

        [Fact]
        public void GivenIInformStateParameter_WhenIListAllDistribuitors_ReturnACollectionOfDistribuitorsWichContainsStateInformed()
        {
            var filter = DistribuitorFiltersDefinition.CreateFilters(state: EUf.PR.GetDescription());
            var fields = FilterDefinitionTester.GetFilters(filter);

            Assert.True(fields.Count() > 0);
            Assert.Equal($"State={EUf.PR.GetDescription()}", fields.Where(x => x.Key == "State")?.FirstOrDefault().Value);
        }

        [Fact]
        public void GivenIInformStatusParameter_WhenIListAllDistribuitors_ReturnACollectionOfDistribuitorsWichContainsStatusInformed()
        {
            var filter = DistribuitorFiltersDefinition.CreateFilters(status: EDistribuitorStatus.A);
            var fields = FilterDefinitionTester.GetFilters(filter);

            Assert.True(fields.Count() > 0);
            Assert.Equal("Status=1", fields.Where(x => x.Key == "Status")?.FirstOrDefault().Value);
        }

        [Fact]
        public void GivenIInformCreatedAtBeginDateParameter_WhenIListAllDistribuitors_ReturnACollectionOfDistribuitorsCreatedAtBeginDateGTEInformed()
        {
            var filter = DistribuitorFiltersDefinition.CreateFilters(createdAtBeginDate: new DateTime(2022, 05, 01));
            var fields = FilterDefinitionTester.GetFilters(filter);

            Assert.True(fields.Count() > 0);
            //Assert.Equal("CreatedAt={ \"$gte\" : ISODate(\"2022-05-01T03:00:00Z\") }", fields.Where(x => x.Key == "CreatedAt")?.FirstOrDefault().Value);
        }

        [Fact]
        public void GivenIInformCreatedAtEndDateParameter_WhenIListAllDistribuitors_ReturnACollectionOfDistribuitorsCreatedAtEndDateLTEInformed()
        {
            var filter = DistribuitorFiltersDefinition.CreateFilters(createdAtEndDate: new DateTime(2022, 05, 01));
            var fields = FilterDefinitionTester.GetFilters(filter);
            var createdAtValue = fields.Where(x => x.Key == "CreatedAt")?.FirstOrDefault().Value;

            Assert.True(fields.Count() > 0);
            //Assert.Equal("CreatedAt={ \"$lte\" : ISODate(\"2022-05-01T03:00:00Z\") }", fields.Where(x => x.Key == "CreatedAt")?.FirstOrDefault().Value);
        }


        [Fact]
        public void GivenIInformInactivatedBeginDateParameter_WhenIListAllDistribuitors_ReturnACollectionOfDistribuitorsInactivatedDateGTEInformed()
        {

            var filter = DistribuitorFiltersDefinition.CreateFilters(inactivatedDateBeginDate: new DateTime(2022, 05, 01));
            var fields = FilterDefinitionTester.GetFilters(filter);
            var isFildsMoreThanZero = fields.Count() > 0;

            var inativateDate = isFildsMoreThanZero ? 
                fields.Where(x => x.Key == "InactivatedDate")?.FirstOrDefault().Value : null;

            Assert.True(isFildsMoreThanZero);
            //Assert.Equal("InactivatedDate={ \"$gte\" : ISODate(\"2022-05-01T03:00:00Z\") }", inativateDate);
        }

        [Fact]
        public void GivenIInformInactivatedEndDateParameter_WhenIListAllDistribuitors_ReturnACollectionOfDistribuitorsInactivatedDateLTEEInformed()
        {
            var filter = DistribuitorFiltersDefinition.CreateFilters(inactivatedDateEndDate: new DateTime(2022, 05, 01));
            var fields = FilterDefinitionTester.GetFilters(filter);

            Assert.True(fields.Count() > 0);
            //Assert.Equal("InactivatedDate={ \"$lte\" : ISODate(\"2022-05-01T03:00:00Z\") }", fields.Where(x => x.Key == "InactivatedDate")?.FirstOrDefault().Value);
        }
    }
}