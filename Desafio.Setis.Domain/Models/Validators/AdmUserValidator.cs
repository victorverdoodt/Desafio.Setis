using Desafio.Setis.Domain.Common;
using Desafio.Setis.Domain.Models.Entities;
using FluentValidation;

namespace Desafio.Setis.Domain.Models.Validators
{
    public class AdmUserValidator : AbstractValidator<AdmUser>
    {
        public AdmUserValidator(List<AdmEntity> admEntities, List<AdmUser> admUsers)
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                    .WithMessage(s => string.Format(ValidatorMessages.IdGreaterThanZero, s.GetType().Name, s.Id, nameof(s.Id)))
                .Must((id) =>
                {
                    return admUsers.Count(e => e.Id == id) <= 1;
                })
                    .WithMessage(s => string.Format(ValidatorMessages.IdDuplicated, s.GetType().Name, s.Id, nameof(s.Id)));

            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage(s => string.Format(ValidatorMessages.FieldRequired, s.GetType().Name, s.Id, nameof(s.Name)))
                .MaximumLength(50)
                    .WithMessage(s => string.Format(ValidatorMessages.ResponsibleNameLength, s.GetType().Name, s.Id, nameof(s.Name), 50));

            RuleFor(x => x.Login)
                .NotEmpty()
                    .WithMessage(s => string.Format(ValidatorMessages.FieldRequired, s.GetType().Name, s.Id, nameof(s.Login)))
                .MaximumLength(16)
                    .WithMessage(s => string.Format(ValidatorMessages.ResponsibleNameLength, s.GetType().Name, s.Id, nameof(s.Login), 16));

            RuleFor(x => x.Password)
                .NotEmpty()
                    .WithMessage(s => string.Format(ValidatorMessages.FieldRequired, s.GetType().Name, s.Id, nameof(s.Password)))
                .MaximumLength(100)
                    .WithMessage(s => string.Format(ValidatorMessages.ResponsibleNameLength, s.GetType().Name, s.Id, nameof(s.Login), 100));

            RuleFor(x => x.EntityId)
                .Must((id) =>
                {
                    return admEntities.Any(e => e.Id == id);
                })
                    .WithMessage(s => string.Format(ValidatorMessages.IdNotFound, s.GetType().Name, s.Id, nameof(s.EntityId)));
        }
    }
}
