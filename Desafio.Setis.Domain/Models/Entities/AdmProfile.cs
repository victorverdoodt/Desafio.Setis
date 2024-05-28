using Desafio.Setis.Domain.Context;
using Desafio.Setis.Domain.Interfaces;
using Desafio.Setis.Domain.Models.Validators;
using FluentValidation.Results;
using System.Xml.Serialization;

namespace Desafio.Setis.Domain.Models.Entities
{
    [Serializable]
    public class AdmProfile : IEntityValidator
    {
        [XmlElement("PER_Id")]
        public int Id { get; set; }

        [XmlElement("PER_SIS_Id")]
        public int SystemId { get; set; }

        [XmlElement("PER_Nome")]
        public string Name { get; set; }

        [XmlIgnore]
        public AdmSystem System { get; set; }

        [XmlIgnore]
        public List<AdmUserToProfile> UserToProfiles { get; set; } = [];

        public ValidationResult Validate(ValidatorContext context)
        {
            var validator = new AdmProfileValidator(context.AdmSystems, context.AdmProfiles);
            var result = validator.Validate(this);
            return result;
        }
    }
}
