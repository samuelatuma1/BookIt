using BookIt.Core.Application.Contracts.AuthService;
using BookIt.Core.Infrastructure.AuthService;
using BookIt.Core.Infrastructure.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookIt.Core.Infrastructure;
public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection service, IConfiguration configuration)
    {

        // Dependency Injection
        service.Configure<JwtConfig>(configuration.GetSection(nameof(JwtConfig)));
        service.AddScoped<IJwtService, JwtService>();
        return service;
    }
}

