using Desafio.Setis.Domain.Models.Entities;


namespace Desafio.Setis.Domain.Context
{
    public class ValidatorContext
    {
        public List<AdmUser> AdmUsers { get; set; }

        public List<AdmEntity> AdmEntities { get; set; }

        public List<AdmProfile> AdmProfiles { get; set; }

        public List<AdmUserToProfile> AdmUsersToProfiles { get; set; }

        public List<AdmSystem> AdmSystems { get; set; }

    }
}
