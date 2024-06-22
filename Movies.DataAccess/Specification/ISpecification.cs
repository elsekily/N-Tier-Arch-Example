using Movies.Core.Common;
using Movies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DataAccess.Specification;
public interface ISpecification<TEntity> where TEntity : BaseEntity
{
    Expression<Func<TEntity, bool>>? Criteria { get; }
    //List<Expression<Func<TEntity, object>>> Includes { get; }
    //Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy { get; }
    //Func<IQueryable<T>, IOrderedQueryable<T>> OrderByDescending { get; }
}
public class Specification<TEntity> : ISpecification<TEntity> where TEntity : BaseEntity
{
    public Specification(Expression<Func<TEntity, bool>> criteria)
    {
        this.Criteria = criteria;
    }
    public Expression<Func<TEntity, bool>> Criteria { get; }
}
public class MovieSearchSpecification : Specification<Movie>
{
    public MovieSearchSpecification(string query) : base(m=>m.Name.Contains(query))
    {
    }
}