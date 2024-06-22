using Microsoft.Extensions.DependencyInjection;
using Movies.Application.MappingProfiles;
using Movies.Application.Services.Core;
using Movies.Application.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application;
public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddServices();

        services.RegisterAutoMapper();

        return services;
    }
    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IMoviesService, MoviesService>();
    }

    private static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IMappingProfilesMarker));
    }
}
