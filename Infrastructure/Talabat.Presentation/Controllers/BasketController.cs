using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.ServiceAbstraction;
using Talabat.Shared.DataTransferObject.BaskeDTos;

namespace Talabat.Presentation.Controllers
{
    public class BasketController(IServiceManager _serviceManager) : BaseApiController
    {
        // Get Basket 
        [HttpGet]
        public async Task<ActionResult<BasketDTo>> GetBasket(string Id)
        {
            var Basket = await _serviceManager.BasketService.GetBasketAsync(Id);
            return Ok(Basket);
        }
        // Create Or Updated Basket
        [HttpPost]
        public async Task<ActionResult<BasketDTo>> CreateOrUpdatedBasket(BasketDTo basket)
        {
            var Basket = await _serviceManager.BasketService.CreateOrUpdateBasketAsync(basket);
            return Ok(Basket);
        }
        // Delete Basket 
        [HttpDelete("{Id}")]
        public async Task<ActionResult<bool>> DeleteBasket(string Id)
        {
            var Result = await _serviceManager.BasketService.DeleteBasketAsync(Id);
            return Ok(Result);
        }


    }
}
