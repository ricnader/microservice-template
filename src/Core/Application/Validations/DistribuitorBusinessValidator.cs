using FluentValidation;
using Application.DTOs.Distribuitor;


namespace Application.Validation
{
    public class DistribuitorBusinessValidator : AbstractValidator<DistribuitorDTO>
    {
        public DistribuitorBusinessValidator()
        {
            //Business rules here
        }        
    }
}
