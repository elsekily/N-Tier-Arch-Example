using Movies.Core.Common;
using Movies.DataAccess.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DataAccess.Extensions;
internal static class SpecificationExtension 
{
    internal static IQueryable<TEntity> ApplyFilter<TEntity>(this IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification) where TEntity : BaseEntity
    {
        return inputQuery.Where(specification.Criteria);
    }
}