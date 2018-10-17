using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using My.FederatedGateway.Extensions;

namespace My.FederatedGateway.Services
{
    public abstract class SessionTokenStore : ITokenStore
    {
        private const string SessionKey = "07b4aa2c-9be4-40ec-8b68-232d95b887f2";
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession Session { get; set; }
        public SessionTokenStore(
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            Session = _httpContextAccessor.HttpContext.Session;
        }
        protected abstract string Scheme { get; }

        private async Task<Dictionary<string, string>> HarvestOidcDataAsync()
        {
            var at = await _httpContextAccessor.HttpContext.GetTokenAsync(Scheme, "access_token");
            var idt = await _httpContextAccessor.HttpContext.GetTokenAsync(Scheme, "id_token");
            var rt = await _httpContextAccessor.HttpContext.GetTokenAsync(Scheme, "refresh_token");
            var tt = await _httpContextAccessor.HttpContext.GetTokenAsync(Scheme, "token_type");
            var ea = await _httpContextAccessor.HttpContext.GetTokenAsync(Scheme, "expires_at");

            var oidc = new Dictionary<string, string>
            {
                {"access_token", at},
                {"id_token", idt},
                {"refresh_token", rt},
                {"token_type", tt},
                {"expires_at", ea}
            };
            return oidc;
        }

        public void HarvestAndStore()
        {
            var tokens = HarvestOidcDataAsync().GetAwaiter().GetResult();
            Session.Set(SessionKey, tokens);
        }

        void InternalRead()
        {
            if (_tokens == null)
            {
                _tokens = Session.Get<Dictionary<string, string>>(SessionKey);
            }
        }

        private Dictionary<string, string> _tokens;
        public Dictionary<string, string> Tokens
        {
            get
            {
                InternalRead();
                return _tokens;
            }
        }
    }
}