using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Omni.BuildingBlocks.Api.Configuration.HttpClient;
using Omni.BuildingBlocks.Authentication;

namespace Omni.BuildingBlocks.Http.Handlers
{
    public static class HandlerExtensions
    {
        public static IHttpClientBuilder AddReAuthHandler(this IHttpClientBuilder builder, ClientConfiguration client)
        {
            return builder.AddHttpMessageHandler(provider =>
            {
                var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
                var accessTokenProvider = provider.GetRequiredService<IAccessTokenProvider>();
                return new ReAuthHandler(accessTokenProvider, client, loggerFactory);
            });
        }
    }
}
