using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Models;

namespace Talabat.DomainLayer.Contracts
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity, TKey> GenericRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
        Task<int> SaveChangeAsync(); 

    }
}
