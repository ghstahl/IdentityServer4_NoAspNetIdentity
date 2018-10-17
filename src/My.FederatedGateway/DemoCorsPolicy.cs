using System.Threading.Tasks;
using IdentityServer4.Services;

namespace My.FederatedGateway
{
    public class DemoCorsPolicy : ICorsPolicyService
    {
        public Task<bool> IsOriginAllowedAsync(string origin)
        {
            return Task.FromResult(true);
        }
    }
}