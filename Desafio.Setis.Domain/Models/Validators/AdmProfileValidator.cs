using Desafio.Setis.Domain.Common;
using Desafio.Setis.Domain.Models.Entities;
using FluentValidation;

namespace Desafio.Setis.Domain.Models.Validators
{
    public class AdmProfileValidator : AbstractValidator<AdmProfile>
    {
        public AdmProfileValidator(List<AdmSystem> admSystems, List<AdmProfile> admProfiles)
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                    .WithMessage(s => string.Format(ValidatorMessages.IdGreaterThanZero, s.GetType().Name, s.Id, nameof(s.Id)))
                .Must((id) =>
                {
                    return admProfiles.Count(e => e.Id == id) <= 1;
                })
                    .WithMessage(s => string.Format(ValidatorMessages.IdDuplicated, s.GetType().Name, s.Id, nameof(s.Id)));


            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage(s => string.Format(ValidatorMessages.FieldRequired, s.GetType().Name, s.Id, nameof(s.Name)))
                .MaximumLength(50)
                    .WithMessage(s => string.Format(ValidatorMessages.ResponsibleNameLength, s.GetType().Name, s.Id, nameof(s.Name), 50));

            RuleFor(x => x.SystemId)
                .Must((Id) =>
                {
                    return admSystems.Any(system => system.Id == Id);
                })
                    .WithMessage(s => string.Format(ValidatorMessages.IdNotFound, s.GetType().Name, s.Id, nameof(s.SystemId)));
        }
    }
}

