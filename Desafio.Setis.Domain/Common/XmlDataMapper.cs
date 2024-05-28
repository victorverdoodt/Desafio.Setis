using Desafio.Setis.Domain.Interfaces;
using System.Xml.Serialization;

namespace Desafio.Setis.Domain.Common
{
    public class XmlDataMapper<T> where T : IXmlContext
    {
        public async Task ExportDataAsync(T data, string filePath)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var writer = new StreamWriter(filePath))
            {
                await Task.Run(() => serializer.Serialize(writer, data));
            }
        }

        public async Task<T> ImportDataAsync(string filePath)
        {
            var serializer = new XmlSerializer(typeof(T));
            using var reader = new StreamReader(filePath);
            var data = await Task.Run(() => (T)serializer.Deserialize(reader));
            data.RebuildRelationships();
            return data;
        }

        public async Task<T> ImportDataAsync(StreamReader reader)
        {
            var serializer = new XmlSerializer(typeof(T));

            var xmlString = await reader.ReadToEndAsync();

            using (var stringReader = new StringReader(xmlString))
            {
                var data = (T)serializer.Deserialize(stringReader);
                data.RebuildRelationships();
                return data;
            }
        }

    }
}
