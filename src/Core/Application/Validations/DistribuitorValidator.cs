using FluentValidation;
using Application.Validation;
using Application.DTOs.Distribuitor;

namespace Application.Validations
{
    public class DistribuitorValidator : AbstractValidator<DistribuitorDTO>
    {
        public DistribuitorValidator()
        {
            Include(new DistribuitorSimpleValidator());
            Include(new DistribuitorBusinessValidator());
        }        
    }
}
