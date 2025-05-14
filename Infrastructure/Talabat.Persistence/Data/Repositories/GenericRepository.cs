using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Contracts;
using Talabat.DomainLayer.Models;
using Talabat.Persistence.Data.DbContexts;
using Talabat.Persistence.Evaluator;

namespace Talabat.Persistence.Data.Repositories
{
    public class GenericRepository<TEnitiy, TKey>(StoreDbContext _dbContext) : IGenericRepository<TEnitiy, TKey> where TEnitiy : BaseEntity<TKey>
    {
        public async Task AddAsync(TEnitiy entity)
        {
            await _dbContext.Set<TEnitiy>().AddAsync(entity);
        }


        public async Task<IEnumerable<TEnitiy>> GetAllAsync()
        {
            return await _dbContext.Set<TEnitiy>().ToListAsync();
        }

        public async Task<TEnitiy?> GetByIdAsync(TKey id)
        {
            return await _dbContext.Set<TEnitiy>().FindAsync(id);
        }

        public void Remove(TEnitiy entity)
        {
            _dbContext.Set<TEnitiy>().Remove(entity);
        }

        public void Update(TEnitiy entity)
        {
            _dbContext.Set<TEnitiy>().Update(entity);
        }
        #region With Specifications
        public async Task<IEnumerable<TEnitiy>> GetAllAsync(ISpecifications<TEnitiy, TKey> specifications)
        {
            // Create Query 
            return await SpecificationsEvaluator.CreateQuery(_dbContext.Set<TEnitiy>(), specifications).ToListAsync();
        }


        public async Task<TEnitiy?> GetByIdAsync(ISpecifications<TEnitiy, TKey> specifications)
        {
            // Create Query 
            return await SpecificationsEvaluator.CreateQuery(_dbContext.Set<TEnitiy>(), specifications).FirstOrDefaultAsync();
        }
        #endregion
    }
}
