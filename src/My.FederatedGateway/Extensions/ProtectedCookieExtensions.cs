using Microsoft.Extensions.DependencyInjection;
using My.FederatedGateway.Services;

namespace My.FederatedGateway.Extensions
{
    public static class ProtectedCookieExtensions
    {
        public static IServiceCollection AddProtectedCookie(this IServiceCollection services)
        {
            services.AddScoped<IProtectedCookieStore, ProtectedCookieStore>();
            return services;
        }
    }
}