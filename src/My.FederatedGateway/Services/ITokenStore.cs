using System.Collections.Generic;

namespace My.FederatedGateway.Services
{
    public interface ITokenStore
    {
        void HarvestAndStore();
        Dictionary<string, string> Tokens { get; }
    }
}