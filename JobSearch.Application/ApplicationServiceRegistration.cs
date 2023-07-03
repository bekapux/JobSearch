global using JobSearch.Application.Contracts;
global using JobSearch.Domain;
global using MediatR;

using JobSearch.Application.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace JobSearch.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(o => o.RegisterServicesFromAssemblies(typeof(BadRequestException).Assembly));
        return services;
    }
}
