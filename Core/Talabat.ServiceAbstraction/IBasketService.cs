using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Shared.DataTransferObject.BaskeDTos;

namespace Talabat.ServiceAbstraction
{
    public interface IBasketService
    {
        // Get Basket 
        Task<BasketDTo> GetBasketAsync(string basketId);
        // Create Or Update Basket 
        Task<BasketDTo> CreateOrUpdateBasketAsync(BasketDTo basket);
        // Delete Basket 
        Task<bool> DeleteBasketAsync(string basketId);

    }
}
