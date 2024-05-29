using System.Linq.Expressions;

namespace Assets.Infrastructure.Specifications;

public abstract class Specification<TEntity> where TEntity : class
{

    public Specification()
    {

    }

    public Specification(Expression<Func<TEntity, bool>> criteria)
    {
        Criteria = criteria;    

    }
        public Expression<Func<TEntity, bool>>? Criteria { get; }
}


