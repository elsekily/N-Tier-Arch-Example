using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities;
using Movies.DataAccess.Identity;
using System.Reflection;

namespace Movies.DataAccess.Persistence;

public class MoviesDbContext : IdentityDbContext<User, IdentityRole<int>, int, IdentityUserClaim<int>,
    IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Director> Directors { get; set; }
    public MoviesDbContext(DbContextOptions<MoviesDbContext> options)
            : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

    }
}