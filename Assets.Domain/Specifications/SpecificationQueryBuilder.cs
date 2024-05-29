namespace Assets.Infrastructure.Specifications;

public static class SpecificationQueryBuilder
{

	public static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQuery, Specification<TEntity> specification) where TEntity : class
	{
		var query = inputQuery;

		if (specification != null)
		{
			query = query.Where(specification.Criteria);
		}

		return query;
	}
}
