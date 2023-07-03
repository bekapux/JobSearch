using JobSearch.Application.Contracts;
using JobSearch.Persistence.DBConfig;
using JobSearch.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobSearch.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<JobSearchDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"),
                    b => b.MigrationsAssembly(typeof(JobSearchDbContext).Assembly.FullName)).EnableSensitiveDataLogging());

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
