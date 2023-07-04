global using JobSearch.Application.Contracts;
global using JobSearch.Domain;
global using MediatR;
global using JobSearch.Application.Features.Jobs.Mapper;
global using JobSearch.Application.Features.Jobs.Mapper.Dtos;
global using JobSearch.Application.Exceptions;
global using JobSearch.Application.Features.Utilities;
global using JobSearch.Application.Features.Jobs.Validators;

using Microsoft.Extensions.DependencyInjection;

namespace JobSearch.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(o => o.RegisterServicesFromAssemblies(typeof(BadRequestException).Assembly));
        services.AddScoped<IJobMapper, JobMapper>();
        return services;
    }
}
