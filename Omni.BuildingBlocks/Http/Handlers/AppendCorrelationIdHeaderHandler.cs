using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace Omni.BuildingBlocks.Http.Handlers
{
    public class AppendCorrelationIdHeaderHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<AppendCorrelationIdHeaderHandler> _logger;

        public AppendCorrelationIdHeaderHandler(ILoggerFactory loggerFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = loggerFactory.CreateLogger<AppendCorrelationIdHeaderHandler>();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            AddCorrelationIdToRequestHeader(request);

            var response = await base.SendAsync(request, cancellationToken);

            return response;
        }

        private void AddCorrelationIdToRequestHeader(HttpRequestMessage request)
        {
            _httpContextAccessor?.HttpContext?.Request?.Headers.TryGetValue(KnownHttpHeaders.CorrelationId,
                out StringValues values);
            var correlationId = values.FirstOrDefault();

            if (string.IsNullOrEmpty(correlationId))
            {
                _logger.LogWarning($"{KnownHttpHeaders.CorrelationId} header is not set.");
            }
            else
            {
                request.Headers.Add(KnownHttpHeaders.CorrelationId, correlationId);
            }
        }
    }
}