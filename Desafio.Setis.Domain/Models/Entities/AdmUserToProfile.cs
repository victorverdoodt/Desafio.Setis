using Desafio.Setis.Domain.Context;
using Desafio.Setis.Domain.Interfaces;
using Desafio.Setis.Domain.Models.Validators;
using FluentValidation.Results;
using System.Xml.Serialization;

namespace Desafio.Setis.Domain.Models.Entities
{
    [Serializable]
    public class AdmUserToProfile : IEntityValidator
    {
        [XmlElement("USP_USU_Id")]
        public int UserId { get; set; }

        [XmlElement("USP_PER_Id")]
        public int ProfileId { get; set; }

        [XmlIgnore]
        public AdmProfile Profile { get; set; }

        [XmlIgnore]
        public AdmUser User { get; set; }

        public ValidationResult Validate(ValidatorContext context)
        {
            var validator = new AdmUserToProfileValidator(context.AdmUsers, context.AdmProfiles, context.AdmUsersToProfiles);
            var result = validator.Validate(this);
            return result;
        }
    }
}
