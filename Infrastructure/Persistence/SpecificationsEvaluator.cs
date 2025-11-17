using System.Linq;

namespace Persistence
{
    public static class SpecificationsEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity,Tkey>(IQueryable<TEntity> inputQuery,ISpecifications<TEntity,Tkey> specifications) where TEntity : BaseEntity<Tkey>
        {
            #region Criteria
            var query = inputQuery;
            if (specifications.Criteria is not null)
                query = query.Where(specifications.Criteria);
            #endregion
            #region OrderBy
            if (specifications.OrderBy is not null)
                query = query.OrderBy(specifications.OrderBy);

            if (specifications.OrderByDescending is not null)
                query = query.OrderByDescending(specifications.OrderByDescending);

            #endregion
            #region Include
            if (specifications.IncludeExpressions is not null && specifications.IncludeExpressions.Count > 0)
                    query = specifications.IncludeExpressions.Aggregate(query, (currentquery, expression) => currentquery.Include(expression));
            #endregion
            #region Pagination
            if(specifications.IsPaginated)
            {
                query = query.Skip(specifications.Skip).Take(specifications.Take);
            }

            #endregion

            return query;
        }



    }
}
