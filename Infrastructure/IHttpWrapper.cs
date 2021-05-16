using System.Threading.Tasks;

namespace ParliamentApp.Infrastructure
{
    public interface IHttpWrapper
    {
        Task<TData> GetXMLDataAsync<TData>(string url);
    }
}