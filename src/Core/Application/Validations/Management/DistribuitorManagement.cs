using FluentValidation;
using Application.DTOs.Distribuitor;

namespace Application.Validations.Management
{
    public class DistribuitorManagement : IDistribuitorManagement

    {
        private readonly IValidator<DistribuitorDTO> _validator;
        public DistribuitorManagement(IValidator<DistribuitorDTO> validator)
        {
            _validator = validator;
        }

        public async Task Manage(DistribuitorDTO distribuitor)
        {
            await _validator.ValidateAndThrowAsync(distribuitor);
        }

    }
}
