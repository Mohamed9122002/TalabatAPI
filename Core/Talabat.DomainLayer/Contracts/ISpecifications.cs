using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Models;

namespace Talabat.DomainLayer.Contracts
{
    public interface ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        // Property Signature For Each Dynamic Part int Query 
        // Where Clause
        public Expression<Func<TEntity, bool>>? Criteria { get; }
        // Include Clause
        public List<Expression<Func<TEntity, object>>> IncludesExpression { get; }
    }
}
