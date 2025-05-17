using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.DomainLayer.Contracts;
using Talabat.DomainLayer.Models.BasketModel;

namespace Talabat.Persistence.Data.Repositories
{
    public class BasketRepository(IConnectionMultiplexer connectionMultiplexer) : IBasketRepository

    {
        private readonly IDatabase _database = connectionMultiplexer.GetDatabase();


        public async Task<CustomerBasket?> CreateOrUpdateBasketAync(CustomerBasket basket, TimeSpan? TimeToLive = null)
        {
            var JsonBasket = JsonSerializer.Serialize(basket);

            var IsCreateOrUpdate = await _database.StringSetAsync(basket.Id, JsonBasket, TimeToLive ?? TimeSpan.FromDays(30));
            if (IsCreateOrUpdate)
                return await GetBasketAync(basket.Id);
            else
                return null;
        }

        public async Task<CustomerBasket?> GetBasketAync(string basketId)
        {
            var basket = await _database.StringGetAsync(basketId);
            if (basket.IsNullOrEmpty)
                return null;
            else
                return JsonSerializer.Deserialize<CustomerBasket>(basket!);
        }

        public async Task<bool> DeleteBasketAync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

    }
}
