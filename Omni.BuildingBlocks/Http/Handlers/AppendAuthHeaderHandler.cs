using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Omni.BuildingBlocks.Http.Handlers
{
    public class AppendAuthHeaderHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<AppendAuthHeaderHandler> _logger;

        public AppendAuthHeaderHandler(ILoggerFactory loggerFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = loggerFactory.CreateLogger<AppendAuthHeaderHandler>();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            await AddAuthorizationRequestHeaderAsync(request);

            var response = await base.SendAsync(request, cancellationToken);

            return response;
        }

        private async Task AddAuthorizationRequestHeaderAsync(HttpRequestMessage request)
        {
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");

            if (string.IsNullOrEmpty(accessToken))
            {
                _logger.LogWarning($"{KnownHttpHeaders.Authorization} header is not set.");
            }
            else
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
        }
    }
}