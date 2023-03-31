using FluentValidation;
using Domain.Enums;
using Application.DTOs.Distribuitor;

namespace Application.Validation
{
    public class DistribuitorSimpleValidator : AbstractValidator<DistribuitorDTO>
    {
        public DistribuitorSimpleValidator()
        {
            RuleFor(d => d.Name).NotNull().WithMessage("'{PropertyName}' Não pode ser nulo")
                .NotEmpty().WithMessage("'{PropertyName}' Não pode estar vazio");
            RuleFor(d => d.State).NotNull().WithMessage("'{PropertyName}' Não pode ser nulo")
                .NotEmpty().WithMessage("'{PropertyName}' Não pode estar vazio");
            RuleFor(d => d.City).NotNull().WithMessage("'{PropertyName}' Não pode ser nulo")
                .NotEmpty().WithMessage("'{PropertyName}' Não pode estar vazio");
            RuleFor(d => d.Neighborhood).NotNull().WithMessage("'{PropertyName}' Não pode ser nulo")
                .NotEmpty().WithMessage("'{PropertyName}' Não pode estar vazio");
            RuleFor(d => d.Address).NotNull().WithMessage("'{PropertyName}' Não pode ser nulo")
                .NotEmpty().WithMessage("'{PropertyName}' Não pode estar vazio");
            RuleFor(d => d.Number).NotNull().WithMessage("'{PropertyName}' Não pode ser nulo")
                .NotEmpty().WithMessage("'{PropertyName}' Não pode estar vazio");
            RuleFor(x => x.Type).IsInEnum().WithMessage("'{PropertyName}' Tipo de distribuitor inválido");
            When(x => x.Type == EDistribuitorType.F, () =>
            {
                RuleFor(x => x.DistribuitorHeadQuartersId).NotNull().WithMessage("Uma matriz deve ser vinculada à filial.");
            });
            When(x => x.Type == EDistribuitorType.M, () =>
            {
                RuleFor(x => x.DistribuitorHeadQuartersId).Null().WithMessage("Uma matriz não pode ser vinculada a outro distribuidor.");
            });
        }
    }
}
