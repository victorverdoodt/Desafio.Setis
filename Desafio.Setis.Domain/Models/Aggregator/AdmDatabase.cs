using Desafio.Setis.Domain.Common;
using Desafio.Setis.Domain.Context;
using Desafio.Setis.Domain.Interfaces;
using Desafio.Setis.Domain.Models.Entities;
using System.Text;
using System.Xml.Serialization;


namespace Desafio.Setis.Domain.Models.Aggregator
{
    [Serializable]
    [XmlRoot("ADM_Database")]
    public class AdmDatabase : IXmlContext
    {
        [XmlArray("ADM_Usuarios")]
        [XmlArrayItem("ADM_Usuario")]
        public List<AdmUser> AdmUsers { get; set; } = [];

        [XmlArray("ADM_Entidades")]
        [XmlArrayItem("ADM_Entidade")]
        public List<AdmEntity> AdmEntities { get; set; } = [];

        [XmlArray("ADM_Perfis")]
        [XmlArrayItem("ADM_Perfil")]
        public List<AdmProfile> AdmProfiles { get; set; } = [];

        [XmlArray("ADM_UsuariosXPerfis")]
        [XmlArrayItem("ADM_UsuarioXPerfil")]
        public List<AdmUserToProfile> AdmUsersToProfiles { get; set; } = [];

        [XmlArray("ADM_Sistemas")]
        [XmlArrayItem("ADM_Sistema")]
        public List<AdmSystem> AdmSystems { get; set; } = [];


        public void RebuildRelationships()
        {
            AdmEntitiesRebuildRelationship();
            AdmProfilesRebuildRelationship();
            AdmUsersToProfilesRebuildRelationship();
        }

        public ValidatorResult ValidateContext()
        {
            StringBuilder validationLog = new();

            var context = new ValidatorContext
            {
                AdmEntities = AdmEntities,
                AdmUsers = AdmUsers,
                AdmSystems = AdmSystems,
                AdmProfiles = AdmProfiles,
                AdmUsersToProfiles = AdmUsersToProfiles
            };

            ValidateEntity(AdmEntities, context, ref validationLog);
            ValidateEntity(AdmUsers, context, ref validationLog);
            ValidateEntity(AdmProfiles, context, ref validationLog);
            ValidateEntity(AdmSystems, context, ref validationLog);
            ValidateEntity(AdmUsersToProfiles, context, ref validationLog);

            return validationLog.Length > 0 ?
                ValidatorResult.Fail(validationLog.ToString()) : ValidatorResult.Success;
        }

        #region private_methods
        private void ValidateEntity<T>(IEnumerable<T> items, ValidatorContext context, ref StringBuilder builder) where T : IEntityValidator
        {
            foreach (var item in items)
            {
                var validator = item.Validate(context);
                if (validator.Errors.Any())
                {
                    builder.AppendLine(string.Join("\n", validator.Errors));
                }
            }
        }
        private void AdmEntitiesRebuildRelationship()
        {
            var entitiesById = AdmEntities.ToDictionary(e => e.Id);
            foreach (var user in AdmUsers)
            {
                if (entitiesById.TryGetValue(user.EntityId, out var entity))
                {
                    user.Entity = entity;
                    entity.Users.Add(user);
                }
            }
        }
        private void AdmProfilesRebuildRelationship()
        {
            var systemsById = AdmSystems.ToDictionary(s => s.Id);
            foreach (var profile in AdmProfiles)
            {
                if (systemsById.TryGetValue(profile.SystemId, out var system))
                {
                    profile.System = system;
                    system.Profiles.Add(profile);
                }
            }
        }
        private void AdmUsersToProfilesRebuildRelationship()
        {
            var usersById = AdmUsers.ToDictionary(u => u.Id);

            var profilesById = AdmProfiles.ToDictionary(p => p.Id);

            foreach (var userToProfile in AdmUsersToProfiles)
            {
                if (usersById.TryGetValue(userToProfile.UserId, out var user) &&
                    profilesById.TryGetValue(userToProfile.ProfileId, out var profile))
                {
                    user.UserToProfiles.Add(userToProfile);
                    profile.UserToProfiles.Add(userToProfile);
                    userToProfile.User = user;
                    userToProfile.Profile = profile;
                }
            }
        }

        #endregion
    }
}
