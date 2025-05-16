using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Contracts;
using Talabat.DomainLayer.Models;


namespace Talabat.ServiceImplemention.Specifications
{
    public abstract class BaseSpecifications<TEnity, TKey> : ISpecifications<TEnity, TKey> where TEnity : BaseEntity<TKey>
    {
        // Property Signature For Each Dynamic Part int Query
        protected BaseSpecifications(Expression<Func<TEnity, bool>>? CriteriaExpression)
        {
            Criteria = CriteriaExpression;
        }
        public Expression<Func<TEnity, bool>>? Criteria { get; private set; }
        #region Include

        public List<Expression<Func<TEnity, object>>> IncludesExpression { get; } = [];
        // Add Include Method 
        public void AddInclude(Expression<Func<TEnity, object>> includeExpression)
        {
            IncludesExpression.Add(includeExpression);
        }
        #endregion
        #region Sorting 
        public Expression<Func<TEnity, object>> OrderBy { get; private set; }
        public Expression<Func<TEnity, object>> OrderByDescending { get; private set; }

        protected void AddOrderBy(Expression<Func<TEnity,object>> OrderByExpression)
        {
            OrderBy = OrderByExpression;

        }
        protected void AddOrderByDescending(Expression<Func<TEnity, object>> OrderByDescendingExpression)
        {
            OrderByDescending = OrderByDescendingExpression;
        }
        #endregion
        #region Pagination
        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get;  set; }

        public void ApplyPaging(int PageSize, int PageIndex)
        {
            IsPagingEnabled = true;
            Take = PageSize;
            Skip = PageSize * (PageIndex - 1);
        }
        #endregion
    }
}
