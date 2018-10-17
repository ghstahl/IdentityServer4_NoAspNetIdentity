using Microsoft.Extensions.DependencyInjection;
using My.FederatedGateway.Services;

namespace My.FederatedGateway.Extensions
{
    public static class AuthenticatedInformationExtensions
    {
        public static IServiceCollection AddAuthenticatedInformation(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticatedInformation, AuthenticatedInformation>();
            return services;
        }
    }
}