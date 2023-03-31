using Application.Dtos;
using FluentValidation.TestHelper;
using Application.Validations;
using MongoDB.Bson;
using Domain.Enums;

namespace Vertem.Agrega.Test.Validations
{
    public class DistribuitorValidationTests
    {
        private readonly DistribuitorValidator _validator;
        public DistribuitorValidationTests()
        {
            _validator = new DistribuitorValidator();
        }


        #region Update Validations 
        [Fact]
        public void GiveNameNotFilled_WhenUpdatigDistribuitor_ReturnsError()
        {
            var model = new DistribuitorDTO { Name = String.Empty };

            var result = _validator.TestValidate(model);

            #region Assert
            result.ShouldHaveValidationErrorFor(d => d.Name); 
            #endregion
        }

        [Fact]
        public void GiveNameNull_WhenUpdatigDistribuitor_ReturnsError()
        {
            var model = new DistribuitorDTO { Name = null };

            var result = _validator.TestValidate(model);

            #region Assert
            result.ShouldHaveValidationErrorFor(d => d.Name);
            #endregion
        }



        [Fact]
        public void GiveStateNotFilled_WhenUpdatigDistribuitor_ReturnsError()
        {
            var model = new DistribuitorDTO { State = String.Empty };

            var result = _validator.TestValidate(model);

            #region Assert
            result.ShouldHaveValidationErrorFor(d => d.State);
            #endregion
        }

        [Fact]
        public void GiveStateNull_WhenUpdatigDistribuitor_ReturnsError()
        {
            var model = new DistribuitorDTO { State = null };

            var result = _validator.TestValidate(model);

            #region Assert
            result.ShouldHaveValidationErrorFor(d => d.State);
            #endregion
        }

        [Fact]
        public void GiveCityNotFilled_WhenUpdatigDistribuitor_ReturnsError()
        {
            var model = new DistribuitorDTO { City = String.Empty };

            var result = _validator.TestValidate(model);

            #region Assert
            result.ShouldHaveValidationErrorFor(d => d.City);
            #endregion
        }

        [Fact]
        public void GiveCityNull_WhenUpdatigDistribuitor_ReturnsError()
        {
            var model = new DistribuitorDTO { City = null };

            var result = _validator.TestValidate(model);

            #region Assert
            result.ShouldHaveValidationErrorFor(d => d.City);
            #endregion
        }




        [Fact]
        public void GiveNeighborhoodnotFilled_WhenUpdatigDistribuitor_ReturnsError()
        {
            var model = new DistribuitorDTO { Neighborhood = String.Empty };

            var result = _validator.TestValidate(model);

            #region Assert
            result.ShouldHaveValidationErrorFor(d => d.Neighborhood);
            #endregion
        }


        [Fact]
        public void GiveNeighborhoodNull_WhenUpdatigDistribuitor_ReturnsError()
        {
            var model = new DistribuitorDTO { Neighborhood = null };

            var result = _validator.TestValidate(model);

            #region Assert
            result.ShouldHaveValidationErrorFor(d => d.Neighborhood);
            #endregion
        }

        [Fact]
        public void GiveAddressNotFilled_WhenUpdatigDistribuitor_ReturnsError()
        {
            var model = new DistribuitorDTO { Address = String.Empty };

            var result = _validator.TestValidate(model);

            #region Assert
            result.ShouldHaveValidationErrorFor(d => d.Address);
            #endregion
        }

        [Fact]
        public void GiveAddressNull_WhenUpdatigDistribuitor_ReturnsError()
        {
            var model = new DistribuitorDTO { Address = null };

            var result = _validator.TestValidate(model);

            #region Assert
            result.ShouldHaveValidationErrorFor(d => d.Address);
            #endregion
        }


        [Fact]
        public void GiveNumberNotFilled_WhenUpdatigDistribuitor_ReturnsError()
        {
            var model = new DistribuitorDTO { Number = String.Empty };

            var result = _validator.TestValidate(model);

            #region Assert
            result.ShouldHaveValidationErrorFor(d => d.Number);
            #endregion
        }

        [Fact]
        public void GiveNumberNull_WhenUpdatigDistribuitor_ReturnsError()
        {
            var model = new DistribuitorDTO { Number = null };

            var result = _validator.TestValidate(model);

            #region Assert
            result.ShouldHaveValidationErrorFor(d => d.Number);
            #endregion
        }

        [Fact]
        public void GivenIInformTypeFAndHeadQuartersIdNotFilled_WhenCreateOrUpdateDistribuitor_ReturnsError()
        {
            var model = new DistribuitorDTO { Type = EDistribuitorType.F, DistribuitorHeadQuartersId = null };

            var result = _validator.TestValidate(model);

            #region Assert
            result.ShouldHaveValidationErrorFor(d => d.DistribuitorHeadQuartersId);
            #endregion

        }

        [Fact]
        public void GivenIInformTypeMAndHeadQuartersIdFilled_WhenCreateOrUpdateDistribuitor_ReturnsError()
        {
            var model = new DistribuitorDTO { Type = EDistribuitorType.M, DistribuitorHeadQuartersId = new ObjectId().ToString() };

            var result = _validator.TestValidate(model);

            #region Assert
            result.ShouldHaveValidationErrorFor(d => d.DistribuitorHeadQuartersId);
            #endregion

        }
        #endregion

    }
}