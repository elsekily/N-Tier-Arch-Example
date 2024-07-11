using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities;
using Movies.DataAccess.Identity;
using System.Reflection;
using Movies.Core.Common;
using Movies.Shared.Services.Core;

namespace Movies.DataAccess.Persistence;

public class MoviesDbContext : IdentityDbContext<User, IdentityRole<int>, int, IdentityUserClaim<int>,
    IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    private readonly IClaimService claimService;

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Director> Directors { get; set; }
    public MoviesDbContext(DbContextOptions<MoviesDbContext> options, IClaimService claimService)
            : base(options)
    {
        this.claimService = claimService;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

    }
    public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<IAuditedEntity>())
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy.Id = claimService.GetUserId();
                    entry.Entity.CreatedOn = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedBy.Id = claimService.GetUserId();
                    entry.Entity.UpdatedOn = DateTime.Now;
                    break;
            }

        return await base.SaveChangesAsync(cancellationToken);
    }
}