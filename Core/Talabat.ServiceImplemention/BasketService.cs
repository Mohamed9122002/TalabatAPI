using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Contracts;
using Talabat.DomainLayer.Exceptions;
using Talabat.DomainLayer.Models.BasketModel;
using Talabat.ServiceAbstraction;
using Talabat.Shared.DataTransferObject.BaskeDTos;

namespace Talabat.ServiceImplemention
{
    public class BasketService(IBasketRepository _basketRepository, IMapper _mapper) : IBasketService
    {
        public async Task<BasketDTo> CreateOrUpdateBasketAsync(BasketDTo basket)
        {
            var CustomerBasket = _mapper.Map<BasketDTo, CustomerBasket>(basket);
            var IsCreatedOrUpdated = _basketRepository.CreateOrUpdateBasketAync(CustomerBasket);
            if (IsCreatedOrUpdated is not null)
            {
                return await GetBasketAsync(basket.Id);
            }
            else
            {
                throw new Exception("Can't Updated Or Create Basket Now Try Again Later");

            }
        }

        public async Task<BasketDTo> GetBasketAsync(string basketId)
        {
            var Basket = await _basketRepository.GetBasketAync(basketId);
            if (Basket is not null)
                return _mapper.Map<CustomerBasket, BasketDTo>(Basket);
            else
                throw new BasketNotFoundException(basketId);
        }
        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _basketRepository.DeleteBasketAync(basketId);
        }

    }
}
