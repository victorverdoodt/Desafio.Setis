using Desafio.Setis.Domain.Models.Aggregator;

namespace Desafio.Setis.Web.Interfaces
{
    public interface IXmlImportService
    {
        Task<AdmDatabase> ImportXmlAsync(Stream xmlStream);
    }
}
