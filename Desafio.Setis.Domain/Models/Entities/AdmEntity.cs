using Desafio.Setis.Domain.Context;
using Desafio.Setis.Domain.Interfaces;
using Desafio.Setis.Domain.Models.Validators;
using FluentValidation.Results;
using System.Xml.Serialization;

namespace Desafio.Setis.Domain.Models.Entities
{
    [Serializable]
    public class AdmEntity : IEntityValidator
    {
        [XmlElement("ENT_Id")]
        public int Id { get; set; }

        [XmlElement("ENT_Nome")]
        public string Name { get; set; }

        [XmlElement("ENT_Responsavel")]
        public string Responsible { get; set; }

        [XmlElement("ENT_TerminalPrefixo")]
        public int TerminalPrefix { get; set; }

        [XmlIgnore]
        public List<AdmUser> Users { get; set; } = [];

        public ValidationResult Validate(ValidatorContext context)
        {
            var validator = new AdmEntityValidator(context.AdmEntities);
            var result = validator.Validate(this);
            return result;
        }
    }
}
