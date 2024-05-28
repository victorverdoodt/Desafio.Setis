using Desafio.Setis.Domain.Common;
using Desafio.Setis.Domain.Models.Entities;
using FluentValidation;

namespace Desafio.Setis.Domain.Models.Validators
{
    public class AdmSystemValidator : AbstractValidator<AdmSystem>
    {
        public AdmSystemValidator(List<AdmSystem> admSystems)
        {
            RuleFor(x => x.Id)
                 .GreaterThan(0)
                    .WithMessage(s => string.Format(ValidatorMessages.IdGreaterThanZero, s.GetType().Name, s.Id, nameof(s.Id)))
                .Must((id) =>
                 {
                     return admSystems.Count(e => e.Id == id) <= 1;
                 })
                    .WithMessage(s => string.Format(ValidatorMessages.IdDuplicated, s.GetType().Name, s.Id, nameof(s.Id)));

            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage(s => string.Format(ValidatorMessages.FieldRequired, s.GetType().Name, s.Id, nameof(s.Name)))
                .MaximumLength(50)
                    .WithMessage(s => string.Format(ValidatorMessages.IdDuplicated, s.GetType().Name, s.Id, nameof(s.Name), 50));
        }
    }
}
