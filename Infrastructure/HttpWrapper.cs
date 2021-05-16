using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParliamentApp.Infrastructure
{
    public class HttpWrapper : IHttpWrapper
    {
        private readonly HttpClient _client;

        public HttpWrapper()
        {
            _client = new HttpClient();
        }

        public async Task<TData> GetXMLDataAsync<TData>(string url)
        {
            var dataStream = await _client.GetStreamAsync(url);
            var serializer = new XmlSerializer(typeof(TData));
            return (TData)serializer.Deserialize(dataStream);
        }
    }
}
