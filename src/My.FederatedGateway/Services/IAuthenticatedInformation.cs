using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace My.FederatedGateway.Services
{
    public interface IAuthenticatedInformation
    {
        Task<AuthenticateResult> GetAuthenticateResultAsync();
    }
}