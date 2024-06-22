using Movies.Core.Common;

namespace Movies.Core.Entities;

public class QueryResult<TEntity> where TEntity : BaseEntity
{
    public List<TEntity> CollectionResult { get; set; }
    public int TotalQueryCount { get; set; }
}