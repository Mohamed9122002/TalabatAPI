using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Contracts;
using Talabat.DomainLayer.Models;

namespace Talabat.Persistence.Evaluator
{
    static class SpecificationsEvaluator
    {
        // CreateQuery=> Function Take IQueryable<TEntity> DbSet and ISpecifications<TEntity, TKey> Expressions and return IQueryable<TEntity>
        //_dbcontext.Products.Where(P => P.Id == id).Include(p => p.ProductBrand).Include(p => p.ProductType);
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(IQueryable<TEntity> entities, ISpecifications<TEntity, TKey> specifications) where TEntity : BaseEntity<TKey>
        {
            var Query = entities;
            // Apply Criteria
            if (specifications.Criteria is not null)
            {
                Query = Query.Where(specifications.Criteria);
            }
            // Apply OrderBy
            if (specifications.OrderBy is not null)
            {
                Query = Query.OrderBy(specifications.OrderBy);
            }
            // Apply OrderByDescending
            if (specifications.OrderByDescending is not null)
            {
                Query = Query.OrderByDescending(specifications.OrderByDescending);
            }
            // Apply Include
            if (specifications.IncludesExpression.Count > 0)
            {
                Query = specifications.IncludesExpression.Aggregate(Query, (CurrentQuery, IncludeEx) => CurrentQuery.Include(IncludeEx));
            }
            // Apply Pagination
            if (specifications.IsPagingEnabled)
            {
                Query = Query.Skip(specifications.Skip).Take(specifications.Take);
            }
            return Query;
        }
    }
}
