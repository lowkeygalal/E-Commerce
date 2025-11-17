using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ISpecifications<TEntity,Tkey> where TEntity : BaseEntity<Tkey>
    {
        #region where
        public Expression<Func<TEntity, bool>>? Criteria { get; }

        #endregion
        #region Include
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; }

        #endregion
        #region OrderBy
        public Expression<Func<TEntity, object>> OrderBy { get; }

        #endregion
        #region OrderByDescending
        public Expression<Func<TEntity, object>> OrderByDescending { get; }

        #endregion
        #region Pagination Skip - Take
        public int Skip { get;}
        public int Take { get; }
        public bool IsPaginated { get; }


        #endregion

    }
}
