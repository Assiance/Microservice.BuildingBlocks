using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Omni.BuildingBlocks.Http.Client.Interfaces
{
    public interface IBaseHttpClient
    {
        Uri BaseAddress { get; }
        HttpRequestHeaders DefaultRequestHeaders { get; }
        Task<T> PutAsync<T>(string url, object item);
        Task<T> PostAsync<T>(string url, object item);
        Task<T> PatchAsync<T>(string url, object item);
        Task<T> GetAsync<T>(string url);
        Task DeleteAsync(string url);
        Task<T> SendAsync<T>(HttpRequestMessage request);
    }
}