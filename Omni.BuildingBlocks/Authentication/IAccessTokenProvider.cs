using System.Threading.Tasks;

namespace Omni.BuildingBlocks.Authentication
{
    public interface IAccessTokenProvider
    {
        Task<string> RefreshAccessTokenAsync(string tokenEndpointUrl, string clientId, string clientSecret);

        Task<string> RefreshAccessTokenAsync(string tokenEndpointUrl, string clientId, string clientSecret,
            string refreshToken);
    }
}