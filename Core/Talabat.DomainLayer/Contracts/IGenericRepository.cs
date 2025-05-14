using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Models;

namespace Talabat.DomainLayer.Contracts
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        // GetAll
        Task<IEnumerable<TEntity>> GetAllAsync();
        // GetById
        Task<TEntity?> GetByIdAsync(TKey id);
        // Add
        Task AddAsync(TEntity entity);
        //Update 
        void Update(TEntity entity);
        // Remove 
        void Remove(TEntity entity);

        #region With Specifications
        // GetAll With Specifications 
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity,TKey> specifications);
        // GetById With Specifications
        Task<TEntity?> GetByIdAsync(ISpecifications<TEntity, TKey> specifications);
        #endregion
    }
}
