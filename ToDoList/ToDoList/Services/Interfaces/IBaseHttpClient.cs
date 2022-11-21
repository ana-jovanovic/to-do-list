using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ToDoList.Services.Interfaces
{
    public interface IBaseHttpClient
    {
        Task<T> Get<T>(string url, IDictionary<string, string> headers = null, IDictionary<string, string> parameters = null);
        Task<HttpResponseMessage> Post(string url, object data = null, IDictionary<string, string> headers = null);
        Task<T> Post<T>(string url, object data = null, IDictionary<string, string> headers = null);
        Task<HttpResponseMessage> Delete(string url, object data = null, IDictionary<string, string> headers = null);
    }
}
