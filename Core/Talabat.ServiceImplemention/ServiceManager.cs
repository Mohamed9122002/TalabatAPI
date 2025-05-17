using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Contracts;
using Talabat.ServiceAbstraction;

namespace Talabat.ServiceImplemention
{
    public class ServiceManager(IUnitOfWork _unitOfWork, IMapper _mapper, IBasketRepository _basketRepository) : IServiceManager
    {
        private readonly Lazy<IProductService> _LazyProductService = new Lazy<IProductService>(() => new ProductService(_unitOfWork, _mapper));
        private readonly Lazy<IBasketService> _LazyBasketService = new Lazy<IBasketService>(() => new BasketService(_basketRepository, _mapper));

        public IProductService ProductService => _LazyProductService.Value;

        public IBasketService BasketService => _LazyBasketService.Value;

    }
}
