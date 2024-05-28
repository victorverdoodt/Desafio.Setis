using Desafio.Setis.Domain.Context;
using Desafio.Setis.Domain.Interfaces;
using Desafio.Setis.Domain.Models.Validators;
using FluentValidation.Results;
using System.Xml.Serialization;

namespace Desafio.Setis.Domain.Models.Entities
{
    [Serializable]
    public class AdmUser : IEntityValidator
    {
        [XmlElement("USU_Id")]
        public int Id { get; set; }

        [XmlElement("USU_ENT_Id")]
        public int EntityId { get; set; }

        [XmlElement("USU_Nome")]
        public string Name { get; set; }

        [XmlElement("USU_Login")]
        public string Login { get; set; }

        [XmlElement("USU_Senha")]
        public string Password { get; set; }

        [XmlElement("USU_Bloqueado")]
        public bool IsBlocked { get; set; }

        [XmlElement("USU_DataAcesso")]
        public DateTime LastAccessDate { get; set; }

        [XmlIgnore]
        public AdmEntity Entity { get; set; }

        [XmlIgnore]
        public List<AdmUserToProfile> UserToProfiles { get; set; } = [];


        public ValidationResult Validate(ValidatorContext context)
        {
            var validator = new AdmUserValidator(context.AdmEntities, context.AdmUsers);
            var result = validator.Validate(this);
            return result;
        }
    }
}
