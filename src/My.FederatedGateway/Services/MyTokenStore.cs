using Microsoft.AspNetCore.Http;

namespace My.FederatedGateway.Services
{
    public class MyTokenStore : CookieTokenStore
    {
        public MyTokenStore(IHttpContextAccessor httpContextAccessor, 
            IProtectedCookieStore protectedCookieStore) : base(httpContextAccessor, protectedCookieStore)
        {
        }
        protected override string Scheme => IdentityServer4.IdentityServerConstants.ExternalCookieAuthenticationScheme;
    }
}