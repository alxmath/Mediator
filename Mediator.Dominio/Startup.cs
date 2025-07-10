using Mediator.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Mediator.Dominio;

public static class Startup
{
    public static IServiceCollection AddApplication(this IServiceCollection services) =>
        services.AddMediator(typeof(Startup).Assembly);
}