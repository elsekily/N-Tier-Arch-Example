using Movies.Core.Entities;
using System.Linq.Expressions;

namespace Movies.Application.Specification;

public abstract class BaseSpecification<T> : ISpecification<T>
{
    public BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    public Expression<Func<T, bool>> Criteria { get; }
    public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
    public Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy { get; private set; }
    public Func<IQueryable<T>, IOrderedQueryable<T>> OrderByDescending { get; private set; }

    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    protected void ApplyOrderBy(Func<IQueryable<T>, IOrderedQueryable<T>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    protected void ApplyOrderByDescending(Func<IQueryable<T>, IOrderedQueryable<T>> orderByDescendingExpression)
    {
        OrderByDescending = orderByDescendingExpression;
    }
}
public class MovieOrderSpecification : BaseSpecification<Movie>
{
    public MovieOrderSpecification(string name)
        : base(c => c.Name.Contains(name))
    {
        ApplyOrderBy(c => c.OrderBy(x => x.Name));
    }
}