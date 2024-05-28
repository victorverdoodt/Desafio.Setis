using Desafio.Setis.Domain.Common;

namespace Desafio.Setis.Domain.Interfaces
{
    public interface IXmlContext
    {
        public void RebuildRelationships();
        public ValidatorResult ValidateContext();
    }
}
