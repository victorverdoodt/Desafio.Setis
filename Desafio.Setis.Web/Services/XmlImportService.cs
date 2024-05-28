using Desafio.Setis.Domain.Common;
using Desafio.Setis.Domain.Models.Aggregator;
using Desafio.Setis.Web.Interfaces;

namespace Desafio.Setis.Web.Services
{
    public class XmlImportService : IXmlImportService
    {
        private readonly XmlDataMapper<AdmDatabase> _xmlDataMapper;
        public XmlImportService(XmlDataMapper<AdmDatabase> xmlDataMapper)
        {
            _xmlDataMapper = xmlDataMapper;
        }

        public async Task<AdmDatabase> ImportXmlAsync(Stream xmlStream)
        {
            AdmDatabase database;
            try
            {
                using (var reader = new StreamReader(xmlStream))
                {
                    database = await _xmlDataMapper.ImportDataAsync(reader);
                }
            }
            catch (Exception)
            {
                throw;
            }
            var validator = database.ValidateContext();
            if (!validator.IsValid)
            {
                throw new InvalidOperationException(validator.Log);
            }
            return database;
        }
    }
}
