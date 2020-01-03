using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Omni.BuildingBlocks.Http;

namespace Omni.BuildingBlocks.Shared.UserProvider
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public UserProviderModel GetCurrentUser()
        {
            var request = _httpContextAccessor.HttpContext.Request;

            var authTokenExists = request.Headers.TryGetValue(KnownHttpHeaders.Authorization, out StringValues requestHeaderValue);
            var userProviderModel = new UserProviderModel();

            if (!authTokenExists) return userProviderModel;

            var authToken = requestHeaderValue.FirstOrDefault();

            if (string.IsNullOrEmpty(authToken)) return userProviderModel;

            var profileToken = new JwtSecurityTokenHandler().ReadJwtToken(authToken);
            userProviderModel.Email = profileToken.Claims.FirstOrDefault(c => c.Type == UserTokenProviderClaims.Email)?.Value;

            return userProviderModel;
        }
    }
}
