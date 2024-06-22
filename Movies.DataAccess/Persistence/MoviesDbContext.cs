using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities;
using System.Reflection;

namespace Movies.DataAccess.Persistence;

public class MoviesDbContext : DbContext
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
