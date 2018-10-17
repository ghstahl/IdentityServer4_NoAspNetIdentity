using Microsoft.Extensions.DependencyInjection;
using My.FederatedGateway.Services;

namespace My.FederatedGateway.Extensions
{
    public static class TokenStoreExtensions
    {
        public static IServiceCollection AddTokenStore(this IServiceCollection services)
        {
            services.AddScoped<ITokenStore, MyTokenStore>();
            return services;
        }
    }
}