using Desafio.Setis.Domain.Common;
using Desafio.Setis.Domain.Models.Entities;
using FluentValidation;

namespace Desafio.Setis.Domain.Models.Validators
{
    public class AdmUserToProfileValidator : AbstractValidator<AdmUserToProfile>
    {
        public AdmUserToProfileValidator(List<AdmUser> admUsers, List<AdmProfile> admProfiles, List<AdmUserToProfile> admUserToProfiles)
        {
            RuleFor(x => x.UserId)
               .Must((id) =>
               {
                   return admUsers.Any(e => e.Id == id);
               })
                   .WithMessage(s => string.Format(ValidatorMessages.IdNotFound, s.GetType().Name, s.UserId, nameof(s.UserId)));

            RuleFor(x => x.ProfileId)
                .Must((id) =>
                {
                    return admProfiles.Any(e => e.Id == id);
                })
                    .WithMessage(s => string.Format(ValidatorMessages.IdNotFound, s.GetType().Name, s.UserId, nameof(s.ProfileId)));

            RuleFor(x => x)
                .Must(x => admUserToProfiles.Count(kp => kp.UserId == x.UserId && kp.ProfileId == x.ProfileId) <= 1)
                    .WithMessage(s => string.Format(ValidatorMessages.IdDuplicated, s.GetType().Name, ($"{s.UserId} com {s.ProfileId}"), ($"{nameof(s.UserId)} e {nameof(s.ProfileId)}")));
        }
    }
}
