namespace Movies.Application.Resources;

public class QueryResultResource<T> where T : class
{
    public List<T> CollectionResult { get; set; }
    public int Page { get; set; }
    public int TotalPages { get; set; }
}