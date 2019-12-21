using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Omni.BuildingBlocks.Http.Client.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Omni.BuildingBlocks.Http.Client
{
    public abstract class BaseHttpClient : IBaseHttpClient
    {
        private readonly HttpClient _httpClient;
        protected readonly ILogger _logger;
        private const string MediaType = "application/json";

        public BaseHttpClient(HttpClient httpClient, ILogger logger)
        {
            httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue(MediaType));

            _httpClient = httpClient;
            _logger = logger;
        }

        public HttpRequestHeaders DefaultRequestHeaders => _httpClient.DefaultRequestHeaders;

        public Uri BaseAddress => _httpClient.BaseAddress;

        public async Task<T> PutAsync<T>(string url, object item)
        {
            var uri = TryGetUri(url);
            var content = GetStringContent(item);
            var response = await _httpClient.PutAsync(uri, content);

            return TryDeserializeObject<T>(response.Content.ReadAsStringAsync().Result, nameof(this.PutAsync));
        }

        public async Task<T> SendAsync<T>(HttpRequestMessage request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(HttpResponseMessage));
            }

            var response = await _httpClient.SendAsync(request);

            return TryDeserializeObject<T>(response.Content.ReadAsStringAsync().Result, nameof(this.SendAsync));
        }

        public async Task<T> PostAsync<T>(string url, object item)
        {
            var uri = TryGetUri(url);
            var content = GetStringContent(item);
            var response = await _httpClient.PostAsync(uri, content);

            return TryDeserializeObject<T>(response.Content.ReadAsStringAsync().Result, nameof(this.PostAsync));
        }

        public async Task<T> PatchAsync<T>(string url, object item)
        {
            var uri = TryGetUri(url);
            var content = GetStringContent(item);
            var response = await _httpClient.PatchAsync(uri, content);

            return TryDeserializeObject<T>(response.Content.ReadAsStringAsync().Result, nameof(this.PutAsync));
        }

        public async Task<T> DeleteAsync<T>(string url)
        {
            var uri = TryGetUri(url);
            var response = await _httpClient.DeleteAsync(uri);

            return TryDeserializeObject<T>(response.Content.ReadAsStringAsync().Result, nameof(this.DeleteAsync));
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var uri = TryGetUri(url);
            var response = await _httpClient.GetAsync(uri);

            return TryDeserializeObject<T>(response.Content.ReadAsStringAsync().Result, nameof(this.GetAsync));
        }

        private StringContent GetStringContent(object item)
        {
            var json = JsonConvert.SerializeObject(item,
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            var content = new StringContent(json, Encoding.UTF8, MediaType);
            return content;
        }

        private Uri TryGetUri(string url)
        {
            ValidateUrlString(url, UriKind.Relative);
            var uri = new Uri(url, UriKind.Relative);
            return uri;
        }

        private void ValidateUrlString(string url, UriKind uriKind)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));
            if (!Uri.IsWellFormedUriString(url, uriKind))
                throw new ArgumentException("URI is not well formed.", nameof(url));
        }

        private T TryDeserializeObject<T>(string jsonObject, string methodName)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonObject);
            }
            catch (JsonSerializationException e)
            {
                throw new ArgumentException(
                    $"HttpClient {methodName} request response deserialization error {e.Message}");
            }
        }
    }
}