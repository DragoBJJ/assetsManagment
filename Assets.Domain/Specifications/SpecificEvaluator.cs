using Assets.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Assets.Domain.Specifications
{
    public static class SpecificEvaluator
    {

        public static IQueryable<TEntity> GetQuery<TEntity>(
            IQueryable<TEntity> inputQueryable,
            Specification<TEntity> specification) where TEntity : class
        {
            IQueryable<TEntity> queryable = inputQueryable;

            if (specification != null)
            {
                queryable = queryable.Where(specification.Criteria);
            }

                specification.IncludeExpressions.Aggregate(queryable,
                (current, includeExpression) => current.Include(includeExpression));
           

            if(specification.OrderByExpression != null)
            {
                 queryable = queryable.OrderBy(specification.OrderByExpression);
            }

            
            if(specification.OrderByDescendingExpression != null)
            {
                queryable = queryable.OrderByDescending(specification.OrderByDescendingExpression); 
            }

            return queryable;   
        }
            
    }
}
