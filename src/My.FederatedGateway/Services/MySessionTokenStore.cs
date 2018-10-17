using Microsoft.AspNetCore.Http;

namespace My.FederatedGateway.Services
{
    public class MySessionTokenStore : SessionTokenStore
    {

        protected override string Scheme => IdentityServer4.IdentityServerConstants.ExternalCookieAuthenticationScheme;

        public MySessionTokenStore(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
    }
}