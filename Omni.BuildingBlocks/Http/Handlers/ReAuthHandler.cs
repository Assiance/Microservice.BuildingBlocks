using Omni.BuildingBlocks.Api.Configuration.HttpClient;
using Omni.BuildingBlocks.Authentication;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Omni.BuildingBlocks.Http.Handlers
{
    public class ReAuthHandler : DelegatingHandler
    {
        private readonly IAccessTokenProvider _accessTokenProvider;
        private readonly ClientConfiguration _client;
        private ILogger<ReAuthHandler> _logger;

        public ReAuthHandler(IAccessTokenProvider accessTokenProvider, ClientConfiguration client, ILoggerFactory loggerFactory)
        {
            _accessTokenProvider = accessTokenProvider;
            _client = client;
            _logger = loggerFactory.CreateLogger<ReAuthHandler>();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var requestUri = request.RequestUri;

                var accessToken = await _accessTokenProvider.RefreshAccessTokenAsync(_client.TokenEndpointUrl,
                    _client.ClientId, _client.ClientSecret);

                if (accessToken != null)
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    response = await base.SendAsync(request, cancellationToken);
                }
            }

            return response;
        }
    }
}