using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Movies.DataAccess.Persistence;
using Movies.DataAccess.Repositories.Core;
using Movies.DataAccess.Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DataAccess;
public static class DataAccessDependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        
        services.AddRepositories();

        return services;
    }
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IMoviesRepository, MoviesRepository>();
       
    }
    private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MoviesDbContext>(options =>
                            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                                       opt => opt.MigrationsAssembly(typeof(MoviesDbContext).Assembly.FullName)));
    }

}
