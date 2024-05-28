using Desafio.Setis.Domain.Context;
using Desafio.Setis.Domain.Interfaces;
using Desafio.Setis.Domain.Models.Validators;
using FluentValidation.Results;
using System.Xml.Serialization;

namespace Desafio.Setis.Domain.Models.Entities
{
    [Serializable]
    public class AdmSystem : IEntityValidator
    {
        [XmlElement("SIS_Id")]
        public int Id { get; set; }

        [XmlElement("SIS_Nome")]
        public string Name { get; set; }

        [XmlElement("SIS_Link")]
        public string Link { get; set; }

        [XmlIgnore]
        public List<AdmProfile> Profiles { get; set; } = [];

        public ValidationResult Validate(ValidatorContext context)
        {
            var validator = new AdmSystemValidator(context.AdmSystems);
            var result = validator.Validate(this);
            return result;
        }
    }
}
