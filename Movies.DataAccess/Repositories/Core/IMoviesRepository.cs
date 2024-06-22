using Movies.Core.Entities;
using Movies.DataAccess.Specification;

namespace Movies.DataAccess.Repositories.Core;

public interface IMoviesRepository : IBaseRepository<Movie>
{
    Task<QueryResult<Movie>> GetMoviesAsync(int page, int pageSize, ISpecification<Movie> specification);
}
