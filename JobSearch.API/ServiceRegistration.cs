using JobSearch.Application;
using JobSearch.Persistence;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace JobSearch.API;

public static class ServiceRegistration
{
    public static void ConfigureApplicationServices(WebApplicationBuilder builder)
    {
        builder.Services.ConfigureApplicationServices();
        builder.Services.ConfigurePersistenceServices(builder.Configuration);
    }

    public static void AddDotNetServices(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers().AddJsonOptions(opt =>
        {
            opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

        builder.Services.AddEndpointsApiExplorer();
    }

    public static void AddSwaggerDoc(IServiceCollection services)
    {
        services.AddSwaggerGen();

        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
            });

            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "JobSearch Api",

            });

        });
    }

    public static void AddCors(WebApplicationBuilder builder)
    {
        builder.Services.AddCors(o =>
        {
            o.AddPolicy("Default", corsPolicyBuilder => corsPolicyBuilder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
        });
    }
}
