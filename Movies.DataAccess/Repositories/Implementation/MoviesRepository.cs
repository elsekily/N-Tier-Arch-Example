using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities;
using Movies.DataAccess.Extensions;
using Movies.DataAccess.Persistence;
using Movies.DataAccess.Repositories.Core;
using Movies.DataAccess.Specification;

namespace Movies.DataAccess.Repositories.Implementation;

public class MoviesRepository : BaseRepository<Movie> , IMoviesRepository
{
    private readonly MoviesDbContext dbContext;

    public MoviesRepository(MoviesDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<QueryResult<Movie>> GetMoviesAsync(int page, int pageSize, ISpecification<Movie> specification) 
    {
        var query = dbContext.Movies.AsQueryable();

        if (specification.Criteria != null)
            query = query.ApplyFilter(specification);

        var count = await query.CountAsync();


        query = query
            .Skip(page * pageSize)
            .Take(pageSize);
        var collection = await query.ToListAsync();

        return new QueryResult<Movie>
        {
            CollectionResult = collection,
            TotalQueryCount = count,
        };
    }

    public async Task<int> GetMoviesCountAsync()
    {
       return await dbContext.Movies.CountAsync();
    }
}
