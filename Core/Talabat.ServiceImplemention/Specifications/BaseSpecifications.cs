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
        protected BaseSpecifications(Expression<Func<TEnity, bool>>? CriteriaExpression)
        {
            Criteria = CriteriaExpression;
        }
        // Property Signature For Each Dynamic Part int Query
        public Expression<Func<TEnity, bool>>? Criteria { get; private set; }

        public List<Expression<Func<TEnity, object>>> IncludesExpression { get; } = [];

        // Add Include Method 
        public void AddInclude(Expression<Func<TEnity, object>> includeExpression)
        {
            IncludesExpression.Add(includeExpression);
        }
    }
}
