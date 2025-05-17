using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Models.BasketModel;

namespace Talabat.DomainLayer.Contracts
{
    public interface IBasketRepository
    {
        // Get Basket 
        Task<CustomerBasket?> GetBasketAync(string basketId);
        // Create Or Update Basket 
        Task<CustomerBasket?> CreateOrUpdateBasketAync(CustomerBasket basket, TimeSpan? TimeToLive = null);
        // Delete Basket 
        Task<bool> DeleteBasketAync(string basketId);

    }
}
