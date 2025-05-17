using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Contracts;
using Talabat.DomainLayer.Models;
using Talabat.Persistence.Data.DbContexts;

namespace Talabat.Persistence.Data.Repositories
{
    public class UnitOfWork(StoreDbContext _dbContext) : IUnitOfWork
    {
        private readonly Dictionary<string, object> _repositories = [];
        public IGenericRepository<TEntity, TKey> GenericRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            // Get Type Name 
            var TypeName = typeof(TEntity).Name;
            // Check if the repository already exists
            if (_repositories.ContainsKey(TypeName))
            {
                return (IGenericRepository<TEntity, TKey>)_repositories[TypeName];
            }
            else
            {
                // Create A new Repository 
                var CreateRepository = new GenericRepository<TEntity, TKey>(_dbContext);
                // Store the repository in the dictionary
                _repositories.Add(TypeName, CreateRepository);
                // Return the repository 
                return CreateRepository;
            }
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
