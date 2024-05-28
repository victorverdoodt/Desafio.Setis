using Desafio.Setis.Domain.Common;
using Desafio.Setis.Domain.Models.Entities;
using FluentValidation;

namespace Desafio.Setis.Domain.Models.Validators
{
    public class AdmEntityValidator : AbstractValidator<AdmEntity>
    {
        public AdmEntityValidator(List<AdmEntity> admEntities)
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                    .WithMessage(s => string.Format(ValidatorMessages.IdGreaterThanZero, s.GetType().Name, s.Id, nameof(s.Id)))
                .Must((id) =>
                {
                    return admEntities.Count(e => e.Id == id) <= 1;
                })
                    .WithMessage(s => string.Format(ValidatorMessages.IdDuplicated, s.GetType().Name, s.Id, nameof(s.Id)));

            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage(s => string.Format(ValidatorMessages.FieldRequired, s.GetType().Name, s.Id, nameof(s.Name)));

            RuleFor(x => x.Responsible)
                .NotEmpty()
                    .WithMessage(s => string.Format(ValidatorMessages.FieldRequired, s.GetType().Name, s.Id, nameof(s.Responsible)))
                .MaximumLength(50)
                    .WithMessage(s => string.Format(ValidatorMessages.ResponsibleNameLength, s.GetType().Name, s.Id, nameof(s.Responsible), 50));
        }
    }
}
